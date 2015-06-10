var AddRecordClick = function (idTab) {
    var tabTitle = idTab.getActiveTab().id;
    switch (tabTitle) {
        case "pnl_QuanHeGiaDinh":
            wdQuanHeGiaDinh.show();
            break;
        case "pnl_QuaTrinhHocTap":
            wdAddBangCap.show();
            break;
        case "pnl_BangCapChungChi":
            wdAddChungChi.show();
            break;
        case "pnl_KinhNghiemLamViec":
            wdKinhNghiemLamViec.show();
            break;
        case "pnl_DaiBieu":
            wdDaiBieu.show();
            break;
        case "pnl_TaiSan":
            wdAddTaiSan.show();
            break;
        case "pnl_KhaNang":
            wdKhaNang.show(); 
            break;
        case "pnl_TepTinDinhKem":
            wdAttachFile.show();
            break;
        case "pnl_KhenThuong":
            wdKhenThuong.show();
            break;
        case "panelKiLuat":
            wdKyLuat.show();
            break;
        case "panelQuaTrinhCongTac":
            wdQuaTrinhCongTac.show();
            break;
        case "panelQuaTrinhDieuChuyen":
            wdQuaTrinhDieuChuyen.show();
            break;
        case "panelTaiNanLaoDong":
            wdTaiNanLaoDong.show();
            break;
    }
}

var DeleteRecordOnGrid = function (idTab) {
    var tabTitle = idTab.getActiveTab().id;
    switch (tabTitle) {
        case "pnl_QuanHeGiaDinh":
            DeleteRecordOnGrid2(GridPanelQHGD, StoreQHGD);
            break;
        case "pnl_QuaTrinhHocTap":
            DeleteRecordOnGrid2(GridPanel_BangCap, Store_BangCap);
            break;
        case "pnl_BangCapChungChi":
            DeleteRecordOnGrid2(GridPanel_ChungChi, Store_BangCapChungChi);
            break;
        case "pnl_KinhNghiemLamViec":
            DeleteRecordOnGrid2(GridPanelKinhNghiemLamViec, StoreKinhNghiemLamViec);
            break;
        case "pnl_DaiBieu":
            DeleteRecordOnGrid2(GridPanel_DaiBieu, StoreDaiBieu);
            break;
        case "pnl_TaiSan":
            DeleteRecordOnGrid2(GridPanelTaiSan, StoreTaiSan);
            break;
        case "pnl_KhaNang":
            DeleteRecordOnGrid2(GridPanelKhaNang, StoreKhaNang);
            break;
        case "pnl_DeTai":
            DeleteRecordOnGrid2(GridPanelDetai, StoreDetai);
            break;
        case "pnl_TepTinDinhKem":
            DeleteRecordOnGrid2(grpTepTinDinhKem, grpTepTinDinhKemStore);
            break;
        case "pnl_KhenThuong":
            DeleteRecordOnGrid2(GridPanelKhenThuong, StoreKhenThuong);
            break;
        case "panelKiLuat":
            DeleteRecordOnGrid2(GridPanelKyLuat, StoreKyLuat);
            break;
        case "panelQuaTrinhCongTac":
            DeleteRecordOnGrid2(GridPanelQuaTrinhCTAC, StoreQuaTrinhCongTac);
            break;
        case "panelQuaTrinhDieuChuyen":
            DeleteRecordOnGrid2(GridPanelQuaTrinhDieuChuyen, StoreQuaTrinhDieuChuyen);
            break;
        case "panelTaiNanLaoDong":
            DeleteRecordOnGrid2(GridPanelTaiNanLaoDong, StoreTaiNanLaoDong);
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
            }            
        }
    });
}

var CopyRecord = function (idTab) {
    Ext.Msg.confirm('Xác nhận', 'Bạn có chắc chắn muốn nhân đôi dữ liệu không', function (btn) {
        if (btn == "yes") {
            var tabTitle = idTab.getActiveTab().id;
            switch (tabTitle) {
                case "pnl_QuanHeGiaDinh":
                    Ext.net.DirectMethods.CopyRecord("Quan hệ gia đình");
                    break;
                case "pnl_QuaTrinhHocTap":
                    Ext.net.DirectMethods.CopyRecord("Quá trình học tập");
                    break;
                case "pnl_BangCapChungChi":
                    Ext.net.DirectMethods.CopyRecord("Bằng cấp chứng chỉ");
                    break;
                case "pnl_KinhNghiemLamViec":
                    Ext.net.DirectMethods.CopyRecord("Kinh nghiệm làm việc");
                    break;
                case "pnl_DaiBieu":
                    Ext.net.DirectMethods.CopyRecord("Đại biểu");
                    break;
                case "pnl_TaiSan":
                    Ext.net.DirectMethods.CopyRecord("Tài sản");
                    break;
                case "pnl_KhaNang":
                    Ext.net.DirectMethods.CopyRecord("Khả năng");
                    break;
                case "pnl_DeTai":
                    Ext.net.DirectMethods.CopyRecord("Đề tài");
                    break;
                case "pnl_TepTinDinhKem":
                    Ext.net.DirectMethods.CopyRecord("Tệp tin đính kèm");
                    break;
                case "panelKiLuat":
                    Ext.net.DirectMethods.CopyRecord("Kỷ luật");
                    break;
                case "panelQuaTrinhCongTac":
                    Ext.net.DirectMethods.CopyRecord("Quá trình công tác");
                    break;
                case "panelQuaTrinhDieuChuyen":
                    Ext.net.DirectMethods.CopyRecord("Quá trình điều chuyển");
                    break;
                case "panelTaiNanLaoDong":
                    Ext.net.DirectMethods.CopyRecord("Tai nạn lao động");
                    break;
            }
        }
    });
}

var RenderTepTinDinhKem = function (value, p, record) {
    if (value != null && value != '') {
        return "<img src='../../Resource/images/attach.png'>";
    }
    return '';
}

var EditClick = function (idTab) {
    var tabTitle = idTab.getActiveTab().id;
    switch (tabTitle) {
        case "pnl_QuanHeGiaDinh":
            Ext.net.DirectMethods.GetDataForQuanHeGiaDinh();
            if (cbQuanHeGiaDinh.store.getCount() == 0) { cbQuanHeGiaDinhStore.reload(); };
            btnUpdateQuanHeGiaDinh.hide();
            btnUpdate.show();
            btnCapNhatVaDongQHGD.hide();
            //wdQuanHeGiaDinh.show();
            break;
        case "pnl_QuaTrinhHocTap":
            EditQuaTrinhHocTap();
            break;
        case "pnl_BangCapChungChi":
            Ext.net.DirectMethods.GetDataForChungChi();
            btnUpdateChungChi.hide();
            btnEditChungChi.show();
            btnUpdateandCloseChungChi.hide();
            //wdAddChungChi.show();
            break;
        case "pnl_KinhNghiemLamViec":
            Ext.net.DirectMethods.GetDataForKinhNghiemLamViec();
            Update.hide();
            btnEditKinhNghiem.show();
            UpdateandClose.hide();
            //wdKinhNghiemLamViec.show();
            break;
        case "pnl_DaiBieu":
            Ext.net.DirectMethods.GetDataForDaiBieu();
            btnCapNhatDaiBieu.hide();
            btnEditDaiBieu.show();
            btnEditAndCloseDaiBieu.hide();
            //wdDaiBieu.show();
            break;
        case "pnl_TaiSan":
            Ext.net.DirectMethods.GetDataForTaiSan();
            btnUpdateTaiSan.hide();
            btnEditTaiSan.show();
            btnUpdateCloseTaiSan.hide();
            break;
        case "pnl_KhaNang":
            Ext.net.DirectMethods.GetDataForKhaNang();
            if (cbKhaNang.store.getCount() == 0) cbKhaNangStore.reload();
            if (cbKhaNangXepLoai.store.getCount() == 0) cbKhaNangXepLoaiStore.reload();
            btnUpdateKhaNang.hide();
            btnEditKhaNang.show();
            btnCapNhatVaDongKhaNang.hide();
            //wdKhaNang.show();
            break; 
        case "pnl_TepTinDinhKem":
            EditTepTinDinhKem();
            break;
        case "pnl_KhenThuong":
            EditKhenThuong();
            break;
        case "panelKiLuat":
            var id = GridPanelKyLuat.getSelectionModel().getSelected();
            if (id == null) {
                alert('Bạn chưa chọn bản ghi nào');
                return;
            }
            Ext.net.DirectMethods.GetDataForKyLuat();
            btnCapNhatKyLuat.hide(); btnEditKyLuat.show(); Button26.hide();
            break;
        case "panelQuaTrinhCongTac":
            EditQuaTrinhCongTac();
            break;
        case "panelQuaTrinhDieuChuyen":
            EditQuaTrinhDieuChuyen();
            break;
        case "panelTaiNanLaoDong":
            EditTaiNanLaoDong();
            break;
    }
}

//Thêm mới đơn vị tính
var addDonViTinh = function () {
    var grid = grpDonViTinh;
    grid.getRowEditor().stopEditing();

    grid.insertRecord(0, {
        DATE_CREATE: (new Date()).clearTime(),
        TEN_DVT: "",
        MA_DVT: "0",
        GHI_CHU: ""
    });
    txtMaDonViTinh.enable();

    grid.getView().refresh();
    grid.getSelectionModel().selectRow(0);
    grid.getRowEditor().startEditing(0);
}
// sửa đơn vị tính
var editDonViTinh = function () {
    var grid = grpDonViTinh;
    grid.getRowEditor().stopEditing();
    var s = grid.getSelectionModel().getSelections();
    for (var i = 0, r; r = s[i]; i++) {
        grid.getView().refresh();
        grid.getSelectionModel().selectRow(r);
        grid.getRowEditor().startEditing(r);
        hdfMaDonViTinh.setValue(r.data.MA_DVT);
    }
    txtMaDonViTinh.disable();
}
// xóa đơn vị tính
var deleteDonViTinh = function (DirectMethods) {
    var grid = grpDonViTinh;
    var Store = grpDonViTinh_Store;
    if (hdfButton.getValue() == 'delete') {
        try {
            grid.getRowEditor().stopEditing();
        } catch (e) {
            alert(e.Message.toString());
        }
        var s = grid.getSelectionModel().getSelections();
        for (var i = 0, r; r = s[i]; i++) {
            Store.remove(r);
            Store.commitChanges();
            DirectMethods.DeleteDonViTinh(r.data.MA_DVT);
        }
    }
}
var RemoveCanceledRecord = function (grid, Store) {
    if (hdfButton.getValue() == 'insert') {
        try {
            grid.getRowEditor().stopEditing();
        } catch (e) {
            alert(e.Message.toString());
        }
        var s = grid.getSelectionModel().getSelections();
        for (var i = 0, r; r = s[i]; i++) {
            Store.remove(r);
        }
    }
}
var GetFileNameUpload = function () {
    var fullPath = file_cv.getValue();
    var arrStr = fullPath.split('.');
    if (arrStr.length >= 2) {
        txtFileName.setValue(arrStr[arrStr.length - 2]);
    }
    else {
        txtFileName.setValue(fullPath);
    }
}
var getSelectedIndexRow = function (grid) {
    var record = grid.getSelectionModel().getSelected();
    var index = grid.store.indexOf(record);
    if (index == -1)
        return 0;
    return index;
}
//Cập nhật lại bản ghi trên grid quản lý các đơn vị tính
addUpdatedRecord = function (maDVT, tenDVT, ghiChu) {
    var rowindex = getSelectedIndexRow(grpDonViTinh);
    //xóa bản ghi cũ
    var s = grpDonViTinh.getSelectionModel().getSelections();
    for (var i = 0, r; r = s[i]; i++) {
        cbxDonViTinh_Store.remove(r);
        cbxDonViTinh_Store.commitChanges();
    }
    //Thêm bản ghi đã update
    grpDonViTinh.insertRecord(rowindex, {
        MA_DVT: maDVT,
        TEN_DVT: tenDVT,
        GHI_CHU: ghiChu,
        DATE_CREATED: (new Date()).clearTime()
    });
    grpDonViTinh.getView().refresh();
    grpDonViTinh.getSelectionModel().selectRow(rowindex);
    grpDonViTinh_Store.commitChanges();
}
var SaveDonViTinh = function (maDVT, tenDVT, ghiChu, DirectMethods) {
    DirectMethods.SaveDonViTinh(maDVT, tenDVT, ghiChu);
    grpDonViTinh_Store.commitChanges();
    //cbxDonViTinh_Store.reload();
    //addUpdatedRecord(maDVT, tenDVT, ghiChu);
}

var EditTepTinDinhKem = function () {
    Ext.net.DirectMethods.GetDataForTepTin();
    btnCapNhatVaDongAttachFile.hide();
    btnUpdateAtachFile.hide();
    btnEditAttachFile.show(); 
}

var EditQuaTrinhDieuChuyen = function () {
    var id = GridPanelQuaTrinhDieuChuyen.getSelectionModel().getSelected();
    if (id == null) {
        alert('Bạn chưa chọn bản ghi nào');
        return;
    }
    Ext.net.DirectMethods.GetDataForQuaTrinhDieuChuyen();
    btnUpdateQuaTrinhDC.hide();
    btnUpdateQuaTrinhDieuChuyen.show();
    Button32.hide();
}

var EditKhenThuong = function () {
    Ext.net.DirectMethods.GetDataForKhenThuong();
    btnEditKhenThuong.show();
    btnUpdateKhenThuong.hide();
    Button24.hide();
}

var EditQuaTrinhCongTac = function () {
    var id = GridPanelQuaTrinhCTAC.getSelectionModel().getSelected();
    if (id == null) {
        alert('Bạn chưa chọn bản ghi nào');
        return;
    }
    Ext.net.DirectMethods.GetDataForQuaTrinhCongTac();
    btnCapNhatQuaTrinhCongTac.hide();
    btnEditQuaTrinhCongTac.show();
    Button30.hide();
}

var EditQuaTrinhHocTap = function () {
    Ext.net.DirectMethods.GetDataForQuaTrinhHocTap();
    if (cbx_NoiDaoTaoBangCap.store.getCount() == 0) cbx_NoiDaoTaoBangCapStore.reload();
    if (cbx_hinhthucdaotaobang.store.getCount() == 0) cbx_hinhthucdaotaobangStore.reload();
    if (cbx_ChuyenNganhBangCap.store.getCount() == 0) cbx_ChuyenNganhBangCapStore.reload();
    if (cbx_trinhdobangcap.store.getCount() == 0) cbx_trinhdobangcapStore.reload();
    if (cbx_xeploaiBangCap.store.getCount() == 0) cbx_xeploaiBangCapStore.reload();
    btnUpdateBangCap.hide();
    btn_EditBangCap.show();
    btnUpdateandCloseBangCap.hide();
}

var EditTaiNanLaoDong = function () {
    var id = GridPanelTaiNanLaoDong.getSelectionModel().getSelected();
    if (id == null) {
        alert('Bạn chưa chọn bản ghi nào');
        return;
    }
    Ext.net.DirectMethods.GetDataForTaiNan();
    btnInsertTaiNan.hide(); btnUpdateTaiNan.show();
    btnInsertTaiNanAndClose.hide();
}
var ValidInputQuanHeGiaDinh = function () {
    if (txtQHGDHoTen.getValue() == '') {
        alert('Bạn chưa nhập họ tên !');
        txtQHGDHoTen.focus();
        return false;
    }
    if (cbQHGDGioiTinh.getValue() == '') {
        alert('Bạn chưa chọn giới tính !');
        cbQHGDGioiTinh.focus();
        return false;
    }
    if (cbQuanHeGiaDinh.getValue() == '') {
        alert('Bạn chưa chọn quan hệ !');
        cbQuanHeGiaDinh.focus();
        return false;
    }
    /////
    if (ValidateDateField(dfQHGDBatDauGiamTru) == false) {
        alert('Định dạng ngày bắt đầu giảm trừ không đúng');
        return false;
    }
    if (ValidateDateField(dfQHGDKetThucGiamTru) == false) {
        alert('Định dạng ngày kết thúc giảm trừ không đúng');
        return false;
    }
    return true;
}

var ValidInputAddChungChi = function () {
    if (cbx_tenchungchi.getValue() == '') {
        alert('Bạn chưa chọn chứng chỉ');
        cbx_tenchungchi.focus();
        return false;
    }
    if (cbx_XepLoaiChungChi.getValue() == '') {
        alert('Bạn chưa chọn xếp loại');
        cbx_XepLoaiChungChi.focus();
        return false;
    }
    //////
    if (ValidateDateField(df_NgayCap) == false) {
        alert('Định dạng ngày cấp không đúng');
        return false;
    }
    if (ValidateDateField(df_NgayHetHan) == false) {
        alert('Định dạng ngày hết hạn không đúng');
        return false;
    }
    return true;
}

var CheckInputKinhNghiemLamViec = function () {
    if (txt_noilamviec.getValue().trim() == '') {
        alert("Bạn chưa nhập nơi làm việc");
        txt_noilamviec.focus();
        return false;
    }
    if (txt_vitriconviec.getValue().trim() == '') {
        alert("Bạn chưa nhập vị trí công việc");
        txt_vitriconviec.focus();
        return false;
    }
    //if (txt_conviecdamnhiem.getValue().trim() == '') {
    //    alert("Bạn chưa nhập công việc đảm nhiệm");
    //    txt_conviecdamnhiem.focus();
    //    return false;
    //}
    if (dfKNLVTuNgay.getValue() == '' || dfKNLVTuNgay.getValue() == null) {
        alert('Bạn chưa nhập ngày bắt đầu');
        dfKNLVTuNgay.focus();
        return false;
    }
    //////
    if (ValidateDateField(dfKNLVTuNgay) == false) {
        alert('Định dạng từ ngày không đúng');
        return false;
    }
    if (ValidateDateField(dfKNLVDenNgay) == false) {
        alert('Định dạng đến ngày không đúng');
        return false;
    }

    return true;
}

var ValidInputDaiBieu = function () {
    if (txtDBLoaiHinh.getValue() == '') {
        alert('Bạn chưa điền loại hình!');
        txtDBLoaiHinh.focus();
        return false;
    }
    if (dfDBTuNgay.getValue() == '') {
        alert('Bạn chưa chọn ngày bắt đầu!');
        dfDBTuNgay.focus();
        return false;
    }
    if (txtDBNhiemKy.getValue() == '') {
        alert('Bạn chưa điền nhiệm kỳ!');
        txtDBNhiemKy.focus();
        return false;
    }
    if (dfDBDenNgay.getValue() == '') {
        alert('Bạn chưa chọn ngày kết thúc!');
        dfDBDenNgay.focus();
        return false;
    }
    ////
    if (ValidateDateField(dfDBTuNgay) == false) {
        alert('Định dạng từ ngày không đúng');
        return false;
    }
    if (ValidateDateField(dfDBDenNgay) == false) {
        alert('Định dạng đến ngày không đúng');
        return false;
    }
    return true;
}

var CheckInputTaiSan = function () {
    if (cbTaiSan.getValue().trim() == '') {
        alert('Bạn chưa chọn vật tư');
        cbTaiSan.focus();
        return false;
    }
    if (txtTaiSanSoLuong.getValue() == '' || txtTaiSanSoLuong.getValue() == null) {
        alert('Bạn chưa nhập số lượng tài sản');
        txtTaiSanSoLuong.focus();
        return false;
    }
    if (cbxDonViTinh.getValue() == '' || cbxDonViTinh.getValue() == null) {
        alert('Bạn chưa chọn đơn vị tính');
        cbxDonViTinh.focus();
        return false;
    }
    if (tsTxtinhTrang.getValue().trim() == '') {
        alert('Bạn chưa nhập tính trạng tài sản');
        tsTxtinhTrang.focus();
        return false;
    }
    if (ValidateDateField(tsDateField) == false) {
        alert('Định dạng ngày nhận không đúng');
        return false;
    }
    return true;
}

var ValidInputKhaNang = function () {
    if (cbKhaNang.getValue() == '') {
        alert('Bạn chưa chọn khả năng!');
        cbKhaNang.focus();
        return false;
    }
    if (cbKhaNangXepLoai.getValue() == '') {
        alert('Bạn chưa chọn xếp loại!');
        cbKhaNangXepLoai.focus();
        return false;
    }
    return true;
}

var ValidInputDeTai = function () {
    if (txtMaDeTai.getValue() == '') {
        alert('Bạn chưa nhập mã đề tài!');
        txtMaDeTai.focus();
        return false;
    }
    if (txtDeTaiTenDeTai.getValue() == '') {
        alert('Bạn chưa điền tên đề tài!');
        txtDeTaiTenDeTai.focus();
        return false;
    }
//    if (txtDeTaiChuNhiemDeTai.getValue() == '') {
//        alert('Bạn chưa điền chủ nhiệm đề tài!');
//        txtDeTaiChuNhiemDeTai.focus();
//        return false;
//    }
    if (txtDeTaiCapDeTai.getValue() == '') {
        alert('Bạn chưa điền cấp đề tài!');
        txtDeTaiCapDeTai.focus();
        return false;
    }
//    if (txDeTaiTuCachThamGia.getValue() == '') {
//        alert('Bạn chưa điền tư cách tham gia!');
//        txDeTaiTuCachThamGia.focus();
//        return false;
//    }
    ////////
    if (ValidateDateField(txtDeTaiTuNgay) == false) {
        alert('Định dạng từ ngày không đúng');
        return false;
    }
    if (ValidateDateField(txtDeTaiDenNgay) == false) {
        alert('Định dạng đến ngày không đúng');
        return false;
    }
    return true;
}

var CheckInputKyLuat = function (el) {
    if (txtKyLuatSoQD.getValue().trim() == '') {
        alert('Bạn chưa nhập số quyết định');
        txtKyLuatSoQD.focus();
        return false;
    }
    if (dfKyLuatNgayQuyetDinh.getValue() == '') {
        alert('Bạn chưa chọn ngày quyết định');
        dfKyLuatNgayQuyetDinh.focus();
        return false;
    }
    if (cbLyDoKyLuat.getValue().trim() == '') {
        alert('Bạn chưa chọn lý do kỷ luật');
        cbLyDoKyLuat.focus();
        return false;
    }
    if (cbHinhThucKyLuat.getValue().trim() == '') {
        alert('Bạn chưa chọn hình thức kỷ luật');
        cbHinhThucKyLuat.focus();
        return false;
    }
    ////////
    if (ValidateDateField(dfKyLuatNgayQuyetDinh) == false) {
        alert('Định dạng ngày quyết định không đúng');
        return false;
    }
    var size = 0;
    for (var num1 = 0; num1 < el.files.length; num1++) {
        var file = el.files[num1];
        size += file.size;
    }
    if (size > 10485760) {
        alert('Phần mềm chỉ hỗ trợ các tệp tin đính kèm nhỏ hơn 10MB');
        return false;
    }
    return true;
}

var CheckInputQuaTrinhCongTac = function (el) {
    if (dfQTCTNgayBatDau.getValue() == '' || dfQTCTNgayBatDau.getValue() == null) {
        alert('Bạn chưa nhập ngày bắt đầu');
        dfQTCTNgayBatDau.focus();
        return false;
    }
    if (dfQTCTNgayKetThuc.getValue() == '' || dfQTCTNgayKetThuc.getValue() == null) {
        alert('Bạn chưa nhập ngày kết thúc');
        dfQTCTNgayKetThuc.focus();
        return false;
    }
    if (txtQTCTNoiDungCongViec.getValue().trim() == '' || txtQTCTNoiDungCongViec.getValue() == null) {
        alert('Bạn chưa nhập nội dung công việc');
        txtQTCTNoiDungCongViec.focus();
        return false;
    }
    if (txtQTCTDiaDiemCT.getValue().trim() == '' || txtQTCTDiaDiemCT.getValue() == null) {
        alert('Bạn chưa nhập địa điểm công tác');
        txtQTCTDiaDiemCT.focus();
        return false;    
    }

    /////////
    if (ValidateDateField(dfQTCTNgayBatDau) == false) {
        alert('Định dạng ngày bắt đầu không đúng');
        return false;
    }
    if (ValidateDateField(dfQTCTNgayQuyetDinh) == false) {
        alert('Định dạng ngày quyết định không đúng');
        return false;
    }
    if (ValidateDateField(dfQTCTNgayKetThuc) == false) {
        alert('Định dạng ngày kết thúc không đúng');
        return false;
    }
    var size = 0;
    for (var num1 = 0; num1 < el.files.length; num1++) {
        var file = el.files[num1];
        size += file.size;
    }
    if (size > 10485760) {
        alert('Phần mềm chỉ hỗ trợ các tệp tin đính kèm nhỏ hơn 10MB');
        return false;
    }
    return true;
}

var CheckInputQuaTrinhDieuChuyen = function (el) {
    if (dfQTDCNgayQuyetDinh.getValue() == '') {
        alert('Bạn chưa chọn ngày quyết định');
        dfQTDCNgayQuyetDinh.focus();
        return false;
    }
    if (dfQTDCNgayCoHieuLuc.getValue() == '') {
        alert('Bạn chưa nhập ngày có hiệu lực');
        dfQTDCNgayCoHieuLuc.focus();
        return false;
    }
    if (cbxQTDCBoPhanMoi.getValue() == '') {
        alert('Bạn chưa nhập bộ phận mới');
        cbxQTDCBoPhanMoi.focus();
        return false;
    }
    //if (cbQTDCBoPhanCu.getValue() == '') {
    //    alert('Bạn chưa nhập bộ phận cũ');
    //    cbQTDCBoPhanCu.focus();
    //    return false;
    //}
    ///////
    if (ValidateDateField(dfQTDCNgayCoHieuLuc) == false) {
        alert('Định dạng ngày có hiệu lực không đúng');
        return false;
    }
    if (ValidateDateField(dfQTDCNgayQuyetDinh) == false) {
        alert('Định dạng ngày quyết định không đúng');
        return false;
    }
    if (ValidateDateField(dfQTDCNgayHetHieuLuc) == false) {
        alert('Định dạng ngày hết hiệu lực không đúng');
        return false;
    }
    var size = 0;
    for (var num1 = 0; num1 < el.files.length; num1++) {
        var file = el.files[num1];
        size += file.size;
    }
    if (size > 10485760) {
        alert('Phần mềm chỉ hỗ trợ các tệp tin đính kèm nhỏ hơn 10MB');
        return false;
    }
    return true;
}

var CheckInputTaiNanLaoDong = function () {
    if (TaiNan_txtLydo.getValue().trim() == '') {
        alert('Bạn chưa nhập nguyên nhân gây tai nạn');
        TaiNan_txtLydo.focus();
        return false;
    }
    if (TaiNan_txtDiaDiemXayRa.getValue().trim() == '') {
        alert('Bạn chưa nhập địa điểm xảy ra tai nạn');
        TaiNan_txtDiaDiemXayRa.focus();
        return false;
    }
    if (TaiNan_txtBoiThuong.getValue().length > 15) {
        alert('Số tiền bồi thường không được vượt quá 12 kí tự');
        TaiNan_txtBoiThuong.focus();
        return false;
    }
    if (ValidateDateField(TaiNan_dfNgayXayRa) == false) {
        alert('Định dạng ngày xảy ra tai nạn không đúng');
        return false;
    }
    if (ValidateDateField(TaiNan_txtNgayBoiThuong) == false) {
        alert('Định dạng ngày bồi thường không đúng');
        return false;
    }
    return true;
}

var ValidInputAttachFile = function () {
    if (txtFileName.getValue() == '') {
        alert('Bạn chưa nhập tên hiển thị!');
        txtFileName.focus();
        return false;
    }
    //hdfAttachFile
    if (file_cv.getValue() == '') {
        alert('Bạn chưa chọn file!');
        file_cv.focus();
        return false;
    }
    return true;
}

var ValidInputQuaTrinhHocTap = function () {
    if (cbx_NoiDaoTaoBangCap.getValue() == '') {
        alert('Bạn chưa nhập nơi đào tạo bằng cấp!');
        cbx_NoiDaoTaoBangCap.focus();
        return false;
    }
    if (cbx_hinhthucdaotaobang.getValue() == '') {
        alert('Bạn chưa chọn hình thức đào tạo!');
        cbx_hinhthucdaotaobang.focus();
        return false;
    }
    if (txt_khoa.getValue() == '') {
        alert('Bạn chưa nhập khoa!');
        txt_khoa.focus();
        return false;
    }
    if (cbx_ChuyenNganhBangCap.getValue() == '') {
        alert('Bạn chưa chọn chuyên ngành!');
        cbx_ChuyenNganhBangCap.focus();
        return false;
    }
    if (cbx_trinhdobangcap.getValue() == '') {
        alert('Bạn chưa chọn trình độ bằng cấp!');
        cbx_trinhdobangcap.focus();
        return false;
    }
    ///////
    if (ValidateDateField(df_ngaybatdauhoc) == false) {
        alert('Định dạng ngày bắt đầu học không đúng');
        return false;
    }
    if (ValidateDateField(df_ngayketthuchoc) == false) {
        alert('Định dạng ngày kết thúc học không đúng');
        return false;
    }
    if (ValidateDateField(df_NgayNhanBang) == false) {
        alert('Định dạng ngày nhận bằng không đúng');
        return false;
    }

    return true;
}

var ChuanHoaTen = function () {
    if (txt_hoten.getValue() != '') {
        var hoten = txt_hoten.getValue().toLowerCase().trim();
        var arrStr = hoten.split(' ');
        var rs = '';
        for (var i = 0; i < arrStr.length; i++) {
            var item = arrStr[i].trim();
            if (item != '') {
                var firstChar = item.substring(0, 1);
                rs += firstChar.toUpperCase() + item.slice(1, item.length) + ' ';
            }
        }
        txt_hoten.setValue(rs.trim());
    }
    return '';
}
/*
Reset các form
*/
var resetFormQuanHeGiaDinh = function () {
    btnUpdateQuanHeGiaDinh.show();
    btnCapNhatVaDongQHGD.show();
    btnUpdate.hide();
    txtQHGDHoTen.reset();
    cbQHGDGioiTinh.reset();
    txtQHGDNamSinh.reset();
    cbQuanHeGiaDinh.reset();
    txtQHGDNgheNghiep.reset();
    txtQHGDNoiLamViec.reset();
    txtQHGDGhiChu.reset();
    dfQHGDBatDauGiamTru.reset();
    dfQHGDKetThucGiamTru.reset();
}

var resetFormDeTai = function () {
    btnUpdateDeTai.show();
    btnEditDeTai.hide();
    btnCapNhatVaDongDeTai.show();
    txtDeTaiTenDeTai.reset();
    txtMaDeTai.reset();
    fufDeTaiTepTinDinhKem.reset();
    hdfDeTaiTepTinDinhKem.reset();
    txtDeTaiCapDeTai.reset(); txtDeTaiChuNhiemDeTai.reset(); txDeTaiTuCachThamGia.reset(); txtDeTaiTuNgay.reset();
    txtDeTaiDenNgay.reset(); txtDeTaiKetQua.reset(); txtDeTaiGhiChu.reset();
}

var resetKhaNang = function () {
    btnUpdateKhaNang.show();
    btnEditKhaNang.hide();
    btnCapNhatVaDongKhaNang.show();
    cbKhaNang.reset(); cbKhaNangXepLoai.reset(); txtKhaNangGhiChu.reset();
}

var ResetWdTaiSan = function () {
    cbTaiSan.reset(); tsDateField.reset(); tsTxtinhTrang.reset(); tsGhiChu.reset();
    txtTaiSanSoLuong.reset(); cbxDonViTinh.reset();
}
var CheckInputKhenThuong = function (el) {
    if (txtKhenThuongSoQuyetDinh.getValue().trim() == '') {
        alert('Bạn chưa nhập số quyết định');
        txtKhenThuongSoQuyetDinh.focus();
        return false;
    }
    if (cbLyDoKhenThuong.getValue().trim() == '') {
        alert('Bạn chưa chọn lý do khen thưởng');
        cbLyDoKhenThuong.focus();
        return false;
    }
    if (dfKhenThuongNgayQuyetDinh.getValue() == '') {
        alert('Bạn chưa chọn ngày quyết định');
        dfKhenThuongNgayQuyetDinh.focus();
        return false;
    }
    if (cbHinhThucKhenThuong.getValue().trim() == '') {
        alert('Bạn chưa chọn hình thức khen thưởng');
        cbHinhThucKhenThuong.focus();
        return false;
    }
    var size = 0;
    for (var num1 = 0; num1 < el.files.length; num1++) {
        var file = el.files[num1];
        size += file.size;
    }
    if (size > 1048576) {
        alert('Phần mềm chỉ hỗ trợ các tệp tin đính kèm nhỏ hơn 10MB');
        return false;
    }
    return true;
}
var ResetWdKinhNghiemLamViec = function () {
    txtGhiChuKinhNghiemLamViec.reset();
    txtLyDoThoiViec.reset();
    nbfMucLuong.reset();
    txtThanhTichTrongCongViec.reset();
    txt_vitriconviec.reset();
    dfKNLVDenNgay.reset();
    txt_noilamviec.reset();
    dfKNLVTuNgay.reset();
}

var ResetWdKhenThuong = function () {
    txtKhenThuongSoQuyetDinh.reset(); dfKhenThuongNgayQuyetDinh.reset(); cbLyDoKhenThuong.reset();
    cbHinhThucKhenThuong.reset(); txtKhenThuongSoTien.reset(); txtKhenThuongGhiCHu.reset();
    hdfKhenThuongNguoiQD.reset(); tgf_KhenThuong_NguoiRaQD.reset(); fufKhenThuongTepTinDinhKem.reset();
    hdfKhenThuongTepTinDinhKem.reset();
}

var ResetWdKyLuat = function () {
    txtKyLuatSoQD.reset(); dfKyLuatNgayQuyetDinh.reset(); cbLyDoKyLuat.reset();
    cbHinhThucKyLuat.reset(); txtKyLuatSoTien.reset(); txtKyLuatGhiChu.reset();
    tgfKyLuatNguoiQD.reset(); hdfKyLuatTepTinDinhKem.reset(); fufKyLuatTepTinDinhKem.reset();
}

var ResetWdQuaTrinhCongTac = function () {
    txtQTCTSoQD.reset(); hdfQTCTNguoiQuyetDinh.reset(); tgf_QTCTNguoiQuyetDinh.reset();
    dfQTCTNgayBatDau.reset(); dfQTCTNgayBatDau.setMinValue(); dfQTCTNgayBatDau.setMaxValue();
    cbCongTacQuocGia.reset();
    dfQTCTNgayQuyetDinh.reset(); dfQTCTNgayQuyetDinh.setMinValue(); dfQTCTNgayQuyetDinh.setMaxValue();
    dfQTCTNgayKetThuc.reset(); dfQTCTNgayKetThuc.setMinValue(); dfQTCTNgayKetThuc.setMaxValue()
    txtQTCTNoiDungCongViec.reset(); txtQTCTDiaDiemCT.reset(); txtQTCTNguoiLienQuan.reset();
    hdfQTCTTepTinDinhKem.reset(); fufQTCTTepTinDinhKem.reset(); txtCongTacGhiChu.reset();
}
var ResetWdQuaTrinhDieuChuyen = function () {
    txtQTDCSoQuyetDinh.reset(); hdfQTDCNguoiQuyetDinh.reset(); tgfQTDCNguoiQuyetDinh.reset();
    dfQTDCNgayCoHieuLuc.reset(); dfQTDCNgayQuyetDinh.reset(); dfQTDCNgayHetHieuLuc.reset();
    cbxQTDCBoPhanMoi.reset(); cbxQTDCChucVuMoi.reset(); cbxCongViecMoi.reset();
    hdfQTDCTepTinDinhKem.reset(); fufQTDCTepTinDinhKem.reset(); txtDieuChuyenGhiChu.reset();
}
var ResetWdTaiNanLaoDong = function () {
    TaiNan_dfNgayXayRa.reset(); TaiNan_txtLydo.reset(); TaiNan_txtDiaDiemXayRa.reset();
    TaiNan_txtThietHai.reset(); TaiNan_txtThuongTat.reset(); TaiNan_txtBoiThuong.reset();
    TaiNan_txtGhiChu.reset(); TaiNan_txtNgayBoiThuong.reset();
}

var resetWdTuCapNhat = function () {
    Update.show();
    btnEditKinhNghiem.hide();
    UpdateandClose.show();
    txt_noilamviec.reset();
    txt_vitriconviec.reset();
    txt_conviecdamnhiem.reset();
    dfKNLVTuNgay.reset();
    dfKNLVDenNgay.reset();
    txt_lydochuyen.reset();
}

var ResetWdQuaTrinhHocTap = function () {
    btnUpdateBangCap.show();
    btn_EditBangCap.hide();
    btnUpdateandCloseBangCap.show();
    txt_khoa.setValue('');
    df_ngaybatdauhoc.reset();
    df_ngayketthuchoc.reset();
    df_NgayNhanBang.reset();
    cbx_NoiDaoTaoBangCap.reset();
    cbx_hinhthucdaotaobang.reset();
    txt_khoa.reset();
    df_ngaybatdauhoc.reset();
    Chk_DaTotNghiep.reset();
    cbx_ChuyenNganhBangCap.reset();
    cbx_trinhdobangcap.reset();
    cbx_xeploaiBangCap.reset();
    df_ngayketthuchoc.reset();
    df_NgayNhanBang.reset();
    txtGhiChuChungChi.reset();
}

var resetWdChungChi = function () {
    btnUpdateChungChi.show();
    btnEditChungChi.hide();
    btnUpdateandCloseChungChi.show();
    df_NgayCap.reset(); df_NgayHetHan.reset();
    cbx_tenchungchi.reset();
    cbx_NoiDaoTao.reset();
    cbx_XepLoaiChungChi.reset();
    txtGhiChuChungChi.reset();
    //cbx_TrinhDoChungChi.reset();
}

var resetDaiBieu = function () {
    btnCapNhatDaiBieu.show();
    btnEditDaiBieu.hide();
    btnEditAndCloseDaiBieu.show();
    txtDBLoaiHinh.reset();
    dfDBTuNgay.reset();
    txtDBNhiemKy.reset();
    dfDBDenNgay.reset();
    txtDBGhiChu.reset();
}

var resetAttachFile = function () {
    txtFileName.reset(); txtGhiChu.reset(); file_cv.reset(); hdfAttachFile.reset();
    btnUpdateAtachFile.show();
    btnEditAttachFile.hide();
    btnCapNhatVaDongAttachFile.show();
}