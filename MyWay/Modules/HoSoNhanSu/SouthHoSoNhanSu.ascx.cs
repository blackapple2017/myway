using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using System.Data;
using DataController;
using Ext.Net;
using ExtMessage;
using System.IO;
using SoftCore;
using SoftCore.Security;

public partial class Modules_HoSoNhanSu_SouthHoSoNhanSu : UserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            hdf_LastUpdatedBy.Text = CurrentUser.ID.ToString();
            TaiNan_dfNgayXayRa.MaxDate = DateTime.Now;
            TaiNan_txtNgayBoiThuong.MaxDate = DateTime.Now;
            SetPermission();
        }
        ucChooseEmployee1.AfterClickAcceptButton += new EventHandler(AfterClickAcceptButton_AfterClickAcceptButton);
    }
    /// <summary>
    /// Phân quyền
    /// </summary>
    private void SetPermission()
    {
        SetVisibleByControlID(CloseTab1, mnuShowHoSoTuyenDung, mnuQuaTrinhDaoTao,
                                  mnuBaoHiem, mnuDaiBieu, mnuDanhGia, mnuDienBienLuong, mnuDeTai, mnuHopDong, mnuKhaNang, mnuKhenThuong,
                                  mnuKyLuat, mnuQuanHeGiaDinh, mnuQuaTrinhCongTac, mnuQuaTrinhDieuChuyen,
                                  mnuTaiSan, MenuItemAttachFile, MenuItemHocTap, MenuItemKNLV, MenuItemBangCapChungChi, MenuItemTNLD,
                                  btnAddRecordInDetailTable, btnDeleteRecord, btnEditRecord);
        if (btnEditRecord.Visible)
        {
            #region Button Sửa
            RowSelectionModelQuaTrinhDaoTao.Listeners.RowSelect.Handler += "#{btnEditRecord}.disable();";
            RowSelectionModelBaoHiem.Listeners.RowSelect.Handler += "#{btnEditRecord}.enable();";
            RowSelectionModelDanhGia.Listeners.RowSelect.Handler += "#{btnEditRecord}.disable();";
            RowSelectionModelDaiBieu.Listeners.RowSelect.Handler += "#{btnEditRecord}.enable();";
            RowSelectionModelDienBienLuong.Listeners.RowSelect.Handler += "#{btnEditRecord}.disable();";
            RowSelectionModelDeTai.Listeners.RowSelect.Handler += "#{btnEditRecord}.enable();";
            RowSelectionModelHopDong.Listeners.RowSelect.Handler += "#{btnEditRecord}.enable();";
            RowSelectionModelKhaNang.Listeners.RowSelect.Handler += "#{btnEditRecord}.enable();";
            RowSelectionModelKhenThuong.Listeners.RowSelect.Handler += "#{btnEditRecord}.enable();";
            RowSelectionModelKyLuat.Listeners.RowSelect.Handler += "#{btnEditRecord}.enable();";
            RowSelectionModelQHGD.Listeners.RowSelect.Handler += "#{btnEditRecord}.enable();";
            RowSelectionModelQuaTrinhCongTac.Listeners.RowSelect.Handler += "#{btnEditRecord}.enable();";
            RowSelectionModelQuaTrinhDieuChuyen.Listeners.RowSelect.Handler += "#{btnEditRecord}.enable();";
            RowSelectionModelTaiSan.Listeners.RowSelect.Handler += "#{btnEditRecord}.enable();";
            RowSelectionModelTepTinDinhKem.Listeners.RowSelect.Handler += "#{btnEditRecord}.enable();";
            RowSelectionModel_BangCap.Listeners.RowSelect.Handler += "#{btnEditRecord}.enable();";
            RowSelectionModelKinhNghiemLamViec.Listeners.RowSelect.Handler += "#{btnEditRecord}.enable();";
            RowSelectionModel_ChungChi.Listeners.RowSelect.Handler += "#{btnEditRecord}.enable();";
            RowSelectionModelTaiNanLaoDong.Listeners.RowSelect.Handler += "#{btnEditRecord}.enable();";
            RowSelectionThuTuc.Listeners.RowSelect.Handler += "#{btnEditRecord}.enable();";
            #endregion
            #region Listener Active
            //panelGeneralInformation.Listeners.Activate.Handler += "#{btnEditRecord}.disable();";
            panelHoSoTuyenDung.Listeners.Activate.Handler += "#{btnEditRecord}.disable();";
            //panelQuaTrinhDaoTao.Listeners.Activate.Handler += "#{btnEditRecord}.disable();";
            //panelBaoHiem.Listeners.Activate.Handler += "#{btnEditRecord}.disable();";
            //panelDaiBieu.Listeners.Activate.Handler += "#{btnEditRecord}.disable();";
            panelDanhGia.Listeners.Activate.Handler += "#{btnEditRecord}.disable();";
            panelDienBienLuong.Listeners.Activate.Handler += "#{btnEditRecord}.disable();";
            //panelDeTai.Listeners.Activate.Handler += "#{btnEditRecord}.disable();";
            //panelHopDong.Listeners.Activate.Handler += "#{btnEditRecord}.disable();";
            //panelKhaNang.Listeners.Activate.Handler += "#{btnEditRecord}.disable();";
            //panelKhenThuong.Listeners.Activate.Handler += "#{btnEditRecord}.disable();";
            //panelKiLuat.Listeners.Activate.Handler += "#{btnEditRecord}.disable();";
            //panelQuanHeGiaDinh.Listeners.Activate.Handler += "#{btnEditRecord}.disable();";
            //panelQuaTrinhCongTac.Listeners.Activate.Handler += "#{btnEditRecord}.disable();";
            //panelQuaTrinhDieuChuyen.Listeners.Activate.Handler += "#{btnEditRecord}.disable();";
            //panelTaiSan.Listeners.Activate.Handler += "#{btnEditRecord}.disable();";
            //panelTepDinhKem.Listeners.Activate.Handler += "#{btnEditRecord}.disable();";
            //panelQuaTrinhHocTap.Listeners.Activate.Handler += "#{btnEditRecord}.disable();";
            //panelKinhNghiemLamViec.Listeners.Activate.Handler += "#{btnEditRecord}.disable();";
            //panelBangCapChungChi.Listeners.Activate.Handler += "#{btnEditRecord}.disable();";
            //panelTaiNanLaoDong.Listeners.Activate.Handler += "#{btnEditRecord}.disable();";
            #endregion
            #region DoubleClick
            GridPanelBaoHiem.Listeners.RowDblClick.Handler += "#{DirectMethods}.GetDataForBaoHiem(); #{btnEditBaoHiem}.show();#{btnUpdateCongViec}.hide();#{btnCNVaDongBaoHiem}.hide();";
            GridPanelDaiBieu.Listeners.RowDblClick.Handler += "#{DirectMethods}.GetDataForDaiBieu();#{btnCapNhatDaiBieu}.hide();#{btnEditDaiBieu}.show();#{Button7}.hide();";
            //GridPanelDanhGia.Listeners.DblClick.Handler += "#{btnUpdateDanhGia}.hide();#{btnEditDanhGia}.show();#{Button14}.hide(); #{DirectMethods}.GetDataForDanhGia();#{wdDanhGia}.show();";
            //GridPanelDienBienLuong.Listeners.DblClick.Handler += "if(#{cbDBL_Ngach}.store.getCount()==0){#{StoreNgach}.reload();};if(#{cbDienBienLuongTenCongViec}.store.getCount()==0){#{StoreCongViec}.reload();};if(#{cbDienBienLuongChucVu}.store.getCount()==0){#{StoreChucVu}.reload();};if(#{cbDienBienLuongLoaiLuong}.store.getCount()==0){#{StoreLoaiLuong}.reload();};#{btnUpdateDienBienLuong}.hide();#{btnEditDienBienLuong}.show();#{Button16}.hide(); #{DirectMethods}.GetDataForDienBienLuong();#{wdDienBienLuong}.show();";
            GridPanelDetai.Listeners.RowDblClick.Handler += "#{DirectMethods}.GetDataForDeTai();#{btnUpdateDeTai}.hide();#{btnEditDeTai}.show();#{Button18}.hide();";
            GridPanelHopDong.Listeners.RowDblClick.Handler += "#{DirectMethods}.GetDataForHopDong();#{hdfButtonClick}.setValue('Edit');#{btnUpdateHopDong}.hide();#{btnEditHopDong}.show();#{Button20}.hide();SouthHoSoNhanSu1_hdfTypeWindow.setValue('HopDong');";
            GridPanelKhaNang.Listeners.RowDblClick.Handler += "#{DirectMethods}.GetDataForKhaNang();#{btnUpdateKhaNang}.hide();#{btnEditKhaNang}.show();#{Button22}.hide();";
            GridPanelKhenThuong.Listeners.RowDblClick.Handler += "#{DirectMethods}.GetDataForKhenThuong();#{hdfButtonClick}.setValue('Edit');#{btnUpdateKhenThuong}.hide();#{btnEditKhenThuong}.show();#{Button24}.hide();SouthHoSoNhanSu1_hdfTypeWindow.setValue('KhenThuong');";
            GridPanelKyLuat.Listeners.RowDblClick.Handler += "#{DirectMethods}.GetDataForKyLuat();#{hdfButtonClick}.setValue('Edit');#{btnCapNhatKyLuat}.hide();  #{Button26}.hide(); #{btnEditKyLuat}.show();SouthHoSoNhanSu1_hdfTypeWindow.setValue('KyLuat');";
            GridPanelQHGD.Listeners.RowDblClick.Handler += "#{DirectMethods}.GetDataForQuanHeGiaDinh();#{btnUpdateQuanHeGiaDinh}.hide();#{btnUpdate}.show();#{Button28}.hide();";
            GridPanelQuaTrinhCTAC.Listeners.RowDblClick.Handler += "#{DirectMethods}.GetDataForQuaTrinhCongTac();#{btnCapNhatQuaTrinhCongTac}.hide();#{btnEditQuaTrinhCongTac}.show();#{Button30}.hide();SouthHoSoNhanSu1_hdfTypeWindow.setValue('QTCT');";
            GridPanelQuaTrinhDieuChuyen.Listeners.RowDblClick.Handler += "#{DirectMethods}.GetDataForQuaTrinhDieuChuyen();#{btnCapNhatQuaTrinhDieuChuyen}.hide();#{btnUpdateQuaTrinhDieuChuyen}.show();#{Button32}.hide();SouthHoSoNhanSu1_hdfTypeWindow.setValue('QTDC');";
            GridPanelTaiSan.Listeners.RowDblClick.Handler += "#{DirectMethods}.GetDataForTaiSan();#{Button2}.hide();#{btnEditTaiSan}.show();#{btnUpdateTaiSan}.hide();";
            grpTepTinDinhKem.Listeners.RowDblClick.Handler += "#{btnEditAttachFile}.show();#{Button10}.hide();#{btnUpdateAtachFile}.hide();#{DirectMethods}.GetDataForTepTin();#{wdAttachFile}.show();";
            GridPanel_BangCap.Listeners.RowDblClick.Handler += "#{DirectMethods}.GetDataForQuaTrinhHocTap();#{btnUpdateBangCap}.hide(); #{btnUpdateandCloseBangCap}.hide();#{btn_EditBangCap}.show();";
            GridPanelKinhNghiemLamViec.Listeners.RowDblClick.Handler += "#{DirectMethods}.GetDataForKinhNghiemLamViec();#{Update}.hide(); #{UpdateandClose}.hide();#{btnEditKinhNghiem}.show();";
            GridPanel_ChungChi.Listeners.RowDblClick.Handler += "#{DirectMethods}.GetDataForChungChi();#{btnUpdateChungChi}.hide();#{btnUpdateandCloseChungChi}.hide();#{btnEditChungChi}.show();";
            GridPanelTaiNanLaoDong.Listeners.RowDblClick.Handler += "#{DirectMethods}.GetDataForTaiNan();#{btnInsertTaiNan}.hide();#{btnUpdateTaiNan}.show();#{btnInsertTaiNanAndClose}.hide();";
            GridThuTucDauVao.Listeners.RowDblClick.Handler += "#{DirectMethods}.GetDataForThuTuc();#{btnUpdateThuTuc}.hide();#{btnUpdateThuTuc1}.show();#{btnUpdateCloseThuTuc}.hide();#{wdThuTucDauVao}.show();";
            #endregion
        }
        if (btnDeleteRecord.Visible)
        {
            #region Button Xóa
            RowSelectionModelHoSoTuyenDung.Listeners.RowSelect.Handler += "#{btnDeleteRecord}.disable();";
            RowSelectionModelQuaTrinhDaoTao.Listeners.RowSelect.Handler += "#{btnDeleteRecord}.enable();";
            RowSelectionModelBaoHiem.Listeners.RowSelect.Handler += "#{btnDeleteRecord}.enable();";
            RowSelectionModelDanhGia.Listeners.RowSelect.Handler += "#{btnDeleteRecord}.disable();";
            RowSelectionModelDaiBieu.Listeners.RowSelect.Handler += "#{btnDeleteRecord}.enable();";
            RowSelectionModelDienBienLuong.Listeners.RowSelect.Handler += "#{btnDeleteRecord}.disable();";
            RowSelectionModelDeTai.Listeners.RowSelect.Handler += "#{btnDeleteRecord}.enable();";
            RowSelectionModelHopDong.Listeners.RowSelect.Handler += "#{btnDeleteRecord}.enable();";
            RowSelectionModelKhaNang.Listeners.RowSelect.Handler += "#{btnDeleteRecord}.enable();";
            RowSelectionModelKhenThuong.Listeners.RowSelect.Handler += "#{btnDeleteRecord}.enable();";
            RowSelectionModelKyLuat.Listeners.RowSelect.Handler += "#{btnDeleteRecord}.enable();";
            RowSelectionModelQHGD.Listeners.RowSelect.Handler += "#{btnDeleteRecord}.enable();";
            RowSelectionModelQuaTrinhCongTac.Listeners.RowSelect.Handler += "#{btnDeleteRecord}.enable();";
            RowSelectionModelQuaTrinhDieuChuyen.Listeners.RowSelect.Handler += "#{btnDeleteRecord}.enable();";
            RowSelectionModelTaiSan.Listeners.RowSelect.Handler += "#{btnDeleteRecord}.enable();";
            RowSelectionModelTepTinDinhKem.Listeners.RowSelect.Handler += "#{btnDeleteRecord}.enable();";
            RowSelectionModel_BangCap.Listeners.RowSelect.Handler += "#{btnDeleteRecord}.enable();";
            RowSelectionModelKinhNghiemLamViec.Listeners.RowSelect.Handler += "#{btnDeleteRecord}.enable();";
            RowSelectionModel_ChungChi.Listeners.RowSelect.Handler += "#{btnDeleteRecord}.enable();";
            RowSelectionModelTaiNanLaoDong.Listeners.RowSelect.Handler += "#{btnDeleteRecord}.enable();";
            RowSelectionThuTuc.Listeners.RowSelect.Handler += "#{btnDeleteRecord}.enable();";
            #endregion
            #region Listener Active
            //panelGeneralInformation.Listeners.Activate.Handler += "#{btnDeleteRecord}.disable();";
            panelHoSoTuyenDung.Listeners.Activate.Handler += "#{btnDeleteRecord}.disable();";
            //panelQuaTrinhDaoTao.Listeners.Activate.Handler += "#{btnDeleteRecord}.disable();";
            //panelBaoHiem.Listeners.Activate.Handler += "#{btnDeleteRecord}.disable();";
            //panelDaiBieu.Listeners.Activate.Handler += "#{btnDeleteRecord}.disable();";
            panelDanhGia.Listeners.Activate.Handler += "#{btnDeleteRecord}.disable();";
            panelDienBienLuong.Listeners.Activate.Handler += "#{btnDeleteRecord}.disable();";
            //panelDeTai.Listeners.Activate.Handler += "#{btnDeleteRecord}.disable();";
            //panelHopDong.Listeners.Activate.Handler += "#{btnDeleteRecord}.disable();";
            //panelKhaNang.Listeners.Activate.Handler += "#{btnDeleteRecord}.disable();";
            //panelKhenThuong.Listeners.Activate.Handler += "#{btnDeleteRecord}.disable();";
            //panelKiLuat.Listeners.Activate.Handler += "#{btnDeleteRecord}.disable();";
            //panelQuanHeGiaDinh.Listeners.Activate.Handler += "#{btnDeleteRecord}.disable();";
            //panelQuaTrinhCongTac.Listeners.Activate.Handler += "#{btnDeleteRecord}.disable();";
            //panelQuaTrinhDieuChuyen.Listeners.Activate.Handler += "#{btnDeleteRecord}.disable();";
            //panelTaiSan.Listeners.Activate.Handler += "#{btnDeleteRecord}.disable();";
            //panelTepDinhKem.Listeners.Activate.Handler += "#{btnDeleteRecord}.disable();";
            //panelQuaTrinhHocTap.Listeners.Activate.Handler += "#{btnDeleteRecord}.disable();";
            //panelKinhNghiemLamViec.Listeners.Activate.Handler += "#{btnDeleteRecord}.disable();";
            //panelBangCapChungChi.Listeners.Activate.Handler += "#{btnDeleteRecord}.disable();";
            //panelTaiNanLaoDong.Listeners.Activate.Handler += "#{btnDeleteRecord}.disable();";
            #endregion
        }
        if (btnAddRecordInDetailTable.Visible)
        {
            #region Button Thêm mới
            panelHoSoTuyenDung.Listeners.Activate.Handler += "#{btnAddRecordInDetailTable}.disable();";
            panelQuaTrinhDaoTao.Listeners.Activate.Handler += "#{btnAddRecordInDetailTable}.enable();";
            panelBaoHiem.Listeners.Activate.Handler += "#{btnAddRecordInDetailTable}.enable();";
            panelDaiBieu.Listeners.Activate.Handler += "#{btnAddRecordInDetailTable}.enable();";
            panelDanhGia.Listeners.Activate.Handler += "#{btnAddRecordInDetailTable}.disable();";
            panelDeTai.Listeners.Activate.Handler += "#{btnAddRecordInDetailTable}.enable();";
            panelHopDong.Listeners.Activate.Handler += "#{btnAddRecordInDetailTable}.enable();";
            panelKhaNang.Listeners.Activate.Handler += "#{btnAddRecordInDetailTable}.enable();";
            panelKhenThuong.Listeners.Activate.Handler += "#{btnAddRecordInDetailTable}.enable();";
            panelKiLuat.Listeners.Activate.Handler += "#{btnAddRecordInDetailTable}.enable();";
            panelQuanHeGiaDinh.Listeners.Activate.Handler += "#{btnAddRecordInDetailTable}.enable();";
            panelQuaTrinhCongTac.Listeners.Activate.Handler += "#{btnAddRecordInDetailTable}.enable();";
            panelTaiSan.Listeners.Activate.Handler += "#{btnAddRecordInDetailTable}.enable();";
            panelTepDinhKem.Listeners.Activate.Handler += "#{btnAddRecordInDetailTable}.enable();";
            panelQuaTrinhHocTap.Listeners.Activate.Handler += "#{btnAddRecordInDetailTable}.enable();";
            panelKinhNghiemLamViec.Listeners.Activate.Handler += "#{btnAddRecordInDetailTable}.enable();";
            panelBangCapChungChi.Listeners.Activate.Handler += "#{btnAddRecordInDetailTable}.enable();";
            panelTaiNanLaoDong.Listeners.Activate.Handler += "#{btnAddRecordInDetailTable}.enable();";
            panelDienBienLuong.Listeners.Activate.Handler += "#{btnAddRecordInDetailTable}.enable();";
            panelThuTucDauVao.Listeners.Activate.Handler += "#{btnAddRecordInDetailTable}.enable();";
            #endregion
            #region Listener Active
            panelGeneralInformation.Listeners.Activate.Handler += "#{btnAddRecordInDetailTable}.disable();";
            panelHoSoTuyenDung.Listeners.Activate.Handler += "#{btnAddRecordInDetailTable}.disable();";
            panelDanhGia.Listeners.Activate.Handler += "#{btnAddRecordInDetailTable}.disable();";
            panelQuaTrinhDaoTao.Listeners.Activate.Handler += "#{btnAddRecordInDetailTable}.disable();";
            #endregion
        }
        if (btnViewPhuCap.Visible)
        {
            #region rowselection
            RowSelectionModelQuaTrinhDaoTao.Listeners.RowSelect.Handler += "#{btnViewPhuCap}.hide();";
            RowSelectionModelBaoHiem.Listeners.RowSelect.Handler += "#{btnViewPhuCap}.hide();";
            RowSelectionModelDanhGia.Listeners.RowSelect.Handler += "#{btnViewPhuCap}.hide();";
            RowSelectionModelDaiBieu.Listeners.RowSelect.Handler += "#{btnViewPhuCap}.hide();";
            RowSelectionModelDienBienLuong.Listeners.RowSelect.Handler += "#{btnViewPhuCap}.show();#{btnViewPhuCap}.enable();";
            RowSelectionModelDeTai.Listeners.RowSelect.Handler += "#{btnViewPhuCap}.hide();";
            RowSelectionModelHopDong.Listeners.RowSelect.Handler += "#{btnViewPhuCap}.hide();";
            RowSelectionModelKhaNang.Listeners.RowSelect.Handler += "#{btnViewPhuCap}.hide();";
            RowSelectionModelKhenThuong.Listeners.RowSelect.Handler += "#{btnViewPhuCap}.hide();";
            RowSelectionModelKyLuat.Listeners.RowSelect.Handler += "#{btnViewPhuCap}.hide();";
            RowSelectionModelQHGD.Listeners.RowSelect.Handler += "#{btnViewPhuCap}.hide();";
            RowSelectionModelQuaTrinhCongTac.Listeners.RowSelect.Handler += "#{btnViewPhuCap}.hide();";
            RowSelectionModelQuaTrinhDieuChuyen.Listeners.RowSelect.Handler += "#{btnViewPhuCap}.hide();";
            RowSelectionModelTaiSan.Listeners.RowSelect.Handler += "#{btnViewPhuCap}.hide();";
            RowSelectionModelTepTinDinhKem.Listeners.RowSelect.Handler += "#{btnViewPhuCap}.hide();";
            RowSelectionModel_BangCap.Listeners.RowSelect.Handler += "#{btnViewPhuCap}.hide();";
            RowSelectionModelKinhNghiemLamViec.Listeners.RowSelect.Handler += "#{btnViewPhuCap}.hide();";
            RowSelectionModel_ChungChi.Listeners.RowSelect.Handler += "#{btnViewPhuCap}.hide();";
            RowSelectionModelTaiNanLaoDong.Listeners.RowSelect.Handler += "#{btnViewPhuCap}.hide();";
            #endregion
            #region active panel
            panelGeneralInformation.Listeners.Activate.Handler += "#{btnViewPhuCap}.hide();";
            panelHoSoTuyenDung.Listeners.Activate.Handler += "#{btnViewPhuCap}.hide();";
            panelQuaTrinhDaoTao.Listeners.Activate.Handler += "#{btnViewPhuCap}.hide();";
            panelBaoHiem.Listeners.Activate.Handler += "#{btnViewPhuCap}.hide();";
            panelDaiBieu.Listeners.Activate.Handler += "#{btnViewPhuCap}.hide();";
            panelDanhGia.Listeners.Activate.Handler += "#{btnViewPhuCap}.hide();";
            panelDienBienLuong.Listeners.Activate.Handler += "#{btnViewPhuCap}.show();";
            panelDeTai.Listeners.Activate.Handler += "#{btnViewPhuCap}.hide();";
            panelHopDong.Listeners.Activate.Handler += "#{btnViewPhuCap}.hide();";
            panelKhaNang.Listeners.Activate.Handler += "#{btnViewPhuCap}.hide();";
            panelKhenThuong.Listeners.Activate.Handler += "#{btnViewPhuCap}.hide();";
            panelKiLuat.Listeners.Activate.Handler += "#{btnViewPhuCap}.hide();";
            panelQuanHeGiaDinh.Listeners.Activate.Handler += "#{btnViewPhuCap}.hide();";
            panelQuaTrinhCongTac.Listeners.Activate.Handler += "#{btnViewPhuCap}.hide();";
            panelQuaTrinhDieuChuyen.Listeners.Activate.Handler += "#{btnViewPhuCap}.hide();";
            panelTaiSan.Listeners.Activate.Handler += "#{btnViewPhuCap}.hide();";
            panelTepDinhKem.Listeners.Activate.Handler += "#{btnViewPhuCap}.hide();";
            panelQuaTrinhHocTap.Listeners.Activate.Handler += "#{btnViewPhuCap}.hide();";
            panelKinhNghiemLamViec.Listeners.Activate.Handler += "#{btnViewPhuCap}.hide();";
            panelBangCapChungChi.Listeners.Activate.Handler += "#{btnViewPhuCap}.hide();";
            panelTaiNanLaoDong.Listeners.Activate.Handler += "#{btnViewPhuCap}.hide();";
            #endregion
        }

        ucChooseEmployee1.AfterClickAcceptButton += new EventHandler(AfterClickAcceptButton_AfterClickAcceptButton);
    }

    void AfterClickAcceptButton_AfterClickAcceptButton(object sender, EventArgs e)
    {
        SelectedRowCollection SelectedRow = ucChooseEmployee1.SelectedRow;
        foreach (var item in SelectedRow)
        {
            DAL.HOSO hs = new HoSoController().GetByMaCB(item.RecordID);
            switch (hdfTypeWindow.Text)
            {
                case "HopDong":
                    tgf_NguoiKyHD.Text = hs.HO_TEN;
                    hdfPrkeyNguoiKyHD.Text = hs.PR_KEY.ToString();
                    break;
                case "KhenThuong":
                    tgf_KhenThuong_NguoiRaQD.Text = hs.HO_TEN;
                    hdfKhenThuongNguoiQD.Text = hs.PR_KEY.ToString();
                    break;
                case "KyLuat":
                    tgfKyLuatNguoiQD.Text = hs.HO_TEN;
                    hdfKyLuatNguoiQD.Text = hs.PR_KEY.ToString();
                    break;
                case "QTCT":
                    tgf_QTCTNguoiQuyetDinh.Text = hs.HO_TEN;
                    hdfQTCTNguoiQuyetDinh.Text = hs.PR_KEY.ToString();
                    break;
                case "QTDC":
                    tgfQTDCNguoiQuyetDinh.Text = hs.HO_TEN;
                    hdfQTDCNguoiQuyetDinh.Text = hs.PR_KEY.ToString();
                    break;
            }
        }
    }

    public void SetProfileImage(string url)
    {
        hsImage.ImageUrl = url;
    }

    #region Các hàm liên quan đến Store

    //protected void StoregrpATM_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    //{
    //    StoregrpATM.DataSource = DataHandler.GetInstance().ExecuteDataTable("HOSO_GetATM", "@prkeyHoso", hdfRecordID.Text);
    //    StoregrpATM.DataBind();
    //}

    protected void StoreDienBienLuong_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        StoreDienBienLuong.DataSource = new HoSoLuongController().GetByPrkeyHoSo(decimal.Parse(hdfRecordID.Text));
        StoreDienBienLuong.DataBind();
    }

    //protected void cbx_HopDongChucVu_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    //{
    //    cbx_HopDongChucVu_Store.DataSource = new DanhMucChucVuController().GetAll();
    //    cbx_HopDongChucVu_Store.DataBind();
    //}

    protected void StoreHoSoTuyenDung_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        DataTable table = DataHandler.GetInstance().ExecuteDataTable("HOSO_LayThongTinTuyenDung", "@PrKeyHOSO", int.Parse("0" + hdfRecordID.Text));
        StoreHoSoTuyenDung.DataSource = table;
        StoreHoSoTuyenDung.DataBind();
    }

    protected void StoreQuaTrinhDaoTao_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            StoreQuaTrinhDaoTao.DataSource = new DaoTaoController().GetThongTinDaoTaoCuaNhanVien(txtMaCB.Text);
            StoreQuaTrinhDaoTao.DataBind();
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }

    protected void StoreBaoHiems_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        DataTable table = DataHandler.GetInstance().ExecuteDataTable("HOSO_GetBaoHiem", "@PrKeyHoso", hdfRecordID.Text);
        StoreBaoHiem.DataSource = table;
        StoreBaoHiem.DataBind();
    }

    protected void StoreDaiBieu_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        DataTable table = DataHandler.GetInstance().ExecuteDataTable("select * from HOSO_DAIBIEU where FR_KEY = " + hdfRecordID.Text);
        StoreDaiBieu.DataSource = table;
        StoreDaiBieu.DataBind();
    }

    protected void StoreDetai_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        DataTable table = DataHandler.GetInstance().ExecuteDataTable("select * from HOSO_DETAI where FR_KEY = " + hdfRecordID.Text);
        StoreDetai.DataSource = table;
        StoreDetai.DataBind();
    }

    protected void StoreHopDong_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        DataTable table = DataHandler.GetInstance().ExecuteDataTable("Hoso_GetHopDong", "@PrKeyHoso", hdfRecordID.Text);
        StoreHopDong.DataSource = table;
        StoreHopDong.DataBind();
    }

    protected void StoreKhaNang_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        DataTable table = DataHandler.GetInstance().ExecuteDataTable("HOSO_GetHoSoKhaNang", "@PrKeyHoso", hdfRecordID.Text);
        StoreKhaNang.DataSource = table;
        StoreKhaNang.DataBind();
    }

    protected void StoreKhenThuong_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        DataTable table = DataHandler.GetInstance().ExecuteDataTable("HOSO_GetKhenThuong", "@PrKeyHoSo", hdfRecordID.Text);
        StoreKhenThuong.DataSource = table;
        StoreKhenThuong.DataBind();
    }

    protected void StoreKyLuat_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        DataTable table = DataHandler.GetInstance().ExecuteDataTable("HOSO_GetKyLuat", "@prKeyHoSo", hdfRecordID.Text);
        StoreKyLuat.DataSource = table;
        StoreKyLuat.DataBind();
    }

    protected void StoreQHGD_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        DataTable table = DataHandler.GetInstance().ExecuteDataTable("HOSO_GetQuanHeGiaDinh", "@PrKeyHoSo", hdfRecordID.Text);
        StoreQHGD.DataSource = table;
        StoreQHGD.DataBind();
    }

    protected void StoreQuaTrinhCongTac_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        StoreQuaTrinhCongTac.DataSource = new HOSO_QT_CTACController().GetByFrkey(decimal.Parse(hdfRecordID.Text));
        StoreQuaTrinhCongTac.DataBind();
    }

    protected void StoreQuaTrinhDieuChuyen_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        StoreQuaTrinhDieuChuyen.DataSource = new HOSO_QT_DIEUCHUYENController().GetByFr_Key(decimal.Parse(hdfRecordID.Text));
        StoreQuaTrinhDieuChuyen.DataBind();
    }

    protected void StoreTaiSan_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        DataTable table = DataHandler.GetInstance().ExecuteDataTable("HOSO_GetTaiSan", "@PrKeyHoso", hdfRecordID.Text);
        StoreTaiSan.DataSource = table;
        StoreTaiSan.DataBind();
    }

    protected void grpTepTinDinhKemStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            grpTepTinDinhKemStore.DataSource = DataHandler.GetInstance().ExecuteDataTable("Attach_GetFileListOfHoSo", "@FR_KEY", decimal.Parse(hdfRecordID.Text));
            grpTepTinDinhKemStore.DataBind();
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }
    protected void grpThuTucDauVaoStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            StoreThuTucDauVao.DataSource = DataHandler.GetInstance().ExecuteDataTable("GetListThuTucDauVao", "@FR_KEY", decimal.Parse(hdfRecordID.Text));
            StoreThuTucDauVao.DataBind();
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }

    protected void Store_BangCap_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        List<HOSO_BANGCAP_UNGVIENInfo1> bangcap = new HOSO_BANGCAP_UNGVIENController().GetByFr_Key(decimal.Parse(hdfRecordID.Text));
        Store_BangCap.DataSource = bangcap;
        Store_BangCap.DataBind();
    }

    protected void StoreKinhNghiemLamViec_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            StoreKinhNghiemLamViec.DataSource = DataHandler.GetInstance().ExecuteDataTable("HOSO_GetKinhNghiemLamViec", "@prkeyHoSo", hdfRecordID.Text);
            StoreKinhNghiemLamViec.DataBind();
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }

    protected void Store_BangCapChungChi_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            List<HOSO_UNGVIEN_CHUNGCHIInfo1> cc = new HOSO_UNGVIEN_CHUNGCHIController().GetByFr_keyHOSO(decimal.Parse(hdfRecordID.Text));
            Store_BangCapChungChi.DataSource = cc;
            Store_BangCapChungChi.DataBind();
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }

    protected void StoreTaiNanLaoDong_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            StoreTaiNanLaoDong.DataSource = new HoSoController().GetTaiNanList(decimal.Parse(hdfRecordID.Text));
            StoreTaiNanLaoDong.DataBind();
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }

    protected void StorePhuCap_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            if (hdfIDHoSoLuong.Text == "")
                return;
            StorePhuCap.DataSource = new HoSoPhuCapPhucLoiController().GetListPhuCap(decimal.Parse("0" + hdfIDHoSoLuong.Text));
            StorePhuCap.DataBind();
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }

    protected void HandleChangesStoreQuaTrinhDaoTao(object sender, BeforeStoreChangedEventArgs e)
    {
        try
        {
            ChangeRecords<NhanVienThamGiaDaoTaoInfo> persons = e.DataHandler.ObjectData<NhanVienThamGiaDaoTaoInfo>();
            DaoTaoController dtController = new DaoTaoController();
            foreach (var item in persons.Updated)
            {
                dtController.UpdateNhanVien(item);
            }
            string notification = string.Empty;
            foreach (var item in persons.Deleted)
            {
                // nếu chưa tồn tại kết quả khóa học thì cho phép xóa
                if (new DaoTaoController().CheckExistResult(item.ID))
                    dtController.DeleteNhanVien(item.ID);
                else
                {
                    notification += item.TenKhoaDaoTao + ", ";
                }
            }
            if (!string.IsNullOrEmpty(notification))
            {
                int pos = notification.LastIndexOf(',');
                if (pos != -1)
                {
                    notification = notification.Remove(pos);
                    X.Msg.Alert("Thông báo", "Các khóa đào tạo: " + notification + " đã có kết quả đánh giá. Bạn không được phép xóa các khóa này.").Show();
                    GridPanelQTDT.Reload();
                }
            }
        }
        catch (Exception ex)
        {
           ExtMessage.Dialog.ShowNotification(ex.Message);
        }
    }

    protected void grp_DanhSachKhoaHocStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            DaoTaoController dtController = new DaoTaoController();
            //string mdv = new UserController().GetDonViByUserID(CurrentUser.ID).FirstOrDefault().MA_DONVI;
            string mdv = Session["MaDonVi"].ToString();
            int c = 0;
            grp_DanhSachKhoaHocStore.DataSource = dtController.GetKeHoachDaoTao(mdv, 0, 100, out c, "", "Đang triển khai");
            grp_DanhSachKhoaHoc.DataBind();
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }

    //protected void StoreCongViec_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    //{
    //    StoreCongViec.DataSource = DataHandler.GetInstance().ExecuteDataTable("select MA_CONGVIEC, TEN_CONGVIEC from DM_CONGVIEC");
    //    StoreCongViec.DataBind();
    //}
    #endregion

    #region Refresh ComboBox
    //protected void cbxDonViTinh_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    //{
    //    cbxDonViTinh_Store.DataSource = new DanhMucDonViTinhController().GetByAll();
    //    cbxDonViTinh_Store.DataBind();
    //}

    //protected void cbHopDongLoaiHopDongStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    //{
    //    try
    //    {
    //        cbHopDongLoaiHopDongStore.DataSource = DataHandler.GetInstance().ExecuteDataTable("select MA_LOAI_HDONG,TEN_LOAI_HDONG from DM_LOAI_HDONG");
    //        cbHopDongLoaiHopDongStore.DataBind();
    //    }
    //    catch (Exception ex)
    //    {
    //        X.Msg.Alert("Thông báo từ hệ thống", "Có lỗi xảy ra: " + ex.Message).Show();
    //    }
    //}

    //protected void cbKhaNangStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    //{
    //    cbKhaNangStore.DataSource = DataHandler.GetInstance().ExecuteDataTable(" select MA_KHANANG,TEN_KHANANG from DM_KHANANG");
    //    cbKhaNangStore.DataBind();
    //}

    //protected void cbKhaNangXepLoaiStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    //{
    //    cbKhaNangXepLoaiStore.DataSource = DataHandler.GetInstance().ExecuteDataTable("select MA_XEPLOAI,TEN_XEPLOAI from DM_XEPLOAI");
    //    cbKhaNangXepLoaiStore.DataBind();
    //}

    //protected void cbLyDoKhenThuongStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    //{
    //    cbLyDoKhenThuongStore.DataSource = DataHandler.GetInstance().ExecuteDataTable("select MA_LYDO_KTHUONG,TEN_LYDO_KTHUONG from DM_LYDO_KTHUONG");
    //    cbLyDoKhenThuongStore.DataBind();
    //}

    //protected void cbHinhThucKhenThuongStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    //{
    //    try
    //    {
    //        cbHinhThucKhenThuongStore.DataSource = DataHandler.GetInstance().ExecuteDataTable("select MA_HT_KTHUONG,TEN_HT_KTHUONG from DM_HT_KTHUONG");
    //        cbHinhThucKhenThuongStore.DataBind();
    //    }
    //    catch (Exception ex)
    //    {
    //        X.Msg.Alert("Thông báo từ hệ thống", "Có lỗi xảy ra: " + ex.Message).Show();
    //    }
    //}

    //protected void cbLyDoKyLuatStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    //{
    //    cbLyDoKyLuatStore.DataSource = DataHandler.GetInstance().ExecuteDataTable("select MA_LYDO_KYLUAT,TEN_LYDO_KYLUAT from DM_LYDO_KYLUAT");
    //    cbLyDoKyLuatStore.DataBind();
    //}

    //protected void cbHinhThucKyLuatStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    //{
    //    cbHinhThucKyLuatStore.DataSource = DataHandler.GetInstance().ExecuteDataTable("select MA_HT_KYLUAT,TEN_HT_KYLUAT from DM_HT_KYLUAT");
    //    cbHinhThucKyLuatStore.DataBind();
    //}

    //protected void cbQuanHeGiaDinhStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    //{
    //    cbQuanHeGiaDinhStore.DataSource = DataHandler.GetInstance().ExecuteDataTable("select MA_QUANHE,TEN_QUANHE from DM_QUANHE");
    //    cbQuanHeGiaDinhStore.DataBind();
    //}

    //protected void cbCongTacQuocGiaStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    //{
    //    cbCongTacQuocGiaStore.DataSource = new DM_NUOCController().GetAll();
    //    cbCongTacQuocGiaStore.DataBind();
    //}

    protected void cbxQTDCBoPhanCu_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        List<StoreComboObject> lists = new DM_DONVIController().GetStoreByParentID("0");
        List<object> obj = new List<object>();
        foreach (var item in lists)
        {
            obj.Add(new { MA = item.MA, TEN = item.TEN });
            LoadMenuCon(obj, item.MA, 1);
        }
        cbxQTDCBoPhanCu_Store.DataSource = obj;
        cbxQTDCBoPhanCu_Store.DataBind();
    }

    private List<object> LoadMenuCon(List<object> obj, string parentID, int k)
    {
        List<StoreComboObject> lists = new DM_DONVIController().GetStoreByParentID(parentID);
        foreach (var item in lists)
        {
            string tmp = "";
            for (int i = 0; i < k; i++)
                tmp += "- ";
            obj.Add(new { MA = item.MA, TEN = tmp + item.TEN });
            obj = LoadMenuCon(obj, item.MA, k + 1);
        }
        return obj;
    }

    //protected void cbxQTDCChucVuCu_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    //{
    //    try
    //    {
    //        cbxQTDCChucVuCu_Store.DataSource = new DanhMucChucVuController().GetAll();
    //        cbxQTDCChucVuCu_Store.DataBind();
    //    }
    //    catch (Exception ex)
    //    {
    //        X.Msg.Alert("Thông báo", ex.Message.ToString()).Show();
    //    }
    //}

    //protected void cbTaiSanStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    //{
    //    List<DM_VTHHInfo> vthh = new DM_VTHHController().GetAll();
    //    cbTaiSanStore.DataSource = vthh;
    //    cbTaiSanStore.DataBind();
    //}

    //protected void cbxCongViecMoi_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    //{
    //    try
    //    {
    //        cbxCongViecMoi_Store.DataSource = new DM_CONGVIECController().GetAll();
    //        cbxCongViecMoi_Store.DataBind();
    //    }
    //    catch (Exception ex)
    //    {
    //        X.Msg.Alert("Thông báo", "Có lỗi xảy ra: " + ex.Message).Show();
    //    }
    //}

    //protected void cbx_NoiDaoTaoBangCapStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    //{
    //    try
    //    {
    //        cbx_NoiDaoTaoBangCapStore.DataSource = new DM_TRUONG_DAOTAOController().GetAll();
    //        cbx_NoiDaoTaoBangCapStore.DataBind();
    //    }
    //    catch (Exception ex)
    //    {
    //        ExtMessage.Dialog.ShowError(ex.Message);
    //    }
    //}

    //protected void cbx_hinhthucdaotaobangStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    //{
    //    try
    //    {
    //        cbx_hinhthucdaotaobangStore.DataSource = new DM_HT_DAOTAOController().GetAll();
    //        cbx_hinhthucdaotaobangStore.DataBind();
    //    }
    //    catch (Exception ex)
    //    {
    //        Dialog.ShowError(ex.Message);
    //    }
    //}

    //protected void cbx_ChuyenNganhBangCapStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    //{
    //    try
    //    {
    //        cbx_ChuyenNganhBangCapStore.DataSource = new DM_CHUYENNGANHController().GetAll();
    //        cbx_ChuyenNganhBangCapStore.DataBind();
    //    }
    //    catch (Exception ex)
    //    {
    //        ExtMessage.Dialog.ShowError(ex.Message);
    //    }
    //}

    //protected void cbx_trinhdobangcapStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    //{
    //    try
    //    {
    //        cbx_trinhdobangcapStore.DataSource = new DM_TRINHDOController().GetAll();
    //        cbx_trinhdobangcapStore.DataBind();
    //    }
    //    catch (Exception ex)
    //    {
    //        Dialog.ShowError(ex.Message);
    //    }
    //}

    //protected void cbx_xeploaiBangCapStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    //{
    //    try
    //    {
    //        cbx_xeploaiBangCapStore.DataSource = new DM_XEPLOAIController().GetAll();
    //        cbx_xeploaiBangCapStore.DataBind();
    //    }
    //    catch (Exception ex)
    //    {
    //        Dialog.ShowError(ex.Message);
    //    }
    //}

    //protected void cbx_tenchungchiStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    //{
    //    try
    //    {
    //        cbx_tenchungchiStore.DataSource = new DM_CHUNGCHIController().GetAll();
    //        cbx_tenchungchiStore.DataBind();
    //    }
    //    catch (Exception ex)
    //    {
    //        Dialog.ShowError(ex.Message);
    //    }
    //}

    //protected void cbx_XepLoaiChungChiStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    //{
    //    try
    //    {
    //        cbx_XepLoaiChungChiStore.DataSource = new DM_XEPLOAIController().GetAll();
    //        cbx_XepLoaiChungChiStore.DataBind();
    //    }
    //    catch (Exception ex)
    //    {
    //        Dialog.ShowError(ex.Message);
    //    }
    //}

    //protected void ccbx_TrinhDoChungChiStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    //{
    //    try
    //    {
    //        cbx_TrinhDoChungChiStore.DataSource = new DM_TRINHDOController().GetAll();
    //        cbx_TrinhDoChungChiStore.DataBind();
    //    }
    //    catch (Exception ex)
    //    {
    //        ExtMessage.Dialog.ShowError(ex.Message);
    //    }
    //}

    protected void StorecbBankID_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            Storecb_BankID.DataSource = DataHandler.GetInstance().ExecuteDataTable("select MA_NH,TEN_NH from DM_NH");//new DM_NGANHANGController().GetAll();
            Storecb_BankID.DataBind();
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }

    #endregion


    #region Các hàm xử lý sự kiện Click
    protected void btnUpdateDaoTao_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DaoTaoController dtController = new DaoTaoController();
            string[] selectedKhoaDaoTao = hdfSelectedKhoaHoc.Text.Split(';');
            string error = "";
            foreach (var item in RowSelectionModel1.SelectedRows)
            {
                string[] tmp = GetSelectedKhoaDaoTao(selectedKhoaDaoTao, item.RecordID).Split(',');
                DAL.DM_NhanVienThamGiaDaoTao nv = new DM_NhanVienThamGiaDaoTao()
                {
                    CreatedBy = CurrentUser.ID,
                    CreatedDate = DateTime.Now,
                    DaThamGia = true,
                    MaCanBo = txtMaCB.Text,//grp_NhanSu_NhapHoSoNhanSu.GetPrimaryKey(),
                    MaKhoaDaoTao = item.RecordID,
                };
                if (!string.IsNullOrEmpty(tmp[1]) && tmp[1] != "null")
                    nv.SoTienCongTyHoTro = decimal.Parse(tmp[1]);

                if (!string.IsNullOrEmpty(tmp[2]) && tmp[1] != "null")
                    nv.SoTienNVDong = decimal.Parse(tmp[2]);

                try
                {
                    dtController.InsertNhanVienThamgiaHoc(nv);
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("Violation of UNIQUE KEY constraint 'ucUnique'"))
                    {
                        error += tmp[3] + ",";
                    }
                }
            }
            GridPanelQTDT.Reload();
            if (!string.IsNullOrEmpty(error))
            {
                Dialog.ShowError("Khóa học  " + error.Remove(error.LastIndexOf(',')) + " đã được thêm vào rồi !");
            }
            wdQuaTrinhDaoTao.Hide();

        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }

    private string GetSelectedKhoaDaoTao(string[] arr, string MaKhoaDaoTao)
    {
        foreach (var item in arr)
        {
            if (item.StartsWith(MaKhoaDaoTao))
            {
                return item;
            }
        }
        return "";
    }

    protected void btnUpdateCongViec_Click(object sender, DirectEventArgs e)
    {
        try
        {
            //string hsluong = String.Format("{0:00.0}", txtBHHSLuong.Text);
            DAL.HOSO_BAOHIEM hosoBaoHiem = new HOSO_BAOHIEM()
            {
                DON_VI = txtBHDonVi.Text,
                FR_KEY = decimal.Parse(hdfRecordID.Text),
                GHI_CHU = txtBHGhiChu.Text,
                HS_LUONG = decimal.Parse("0" + txtBHHSLuong.Text.Replace(".", ",")),
                MA_CONGVIEC = cbBHCongViec.SelectedItem.Value,
                MUC_LUONG = decimal.Parse("0" + txtBHMucLuong.Text),
                PHUCAP = decimal.Parse("0" + txtBHPhuCap.Text),
                TYLE = txtBHTyle.Text
            };
            if (!SoftCore.Util.GetInstance().IsDateNull(dfBHDenNgay.SelectedDate))
                hosoBaoHiem.DEN_NGAY = dfBHDenNgay.SelectedDate != null ? dfBHDenNgay.SelectedDate.Day + "/" + dfBHDenNgay.SelectedDate.Month + "/" + dfBHDenNgay.SelectedDate.Year : "";
            if (!SoftCore.Util.GetInstance().IsDateNull(dfBHTuNgay.SelectedDate))
                hosoBaoHiem.TU_NGAY = dfBHTuNgay.SelectedDate != null ? dfBHTuNgay.SelectedDate.Day + "/" + dfBHTuNgay.SelectedDate.Month + "/" + dfBHTuNgay.SelectedDate.Year : "";
            if (e.ExtraParams["Command"] == "Update")
            {
                hosoBaoHiem.PR_KEY = decimal.Parse(RowSelectionModelBaoHiem.SelectedRecordID);
                new HoSoController().UpdateBaoHiem(hosoBaoHiem);
                wdBaoHiem.Hide();
            }
            else
            {
                new HoSoController().InsertBaoHiem(hosoBaoHiem);
            }
            if (e.ExtraParams["Close"] == "True")
            {
                wdBaoHiem.Hide();
            }
            GridPanelBaoHiem.Reload();
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }

    protected void btnCapNhatDaiBieu_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DAL.HOSO_DAIBIEU daibieu = new HOSO_DAIBIEU()
            {
                GHI_CHU = txtDBGhiChu.Text.Trim(),
                FR_KEY = decimal.Parse(hdfRecordID.Text),
                LOAI_HINH = txtDBLoaiHinh.Text.Trim(),
                NHIEM_KY = txtDBNhiemKy.Text.Trim(),
                TU_NGAY = dfDBTuNgay.SelectedDate.ToString(),//dfDBTuNgay.SelectedDate.Day + "/" + dfDBTuNgay.SelectedDate.Month + "/" + dfDBTuNgay.SelectedDate.Year,
                DEN_NGAY = dfDBDenNgay.SelectedDate.ToString()//.SelectedDate.Day + "/" + dfDBDenNgay.SelectedDate.Month + "/" + dfDBDenNgay.SelectedDate.Year
            };
            if (e.ExtraParams["Command"] == "Update")
            {
                daibieu.PR_KEY = decimal.Parse(RowSelectionModelDaiBieu.SelectedRecordID);
                wdDaiBieu.Hide();
                new HoSoController().UpdateDaiBieu(daibieu);
            }
            else
            {
                new HoSoController().InsertDaiBieu(daibieu);
            }
            if (e.ExtraParams["Close"] == "True")
            {
                wdDaiBieu.Hide();
            }
            GridPanelDaiBieu.Reload();
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }

    protected void btnUpdateTheNganHang_Click(object sender, DirectEventArgs e)
    {
        try
        {

            //if (e.ExtraParams["Command"] == "Update" && new DALController().Update(wdTheNganHang, "HOSO_ATM", RowSelectionModelATM.SelectedRecordID))
            //{
            //    //grpATM.Reload();
            //    Dialog.ShowNotification("Cập nhật thành công !");
            //    wdTheNganHang.Hide();
            //}
            if (e.ExtraParams["Command"] != "Update" && new DALController().Add(wdTheNganHang, "HOSO_ATM"))
            {
                //grpATM.Reload();
                nbf_ATMNumber.Reset();
                cb_BankID.Reset();
                txt_Note.Reset();
                chk_IsInUsed.Reset();
                Dialog.ShowNotification("Cập nhật thành công !");
            }
            if (e.ExtraParams["Close"] == "True")
                wdTheNganHang.Hide();
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }

    #region các hàm dùng chung
    /// <summary>
    /// upload file from computer to server
    /// </summary>
    /// <param name="sender">ID of FileUploadField</param>
    /// <param name="directory">directory of folder HoSoNhanSu</param>
    /// <param name="relativePath">the relative path to place you want to save file</param>
    /// <returns>The path of file after upload to server</returns>
    public string UploadFile(object sender, string relativePath)
    {
        FileUploadField obj = (FileUploadField)sender;
        HttpPostedFile file = obj.PostedFile;
        DirectoryInfo dir = new DirectoryInfo(Server.MapPath(relativePath));  // save file to directory HoSoNhanSu/File
        // if directory not exist then create this
        if (dir.Exists == false)
            dir.Create();
        string rdstr = SoftCore.Util.GetInstance().GetRandomString(7);
        string path = Server.MapPath(relativePath) + "/" + rdstr + "_" + obj.FileName;
        if (File.Exists(path))
            return "";
        FileInfo info = new FileInfo(path);
        file.SaveAs(path);
        return relativePath + "/" + rdstr + "_" + obj.FileName;
    }

    /// <summary>
    /// Delete Attach file of table include: delete column TepTinDinhKem in database and delete physical file in server
    /// </summary>
    /// <param name="TableName">Name of table</param>
    /// <param name="Prkey">Prkey of employee</param>
    public void DeleteTepTinDinhKem(string tableName, decimal prkey, Hidden sender)
    {
        try
        {
            // xóa trong csdl
            //           DataController.DataHandler.GetInstance().ExecuteNonQuery("HOSO_DeleteTepTinDinhKem", "@TableName", "@Prkey", tableName, prkey).ToString();
            // xóa file trong thư mục
            string serverPath = Server.MapPath(sender.Text);
            if (Util.GetInstance().FileIsExists(serverPath) == false)
            {
                Dialog.ShowNotification("Tệp tin không tồn tại hoặc đã bị xóa !");
                return;
            }
            File.Delete(serverPath);
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }

    public void DeleteTepTinDinhKem(string tableName, int id, Hidden sender)
    {
        try
        {
            // xóa trong csdl
            //    DataController.DataHandler.GetInstance().ExecuteNonQuery("HOSO_DeleteAttachFile", "@TableName", "@ID", tableName, id).ToString();
            // xóa file trong thư mục
            string serverPath = Server.MapPath(sender.Text);
            if (Util.GetInstance().FileIsExists(serverPath) == false)
            {
                Dialog.ShowNotification("Tệp tin không tồn tại hoặc đã bị xóa !");
                return;
            }
            File.Delete(serverPath);
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }

    /// <summary>
    /// Return attach file to client when user click download button
    /// </summary>
    /// <param name="TableName">Name of table</param>
    /// <param name="Prkey">Prkey of employee</param>
    public void DownloadAttachFile(string TableName, Hidden sender)
    {
        try
        {
            if (string.IsNullOrEmpty(sender.Text))
            {
                Dialog.ShowNotification("Không có tệp tin đính kèm");
                return;
            }
            string serverPath = Server.MapPath(sender.Text);
            if (Util.GetInstance().FileIsExists(serverPath) == false)
            {
                Dialog.ShowNotification("Tệp tin không tồn tại hoặc đã bị xóa !");
                return;
            }
            Response.Clear();
            //  Response.ContentType = "application/octet-stream";

            Response.AddHeader("Content-Disposition", "attachment; filename=" + sender.Text.Replace(" ", "_"));
            Response.WriteFile(serverPath);
            Response.End();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", ex.Message).Show();
        }
    }

    [DirectMethod]
    public void DownloadAttach(string path)
    {
        string serverPath = Server.MapPath("") + "/" + path;
        if (Util.GetInstance().FileIsExists(serverPath) == false)
        {
            Dialog.ShowNotification("Tệp tin không tồn tại hoặc đã bị xóa !");
            return;
        }
        Response.Clear();
        //  Response.ContentType = "application/octet-stream";
        Response.AddHeader("Content-Disposition", "attachment; filename=" + path.Replace(" ", "_"));
        Response.WriteFile(serverPath);
        Response.End();
    }
    #endregion

    //############# đề tài
    protected void btnUpdateDeTai_Click(object sender, DirectEventArgs e)
    {
        try
        {
            // upload file
            string path = string.Empty;
            if (fufDeTaiTepTinDinhKem.HasFile)
            {
                string directory = Server.MapPath("");
                path = UploadFile(fufDeTaiTepTinDinhKem, "File/DeTai");
            }
            DAL.HOSO_DETAI detai = new HOSO_DETAI()
            {
                MaDeTai = txtMaDeTai.Text.Trim(),
                CAP_DETAI = txtDeTaiCapDeTai.Text.Trim(),
                CHUNHIEM_DETAI = txtDeTaiChuNhiemDeTai.Text.Trim(),
                GHI_CHU = txtDeTaiGhiChu.Text.Trim(),
                FR_KEY = decimal.Parse(hdfRecordID.Text),
                KET_QUA = txtDeTaiKetQua.Text.Trim(),
                TEN_DETAI = txtDeTaiTenDeTai.Text.Trim(),
                TUCACH_THAMGIA = txDeTaiTuCachThamGia.Text.Trim(),
                DEN_NGAY = txtDeTaiDenNgay.Text.Trim(),
                TU_NGAY = txtDeTaiTuNgay.Text.Trim(),
            };
            if (path != "")
                detai.TepTinDinhKem = path;
            else
                detai.TepTinDinhKem = hdfDeTaiTepTinDinhKem.Text;
            if (e.ExtraParams["Command"] == "Update")
            {
                detai.PR_KEY = decimal.Parse(RowSelectionModelDeTai.SelectedRecordID);
                wdDeTai.Hide();
                new HoSoController().UpdateDetai(detai);
            }
            else
            {
                new HoSoController().InsertDeTai(detai);
                if (e.ExtraParams["Close"] == "True")
                {
                    wdDeTai.Hide();
                }
            }
            //grp_NhanSu_NhapHoSoNhanSu.CallScriptUsingResourceManager("#{StoreDeTai}.reload();");
            GridPanelDetai.Reload();
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }
    protected void btnDeTaiDownload_Click(object sender, DirectEventArgs e)
    {
        string directory = Server.MapPath("");
        DownloadAttachFile("HOSO_DETAI", hdfDeTaiTepTinDinhKem);
    }
    protected void btnDeTaiDelete_Click(object sender, DirectEventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(RowSelectionModelDeTai.SelectedRecordID))
            {
                DeleteTepTinDinhKem("HOSO_DETAI", decimal.Parse(RowSelectionModelDeTai.SelectedRecordID), hdfDeTaiTepTinDinhKem);
                hdfDeTaiTepTinDinhKem.Reset();
                fufDeTaiTepTinDinhKem.Reset();
                //GridPanelDetai.Reload();
            }
            else
            {
                Dialog.ShowNotification("Tệp tin không tồn tại hoặc đã bị xóa!");
            }
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }
    ///////////////////////////

    //############# hợp đồng
    protected void btnUpdateHopDong_Click(object sender, DirectEventArgs e)
    {
        try
        {
            // upload file
            string path = string.Empty;
            if (fufHopDongTepTin.HasFile)
            {
                string directory = Server.MapPath("");
                path = UploadFile(fufHopDongTepTin, "File/HopDong");
            }
            DAL.HOSO_HOPDONG hopdong = new HOSO_HOPDONG()
            {
                FR_KEY = decimal.Parse(hdfRecordID.Text),
                MA_CONGVIEC = hdfViTriCongViec.Text,
                MA_LOAI_HDONG = cbHopDongLoaiHopDong.SelectedItem.Value,
                MA_TT_HDONG = hdfTinhTrangHopDong.Text,//cbHopDongTinhTrangHopDong.SelectedItem.Value,
                NGAY_HDONG = dfHopDongNgayHopDong.SelectedDate,
            };
            // sinh số hợp đồng
            string suffix = new HeThongController().GetValueByName(SystemConfigParameter.SUFFIX_SOHOPDONG, Session["MaDonVi"].ToString());
            hopdong.SO_HDONG = new HoSoController().GenerateSoHopDong("HOSO_HOPDONG", "SO_HDONG", suffix);
            if (!string.IsNullOrEmpty(txtHopDongSoHopDong.Text) && string.IsNullOrEmpty(hopdong.SO_HDONG))
                hopdong.SO_HDONG = txtHopDongSoHopDong.Text;

            if (!dfHopDongNgayKiKet.SelectedDate.ToString().Contains("0001"))
                hopdong.NGAYKT_HDONG = dfHopDongNgayKiKet.SelectedDate;
            if (!dfNgayCoHieuLuc.SelectedDate.ToString().Contains("0001"))
                hopdong.NgayCoHieuLuc = dfNgayCoHieuLuc.SelectedDate;
            if (!string.IsNullOrEmpty(hdfPrkeyNguoiKyHD.Text))
                hopdong.PrkeyNguoiDaiDienKyHD = decimal.Parse("0" + hdfPrkeyNguoiKyHD.Text);
            if (cbx_HopDongChucVu.SelectedItem.Value != null)
                hopdong.MaChucVuNguoiKyHD = cbx_HopDongChucVu.SelectedItem.Value;
            if (path != "")
                hopdong.TepTinDinhKem = path;
            else
                hopdong.TepTinDinhKem = hdfHopDongTepTinDK.Text;
            hopdong.GhiChu = txtHopDongGhiChu.Text;
            hopdong.CreatedBy = CurrentUser.ID;
            hopdong.TrangThaiHopDong = cbx_HopDongTrangThai.SelectedItem.Value;
            hopdong.CreatedDate = DateTime.Now;
            if (e.ExtraParams["Command"] == "Update")
            {
                hopdong.PR_KEY = decimal.Parse(RowSelectionModelHopDong.SelectedRecordID);
                new HOSO_HOPDONGController().Update(hopdong);
                // update Hợp đồng lại Hồ sơ nếu như có sự thay đổi
                if (hopdong.MA_LOAI_HDONG != hdfMaHopDongOld.Text)
                {
                    new HoSoController().UpdateLoaiHopDong(hopdong.MA_LOAI_HDONG, hopdong.FR_KEY);
                }
                wdHopDong.Hide();
            }
            else
            {
                // kiểm tra còn hợp đồng nào chưa hết hạn không
                if (new HOSO_HOPDONGController().CheckBeforeInsert(decimal.Parse(hdfRecordID.Text), hopdong.NgayCoHieuLuc) == false)  // cán bộ còn ít nhất 1 hợp đồng có giá trị
                {
                    X.Msg.Alert("Thông báo", "Hợp đồng hiện tại của cán bộ vẫn còn hiệu lực. Bạn không được phép thay đổi loại hợp đồng.").Show();
                    return;
                }
                new HOSO_HOPDONGController().Insert(hopdong);
                // update hợp đồng mới vào Hồ sơ nhân sự
                new HoSoController().UpdateLoaiHopDong(hopdong.MA_LOAI_HDONG, hopdong.FR_KEY);

                if (e.ExtraParams["Close"] == "True")
                {
                    wdHopDong.Hide();
                }
                else
                {
                    GenerateSoQD();
                }
            }
            GridPanelHopDong.Reload();
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }
    protected void btnUpdateLuong_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DAL.HOSO_LUONG luong = new HOSO_LUONG()
            {
                PrKeyHoSo = decimal.Parse(hdfRecordID.Text),
                HeSoLuong = double.Parse("0" + txtHeSoLuong.Text),
                LuongCung = double.Parse("0" + txtLuongCung.Text),
                LuongDongBHXH = double.Parse("0" + txtLuongDongBH.Text),
                NgayHuongLuong = DateTime.Parse(dfNgayHuongLuong.SelectedValue.ToString()),
                NgayHieuLuc = DateTime.Parse(dfNgayHieuLuc.SelectedValue.ToString()),
                NgayQuyetDinh = DateTime.Parse(dfNgayQuyetDinh.SelectedValue.ToString())
            };
            if (e.ExtraParams["Command"] == "Update")
            {
                luong.ID = int.Parse(RowSelectionModelHopDong.SelectedRecordID);
                HoSoLuongController hsl1 =  new HoSoLuongController();
                hsl1.Update(luong);
                wdDienBienLuong.Hide();
            }
            else
            {
                HoSoLuongController hslx = new HoSoLuongController();
                hslx.Add(luong);
            }
            GridPanelHopDong.Reload();
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }
    protected void btnHopDongAttachDownload_Click(object sender, DirectEventArgs e)
    {
        string directory = Server.MapPath("");
        DownloadAttachFile("HOSO_HOPDONG", hdfHopDongTepTinDK);
    }
    protected void btnHopDongAttachDelete_Click(object sender, DirectEventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(RowSelectionModelHopDong.SelectedRecordID))
            {
                DeleteTepTinDinhKem("HOSO_HOPDONG", decimal.Parse(RowSelectionModelHopDong.SelectedRecordID), hdfHopDongTepTinDK);
                hdfHopDongTepTinDK.Text = "";
                GridPanelHopDong.Reload();
            }
            else
            {
                Dialog.ShowNotification("Tệp tin không tồn tại hoặc đã bị xóa!");
            }
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }

    [DirectMethod]
    public void GenerateSoQD()
    {
        string suffix = new HeThongController().GetValueByName(SystemConfigParameter.SUFFIX_SOHOPDONG, Session["MaDonVi"].ToString());
        string sohd = new HoSoController().GenerateSoHopDong("HOSO_HOPDONG", "SO_HDONG", suffix);
        txtHopDongSoHopDong.Text = sohd;
    }
    //////////////////////////

    protected void btnUpdateKhaNang_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DAL.HOSO_KHANANG khaNang = new HOSO_KHANANG()
            {
                FR_KEY = decimal.Parse(hdfRecordID.Text),
                GHI_CHU = txtKhaNangGhiChu.Text,
                MA_KHANANG = cbKhaNang.SelectedItem.Value,
                MA_XEPLOAI = cbKhaNangXepLoai.SelectedItem.Value,

            };
            if (e.ExtraParams["Command"] == "Update")
            {
                khaNang.PR_KEY = decimal.Parse(RowSelectionModelKhaNang.SelectedRecordID);
                wdKhaNang.Hide();
                new HoSoController().UpdateKhaNang(khaNang);
            }
            else
            {
                new HoSoController().InsertKhaNang(khaNang);
                if (e.ExtraParams["Close"] == "True")
                {
                    wdKhaNang.Hide();
                }
            }
            //grp_NhanSu_NhapHoSoNhanSu.CallScriptUsingResourceManager("#{StoreKhaNang}.reload();");
            GridPanelKhaNang.Reload();
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }

    protected void btnUpdateKhenThuong_Click(object sender, DirectEventArgs e)
    {
        try
        {
            // insert ly do khen thuong (neu co)
            string maLyDoKT = "";
            if (hdfIsDanhMuc.Text == "0")
            {
                try
                {
                    DAL.DM_LYDO_KTHUONG lyDo = new DM_LYDO_KTHUONG();
                    lyDo.TEN_LYDO_KTHUONG = cbLyDoKhenThuong.Text;
                    lyDo.MA_DONVI = Session["MaDonVi"].ToString();
                    lyDo.USERNAME = CurrentUser.DisplayName;
                    lyDo.DATE_CREATE = DateTime.Now;
                    lyDo.MA_LYDO_KTHUONG = CommonUtil.GetInstance().GenerateMaSo("DM_LYDO_KTHUONG", "MA_LYDO_KTHUONG", "KT");
                    new DM_LyDoKhenThuongControllercs().Insert(lyDo);
                    maLyDoKT = cbLyDoKhenThuong.Text;
                }
                catch (Exception)
                {
                    maLyDoKT = cbLyDoKhenThuong.Text;
                }
            }
            else
            {
                maLyDoKT = cbLyDoKhenThuong.SelectedItem.Text;
            }
            if (string.IsNullOrEmpty(maLyDoKT))
            {
                X.Msg.Alert("Thông báo", "Không tìm thấy lý do khen thưởng. Vui lòng thử lại!").Show();
                return;
            }
            // upload file
            string path = string.Empty;
            if (fufKhenThuongTepTinDinhKem.HasFile)
            {
                string directory = Server.MapPath("");
                path = UploadFile(fufKhenThuongTepTinDinhKem, "File/KhenThuong");
            }
            DAL.HOSO_KHENTHUONG khenthuong = new HOSO_KHENTHUONG()
            {
                FR_KEY = decimal.Parse(hdfRecordID.Text),
                GHI_CHU = txtKhenThuongGhiCHu.Text,
                LYDO_KTHUONG = maLyDoKT,
                MA_HT_KTHUONG = cbHinhThucKhenThuong.SelectedItem.Value,
                SO_QD = txtKhenThuongSoQuyetDinh.Text,
                SO_TIEN = decimal.Parse("0" + txtKhenThuongSoTien.Text),
                PrkeyNguoiQuyetDinh = decimal.Parse("0" + hdfKhenThuongNguoiQD.Text),
                SoDiem = double.Parse("0" + nbfSoDiemKhenThuong.Text.Replace(".", ","))
            };
            if (!SoftCore.Util.GetInstance().IsDateNull(dfKhenThuongNgayQuyetDinh.SelectedDate))
            {
                khenthuong.NGAY_QD = dfKhenThuongNgayQuyetDinh.SelectedDate;
            }
            if (path != "")
                khenthuong.TepTinDinhKem = path;
            else
                khenthuong.TepTinDinhKem = hdfKhenThuongTepTinDinhKem.Text;
            if (e.ExtraParams["Command"] == "Update")
            {
                wdKhenThuong.Hide();
                khenthuong.PR_KEY = decimal.Parse(RowSelectionModelKhenThuong.SelectedRecordID);
                new HoSoKhenThuongController().UpdateKhenThuong(khenthuong);
            }
            else
            {
                new HoSoKhenThuongController().InsertKhenThuong(khenthuong);
                if (e.ExtraParams["Close"] == "True")
                {
                    wdKhenThuong.Hide();
                }
                else
                {
                    GenerateKhenThuongSoQD();
                }
            }
            //grp_NhanSu_NhapHoSoNhanSu.CallScriptUsingResourceManager("#{StoreKhenThuong}.reload();");
            GridPanelKhenThuong.Reload();
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }
    protected void btnKhenThuongDownload_Click(object sender, DirectEventArgs e)
    {
        string directory = Server.MapPath("");
        DownloadAttachFile("HOSO_KHENTHUONG", hdfKhenThuongTepTinDinhKem);
    }
    protected void btnKhenThuongDelete_Click(object sender, DirectEventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(RowSelectionModelKhenThuong.SelectedRecordID))
            {
                DeleteTepTinDinhKem("HOSO_KHENTHUONG", decimal.Parse(RowSelectionModelKhenThuong.SelectedRecordID), hdfKhenThuongTepTinDinhKem);
                hdfKhenThuongTepTinDinhKem.Text = "";
                GridPanelKhenThuong.Reload();
            }
            else
            {
                Dialog.ShowNotification("Tệp tin không tồn tại hoặc đã bị xóa!");
            }
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }

    [DirectMethod]
    public void GenerateKhenThuongSoQD()
    {
        string suffix = new HeThongController().GetValueByName(SystemConfigParameter.SUFFIX_SOQDKHENTHUONG, Session["MaDonVi"].ToString());
        string sohd = new HoSoController().GenerateSoHopDong("HOSO_KHENTHUONG", "SO_QD", suffix);
        txtKhenThuongSoQuyetDinh.Text = sohd;
    }
    ////////////////////////////

    //############## kỷ luật
    protected void btnCapNhatKyLuat_Click(object sender, DirectEventArgs e)
    {
        try
        {
            // insert ly do khen thuong (neu co)
            string maLyDoKL = "";
            if (hdfIsDanhMucKL.Text == "0")
            {
                try
                {
                    DAL.DM_LYDO_KYLUAT lyDo = new DM_LYDO_KYLUAT();
                    lyDo.TEN_LYDO_KYLUAT = cbLyDoKyLuat.Text;
                    lyDo.MA_DONVI = Session["MaDonVi"].ToString();
                    lyDo.USERNAME = CurrentUser.DisplayName;
                    lyDo.DATE_CREATE = DateTime.Now;
                    lyDo.MA_LYDO_KYLUAT = CommonUtil.GetInstance().GenerateMaSo("DM_LYDO_KYLUAT", "MA_LYDO_KYLUAT", "KL");
                    new DM_LyDoKyLuatController().Insert(lyDo);
                    maLyDoKL = cbLyDoKyLuat.Text;
                }
                catch (Exception)
                {
                    maLyDoKL = cbLyDoKyLuat.Text;
                }
            }
            else
            {
                maLyDoKL = cbLyDoKyLuat.SelectedItem.Text;
            }
            if (string.IsNullOrEmpty(maLyDoKL))
            {
                X.Msg.Alert("Thông báo", "Không tìm thấy lý do khen thưởng. Vui lòng thử lại!").Show();
                return;
            }
            // upload file
            string path = string.Empty;
            if (fufKyLuatTepTinDinhKem.HasFile)
            {
                string directory = Server.MapPath("");
                path = UploadFile(fufKyLuatTepTinDinhKem, "File/KyLuat");
            }
            DAL.HOSO_KYLUAT kyluat = new HOSO_KYLUAT()
            {
                FR_KEY = decimal.Parse(hdfRecordID.Text),
                GHI_CHU = txtKyLuatGhiChu.Text,
                MA_HT_KYLUAT = cbHinhThucKyLuat.SelectedItem.Value,
                LYDO_KYLUAT = maLyDoKL,
                SO_TIEN = decimal.Parse("0" + txtKyLuatSoTien.Text),
                SO_QD = txtKyLuatSoQD.Text,
                NGAY_QD = dfKyLuatNgayQuyetDinh.SelectedDate,
                PrkeyNguoiQuyetDinh = decimal.Parse("0" + hdfKyLuatNguoiQD.Text),
                SoDiem = double.Parse("0" + nbfSoDiem.Text.Replace(".", ","))
            };
            if (path != "")
                kyluat.TepTinDinhKem = path;
            else
                kyluat.TepTinDinhKem = hdfKyLuatTepTinDinhKem.Text;
            if (e.ExtraParams["Command"] == "Update")
            {
                kyluat.PR_KEY = decimal.Parse(RowSelectionModelKyLuat.SelectedRecordID);
                new HoSoKyLuatController().UpdateKyLuat(kyluat);
                wdKyLuat.Hide();
            }
            else
            {
                new HoSoKyLuatController().InsertKyluat(kyluat);
                if (e.ExtraParams["Close"] == "True")
                {
                    wdKyLuat.Hide();
                }
                else
                {
                    GenerateKyLuatSoQD();
                }
            }
            //grp_NhanSu_NhapHoSoNhanSu.CallScriptUsingResourceManager("#{StoreKyLuat}.reload();");
            GridPanelKyLuat.Reload();
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }
    protected void btnKyLuatDownload_Click(object sender, DirectEventArgs e)
    {
        string directory = Server.MapPath("");
        DownloadAttachFile("HOSO_KYLUAT", hdfKyLuatTepTinDinhKem);
    }
    protected void btnKyLuatDelete_Click(object sender, DirectEventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(RowSelectionModelKyLuat.SelectedRecordID))
            {
                DeleteTepTinDinhKem("HOSO_KYLUAT", decimal.Parse(RowSelectionModelKyLuat.SelectedRecordID), hdfKyLuatTepTinDinhKem);
                hdfKyLuatTepTinDinhKem.Text = "";
                GridPanelKyLuat.Reload();
            }
            else
            {
                Dialog.ShowNotification("Tệp tin không tồn tại hoặc đã bị xóa!");
            }
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }

    [DirectMethod]
    public void GenerateKyLuatSoQD()
    {
        string suffix = new HeThongController().GetValueByName(SystemConfigParameter.SUFFIX_SOQDKYLUAT, Session["MaDonVi"].ToString());
        string sohd = new HoSoController().GenerateSoHopDong("HOSO_KYLUAT", "SO_QD", suffix);
        txtKyLuatSoQD.Text = sohd;
    }
    ///////////////////////////

    protected void btnUpdateQuanHeGiaDinh_Click(object sender, DirectEventArgs e)
    {
        try
        {
            SoftCore.Util util = new Util();
            DAL.HOSO_QH_GIADINH qhgd = new HOSO_QH_GIADINH()
            {
                FR_KEY = decimal.Parse(hdfRecordID.Text),
                GHI_CHU = txtQHGDGhiChu.Text,
                HO_TEN = txtQHGDHoTen.Text,
                GIOI_TINH = cbQHGDGioiTinh.Text,
                MA_QUANHE = cbQuanHeGiaDinh.SelectedItem.Value,
                NOI_LAMVIEC = txtQHGDNoiLamViec.Text,
                TUOI = txtQHGDNamSinh.Text,
                NGHE_NGHIEP = txtQHGDNgheNghiep.Text,
                LaNguoiPhuThuoc = chkQHGDLaNguoiPhuThuoc.Checked,
                SoCMT = txtSoCMT.Text
            };
            if (chkQHGDLaNguoiPhuThuoc.Checked == true)
            {
                if (!util.IsDateNull(dfQHGDBatDauGiamTru.SelectedDate))
                    qhgd.NgayBatDauGiamTru = dfQHGDBatDauGiamTru.SelectedDate;
                if (!util.IsDateNull(dfQHGDKetThucGiamTru.SelectedDate))
                    qhgd.NgayKetThucGiamTru = dfQHGDKetThucGiamTru.SelectedDate;
            }
            if (e.ExtraParams["Command"] == "Update")
            {
                wdQuanHeGiaDinh.Hide();
                qhgd.PR_KEY = decimal.Parse(RowSelectionModelQHGD.SelectedRecordID);
                new HoSoController().UpdateQuanHeGiaDinh(qhgd);
            }
            else
            {
                new HoSoController().InsertQuanHeGiaDinh(qhgd);
                if (e.ExtraParams["Close"] == "True")
                {
                    wdQuanHeGiaDinh.Hide();
                }
            }
            //grp_NhanSu_NhapHoSoNhanSu.CallScriptUsingResourceManager("#{StoreQHGD}.reload();");
            GridPanelQHGD.Reload();
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }

    //############## quá trình công tác
    protected void btnCapNhatQuaTrinhCongTac_Click(object sender, DirectEventArgs e)
    {
        try
        {
            // upload file
            string path = string.Empty;
            if (fufQTCTTepTinDinhKem.HasFile)
            {
                string directory = Server.MapPath("");
                path = UploadFile(fufQTCTTepTinDinhKem, "File/QuaTrinhCongTac");
            }
            DAL.HOSO_QT_CTAC qtcongTac = new HOSO_QT_CTAC()
            {
                FR_KEY = decimal.Parse(hdfRecordID.Text),
                MaQuocGia = cbCongTacQuocGia.SelectedItem.Value,
                NguoiLienQuan = txtQTCTNguoiLienQuan.Text,
                NoiDungCongViec = txtQTCTNoiDungCongViec.Text,
                SoQuyetDinh = txtQTCTSoQD.Text,
                DiaDiemCongTac = txtQTCTDiaDiemCT.Text,
                GHI_CHU = txtCongTacGhiChu.Text,
            };
            if (hdfQTCTNguoiQuyetDinh.Text != "")
                qtcongTac.PrkeyNguoiQuyetDinh = decimal.Parse("0" + hdfQTCTNguoiQuyetDinh.Text);
            if (!dfQTCTNgayQuyetDinh.SelectedDate.ToString().Contains("0001"))
                qtcongTac.NgayQuyetDinh = dfQTCTNgayQuyetDinh.SelectedDate;
            if (!dfQTCTNgayBatDau.SelectedDate.ToString().Contains("0001"))
                qtcongTac.ThoiGianBatDau = dfQTCTNgayBatDau.SelectedDate;
            if (!dfQTCTNgayKetThuc.SelectedDate.ToString().Contains("0001"))
                qtcongTac.ThoiGianKetThuc = dfQTCTNgayKetThuc.SelectedDate;
            if (path != null && path != "")
                qtcongTac.TepTinDinhKem = path;
            else
                qtcongTac.TepTinDinhKem = hdfQTCTTepTinDinhKem.Text;
            if (e.ExtraParams["Command"] == "Update")
            {
                qtcongTac.PR_KEY = decimal.Parse(RowSelectionModelQuaTrinhCongTac.SelectedRecordID);
                new HOSO_QT_CTACController().UpdateQuaTrinhCongTac(qtcongTac);
                //grp_NhanSu_NhapHoSoNhanSu.CallScriptUsingResourceManager("#{StoreQuaTrinhCongTac}.reload();");
                GridPanelQuaTrinhCTAC.Reload();
                wdQuaTrinhCongTac.Hide();
            }
            else
            {
                new HOSO_QT_CTACController().InsertQuaTrinhCongTac(qtcongTac);
                if (e.ExtraParams["Close"] == "True")
                {
                    wdQuaTrinhCongTac.Hide();
                }
                else
                {
                    GenerateQTCTSoQD();
                }
            }
            GridPanelQuaTrinhCTAC.Reload();
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }
    protected void btnQTCTDownload_Click(object sender, DirectEventArgs e)
    {
        string directory = Server.MapPath("");
        DownloadAttachFile("HOSO_QT_CTAC", hdfQTCTTepTinDinhKem);
    }
    protected void btnQTCTDelete_Click(object sender, DirectEventArgs e)
    {
        if (hdfRecordID.Text != "")
        {
            DeleteTepTinDinhKem("HOSO_QT_CTAC", decimal.Parse(RowSelectionModelQuaTrinhCongTac.SelectedRecordID), hdfQTCTTepTinDinhKem);
            hdfQTCTTepTinDinhKem.Text = "";
            GridPanelQuaTrinhCTAC.Reload();
        }
    }

    [DirectMethod]
    public void GenerateQTCTSoQD()
    {
        string suffix = new HeThongController().GetValueByName(SystemConfigParameter.SUFFIX_SOQDCONGTAC, Session["MaDonVi"].ToString());
        string sohd = new HoSoController().GenerateSoHopDong("HOSO_QT_CTAC", "SoQuyetDinh", suffix);
        txtQTCTSoQD.Text = sohd;
    }
    ///////////////////////////

    //############## quá trình điều chuyển
    protected void btnCapNhatQuaTrinhDieuChuyen_Click(object sender, DirectEventArgs e)
    {
        try
        {
            HoSoController hsController = new HoSoController();
            HOSO_QT_DIEUCHUYENController dcController = new HOSO_QT_DIEUCHUYENController();
            // upload file
            string path = string.Empty;
            if (fufQTDCTepTinDinhKem.HasFile)
            {
                string directory = Server.MapPath("");
                path = UploadFile(fufQTDCTepTinDinhKem, "File/QuaTrinhDieuChuyen");
            }
            DAL.HOSO_QT_DIEUCHUYEN dieuchuyen = new HOSO_QT_DIEUCHUYEN()
            {
                FR_KEY = decimal.Parse(hdfRecordID.Text),
                SoQuyetDinh = txtQTDCSoQuyetDinh.Text,
                MaBoPhanMoi = hdfQTDCBoPhanMoi.Text,//cbxQTDCBoPhanMoi.SelectedItem.Value,
                MaChucVuMoi = hdfQTDCChucVuMoi.Text,//cbxQTDCChucVuMoi.SelectedItem.Value,
                MaCongViecMoi = hdfCongViecMoi.Text,//cbxCongViecMoi.SelectedItem.Value,
                GhiChu = txtDieuChuyenGhiChu.Text,
            };
            if (hdfQTDCNguoiQuyetDinh.Text != "")
                dieuchuyen.PrkeyNguoiQuyetDinh = decimal.Parse("0" + hdfQTDCNguoiQuyetDinh.Text);
            if (!dfQTDCNgayQuyetDinh.SelectedDate.ToString().Contains("0001"))
                dieuchuyen.NgayQuyetDinh = dfQTDCNgayQuyetDinh.SelectedDate;
            if (!dfQTDCNgayCoHieuLuc.SelectedDate.ToString().Contains("0001"))
                dieuchuyen.NgayCoHieuLuc = dfQTDCNgayCoHieuLuc.SelectedDate;
            if (!dfQTDCNgayHetHieuLuc.SelectedDate.ToString().Contains("0001"))
                dieuchuyen.NgayHetHieuLuc = dfQTDCNgayHetHieuLuc.SelectedDate;
            if (path != "")
                dieuchuyen.TepTinDinhKem = path;
            else
                dieuchuyen.TepTinDinhKem = hdfQTDCTepTinDinhKem.Text;
            if (e.ExtraParams["Command"] == "Update")
            {
                dieuchuyen.PR_KEY = decimal.Parse(RowSelectionModelQuaTrinhDieuChuyen.SelectedRecordID);
                dcController.Update(dieuchuyen);
                // cập nhật đơn vị cho hồ sơ nếu có sự thay đổi
                // cập nhật bộ phận mới
                //if (cbxQTDCBoPhanMoi.SelectedItem != null && dieuchuyen.MaBoPhanCu != cbxQTDCBoPhanMoi.SelectedItem.Value)
                if (!string.IsNullOrEmpty(hdfQTDCBoPhanMoi.Text) && dieuchuyen.MaBoPhanCu != hdfQTDCBoPhanMoi.Text)
                {
                    hsController.UpdateMaDonVi(dieuchuyen.FR_KEY, dieuchuyen.MaBoPhanMoi);
                }
                // cập nhật chức vụ mới
                //if (cbxQTDCChucVuMoi.SelectedItem != null && dieuchuyen.MaChucVuCu != cbxQTDCChucVuMoi.SelectedItem.Value)
                if (!string.IsNullOrEmpty(hdfQTDCChucVuMoi.Text) && dieuchuyen.MaChucVuCu != hdfQTDCChucVuMoi.Text)
                {
                    hsController.UpdateMaChucVu(dieuchuyen.FR_KEY, dieuchuyen.MaChucVuMoi);
                }
                // cập nhật công việc mới
                //if (cbxCongViecMoi.SelectedItem != null && dieuchuyen.MaCongViecCu != cbxCongViecMoi.SelectedItem.Value)
                if (!string.IsNullOrEmpty(hdfCongViecMoi.Text) && dieuchuyen.MaCongViecCu != hdfCongViecMoi.Text)
                {
                    hsController.UpdateMaCongViec(dieuchuyen.FR_KEY, dieuchuyen.MaCongViecMoi);
                }
                wdQuaTrinhDieuChuyen.Hide();
            }
            else
            {
                HOSO hs = hsController.GetByPrKey(dieuchuyen.FR_KEY);
                if (hs != null)
                {
                    dieuchuyen.MaBoPhanCu = hs.MA_DONVI;
                    dieuchuyen.MaChucVuCu = hs.MA_CHUCVU;
                    dieuchuyen.MaCongViecCu = hs.MA_CONGVIEC;
                }
                dcController.Insert(dieuchuyen);
                // cập nhật đơn vị cho HOSO
                hsController.UpdateMaDonVi(dieuchuyen.FR_KEY, dieuchuyen.MaBoPhanMoi);
                hsController.UpdateMaChucVu(dieuchuyen.FR_KEY, dieuchuyen.MaChucVuMoi);
                hsController.UpdateMaCongViec(dieuchuyen.FR_KEY, dieuchuyen.MaCongViecMoi);
                if (e.ExtraParams["Close"] == "True")
                {
                    wdQuaTrinhDieuChuyen.Hide();
                }
            }
            //grp_NhanSu_NhapHoSoNhanSu.CallScriptUsingResourceManager("#{StoreQuaTrinhDieuChuyen}.reload();");
            GridPanelQuaTrinhDieuChuyen.Reload();
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }
    protected void btnQTDCDownload_Click(object sender, DirectEventArgs e)
    {
        string directory = Server.MapPath("");
        DownloadAttachFile("HOSO_QT_DIEUCHUYEN", hdfQTDCTepTinDinhKem);
    }
    protected void btnQTDCDelete_Click(object sender, DirectEventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(RowSelectionModelQuaTrinhDieuChuyen.SelectedRecordID))
            {
                DeleteTepTinDinhKem("HOSO_QT_DIEUCHUYEN", decimal.Parse(RowSelectionModelQuaTrinhDieuChuyen.SelectedRecordID), hdfQTDCTepTinDinhKem);
                hdfQTDCTepTinDinhKem.Text = "";
                GridPanelQuaTrinhDieuChuyen.Reload();
            }
            else
            {
                Dialog.ShowNotification("Tệp tin không tồn tại hoặc đã bị xóa!");
            }
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }

    [DirectMethod]
    public void GenerateQTDCSoQD()
    {
        string suffix = new HeThongController().GetValueByName(SystemConfigParameter.SUFFIX_SOQDDIEUCHUYEN, Session["MaDonVi"].ToString());
        string sohd = new HoSoController().GenerateSoHopDong("HOSO_QT_DIEUCHUYEN", "SoQuyetDinh", suffix);
        txtQTDCSoQuyetDinh.Text = sohd;
    }
    ///////////////////////////
    //############### tài sản
    [DirectMethod]
    public void GetDVTByTaiSan(string maTaiSan)
    {
        DataTable dtTenDVT = DataHandler.GetInstance().ExecuteDataTable("HOSO_GetDVTByTaiSan", "@MaTaiSan", maTaiSan);
        if (dtTenDVT.Rows.Count > 0)
        {
            cbxDonViTinh.SetValue(dtTenDVT.Rows[0]["TEN_DVT"].ToString());
            hdfDonViTinh.SetValue(dtTenDVT.Rows[0]["MA_DVT"].ToString());
        }
    }
    protected void btnUpdateTaiSan_Click(object sender, DirectEventArgs e)
    {
        try
        {
            HoSoController hs = new HoSoController();
            DAL.HOSO_TAISAN ts = new HOSO_TAISAN()
            {
                FR_KEY = decimal.Parse(hdfRecordID.Text),
                GHI_CHU = tsGhiChu.Text,
                MA_VTHH = cbTaiSan.SelectedItem.Value,
                SoLuong = int.Parse("0" + txtTaiSanSoLuong.Text),
                MaDonViTinh = hdfDonViTinh.Text,
                TINH_TRANG = tsTxtinhTrang.Text,
                HanSuDung = DateTime.Parse(dfTSanHSD.Value.ToString())
            };
            if (!SoftCore.Util.GetInstance().IsDateNull(tsDateField.SelectedDate))
                ts.NGAY_NHAN = tsDateField.SelectedDate;
            if (e.ExtraParams["Command"] == "Update")
            {
                ts.PR_KEY = decimal.Parse(RowSelectionModelTaiSan.SelectedRecordID);
                hs.UpdateTaiSan(ts);
                wdAddTaiSan.Hide();
                GridPanelTaiSan.Reload();
            }
            else
            {
                hs.InsertTaiSan(ts);
                if (e.ExtraParams["Close"] == "True")
                {
                    wdAddTaiSan.Hide();
                }
                GridPanelTaiSan.Reload();
            }
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }
    //////////////////////////

    protected void btnUpdateAtachFile_Click(object sender, DirectEventArgs e)
    {
        try
        {
            // upload file
            string path = string.Empty;
            if (file_cv.HasFile)
            {
                path = UploadFile(file_cv, "../HoSoNhanSu/File/TepTinDinhKem");
            }
            DAL.HOSO_TepTinDinhKem attach = new HOSO_TepTinDinhKem()
            {
                CreatedBy = CurrentUser.ID,
                CreatedDate = DateTime.Now,
                Duyet = false,
                FR_KEY = decimal.Parse(hdfRecordID.Text),
                GhiChu = txtGhiChu.Text,
                TenTepTin = txtFileName.Text,
            };
            if (path != "")
            {
                attach.Link = path;
                HttpPostedFile file = file_cv.PostedFile;
                attach.SizeKB = file.ContentLength / 1024;
            }
            else
                attach.Link = hdfDinhKem.Text;
            if (e.ExtraParams["Command"] == "Update")
            {
                attach.PR_KEY = int.Parse(RowSelectionModelTepTinDinhKem.SelectedRecordID);
                new HOSO_TEPTINDINHKEMControllor().Update(attach);
                wdAttachFile.Hide();
            }
            else
            {
                new HoSoController().InsertTepTin(attach);
                if (e.ExtraParams["Close"] == "True")
                {
                    wdAttachFile.Hide();
                }
            }
            grpTepTinDinhKem.Reload();
            //double fileSize = 0;
            //#region upload file
            //HttpPostedFile file = file_cv.PostedFile;

            //string path = string.Empty;
            //string tenfile = string.Empty;
            //if (file != null)
            //{
            //    if (file_cv.HasFile == false && file.ContentLength > 2000000)
            //    {
            //        Dialog.ShowNotification("File không được lớn hơn 200kb");
            //        return;
            //    }
            //    else
            //    {
            //        fileSize = file.ContentLength;
            //        DirectoryInfo dir = new DirectoryInfo(Server.MapPath("File/TepTinDinhKem"));
            //        if (dir.Exists == false)
            //            dir.Create();
            //        tenfile = file_cv.FileName;
            //        while (Util.GetInstance().FileIsExists(Server.MapPath("File/TepTinDinhKem") + "/" + tenfile) == true)
            //        {
            //            tenfile = Util.GetInstance().GetRandomString(3) + file_cv.FileName;
            //        }
            //        path = Server.MapPath("File/TepTinDinhKem" + "/" + tenfile);
            //    }
            //}

            //if (string.IsNullOrEmpty(path) == false && string.IsNullOrEmpty(tenfile) == false)
            //{
            //    file.SaveAs(path);
            //}
            //if (e.ExtraParams["Close"] == "True")
            //{
            //    wdAttachFile.Hide();
            //}
            //#endregion
            //DAL.HOSO_TepTinDinhKem attachFile = new HOSO_TepTinDinhKem()
            //{
            //    CreatedBy = CurrentUser.ID,
            //    CreatedDate = DateTime.Now,
            //    FR_KEY = decimal.Parse(hdfRecordID.Text),
            //    GhiChu = txtGhiChu.Text.Trim(),
            //    Link = string.IsNullOrEmpty(tenfile) == false ? "File/TepTinDinhKem/" + tenfile : "",
            //    TenTepTin = txtFileName.Text,
            //    SizeKB = fileSize / 1024
            //};
            //if (e.ExtraParams["command"] == "Update")
            //{
            //    attachFile.Link = hdfDinhKem.Text;
            //    attachFile.PR_KEY = int.Parse(RowSelectionModelTepTinDinhKem.SelectedRecordID);
            //    string oldFilePath = string.Empty;
            //    new HoSoController().UpdateTepTin(attachFile, out oldFilePath);
            //    if (string.IsNullOrEmpty(path) == false && string.IsNullOrEmpty(tenfile) == false && string.IsNullOrEmpty(oldFilePath) == false)
            //    {
            //        FileInfo f = new FileInfo(Server.MapPath(oldFilePath));
            //        if (f.Exists)
            //        {
            //            f.Delete();
            //        }
            //    }
            //    wdAttachFile.Hide();
            //}
            //else
            //{
            //    new HoSoController().InsertTepTin(attachFile);
            //    if (e.ExtraParams["Close"] == "True")
            //    {
            //        wdAttachFile.Hide();
            //    }
            //}
            ////grp_NhanSu_NhapHoSoNhanSu.CallScriptUsingResourceManager("#{grpTepTinDinhKemStore}.reload();");
            //grpTepTinDinhKem.Reload();
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }

    protected void btnUpdateThuTuc_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DAL.ThuTucDauVao thutuc = new ThuTucDauVao()
            {
                CreatedBy = CurrentUser.ID,
                CreatedDate = DateTime.Now,
                TenThuTuc = txtTenThuTuc.Text,
                HoanThanh = chbHoanThanh.Checked
            };
            if (e.ExtraParams["Command"] == "Update")
            {
                thutuc.ID = int.Parse(RowSelectionModelTepTinDinhKem.SelectedRecordID);
                new HoSoController().UpdateThuTucDauVao(thutuc);
                wdThuTucDauVao.Hide();
            }
            else
            {
                new HoSoController().InsertThuTuc(thutuc);
                if (e.ExtraParams["Close"] == "True")
                {
                    wdAttachFile.Hide();
                }
            }
            grpTepTinDinhKem.Reload();
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }
    protected void btnDownloadAttachFile_Click(object sender, DirectEventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(e.ExtraParams["AttachFile"]))
            {
                Dialog.ShowNotification("Không có tệp tin đính kèm");
                return;
            }
            string serverPath = Server.MapPath(e.ExtraParams["AttachFile"]);
            //Dialog.ShowError(serverPath);
            if (Util.GetInstance().FileIsExists(serverPath) == false)
            {
                Dialog.ShowNotification("Tệp tin không tồn tại hoặc đã bị xóa !");
                return;
            }
            Response.Clear();
            //  Response.ContentType = "application/octet-stream";

            Response.AddHeader("Content-Disposition", "attachment; filename=" + e.ExtraParams["AttachFile"].Replace(" ", "_"));
            Response.WriteFile(serverPath);
            Response.End();
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }

    protected void Update_Click(object sender, DirectEventArgs e)
    {
        try
        {
            HOSO_UNGVIEN_KINHNGHIEMLAMVIECController kingnghiemlamviec = new HOSO_UNGVIEN_KINHNGHIEMLAMVIECController();
            DAL.HOSO_UNGVIEN_KINHNGHIEMLAMVIEC kinhnghiem = new HOSO_UNGVIEN_KINHNGHIEMLAMVIEC()
            {
                FR_KEY = decimal.Parse(hdfRecordID.Text),
                NoiLamViec = txt_noilamviec.Text,
                KinhNghiemDatDuoc = txtThanhTichTrongCongViec.Text,
                LyDoThoiViec = txtLyDoThoiViec.Text,
                MucLuong = decimal.Parse("0" + nbfMucLuong.Text),
                GhiChu = txtGhiChuKinhNghiemLamViec.Text,
                ViTriCongViec = txt_vitriconviec.Text,
            };
            if (!SoftCore.Util.GetInstance().IsDateNull(dfKNLVTuNgay.SelectedDate))
                kinhnghiem.TuThangNam = dfKNLVTuNgay.SelectedDate;//txt_tuthangnam.Text; 
            if (!SoftCore.Util.GetInstance().IsDateNull(dfKNLVDenNgay.SelectedDate))
                kinhnghiem.DenThangNam = dfKNLVDenNgay.SelectedDate;//txt_denthangnam.Text; 
            kinhnghiem.CreatedUser = CurrentUser.ID;

            if (e.ExtraParams["Command"] == "Edit")
            {
                kinhnghiem.ID = int.Parse(RowSelectionModelKinhNghiemLamViec.SelectedRecordID);
                kingnghiemlamviec.Update(kinhnghiem);
                wdKinhNghiemLamViec.Hide();
                GridPanelKinhNghiemLamViec.Reload();
            }
            else
            {
                kingnghiemlamviec.Insert(kinhnghiem);
                if (e.ExtraParams["Close"] == "True")
                {
                    wdKinhNghiemLamViec.Hide();
                }
                GridPanelKinhNghiemLamViec.Reload();
            }
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }

    protected void btnUpdateBangCap_Click(object sender, DirectEventArgs e)
    {
        try
        {
            HOSO_BANGCAP_UNGVIENController hsbangcapuv = new HOSO_BANGCAP_UNGVIENController();
            DAL.HOSO_BANGCAP_UNGVIEN hsbangcap = new DAL.HOSO_BANGCAP_UNGVIEN();
            hsbangcap.KHOA = txt_khoa.Text;
            hsbangcap.MA_HT_DAOTAO = cbx_hinhthucdaotaobang.SelectedItem.Value;
            hsbangcap.MA_TRINHDO = cbx_trinhdobangcap.SelectedItem.Value;
            hsbangcap.MA_XEPLOAI = cbx_xeploaiBangCap.SelectedItem.Value;
            hsbangcap.USERNAME = CurrentUser.ID.ToString();
            hsbangcap.MA_TRUONG_DAOTAO = hdfMaTruongDaoTao.Text;//cbx_NoiDaoTaoBangCap.SelectedItem.Value;
            hsbangcap.FR_KEY = decimal.Parse(hdfRecordID.Text);
            if (!string.IsNullOrEmpty(hdfMaChuyenNganh.Text))
                hsbangcap.MA_CHUYENNGANH = hdfMaChuyenNganh.Text;//cbx_ChuyenNganhBangCap.SelectedItem.Value;
            hsbangcap.DA_TN = Chk_DaTotNghiep.Checked;
            if (!string.IsNullOrEmpty(txtNamNhanBang.Text))
                hsbangcap.NGAY_NHANBANG = new DateTime(int.Parse(txtNamNhanBang.Text), 1, 1);
            if (!string.IsNullOrEmpty(txtTuNam.Text))
                hsbangcap.TU_NGAY = new DateTime(int.Parse(txtTuNam.Text), 1, 1);
            //hsbangcap.TU_NGAY = df_ngaybatdauhoc.SelectedDate;
            if (!string.IsNullOrEmpty(txtDenNam.Text))
                hsbangcap.DEN_NGAY = new DateTime(int.Parse(txtDenNam.Text), 1, 1);
            //hsbangcap.DEN_NGAY = df_ngayketthuchoc.SelectedDate;
            hsbangcap.DATE_CREATE = DateTime.Now;
            if (e.ExtraParams["Command"] == "Edit")
            {
                hsbangcap.ID = int.Parse(RowSelectionModel_BangCap.SelectedRecordID);
                hsbangcapuv.Update(hsbangcap);
                wdAddBangCap.Hide();
            }
            else
            {
                hsbangcapuv.Insert(hsbangcap);
                if (e.ExtraParams["Close"] == "True")
                {
                    wdAddBangCap.Hide();
                }
            }
            GridPanel_BangCap.Reload();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo", ex.Message.ToString());
        }
    }

    protected void btnUpdateTaiNan_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DAL.HOSO_TAINANLAODONG taiNan = new HOSO_TAINANLAODONG()
            {
                BOI_THUONG = TaiNan_txtBoiThuong.Text.Trim(),
                DIA_DIEM = TaiNan_txtDiaDiemXayRa.Text.Trim(),
                GHI_CHU = TaiNan_txtGhiChu.Text.Trim(),
                LY_DO = TaiNan_txtLydo.Text.Trim(),
                //   NGAY_XAY_RA = TaiNan_dfNgayXayRa.SelectedDate,
                FR_KEY = decimal.Parse(hdfRecordID.Text),
                THIET_HAI = TaiNan_txtThietHai.Text.Trim(),
                THUONG_TAT = TaiNan_txtThuongTat.Text.Trim(),
                CreatedBy = CurrentUser.ID,
                CreatedDate = DateTime.Now
            };
            if (!SoftCore.Util.GetInstance().IsDateNull(TaiNan_txtNgayBoiThuong.SelectedDate))
            {
                taiNan.NgayBoiThuong = TaiNan_txtNgayBoiThuong.SelectedDate;
            }
            if (!SoftCore.Util.GetInstance().IsDateNull(TaiNan_dfNgayXayRa.SelectedDate))
            {
                taiNan.NGAY_XAY_RA = TaiNan_dfNgayXayRa.SelectedDate;
            }
            if (e.ExtraParams["Command"] == "Update")
            {
                taiNan.ID = int.Parse(RowSelectionModelTaiNanLaoDong.SelectedRecordID);
                new HoSoController().UpdateTaiNanLaoDong(taiNan, CurrentUser.ID);
            }
            else
            {
                new HoSoController().InsertTaiNanLaoDong(taiNan);
            }
            if (e.ExtraParams["Close"] == "True")
            {
                wdTaiNanLaoDong.Hide();
            }

            //grp_NhanSu_NhapHoSoNhanSu.CallScriptUsingResourceManager("#{StoreTaiNanLaoDong}.reload();");
            GridPanelTaiNanLaoDong.Reload();
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }

    protected void btnUpdateChungChi_Click(object sender, DirectEventArgs e)
    {
        try
        {
            HOSO_UNGVIEN_CHUNGCHIController ctrol = new HOSO_UNGVIEN_CHUNGCHIController();
            DAL.HOSO_UNGVIEN_CHUNGCHI hschungchi = new HOSO_UNGVIEN_CHUNGCHI();
            hschungchi.MaChungChi = cbx_tenchungchi.SelectedItem.Value;
            if (df_NgayCap.SelectedDate.ToString().Contains("0001") == false)
            {
                hschungchi.NgayCap = df_NgayCap.SelectedDate;// DateTime.Parse(df_NgayCap.Value.ToString());
            }
            if (df_NgayHetHan.SelectedDate.ToString().Contains("0001") == false)
            {
                hschungchi.NgayHetHan = df_NgayHetHan.SelectedDate;// DateTime.Parse(df_NgayHetHan.Value.ToString());
            }
            hschungchi.NoiDaoTao = cbx_NoiDaoTao.Text;
            hschungchi.MA_XEPLOAI = cbx_XepLoaiChungChi.SelectedItem.Value;
            hschungchi.FR_KEY_HOSO = decimal.Parse(hdfRecordID.Text);
            hschungchi.GhiChu = txtGhiChuChungChi.Text;
            if (e.ExtraParams["Command"] == "Edit")
            {
                hschungchi.ID = int.Parse(RowSelectionModel_ChungChi.SelectedRecordID);
                ctrol.Update(hschungchi);
                wdAddChungChi.Hide();
            }
            else
            {
                ctrol.Insert(hschungchi);
                if (e.ExtraParams["Close"] == "True")
                {
                    wdAddChungChi.Hide();
                }
            }
            GridPanel_ChungChi.Reload();
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }
    #endregion

    /// <summary>
    /// Xóa các bản ghi trên Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void HandleChangesDelete(object sender, BeforeStoreChangedEventArgs e)
    {
        string deleted = e.DataHandler.JsonData;
        string prkey = deleted.Remove(deleted.IndexOf(','));
        prkey = prkey.Substring(prkey.LastIndexOf(':') + 1);
        Ext.Net.Store store = sender as Ext.Net.Store;
        switch (store.ID)
        {
            case "StoreHoSoTuyenDung":
                DataHandler.GetInstance().ExecuteNonQuery("delete from HOSO_TUYENDUNG where PR_KEY = " + prkey);
                break;
            case "StoreBaoHiem":
                DataHandler.GetInstance().ExecuteNonQuery("delete from HOSO_BAOHIEM where PR_KEY = " + prkey);
                break;
            case "StoreHopDong":
                DataHandler.GetInstance().ExecuteNonQuery("delete from HOSO_HOPDONG where PR_KEY = " + prkey);
                break;
            case "StoreDaiBieu":
                DataHandler.GetInstance().ExecuteNonQuery("delete from HOSO_DAIBIEU where PR_KEY = " + prkey);
                break;
            case "StoreDienBienLuong":
                DataHandler.GetInstance().ExecuteNonQuery("delete from HOSO_DB_LUONG where PR_KEY = " + prkey);
                break;
            case "StoreDetai":
                DataHandler.GetInstance().ExecuteNonQuery("delete from HOSO_DETAI where PR_KEY = " + prkey);
                break;
            case "StoreKhaNang":
                DataHandler.GetInstance().ExecuteNonQuery("delete from HOSO_KHANANG where PR_KEY = " + prkey);
                break;
            case "StoreKhenThuong":
                DataHandler.GetInstance().ExecuteNonQuery("delete from HOSO_KHENTHUONG where PR_KEY = " + prkey);
                break;
            case "StoreKyLuat":
                DataHandler.GetInstance().ExecuteNonQuery("delete from HOSO_KYLUAT where PR_KEY = " + prkey);
                break;
            case "StoreQHGD":
                DataHandler.GetInstance().ExecuteNonQuery("delete from HOSO_QH_GIADINH where PR_KEY = " + prkey);
                break;
            case "StoreQuaTrinhCongTac":
                DataHandler.GetInstance().ExecuteNonQuery("delete from HOSO_QT_CTAC where PR_KEY = " + prkey);
                break;
            case "StoreQuaTrinhDieuChuyen":
                DataHandler.GetInstance().ExecuteNonQuery("delete from HOSO_QT_DIEUCHUYEN where PR_KEY = " + prkey);
                break;
            case "StoreTaiSan":
                DataHandler.GetInstance().ExecuteNonQuery("delete from HOSO_TAISAN where PR_KEY = " + prkey);
                break;
            case "StoreTaiNanLaoDong":
                DataHandler.GetInstance().ExecuteNonQuery("delete from HOSO_TAINANLAODONG where ID = " + RowSelectionModelTaiNanLaoDong.SelectedRecordID);
                break;
            case "StoreThuTucDauVao":
                DataHandler.GetInstance().ExecuteNonQuery("delete from ThuTucDauVao where ID = " + RowSelectionThuTuc.SelectedRecordID);
                break;
            case "Store_BangCapChungChi":
                DataHandler.GetInstance().ExecuteNonQuery("delete from HOSO_UNGVIEN_CHUNGCHI where ID = " + RowSelectionModel_ChungChi.SelectedRecordID);
                break;
            case "grpTepTinDinhKemStore":
                try
                {
                    HoSoController hsController = new HoSoController();
                    FileInfo f = null;
                    string linkFile = string.Empty;
                    hsController.DeleteTepTin(int.Parse(RowSelectionModelTepTinDinhKem.SelectedRecordID), out linkFile);
                    if (!string.IsNullOrEmpty(linkFile))
                    {
                        f = new FileInfo(Server.MapPath(linkFile));
                        if (f.Exists)
                        {
                            f.Delete();
                        }
                    }
                }
                catch (Exception ex)
                {
                    ExtMessage.Dialog.ShowError(ex.Message);
                }
                break;
            case "StoreKinhNghiemLamViec":
                DataHandler.GetInstance().ExecuteNonQuery("delete from HOSO_UNGVIEN_KINHNGHIEMLAMVIEC where ID = " + RowSelectionModelKinhNghiemLamViec.SelectedRecordID);
                break;
            case "Store_BangCap":
                DataHandler.GetInstance().ExecuteNonQuery("delete from HOSO_BANGCAP_UNGVIEN where ID = " + RowSelectionModel_BangCap.SelectedRecordID);
                break;
            //case "StoregrpATM":
            //    DataHandler.GetInstance().ExecuteNonQuery("delete from HOSO_ATM where ID = " + RowSelectionModelATM.SelectedRecordID);
            //    break;
        }
        btnDeleteRecord.Disabled = true;
        btnEditRecord.Disabled = true;
    }

    #region Các hàm xử lý sự kiện sửa
    [DirectMethod]
    public void GetDataForBaoHiem()
    {
        string id = RowSelectionModelBaoHiem.SelectedRecordID;
        if (id == "")
        {
            X.Msg.Alert("Thông báo", "Bạn chưa chọn bản ghi nào").Show();
        }
        else
        {
            DAL.HOSO_BAOHIEM baohiem = new HoSoController().GetBaoHiem(decimal.Parse(id));
            txtBHDonVi.Text = baohiem.DON_VI;
            cbBHCongViec.SelectedItem.Value = baohiem.MA_CONGVIEC;
            if (baohiem.TU_NGAY != null && !baohiem.TU_NGAY.ToString().Contains("0001"))
                dfBHTuNgay.SelectedDate = DateTime.Parse(baohiem.TU_NGAY);
            if (baohiem.DEN_NGAY != null && !baohiem.DEN_NGAY.ToString().Contains("0001"))
                dfBHDenNgay.SelectedDate = DateTime.Parse(baohiem.DEN_NGAY);
            txtBHPhuCap.Text = baohiem.PHUCAP.ToString();
            txtBHMucLuong.Text = baohiem.MUC_LUONG.ToString();
            txtBHHSLuong.Text = baohiem.HS_LUONG.ToString().Replace(",", ".");
            txtBHGhiChu.Text = baohiem.GHI_CHU;
            txtBHTyle.Text = baohiem.TYLE;
            wdBaoHiem.Show();
        }
    }

    [DirectMethod]
    public void GetDataForDaiBieu()
    {
        string id = RowSelectionModelDaiBieu.SelectedRecordID;
        if (id == "")
        {
            X.Msg.Alert("Thông báo", "Bạn chưa chọn bản ghi nào").Show();
        }
        else
        {
            DAL.HOSO_DAIBIEU daibieu = new HoSoController().GetDaiBieu(decimal.Parse(id));
            txtDBLoaiHinh.Text = daibieu.LOAI_HINH;
            txtDBNhiemKy.Text = daibieu.NHIEM_KY;
            if (daibieu.TU_NGAY != null && !daibieu.TU_NGAY.Contains("0001"))
                dfDBTuNgay.SelectedDate = DateTime.Parse(daibieu.TU_NGAY);
            if (daibieu.DEN_NGAY != null && !daibieu.DEN_NGAY.Contains("0001"))
                dfDBDenNgay.SelectedDate = DateTime.Parse(daibieu.DEN_NGAY);
            txtDBGhiChu.Text = daibieu.GHI_CHU;
            wdDaiBieu.Show();
        }
    }

    [DirectMethod]
    public void GetDataForDeTai()
    {
        string id = RowSelectionModelDeTai.SelectedRecordID;
        if (id == "")
        {
            X.Msg.Alert("Thông báo", "Bạn chưa chọn bản ghi nào").Show();
        }
        else
        {
            DAL.HOSO_DETAI detai = new HoSoController().GetDeTai(decimal.Parse(id));
            txtMaDeTai.Text = detai.MaDeTai;
            txtDeTaiTenDeTai.Text = detai.TEN_DETAI;
            txtDeTaiCapDeTai.Text = detai.CAP_DETAI;
            txtDeTaiChuNhiemDeTai.Text = detai.CHUNHIEM_DETAI;
            txtDeTaiDenNgay.Text = detai.DEN_NGAY;
            txtDeTaiTuNgay.Text = detai.TU_NGAY;
            txtDeTaiKetQua.Text = detai.KET_QUA;
            txtDeTaiGhiChu.Text = detai.GHI_CHU;
            txDeTaiTuCachThamGia.Text = detai.TUCACH_THAMGIA;
            if (!string.IsNullOrEmpty(detai.TepTinDinhKem))
            {
                int pos = detai.TepTinDinhKem.LastIndexOf('/');
                if (pos != -1)
                {
                    string tenTT = detai.TepTinDinhKem.Substring(pos + 1);
                    fufDeTaiTepTinDinhKem.Text = tenTT;
                }
                hdfDeTaiTepTinDinhKem.Text = detai.TepTinDinhKem;
            }
            wdDeTai.Show();
        }
    }

    [DirectMethod]
    public void GetDataForHopDong()
    {
        string id = RowSelectionModelHopDong.SelectedRecordID;
        if (id == "")
        {
            X.Msg.Alert("Thông báo", "Bạn chưa chọn bản ghi nào").Show();
        }
        else
        {
            DAL.HOSO_HOPDONG hopdong = new HoSoController().GetHopDong(decimal.Parse(id));
            txtHopDongSoHopDong.Text = hopdong.SO_HDONG;
            cbHopDongLoaiHopDong.SetValue(hopdong.MA_LOAI_HDONG);
            hdfMaHopDongOld.Text = hopdong.MA_LOAI_HDONG;
            hdfTinhTrangHopDong.Text = hopdong.MA_TT_HDONG;
            cbHopDongTinhTrangHopDong.SetValue(new HoSoController().GetTenByMa(hopdong.MA_TT_HDONG));
            hdfViTriCongViec.SetValue(hopdong.MA_CONGVIEC);
            DAL.DM_CONGVIEC cv = new DM_CONGVIECController().GetByMaCV(hopdong.MA_CONGVIEC);
            if (cv != null)
            {
                cbx_congviec.Text = cv.TEN_CONGVIEC;
            }
            if (hopdong.NGAYKT_HDONG != null && !hopdong.NGAYKT_HDONG.ToString().Contains("0001"))
                dfHopDongNgayKiKet.SetValue(hopdong.NGAYKT_HDONG);
            if (hopdong.NGAY_HDONG != null && !hopdong.NGAY_HDONG.ToString().Contains("0001"))
                dfHopDongNgayHopDong.SetValue(hopdong.NGAY_HDONG);
            if (hopdong.NgayCoHieuLuc != null && !hopdong.NgayCoHieuLuc.ToString().Contains("0001"))
                dfNgayCoHieuLuc.SetValue(hopdong.NgayCoHieuLuc);
            if (hopdong.PrkeyNguoiDaiDienKyHD != null)
            {
                HOSO tmp = new HoSoController().GetByPrKey(hopdong.PrkeyNguoiDaiDienKyHD.Value);
                if (tmp != null)
                {
                    tgf_NguoiKyHD.Text = tmp.HO_TEN;
                    hdfPrkeyNguoiKyHD.Text = hopdong.PrkeyNguoiDaiDienKyHD.ToString();
                }
            }
            cbx_HopDongChucVu.SetValue(hopdong.MaChucVuNguoiKyHD);
            if (!string.IsNullOrEmpty(hopdong.TepTinDinhKem))
            {
                int pos = hopdong.TepTinDinhKem.LastIndexOf('/');
                if (pos != -1)
                {
                    string tenTT = hopdong.TepTinDinhKem.Substring(pos + 1);
                    fufHopDongTepTin.Text = tenTT;
                }
                hdfHopDongTepTinDK.Text = hopdong.TepTinDinhKem;
            }
            cbx_HopDongTrangThai.SetValue(hopdong.TrangThaiHopDong);
            txtHopDongGhiChu.Text = hopdong.GhiChu;
            wdHopDong.Show();
        }
    }

    [DirectMethod]
    public void GetDataForKhaNang()
    {
        string id = RowSelectionModelKhaNang.SelectedRecordID;
        if (id == "")
        {
            X.Msg.Alert("Thông báo", "Bạn chưa chọn bản ghi nào").Show();
        }
        else
        {
            DAL.HOSO_KHANANG khanang = new HoSoController().GetKhaNang(decimal.Parse(id));
            cbKhaNang.SelectedItem.Value = khanang.MA_KHANANG;
            cbKhaNangXepLoai.SelectedItem.Value = khanang.MA_XEPLOAI;
            txtKhaNangGhiChu.Text = khanang.GHI_CHU;
            wdKhaNang.Show();
        }
    }

    [DirectMethod]
    public void GetDataForKhenThuong()
    {
        string id = RowSelectionModelKhenThuong.SelectedRecordID;
        if (id == "")
        {
            X.Msg.Alert("Thông báo", "Bạn chưa chọn bản ghi nào").Show();
        }
        else
        {
            DAL.HOSO_KHENTHUONG khenthuong = new HoSoKhenThuongController().GetKhenThuong(decimal.Parse(id));
            txtKhenThuongSoQuyetDinh.Text = khenthuong.SO_QD;
            if (!SoftCore.Util.GetInstance().IsDateNull(khenthuong.NGAY_QD))
                dfKhenThuongNgayQuyetDinh.SetValue(khenthuong.NGAY_QD);
            cbHinhThucKhenThuong.SetValue(khenthuong.MA_HT_KTHUONG);
            cbLyDoKhenThuong.SetValue(khenthuong.LYDO_KTHUONG);
            txtKhenThuongSoTien.Text = khenthuong.SO_TIEN.ToString();
            txtKhenThuongGhiCHu.Text = khenthuong.GHI_CHU;
            nbfSoDiemKhenThuong.Text = khenthuong.SoDiem.ToString().Replace(",", ".");
            if (khenthuong.PrkeyNguoiQuyetDinh != null)
            {
                HOSO tmp = new HoSoController().GetByPrKey(khenthuong.PrkeyNguoiQuyetDinh.Value);
                if (tmp != null)
                {
                    tgf_KhenThuong_NguoiRaQD.Text = tmp.HO_TEN;
                    hdfKhenThuongNguoiQD.Text = khenthuong.PrkeyNguoiQuyetDinh.ToString();
                }
            }
            if (!string.IsNullOrEmpty(khenthuong.TepTinDinhKem))
            {
                int pos = khenthuong.TepTinDinhKem.LastIndexOf('/');
                if (pos != -1)
                {
                    string tenTT = khenthuong.TepTinDinhKem.Substring(pos + 1);
                    fufKhenThuongTepTinDinhKem.Text = tenTT;
                }
                hdfKhenThuongTepTinDinhKem.Text = khenthuong.TepTinDinhKem;
            }
            wdKhenThuong.Show();
        }
    }

    [DirectMethod]
    public void GetDataForKyLuat()
    {
        string id = RowSelectionModelKyLuat.SelectedRecordID;
        if (id == "")
        {
            X.Msg.Alert("Thông báo", "Bạn chưa chọn bản ghi nào").Show();
        }
        else
        {
            DAL.HOSO_KYLUAT kyluat = new HoSoKyLuatController().GetKyLuat(decimal.Parse(id));
            txtKyLuatSoQD.Text = kyluat.SO_QD;
            dfKyLuatNgayQuyetDinh.SelectedDate = kyluat.NGAY_QD.Value;
            cbLyDoKyLuat.SelectedItem.Value = kyluat.LYDO_KYLUAT;
            cbHinhThucKyLuat.SelectedItem.Value = kyluat.MA_HT_KYLUAT;
            txtKyLuatSoTien.Text = kyluat.SO_TIEN.ToString();
            txtKyLuatGhiChu.Text = kyluat.GHI_CHU;
            nbfSoDiem.Text = kyluat.SoDiem.ToString().Replace(",", ".");
            if (kyluat.PrkeyNguoiQuyetDinh != null)
            {
                HOSO tmp = new HoSoController().GetByPrKey(kyluat.PrkeyNguoiQuyetDinh.Value);
                if (tmp != null)
                {
                    tgfKyLuatNguoiQD.Text = tmp.HO_TEN;
                    hdfKyLuatNguoiQD.Text = kyluat.PrkeyNguoiQuyetDinh.ToString();
                }
            }
            if (!string.IsNullOrEmpty(kyluat.TepTinDinhKem))
            {
                int pos = kyluat.TepTinDinhKem.LastIndexOf('/');
                if (pos != -1)
                {
                    string tenTT = kyluat.TepTinDinhKem.Substring(pos + 1);
                    fufKyLuatTepTinDinhKem.Text = tenTT;
                }
                hdfKyLuatTepTinDinhKem.Text = kyluat.TepTinDinhKem;
            }
            wdKyLuat.Show();
        }
    }

    [DirectMethod]
    public void GetDataForQuanHeGiaDinh()
    {
        string id = RowSelectionModelQHGD.SelectedRecordID;
        if (id == "")
        {
            X.Msg.Alert("Thông báo", "Bạn chưa chọn bản ghi nào").Show();
        }
        else
        {
            DAL.HOSO_QH_GIADINH giadinh = new HoSoController().GetQuanHeGiaDinh(decimal.Parse(id));
            txtQHGDHoTen.Text = giadinh.HO_TEN;
            cbQHGDGioiTinh.SelectedItem.Value = giadinh.GIOI_TINH;
            //txtQHGDNamSinh.Text = giadinh.TUOI;
            txtQHGDNamSinh.SetValue(giadinh.TUOI);
            cbQuanHeGiaDinh.SelectedItem.Value = giadinh.MA_QUANHE;
            txtQHGDNgheNghiep.Text = giadinh.NGHE_NGHIEP;
            txtQHGDNoiLamViec.Text = giadinh.NOI_LAMVIEC;
            txtQHGDGhiChu.Text = giadinh.GHI_CHU;
            txtSoCMT.Text = giadinh.SoCMT;
            chkQHGDLaNguoiPhuThuoc.Checked = giadinh.LaNguoiPhuThuoc.HasValue ? giadinh.LaNguoiPhuThuoc.Value : false;
            if (chkQHGDLaNguoiPhuThuoc.Checked == true)
            {
                dfQHGDBatDauGiamTru.SetValue(giadinh.NgayBatDauGiamTru);
                dfQHGDKetThucGiamTru.SetValue(giadinh.NgayKetThucGiamTru);
            }
            wdQuanHeGiaDinh.Show();
        }
    }

    [DirectMethod]
    public void GetDataForQuaTrinhCongTac()
    {
        string id = RowSelectionModelQuaTrinhCongTac.SelectedRecordID;
        if (id == "")
        {
            X.Msg.Alert("Thông báo", "Bạn chưa chọn bản ghi nào").Show();
        }
        else
        {
            DAL.HOSO_QT_CTAC qtCongTac = new HOSO_QT_CTACController().GetQuaTrinhCongTac(decimal.Parse(id));
            txtQTCTSoQD.Text = qtCongTac.SoQuyetDinh;
            if (qtCongTac.PrkeyNguoiQuyetDinh != null)
            {
                HOSO hs = new HoSoController().GetByPrKey(qtCongTac.PrkeyNguoiQuyetDinh.Value);
                if (hs != null)
                {
                    hdfQTCTNguoiQuyetDinh.Text = hs.PR_KEY.ToString();
                    tgf_QTCTNguoiQuyetDinh.Text = hs.HO_TEN;
                }
            }
            dfQTCTNgayQuyetDinh.SetValue(qtCongTac.NgayQuyetDinh);
            dfQTCTNgayBatDau.SetValue(qtCongTac.ThoiGianBatDau);
            dfQTCTNgayKetThuc.SetValue(qtCongTac.ThoiGianKetThuc);
            txtQTCTNoiDungCongViec.Text = qtCongTac.NoiDungCongViec;
            txtQTCTDiaDiemCT.Text = qtCongTac.DiaDiemCongTac;
            txtQTCTNguoiLienQuan.Text = qtCongTac.NguoiLienQuan;
            cbCongTacQuocGia.SetValue(qtCongTac.MaQuocGia);
            txtQTCTDiaDiemCT.Text = qtCongTac.DiaDiemCongTac;
            if (!string.IsNullOrEmpty(qtCongTac.TepTinDinhKem))
            {
                int pos = qtCongTac.TepTinDinhKem.LastIndexOf('/');
                if (pos != -1)
                {
                    string tenTT = qtCongTac.TepTinDinhKem.Substring(pos + 1);
                    fufQTCTTepTinDinhKem.Text = tenTT;
                }
                hdfQTCTTepTinDinhKem.Text = qtCongTac.TepTinDinhKem;
            }
            txtCongTacGhiChu.Text = qtCongTac.GHI_CHU;
            wdQuaTrinhCongTac.Show();
        }
    }

    [DirectMethod]
    public void GetDataForQuaTrinhDieuChuyen()
    {
        string id = RowSelectionModelQuaTrinhDieuChuyen.SelectedRecordID;
        if (id == "")
        {
            X.Msg.Alert("Thông báo", "Bạn chưa chọn bản ghi nào").Show();
        }
        else
        {
            DAL.HOSO_QT_DIEUCHUYEN dieuchuyen = new HOSO_QT_DIEUCHUYENController().GetQuaTrinhDieuChuyen(decimal.Parse(id));
            txtQTDCSoQuyetDinh.Text = dieuchuyen.SoQuyetDinh;
            if (dieuchuyen.PrkeyNguoiQuyetDinh != null)
            {
                HOSO hs = new HoSoController().GetByPrKey(dieuchuyen.PrkeyNguoiQuyetDinh.Value);
                if (hs != null)
                {
                    hdfQTDCNguoiQuyetDinh.Text = hs.PR_KEY.ToString();
                    tgfQTDCNguoiQuyetDinh.Text = hs.HO_TEN;
                }
            }
            dfQTDCNgayQuyetDinh.SetValue(dieuchuyen.NgayQuyetDinh);
            dfQTDCNgayCoHieuLuc.SetValue(dieuchuyen.NgayCoHieuLuc);
            dfQTDCNgayHetHieuLuc.SetValue(dieuchuyen.NgayHetHieuLuc);
            hdfQTDCBoPhanMoi.Text = dieuchuyen.MaBoPhanMoi;
            if (!string.IsNullOrEmpty(dieuchuyen.MaBoPhanMoi))
            {
                cbxQTDCBoPhanMoi.SetValue(new DM_DONVIController().GetNameById(dieuchuyen.MaBoPhanMoi)); 
            }
            hdfQTDCChucVuMoi.Text = dieuchuyen.MaChucVuMoi;
            if (!string.IsNullOrEmpty(dieuchuyen.MaChucVuMoi))
            {
                cbxQTDCChucVuMoi.SetValue(new DM_CHUCVUController().GetNameById(dieuchuyen.MaBoPhanMoi)); 
            }
            if (!string.IsNullOrEmpty(dieuchuyen.MaCongViecMoi))
            {
                cbxCongViecMoi.SetValue(new DM_CONGVIECController().GetNameById(dieuchuyen.MaCongViecMoi)); 
            }
            if (!string.IsNullOrEmpty(dieuchuyen.TepTinDinhKem))
            {
                int pos = dieuchuyen.TepTinDinhKem.LastIndexOf('/');
                if (pos != -1)
                {
                    string tenTT = dieuchuyen.TepTinDinhKem.Substring(pos + 1);
                    fufQTDCTepTinDinhKem.Text = tenTT;
                }
                hdfQTDCTepTinDinhKem.Text = dieuchuyen.TepTinDinhKem;
            }
            txtDieuChuyenGhiChu.Text = dieuchuyen.GhiChu;
            wdQuaTrinhDieuChuyen.Show();
        }
    }

    [DirectMethod]
    public void GetDataForTaiSan()
    {
        string id = RowSelectionModelTaiSan.SelectedRecordID;
        if (id == "")
        {
            X.Msg.Alert("Thông báo", "Bạn chưa chọn bản ghi nào").Show();
        }
        else
        {
            DAL.HOSO_TAISAN taisan = new HoSoController().GetTaiSan(decimal.Parse(id));
            cbTaiSan.SelectedItem.Value = taisan.MA_VTHH;
            txtTaiSanSoLuong.SetValue(taisan.SoLuong);
            hdfDonViTinh.SetValue(taisan.MaDonViTinh);
            cbxDonViTinh.SetValue(taisan.MaDonViTinh);
            if (taisan.NGAY_NHAN != null)
                tsDateField.SelectedDate = taisan.NGAY_NHAN.Value;
            tsTxtinhTrang.Text = taisan.TINH_TRANG;
            tsGhiChu.Text = taisan.GHI_CHU;
            wdAddTaiSan.Show();
        }
    }

    [DirectMethod]
    public void GetDataForChungChi()
    {
        try
        {
            string id = RowSelectionModel_ChungChi.SelectedRecordID;
            if (id == "")
            {
                X.Msg.Alert("Thông báo", "Bạn chưa chọn bản ghi nào").Show();
            }
            else
            {
                DAL.HOSO_UNGVIEN_CHUNGCHI chungChi = new DM_CHUNGCHIController().GetById(int.Parse(id));
                if (chungChi == null)
                {
                    return;
                }
                cbx_tenchungchi.SetValue(chungChi.MaChungChi);
                cbx_NoiDaoTao.Text = chungChi.NoiDaoTao;
                if (chungChi.NgayCap.HasValue && chungChi.NgayCap.Value.ToString().Contains("0001") == false)
                {
                    df_NgayCap.SelectedDate = chungChi.NgayCap.Value;
                }
                cbx_XepLoaiChungChi.SetValue(chungChi.MA_XEPLOAI);
                txtGhiChuChungChi.Text = chungChi.GhiChu;
                if (chungChi.NgayHetHan.HasValue && chungChi.NgayHetHan.Value.ToString().Contains("0001") == false)
                {
                    df_NgayHetHan.SelectedDate = chungChi.NgayHetHan.Value;
                }
                wdAddChungChi.Show();
            }
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }

    [DirectMethod]
    public void GetDataForTaiNan()
    {
        try
        {
            string id = RowSelectionModelTaiNanLaoDong.SelectedRecordID;
            if (id == "")
            {
                X.Msg.Alert("Thông báo", "Bạn chưa chọn bản ghi nào").Show();
            }
            else
            {
                DAL.HOSO_TAINANLAODONG taiNan = new HoSoController().getTaiNan(int.Parse(id));
                if (taiNan.NGAY_XAY_RA.HasValue)
                {
                    TaiNan_dfNgayXayRa.SelectedDate = taiNan.NGAY_XAY_RA.Value;
                }
                if (taiNan.NgayBoiThuong.HasValue)
                {
                    TaiNan_txtNgayBoiThuong.SelectedDate = taiNan.NgayBoiThuong.Value;
                }
                TaiNan_txtBoiThuong.Text = taiNan.BOI_THUONG;
                TaiNan_txtDiaDiemXayRa.Text = taiNan.DIA_DIEM;
                TaiNan_txtGhiChu.Text = taiNan.GHI_CHU;
                TaiNan_txtLydo.Text = taiNan.LY_DO;
                TaiNan_txtThietHai.Text = taiNan.THIET_HAI;
                TaiNan_txtThuongTat.Text = taiNan.THUONG_TAT;
                wdTaiNanLaoDong.Show();
            }
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }
    [DirectMethod]
    public void GetDataForThuTuc()
    {
        try
        {
            string id = RowSelectionThuTuc.SelectedRecordID;
            if (id == "")
            {
                X.Msg.Alert("Thông báo", "Bạn chưa chọn bản ghi nào").Show();
            }
            else
            {
                DAL.ThuTucDauVao thutuc = new HoSoController().getThuTuc(int.Parse(id));
                txtTenThuTuc.Text = thutuc.TenThuTuc;
                chbHoanThanh.SetValue(thutuc.HoanThanh);
                wdThuTucDauVao.Show();
            }
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }

    [DirectMethod]
    public void GetDataForTepTin()
    {
        string id = RowSelectionModelTepTinDinhKem.SelectedRecordID;
        if (id == "")
        {
            X.Msg.Alert("Thông báo", "Bạn chưa chọn bản ghi nào").Show();
        }
        else
        {
            DAL.HOSO_TepTinDinhKem teptin = new HoSoController().GetTepTin(int.Parse(id));
            if (teptin == null)
            {
                return;
            }
            txtFileName.Text = teptin.TenTepTin;
            hdfDinhKem.Text = teptin.Link;
            file_cv.Text = new CommonUtil().GetFileName(teptin.Link);
            //file_cv.Disabled = true;
            txtGhiChu.Text = teptin.GhiChu;
            wdAttachFile.Show();
        }
    }

    [DirectMethod]
    public void GetDataForKinhNghiemLamViec()
    {
        string id = RowSelectionModelKinhNghiemLamViec.SelectedRecordID;
        if (id == "")
        {
            X.Msg.Alert("Thông báo", "Bạn chưa chọn bản ghi nào").Show();
        }
        else
        {
            DAL.HOSO_UNGVIEN_KINHNGHIEMLAMVIEC knlv = new HoSoController().GetKinhNghiemLamViec(int.Parse(id));
            if (knlv == null)
            {
                return;
            }
            txt_noilamviec.Text = knlv.NoiLamViec;
            txt_vitriconviec.Text = knlv.ViTriCongViec;
            txtLyDoThoiViec.Text = knlv.LyDoThoiViec;
            nbfMucLuong.Value = knlv.MucLuong;
            txtGhiChuKinhNghiemLamViec.Text = knlv.GhiChu;
            if (!SoftCore.Util.GetInstance().IsDateNull(knlv.TuThangNam))
                dfKNLVTuNgay.SetValue(knlv.TuThangNam);
            if (!SoftCore.Util.GetInstance().IsDateNull(knlv.DenThangNam))
                dfKNLVDenNgay.SetValue(knlv.DenThangNam);
            txtThanhTichTrongCongViec.Text = knlv.KinhNghiemDatDuoc;
            wdKinhNghiemLamViec.Show();
        }
    }

    [DirectMethod]
    public void GetDataForQuaTrinhHocTap()
    {
        try
        {
            string id = RowSelectionModel_BangCap.SelectedRecordID;
            if (id == "")
            {
                X.Msg.Alert("Thông báo", "Bạn chưa chọn bản ghi nào").Show();
            }
            else
            {
                DAL.HOSO_BANGCAP_UNGVIEN bangcap = new HoSoController().getQuaTrinhHocTap(int.Parse(id));
                if (bangcap.MA_TRUONG_DAOTAO != null)
                {
                    cbx_NoiDaoTaoBangCap.Text = bangcap.DM_TRUONG_DAOTAO.TEN_TRUONG_DAOTAO;
                    hdfMaTruongDaoTao.Text = bangcap.MA_TRUONG_DAOTAO;
                }
                cbx_hinhthucdaotaobang.SetValue(bangcap.MA_HT_DAOTAO);
                txt_khoa.Text = bangcap.KHOA;
                if (bangcap.TU_NGAY.HasValue && bangcap.TU_NGAY.Value.ToString().Contains("0001") == false)
                {
                    //df_ngaybatdauhoc.SelectedDate = bangcap.TU_NGAY.Value;
                    txtTuNam.Text = bangcap.TU_NGAY.Value.Year.ToString();
                }
                Chk_DaTotNghiep.Checked = bangcap.DA_TN.Value;
                if (bangcap.MA_CHUYENNGANH != null)
                {
                    cbx_ChuyenNganhBangCap.Text = bangcap.DM_CHUYENNGANH.TEN_CHUYENNGANH;
                    hdfMaChuyenNganh.Text = bangcap.MA_CHUYENNGANH;
                }
                cbx_trinhdobangcap.SetValue(bangcap.MA_TRINHDO);
                cbx_xeploaiBangCap.SetValue(bangcap.MA_XEPLOAI);
                if (bangcap.DEN_NGAY.HasValue && bangcap.DEN_NGAY.Value.ToString().Contains("0001") == false)
                {
                    //df_ngayketthuchoc.SelectedDate = bangcap.DEN_NGAY.Value;
                    txtDenNam.Text = bangcap.DEN_NGAY.Value.Year.ToString();
                }
                if (bangcap.NGAY_NHANBANG.HasValue && !bangcap.NGAY_NHANBANG.Value.ToString().Contains("0001"))
                    txtNamNhanBang.SetValue(bangcap.NGAY_NHANBANG.Value.Year);
                wdAddBangCap.Show();
            }
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }
    #endregion

    [DirectMethod]
    public void SetNgayHetHD()
    {
        string ma_hd = cbHopDongLoaiHopDong.SelectedItem != null ? cbHopDongLoaiHopDong.SelectedItem.Value : "";
        if (ma_hd != "" && !dfNgayCoHieuLuc.SelectedDate.ToString().Contains("0001"))
        {
            string month = new DM_LOAI_HDONGController().GetMonth(ma_hd);
            int mont = int.Parse("0" + month);
            if (mont > 0)
            {
                DateTime ngay_bd = dfNgayCoHieuLuc.SelectedDate;
                ngay_bd = ngay_bd.AddMonths(mont);
                ngay_bd = ngay_bd.AddDays(-1);

                dfHopDongNgayKiKet.SetValue(ngay_bd);
            }
        }
    }

    [DirectMethod]
    public void DeleteDonViTinh(string maDVT)
    {
        try
        {
            new DanhMucDonViTinhController().Delete(maDVT);
            hdfMaDonViTinh.Text = "";
        }
        catch (Exception ex)
        {
            if (ex.Message.ToString().Contains("FK_HOSO_TAISAN_DM_DVT"))
            {
                X.Msg.Alert("Thông báo từ hệ thống", "Đơn vị tính đang được sử dụng. Bạn không được phép xóa").Show();
            }
        }
    }

    [DirectMethod]
    public void SaveDonViTinh(string maDVT, string tenDVT, string ghiChu)
    {
        try
        {
            DanhMucDonViTinhController controller = new DanhMucDonViTinhController();
            DAL.DM_DVT dvt = new DAL.DM_DVT()
            {
                MA_DVT = maDVT,
                TEN_DVT = tenDVT,
                GHI_CHU = ghiChu,
                MA_DONVI = Session["MaDonVi"].ToString(),
                USERNAME = CurrentUser.ID.ToString(),
                DATE_CREATE = DateTime.Now,
            };
            if (hdfMaDonViTinh.Text != "")
            {
                string maDonViTinh = hdfMaDonViTinh.Text;
                dvt.MA_DVT = maDonViTinh;
                controller.Update(dvt);
            }
            else
            {
                controller.Insert(dvt);
            }
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Thông báo lỗi", ex.Message).Show();
        }
    }

    protected void grpDonViTinh_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        grpDonViTinh_Store.DataSource = new DanhMucDonViTinhController().GetByAll();
        grpDonViTinh_Store.DataBind();
    }
}