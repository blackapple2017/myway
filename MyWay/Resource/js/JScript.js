var AddRecordClick = function (idTab) {
    var tabTitle = idTab.getActiveTab().id;
    switch (tabTitle) {
        case "SouthHoSoNhanSu1_panelHoSoTuyenDung":
            SouthHoSoNhanSu1_StoreHoSoTuyenDung.reload();
            break;
        case "SouthHoSoNhanSu1_panelQuaTrinhDaoTao":
            SouthHoSoNhanSu1_wdQuaTrinhDaoTao.show();
            break;
        case "SouthHoSoNhanSu1_panelBaoHiem":
            SouthHoSoNhanSu1_wdBaoHiem.show();
            break;
        case "SouthHoSoNhanSu1_panelDaiBieu":
            SouthHoSoNhanSu1_wdDaiBieu.show();
            break;
        case "SouthHoSoNhanSu1_panelDeTai":
            SouthHoSoNhanSu1_wdDeTai.show();
            break;
        case "SouthHoSoNhanSu1_panelHopDong":
            SouthHoSoNhanSu1_wdHopDong.show();
            SouthHoSoNhanSu1_hdfTypeWindow.setValue('HopDong');
            break;
        case "SouthHoSoNhanSu1_panelKhaNang":
            SouthHoSoNhanSu1_wdKhaNang.show();
            break;
        case "SouthHoSoNhanSu1_panelDienBienLuong":
            SouthHoSoNhanSu1_wdDienBienLuong.show();
            break;
        case "SouthHoSoNhanSu1_panelKhenThuong":
            SouthHoSoNhanSu1_wdKhenThuong.show();
            SouthHoSoNhanSu1_hdfTypeWindow.setValue('KhenThuong');
            break;
        case "SouthHoSoNhanSu1_panelKiLuat":
            SouthHoSoNhanSu1_wdKyLuat.show();
            SouthHoSoNhanSu1_hdfTypeWindow.setValue('KyLuat');
            break;
        case "SouthHoSoNhanSu1_panelQuanHeGiaDinh":
            SouthHoSoNhanSu1_wdQuanHeGiaDinh.show();
            break;
        case "SouthHoSoNhanSu1_panelQuaTrinhCongTac":
            SouthHoSoNhanSu1_wdQuaTrinhCongTac.show();
            SouthHoSoNhanSu1_hdfTypeWindow.setValue('QTCT');
            break;
        case "SouthHoSoNhanSu1_panelQuaTrinhDieuChuyen":
            SouthHoSoNhanSu1_wdQuaTrinhDieuChuyen.show();
            SouthHoSoNhanSu1_hdfTypeWindow.setValue('QTDC');
            break;
        case "SouthHoSoNhanSu1_panelTaiSan":
            SouthHoSoNhanSu1_wdAddTaiSan.show();
            break;
        case "SouthHoSoNhanSu1_panelTepDinhKem":
            SouthHoSoNhanSu1_wdAttachFile.show();
            break;
        case "SouthHoSoNhanSu1_panelTaiNanLaoDong":
            SouthHoSoNhanSu1_wdTaiNanLaoDong.show();
            break;
        case "SouthHoSoNhanSu1_panelBangCapChungChi":
            SouthHoSoNhanSu1_wdAddChungChi.show();
            break;
        case "SouthHoSoNhanSu1_panelKinhNghiemLamViec":
            SouthHoSoNhanSu1_wdKinhNghiemLamViec.show();
            break;
        case "SouthHoSoNhanSu1_panelQuaTrinhHocTap":
            SouthHoSoNhanSu1_wdAddBangCap.show();
            break;
        case "SouthHoSoNhanSu1_panelTheNganHang":
            SouthHoSoNhanSu1_wdTheNganHang.show();
            break;
    }
}

var DeleteRecordOnGrid = function () {
    var tabTitle = SouthHoSoNhanSu1_TabPanelBottom.getActiveTab().id;
    switch (tabTitle) {
        case "SouthHoSoNhanSu1_panelHoSoTuyenDung":
            DeleteRecordOnGrid2(SouthHoSoNhanSu1_GridPanelHoSoTuyenDung, SouthHoSoNhanSu1_StoreHoSoTuyenDung);
            break;
        case "SouthHoSoNhanSu1_panelQuaTrinhDaoTao":
            DeleteRecordOnGrid2(SouthHoSoNhanSu1_GridPanelQTDT, SouthHoSoNhanSu1_StoreQuaTrinhDaoTao);
            break;
        case "SouthHoSoNhanSu1_panelBaoHiem":
            DeleteRecordOnGrid2(SouthHoSoNhanSu1_GridPanelBaoHiem, SouthHoSoNhanSu1_StoreBaoHiem);
            break;
        case "SouthHoSoNhanSu1_panelDaiBieu":
            DeleteRecordOnGrid2(SouthHoSoNhanSu1_GridPanelDaiBieu, SouthHoSoNhanSu1_StoreDaiBieu);
            break;
        case "SouthHoSoNhanSu1_panelDeTai":
            DeleteRecordOnGrid2(SouthHoSoNhanSu1_GridPanelDetai, SouthHoSoNhanSu1_StoreDetai);
            break;
        case "SouthHoSoNhanSu1_panelHopDong":
            DeleteRecordOnGrid2(SouthHoSoNhanSu1_GridPanelHopDong, SouthHoSoNhanSu1_StoreHopDong);
            break;
        case "SouthHoSoNhanSu1_panelKhaNang":
            DeleteRecordOnGrid2(SouthHoSoNhanSu1_GridPanelKhaNang, SouthHoSoNhanSu1_StoreKhaNang);
            break;
        case "SouthHoSoNhanSu1_panelKhenThuong":
            DeleteRecordOnGrid2(SouthHoSoNhanSu1_GridPanelKhenThuong, SouthHoSoNhanSu1_StoreKhenThuong);
            break;
        case "SouthHoSoNhanSu1_panelKiLuat":
            DeleteRecordOnGrid2(SouthHoSoNhanSu1_GridPanelKyLuat, SouthHoSoNhanSu1_StoreKyLuat);
            break;
        case "SouthHoSoNhanSu1_panelQuanHeGiaDinh":
            DeleteRecordOnGrid2(SouthHoSoNhanSu1_GridPanelQHGD, SouthHoSoNhanSu1_StoreQHGD);
            break;
        case "SouthHoSoNhanSu1_panelQuaTrinhCongTac":
            DeleteRecordOnGrid2(SouthHoSoNhanSu1_GridPanelQuaTrinhCTAC, SouthHoSoNhanSu1_StoreQuaTrinhCongTac);
            break;
        case "SouthHoSoNhanSu1_panelQuaTrinhDieuChuyen":
            DeleteRecordOnGrid2(SouthHoSoNhanSu1_GridPanelQuaTrinhDieuChuyen, SouthHoSoNhanSu1_StoreQuaTrinhDieuChuyen);
            break;
        case "SouthHoSoNhanSu1_panelTaiSan":
            DeleteRecordOnGrid2(SouthHoSoNhanSu1_GridPanelTaiSan, SouthHoSoNhanSu1_StoreTaiSan);
            break;
        case "SouthHoSoNhanSu1_panelTaiNanLaoDong":
            DeleteRecordOnGrid2(SouthHoSoNhanSu1_GridPanelTaiNanLaoDong, SouthHoSoNhanSu1_StoreTaiNanLaoDong);
            break;
        case "SouthHoSoNhanSu1_panelBangCapChungChi":
            DeleteRecordOnGrid2(SouthHoSoNhanSu1_GridPanel_ChungChi, SouthHoSoNhanSu1_Store_BangCapChungChi);
            break;
        case "SouthHoSoNhanSu1_panelTepDinhKem":
            DeleteRecordOnGrid2(SouthHoSoNhanSu1_grpTepTinDinhKem, SouthHoSoNhanSu1_grpTepTinDinhKemStore);
            break;
        case "SouthHoSoNhanSu1_panelKinhNghiemLamViec":
            DeleteRecordOnGrid2(SouthHoSoNhanSu1_GridPanelKinhNghiemLamViec, SouthHoSoNhanSu1_StoreKinhNghiemLamViec);
            break;
        case "SouthHoSoNhanSu1_panelQuaTrinhHocTap":
            DeleteRecordOnGrid2(SouthHoSoNhanSu1_GridPanel_BangCap, SouthHoSoNhanSu1_Store_BangCap);
            break;
        case "SouthHoSoNhanSu1_panelTheNganHang":
            DeleteRecordOnGrid2(SouthHoSoNhanSu1_grpATM, SouthHoSoNhanSu1_StoregrpATM);
            break;
    }
}

var DeleteRecordOnGrid2 = function (grid, store) {
    Ext.Msg.confirm('Xác nhận', 'Bạn có chắc chắn muốn xóa không ?', function (btn) {
        if (btn == "yes") {
            try {
                grid.getRowEditor().stopEditing();
            } catch (e) {

            }
            var s = grid.getSelectionModel().getSelections();
            for (var i = 0, r; r = s[i]; i++) {
                store.remove(r);
                store.commitChanges();
            }
			grid.getSelectionModel().clearSelections();
        }
    });
}

var CopyRecord = function (DirectMethods) {
    var tabTitle = SouthHoSoNhanSu1_TabPanelBottom.getActiveTab().id;
    switch (tabTitle) {
        case "SouthHoSoNhanSu1_panelHoSoTuyenDung":
            DirectMethods.CopyRecord("Hồ sơ tuyển dụng");
            break;
        case "SouthHoSoNhanSu1_panelQuaTrinhDaoTao":
            DirectMethods.CopyRecord("Quá trình đào tạo");
            break;
        case "SouthHoSoNhanSu1_panelBaoHiem":
            DirectMethods.CopyRecord("Bảo hiểm");
            break;
        case "SouthHoSoNhanSu1_panelDaiBieu":
            DirectMethods.CopyRecord("Đại biểu");
            break;
        case "SouthHoSoNhanSu1_panelDeTai":
            DirectMethods.CopyRecord("Đề tài");
            break;
        case "SouthHoSoNhanSu1_panelHopDong":
            DirectMethods.CopyRecord("Hợp đồng");
            break;
        case "SouthHoSoNhanSu1_panelKhaNang":
            DirectMethods.CopyRecord("Khả năng");
            break;
        case "SouthHoSoNhanSu1_panelKhenThuong":
            DirectMethods.CopyRecord("Khen thưởng");
            break;
        case "SouthHoSoNhanSu1_panelKiLuat":
            DirectMethods.CopyRecord("Kỷ luật");
            break;
        case "SouthHoSoNhanSu1_panelQuanHeGiaDinh":
            DirectMethods.CopyRecord("Quan hệ gia đình");
            break;
        case "SouthHoSoNhanSu1_panelQuaTrinhCongTac":
            DirectMethods.CopyRecord("Quá trình công tác");
            break;
        case "SouthHoSoNhanSu1_panelQuaTrinhDieuChuyen":
            DirectMethods.CopyRecord("Quá trình điều chuyển");
            break;
        case "SouthHoSoNhanSu1_panelTaiSan":
            DirectMethods.CopyRecord("Tài sản");
            break;
        case "SouthHoSoNhanSu1_panelTaiNanLaoDong":
            DirectMethods.CopyRecord("Tai nạn lao động");
            break;
        case "SouthHoSoNhanSu1_panelBangCapChungChi":
            DirectMethods.CopyRecord("Bằng cấp chứng chỉ");
            break;
        case "SouthHoSoNhanSu1_panelKinhNghiemLamViec":
            DirectMethods.CopyRecord("Kinh nghiệm làm việc");
            break;
        case "SouthHoSoNhanSu1_panelQuaTrinhHocTap":
            DirectMethods.CopyRecord("Quá trình học tập");
            break;
    }
}
var openEditTheNganHangWindow = function () {
    var id = SouthHoSoNhanSu1_grpATM.getSelectionModel().getSelected();
    var data = SouthHoSoNhanSu1_grpATM.getSelectionModel().getSelected().data;
    if (id == null) {
        alert('Bạn chưa chọn bản ghi nào');
        return;
    }
    //setup value
    SouthHoSoNhanSu1_nbf_ATMNumber.setValue(data.ATMNumber);
    SouthHoSoNhanSu1_cb_BankID.setValue(data.BankID);
    SouthHoSoNhanSu1_chk_IsInUsed.setValue(data.IsInUsed);
    //setup window
    SouthHoSoNhanSu1_Button5.show();
    SouthHoSoNhanSu1_btnUpdateTheNganHang.hide();
    SouthHoSoNhanSu1_Button4.hide();
    SouthHoSoNhanSu1_wdTheNganHang.show();
}

var EditClick = function (DirectMethods) {
    var tabTitle = SouthHoSoNhanSu1_TabPanelBottom.getActiveTab().id;
    switch (tabTitle) {
        case "SouthHoSoNhanSu1_panelHoSoTuyenDung":
            SouthHoSoNhanSu1_StoreHoSoTuyenDung.reload();
            break;
        case "SouthHoSoNhanSu1_panelQuaTrinhDaoTao":
            var id = SouthHoSoNhanSu1_GridPanelQTDT.getSelectionModel().getSelected();
            if (id == null) {
                alert('Bạn chưa chọn bản ghi nào');
                return;
            }
            DirectMethods.GetDataForQuaTrinhDaoTao();
            btnUpdateDaoTao.hide();
            btnEditDaoTao.show();
            Button10.hide();
            //wdQuaTrinhDaoTao.show();
            break;
        case "SouthHoSoNhanSu1_panelBaoHiem":
            var id = SouthHoSoNhanSu1_GridPanelBaoHiem.getSelectionModel().getSelected();
            if (id == null) {
                alert('Bạn chưa chọn bản ghi nào');
                return;
            }
            DirectMethods.GetDataForBaoHiem();
            SouthHoSoNhanSu1_btnUpdateCongViec.hide(); SouthHoSoNhanSu1_btnEditBaoHiem.show(); SouthHoSoNhanSu1_btnCNVaDongBaoHiem.hide();
            //SouthHoSoNhanSu1_wdBaoHiem.show();
            break;
        case "SouthHoSoNhanSu1_panelDaiBieu":
            var id = SouthHoSoNhanSu1_GridPanelDaiBieu.getSelectionModel().getSelected();
            if (id == null) {
                alert('Bạn chưa chọn bản ghi nào');
                return;
            }
            DirectMethods.GetDataForDaiBieu(); SouthHoSoNhanSu1_btnCapNhatDaiBieu.hide(); SouthHoSoNhanSu1_btnEditDaiBieu.show(); SouthHoSoNhanSu1_Button7.hide();
            //SouthHoSoNhanSu1_wdDaiBieu.show();
            break;
        case "SouthHoSoNhanSu1_panelDeTai":
            var id = SouthHoSoNhanSu1_GridPanelDetai.getSelectionModel().getSelected();
            if (id == null) {
                alert('Bạn chưa chọn bản ghi nào');
                return;
            }
            DirectMethods.GetDataForDeTai(); SouthHoSoNhanSu1_btnUpdateDeTai.hide(); SouthHoSoNhanSu1_btnEditDeTai.show(); SouthHoSoNhanSu1_Button18.hide();
            //SouthHoSoNhanSu1_wdDeTai.show();
            break;
        case "SouthHoSoNhanSu1_panelHopDong":
            var id = SouthHoSoNhanSu1_GridPanelHopDong.getSelectionModel().getSelected();
            if (id == null) {
                alert('Bạn chưa chọn bản ghi nào');
                return;
            }
            DirectMethods.GetDataForHopDong();
            if (SouthHoSoNhanSu1_cbHopDongLoaiHopDong.store.getCount() == 0) SouthHoSoNhanSu1_cbHopDongLoaiHopDongStore.reload();
            if (SouthHoSoNhanSu1_cbHopDongTinhTrangHopDong.store.getCount() == 0) SouthHoSoNhanSu1_cbHopDongTinhTrangHopDongStore.reload();
            if (SouthHoSoNhanSu1_cbx_congviec.store.getCount() == 0) SouthHoSoNhanSu1_cbx_congviec.store.reload();
            if (SouthHoSoNhanSu1_cbx_HopDongChucVu.store.getCount() == 0) SouthHoSoNhanSu1_cbx_HopDongChucVu_Store.reload();
            SouthHoSoNhanSu1_btnUpdateHopDong.hide(); SouthHoSoNhanSu1_btnEditHopDong.show(); SouthHoSoNhanSu1_Button20.hide();
            SouthHoSoNhanSu1_hdfTypeWindow.setValue('HopDong');
            break;
        case "SouthHoSoNhanSu1_panelKhaNang":
            var id = SouthHoSoNhanSu1_GridPanelKhaNang.getSelectionModel().getSelected();
            if (id == null) {
                alert('Bạn chưa chọn bản ghi nào');
                return;
            }
            DirectMethods.GetDataForKhaNang();
            if (SouthHoSoNhanSu1_cbKhaNang.store.getCount() == 0) SouthHoSoNhanSu1_cbKhaNangStore.reload();
            if (SouthHoSoNhanSu1_cbKhaNangXepLoai.store.getCount() == 0) SouthHoSoNhanSu1_cbKhaNangXepLoaiStore.reload();
            SouthHoSoNhanSu1_btnUpdateKhaNang.hide();
            SouthHoSoNhanSu1_btnEditKhaNang.show();
            SouthHoSoNhanSu1_Button22.hide();
            //SouthHoSoNhanSu1_wdKhaNang.show();
            break;
        case "SouthHoSoNhanSu1_panelKhenThuong":
            var id = SouthHoSoNhanSu1_GridPanelKhenThuong.getSelectionModel().getSelected();
            if (id == null) {
                alert('Bạn chưa chọn bản ghi nào');
                return;
            }
            DirectMethods.GetDataForKhenThuong();
            if (SouthHoSoNhanSu1_cbLyDoKhenThuong.store.getCount() == 0) SouthHoSoNhanSu1_cbLyDoKhenThuongStore.reload();
            if (SouthHoSoNhanSu1_cbHinhThucKhenThuong.store.getCount() == 0) SouthHoSoNhanSu1_cbHinhThucKhenThuongStore.reload();
            SouthHoSoNhanSu1_btnUpdateKhenThuong.hide(); SouthHoSoNhanSu1_btnEditKhenThuong.show();
            SouthHoSoNhanSu1_Button24.hide();
            SouthHoSoNhanSu1_hdfTypeWindow.setValue('KhenThuong');
            break;
        case "SouthHoSoNhanSu1_panelKiLuat":
            var id = SouthHoSoNhanSu1_GridPanelKyLuat.getSelectionModel().getSelected();
            if (id == null) {
                alert('Bạn chưa chọn bản ghi nào');
                return;
            }
            DirectMethods.GetDataForKyLuat();
            if (SouthHoSoNhanSu1_cbLyDoKyLuat.store.getCount() == 0) { SouthHoSoNhanSu1_cbLyDoKyLuatStore.reload(); };
            if (SouthHoSoNhanSu1_cbHinhThucKyLuat.store.getCount() == 0) { SouthHoSoNhanSu1_cbHinhThucKyLuatStore.reload(); };
            SouthHoSoNhanSu1_btnCapNhatKyLuat.hide(); SouthHoSoNhanSu1_btnEditKyLuat.show(); SouthHoSoNhanSu1_Button26.hide();
            SouthHoSoNhanSu1_hdfTypeWindow.setValue('KyLuat');
            break;
        case "SouthHoSoNhanSu1_panelQuanHeGiaDinh":
            var id = SouthHoSoNhanSu1_GridPanelQHGD.getSelectionModel().getSelected();
            if (id == null) {
                alert('Bạn chưa chọn bản ghi nào');
                return;
            }
            DirectMethods.GetDataForQuanHeGiaDinh();
            if (SouthHoSoNhanSu1_cbQuanHeGiaDinh.store.getCount() == 0) { SouthHoSoNhanSu1_cbQuanHeGiaDinhStore.reload(); };
            SouthHoSoNhanSu1_btnUpdateQuanHeGiaDinh.hide();
            SouthHoSoNhanSu1_btnUpdate.show();
            SouthHoSoNhanSu1_Button28.hide();
            //SouthHoSoNhanSu1_wdQuanHeGiaDinh.show();
            break;
        case "SouthHoSoNhanSu1_panelQuaTrinhCongTac":
            var id = SouthHoSoNhanSu1_GridPanelQuaTrinhCTAC.getSelectionModel().getSelected();
            if (id == null) {
                alert('Bạn chưa chọn bản ghi nào');
                return;
            }
            DirectMethods.GetDataForQuaTrinhCongTac();
            if (SouthHoSoNhanSu1_cbCongTacQuocGia.store.getCount() == 0) { SouthHoSoNhanSu1_cbCongTacQuocGiaStore.reload(); };
            SouthHoSoNhanSu1_btnCapNhatQuaTrinhCongTac.hide();
            SouthHoSoNhanSu1_btnEditQuaTrinhCongTac.show();
            SouthHoSoNhanSu1_Button30.hide();
            SouthHoSoNhanSu1_hdfTypeWindow.setValue('QTCT');
            break;
        case "SouthHoSoNhanSu1_panelQuaTrinhDieuChuyen":
            var id = SouthHoSoNhanSu1_GridPanelQuaTrinhDieuChuyen.getSelectionModel().getSelected();
            if (id == null) {
                alert('Bạn chưa chọn bản ghi nào');
                return;
            }
            DirectMethods.GetDataForQuaTrinhDieuChuyen();
            SouthHoSoNhanSu1_btnCapNhatQuaTrinhDieuChuyen.hide();
            SouthHoSoNhanSu1_btnUpdateQuaTrinhDieuChuyen.show();
            SouthHoSoNhanSu1_Button32.hide();
            SouthHoSoNhanSu1_hdfTypeWindow.setValue('QTDC');
            break;
        case "SouthHoSoNhanSu1_panelTaiSan":
            var id = SouthHoSoNhanSu1_GridPanelTaiSan.getSelectionModel().getSelected();
            if (id == null) {
                alert('Bạn chưa chọn bản ghi nào');
                return;
            }
            DirectMethods.GetDataForTaiSan();
            SouthHoSoNhanSu1_Button2.hide();
            SouthHoSoNhanSu1_btnEditTaiSan.show();
            SouthHoSoNhanSu1_btnUpdateTaiSan.hide();
            if (SouthHoSoNhanSu1_cbTaiSan.store.getCount() == 0) { SouthHoSoNhanSu1_cbTaiSanStore.reload(); };
            //SouthHoSoNhanSu1_wdAddTaiSan.show();
            break;
        case "SouthHoSoNhanSu1_panelBangCapChungChi":
            var id = SouthHoSoNhanSu1_GridPanel_ChungChi.getSelectionModel().getSelected();
            if (id == null) {
                alert('Bạn chưa chọn bản ghi nào');
                return;
            }
            DirectMethods.GetDataForChungChi();
            if (SouthHoSoNhanSu1_cbx_tenchungchi.store.getCount() == 0) { SouthHoSoNhanSu1_cbx_tenchungchiStore.reload(); }
            if (SouthHoSoNhanSu1_cbx_XepLoaiChungChi.store.getCount() == 0) { SouthHoSoNhanSu1_cbx_XepLoaiChungChiStore.reload(); }
            SouthHoSoNhanSu1_btnUpdateChungChi.hide(); SouthHoSoNhanSu1_btnUpdateandCloseChungChi.hide(); SouthHoSoNhanSu1_btnEditChungChi.show();
            //SouthHoSoNhanSu1_wdAddChungChi.show();
            break;
        case "SouthHoSoNhanSu1_panelTaiNanLaoDong":
            var id = SouthHoSoNhanSu1_GridPanelTaiNanLaoDong.getSelectionModel().getSelected();
            if (id == null) {
                alert('Bạn chưa chọn bản ghi nào');
                return;
            }
            DirectMethods.GetDataForTaiNan();
            SouthHoSoNhanSu1_btnInsertTaiNan.hide(); SouthHoSoNhanSu1_btnUpdateTaiNan.show();
            SouthHoSoNhanSu1_btnInsertTaiNanAndClose.hide();
            //SouthHoSoNhanSu1_wdTaiNanLaoDong.show();
            break;
        case "SouthHoSoNhanSu1_panelTepDinhKem":
            var id = SouthHoSoNhanSu1_grpTepTinDinhKem.getSelectionModel().getSelected();
            if (id == null) {
                alert('Bạn chưa chọn bản ghi nào');
                return;
            }
            DirectMethods.GetDataForTepTin();
            SouthHoSoNhanSu1_btnEditAttachFile.show(); SouthHoSoNhanSu1_Button10.hide(); SouthHoSoNhanSu1_btnUpdateAtachFile.hide();
            //SouthHoSoNhanSu1_wdAttachFile.show();
            break;
        case "SouthHoSoNhanSu1_panelKinhNghiemLamViec":
            var id = SouthHoSoNhanSu1_GridPanelKinhNghiemLamViec.getSelectionModel().getSelected();
            if (id == null) {
                alert('Bạn chưa chọn bản ghi nào');
                return;
            }
            DirectMethods.GetDataForKinhNghiemLamViec();
            SouthHoSoNhanSu1_Update.hide(); SouthHoSoNhanSu1_UpdateandClose.hide(); SouthHoSoNhanSu1_btnEditKinhNghiem.show();
            break;
        case "SouthHoSoNhanSu1_panelQuaTrinhHocTap":
            var id = SouthHoSoNhanSu1_GridPanel_BangCap.getSelectionModel().getSelected();
            if (id == null) {
                alert('Bạn chưa chọn bản ghi nào');
                return;
            }
            DirectMethods.GetDataForQuaTrinhHocTap();
            SouthHoSoNhanSu1_btnUpdateBangCap.hide(); SouthHoSoNhanSu1_btnUpdateandCloseBangCap.hide(); SouthHoSoNhanSu1_btn_EditBangCap.show();
            //SouthHoSoNhanSu1_wdAddBangCap.show();
            break;
        case "SouthHoSoNhanSu1_panelTheNganHang":
            openEditTheNganHangWindow();
            break;
    }
}
