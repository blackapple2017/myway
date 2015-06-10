var ValidateDateField = function (idDateField) {
    reg = /^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/;
    testdf = reg.test(idDateField.getRawValue());
    if (!testdf && idDateField.getRawValue() != '' && idDateField.getRawValue() != null) {
        idDateField.focus();
        return false;
    }
    return true;
}
var CheckSelectedRecordPrint = function (grid, Store) {
    if (hdfRecordID.getValue() == '') {
        alert('Bạn chưa chọn bản ghi nào');
        return false;
    }
    var s = grid.getSelectionModel().getSelections();
    var count = 0;
    for (var i = 0, r; r = s[i]; i++) {
        count++;
    }
    if (count > 1) {
        alert('Bạn chỉ được chọn một bản ghi');
        return false;
    }
    return true;
}
var checkInputThemMoiYCTD = function () {
    var yeuCau = cbDonViList.getValue();
    if (yeuCau == '') {
        alert('Bạn chưa chọn yêu cầu');
        return false;
    }

    var thaoTacNoiTuyen = cbThaoTac_MaThaoTac.getValue();
    if (thaoTacNoiTuyen == '') {
        alert('Bạn chưa chọn thao tác');
        return false;
    }

    var dapUng = mcbValueList_DapUng.getValue();
    if (dapUng == '') {
        alert('Bạn chưa chọn giá trị');
        return false;
    }

    var ngoaiTuyen = cbThaoTac_RecordRelation.getValue();
    if (ngoaiTuyen == '') {
        alert('Bạn chưa chọn thao tác ngoại tuyến');
        return false;
    }


    return true;
};
var checkInputNhanKHTD = function () {
    if (txt_NewID.getValue() == '') {
        alert('Bạn chưa nhập mã kế hoạch');
        return false;
    }
    return true;
};

var ResetpnlYCTuyenDung = function () {
    lbSoLuongTuyen.reset();
    lbSoVongPV.reset();
    lbChucVu.reset();
    lbCongViec.reset();
    lbBoPhan.reset();
    lbMucLuongToiThieu.reset();
    lbMucLuongToiDa.reset();
    lbKinhPhiDuTru.reset();
    lbThoiGianThuViec.reset();
    lbLyDoTuyenDung.reset();
    //lbYeuCauBangCap.reset();
    //lbYeuCauGioiTinh.reset();
    lbHanNopHoSo.reset();
    lbNgayBatDau.reset();
    lbNgayKetThuc.reset();
}

var LoadTableRelation = function () {
    ResetpnlYCTuyenDung();
    var selectedPanel = pnlYeuCauTuyenDung.getActiveTab().id;
    switch (selectedPanel) {
        case "pnlYCTuyenDung":
            var s = grp_KeHoachTuyenDung.getSelectionModel().getSelections();
            for (var i = 0, r; r = s[i]; i++) {
                lbSoLuongTuyen.setValue(r.data.SoLuongCanTuyen);
                lbSoVongPV.setValue(r.data.SoVongPhongVan);
                lbChucVu.setValue(r.data.TEN_CHUCVU);
                lbCongViec.setValue(r.data.TEN_CONGVIEC);
                lbBoPhan.setValue(r.data.TEN_DONVI);
                lbMucLuongToiThieu.setValue(r.data.MucLuongDuKienToiThieu);
                lbMucLuongToiDa.setValue(r.data.MucLuongDuKienToiDa);
                lbKinhPhiDuTru.setValue(r.data.KinhPhiDuTru);
                lbThoiGianThuViec.setValue(r.data.ThoiGianThuViec + ' tháng');
                lbLyDoTuyenDung.setValue(r.data.LyDoTuyen);
                lbHanNopHoSo.setValue(RenderDate(r.data.HanNopHoSo));
                lbNgayBatDau.setValue(RenderDate(r.data.NgayBatDau));
                lbNgayKetThuc.setValue(RenderDate(r.data.NgayKetThuc));
            }
            break;
        case "pnchiphituyendung":
            stChiPhiTuyenDung.reload();
            break;
        case "pnlMonThiTuyen":
            stSubjectList.reload();
            break;
        case "pnHoiDongTuyenDung":
            stCouncilRecruitment.reload();
            break;
        default:
            break;
    }
};
var RenderTimeJob = function (value, p, record) {
    if (value != null && value != '') {
        return "<span style='float:right;'>" + value + " tháng </span>";
    }
    return value;
}
var checkInputThemMoiKHTD = function () {
    if (txt_TenKeHoach.getValue().trim() == '') {
        alert('Bạn chưa nhập Tên kế hoạch');
        txt_TenKeHoach.focus();
        return false;
    }
    if (txt_SoLuongCanTuyen.getValue() == '') {
        alert('Bạn chưa nhập số lượng cần tuyển');
        txt_SoLuongCanTuyen.focus();
        return false;
    }
    if (cbx_MaCongViec.getValue() == '') {
        alert('Bạn chưa chọn công việc');
        cbx_MaCongViec.focus();
        return false;
    }
    if (cbx_Ma_DonVi.getValue() == '') {
        alert('Bạn chưa bộ phận');
        cbx_Ma_DonVi.focus();
        return false;
    }
    if (ValidateDateField(df_HanNopHoSo) == false) {
        alert('Định dạng ngày hạn nộp hồ sơ không đúng');
        df_HanNopHoSo.focus();
        return false;
    }
    if (ValidateDateField(df_NgayBatDau) == false) {
        alert('Định dạng ngày bắt đầu không đúng');
        df_NgayBatDau.focus();
        return false;
    }
    if (ValidateDateField(df_NgayKetThuc) == false) {
        alert('Định dạng ngày kết thúc không đúng');
        df_NgayKetThuc.focus();
        return false;
    }
    if (((df_NgayKetThuc.getValue() != '') && (df_HanNopHoSo.getValue() != '')) && (df_NgayKetThuc.getValue() < df_HanNopHoSo.getValue())) {
        alert('Hạn nộp hồ sơ phải trước hoặc trong ngày kết thúc');
        df_HanNopHoSo.focus();
        return false;
    }
    if (((df_NgayKetThuc.getValue() != '') && (df_NgayBatDau.getValue() != '')) && (df_NgayKetThuc.getValue() < df_NgayBatDau.getValue())) {
        alert('Ngày kết thúc phải sau ngày bắt đầu');
        df_NgayKetThuc.focus();
        return false;
    }
    return true;
}

var addKhoanChi = function () {
    var grid = gpCacKhoanChiPhi;
    grid.getRowEditor().stopEditing();
    grid.insertRecord(0, {
        TenChiPhi: "",
        SoTien: "",
        NguonChi: "",
        NgayChi: (new Date()).clearTime()
    });
    grid.getView().refresh();
    grid.getSelectionModel().selectRow(0);
    grid.getRowEditor().startEditing(0);
};

var removeKhoanChi = function () {
    var grid = gpCacKhoanChiPhi;
    grid.getRowEditor().stopEditing();
    var s = grid.getSelectionModel().getSelections();
    try {
        for (var i = 0, r; r = s[i]; i++) {
            gpStoreCacKhoanChiPhi.remove(r);
        }
    } catch (e) {
    }
};

var SetNguoiChamThi = function (value) {
    //  $(this).closest('').find('').val(value);
};

var nameNgoaiTuyenRender = function (value) {
    var r = yeuCauTuyenDungStoreThaoTacNgoaiTuyen.getById(value);
    if (Ext.isEmpty(r)) {
        return "";
    }
    return r.data.TEN;
};

var nameNoiTuyenRender = function (value) {
    var r = yeuCauTuyenDungStoreThaoTacNoiTuyen.getById(value);
    if (Ext.isEmpty(r)) {
        return "";
    }
    return r.data.TEN;
};

var checkInputWdChiPhi = function () { return true; };

var hideWdAddRequest = function () { return true; };



//Load dữ liệu ở combobox trong window thêm/sửa kế hoạch đào tạo
var LoadDataInCombo = function () {
    if (cbxChucVu.store.getCount() == 0) cbxChucVu_Store.reload();
    if (cbxCongViec.store.getCount() == 0) cbxCongViec_Store.reload();
    if (cbxPhongBan.store.getCount() == 0) cbxPhongBan_Store.reload();
};

var enterKeyPressHandler = function (f, e) {
    if (e.getKey() == e.ENTER) {
        PagingToolbar1.pageIndex = 0;
        PagingToolbar1.doLoad();
    }
    if (txtSearch.getValue() != '') {
        this.triggers[0].show();
    }
    if (txtSearch.getValue() == '') {
        this.triggers[0].hide();
    }
};

var getSelectedIndexRow = function () {
    var record = grp_KeHoachTuyenDung.getSelectionModel().getSelected();
    var index = grp_KeHoachTuyenDung.store.indexOf(record);
    if (index == -1)
        return 0;
    return index;
};

var CheckSelectKeHoach = function (hdfRecordID) {
    if (hdfRecordID.getValue() == '') {
        Ext.Msg.alert('Thông báo', 'Bạn chưa chọn kế hoạch nào !');
        return false;
    }
    return true;
};

var addUpdatedRecord = function (id, tenkehoach, congviec, soluong, phongban, ngaybd, ngaykt, kinhphi, trangthai) {
    var rowindex = getSelectedIndexRow();
    //xóa bản ghi cũ
    var s = grp_KeHoachTuyenDung.getSelectionModel().getSelections();
    for (var i = 0, r; r = s[i]; i++) {
        store_KeHoachTuyenDung.remove(r);
        store_KeHoachTuyenDung.commitChanges();
    }
    //Thêm bản ghi đã update
    grp_KeHoachTuyenDung.insertRecord(rowindex, {
        ID: id,
        TenKeHoach: tenkehoach,
        TEN_CONGVIEC: congviec,
        SoLuongCanTuyen: soluong,
        TEN_PHONG: phongban,
        NgayBatDau: ngaybd,
        NgayKetThuc: ngaykt,
        KinhPhiDuTru: kinhphi,
        TrangThaiXuLy: trangthai
    });
    grp_KeHoachTuyenDung.getView().refresh();
    grp_KeHoachTuyenDung.getSelectionModel().selectRow(rowindex);
    store_KeHoachTuyenDung.commitChanges();
};

var addRecord = function (id, tenkehoach, congviec, soluong, phongban, ngaybd, ngaykt, kinhphi, trangthai) {
    var rowindex = getSelectedIndexRow();
    grp_KeHoachTuyenDung.insertRecord(rowindex, {
        ID: id,
        TenKeHoach: tenkehoach,
        TEN_CONGVIEC: congviec,
        SoLuongCanTuyen: soluong,
        TEN_PHONG: phongban,
        NgayBatDau: ngaybd,
        NgayKetThuc: ngaykt,
        KinhPhiDuTru: kinhphi,
        TrangThaiXuLy: trangthai
    });
    grp_KeHoachTuyenDung.getView().refresh();
    grp_KeHoachTuyenDung.getSelectionModel().selectRow(rowindex);
    store_KeHoachTuyenDung.commitChanges();
};

var resetForm = function () {
    txt_TenKeHoach.reset();
    txt_ThoiGianThuViec.reset();
    txt_MucLuongDuKienToiThieu.reset();
    txt_MucLuongDuKienToiDa.reset();
    txt_SoVongPhongVan.reset();
    txt_SoLuongCanTuyen.reset();
    txt_GhiChu.reset();
    txt_KinhPhiDuTru.reset();
    df_HanNopHoSo.reset();
    df_NgayBatDau.reset();
    df_NgayKetThuc.reset();
    hdfLyDoTuyenDung.reset();
    cbx_MaChucVu.reset();
    cbx_MaCongViec.reset();
    cbx_Ma_DonVi.reset();
    cbx_LyDoTuyenDung.reset();
    hdfMaChucVu.reset();
    hdfMaCongViec.reset();
    hdfMaDonVi.reset();
    btnCapNhatKeHoachTuyenDung.show();
    btnEditKeHoachTuyenDung.hide();
    btnCapNhat_DongLaiKHTD.show();
    txt_TenKeHoach.focus();
};

var setValueWdKeHoachTuyenDung = function () {
    var data = checkboxSelection.getSelected().data;
    if (data == null) {
        return;
    }    
    txt_TenKeHoach.setValue(data.TenKeHoach);
    txt_ThoiGianThuViec.setValue(data.ThoiGianThuViec);
    txt_MucLuongDuKienToiThieu.setValue(data.MucLuongDuKienToiThieu);
    txt_MucLuongDuKienToiDa.setValue(data.MucLuongDuKienToiDa);
    txt_SoVongPhongVan.setValue(data.SoVongPhongVan);
    txt_SoLuongCanTuyen.setValue(data.SoLuongCanTuyen);
    txt_GhiChu.setValue(data.GhiChu);
    txt_KinhPhiDuTru.setValue(data.KinhPhiDuTru);
    df_HanNopHoSo.setValue(RenderDate(data.HanNopHoSo, null, null));
    df_NgayBatDau.setValue(RenderDate(data.NgayBatDau, null, null));
    df_NgayKetThuc.setValue(RenderDate(data.NgayKetThuc, null, null));
    cbx_MaChucVu.setValue(data.TEN_CHUCVU);
    cbx_MaCongViec.setValue(data.TEN_CONGVIEC);
    cbx_Ma_DonVi.setValue(data.TEN_DONVI);
    cbx_LyDoTuyenDung.setValue(data.LyDoTuyen);
    hdfLyDoTuyenDung.setValue(data.MaLyDoTuyen);
    hdfMaChucVu.setValue(data.MaChucVu);
    hdfMaCongViec.setValue(data.MaCongViec);
    hdfMaDonVi.setValue(data.MA_DONVI);
    btnCapNhatKeHoachTuyenDung.hide();
    btnEditKeHoachTuyenDung.show();
    btnCapNhat_DongLaiKHTD.hide();
    wdInsertKeHoachTuyenDung.show();
}

var ConvertStringToNumberFormart = function (inputControl) {
    try {
        var value = inputControl.getValue();
        if (value == null)
            return "";
        var l = (value + "").length - 3;
        var s = value + "";
        var rs = "";
        var count = 0;
        for (var i = l - 1; i >= 0; i--) {
            count++;
            if (count == 3) {
                rs = "," + s.charAt(i) + rs;
                count = 0;
            }
            else {
                rs = s.charAt(i) + rs;
            }
        }
        if (rs.charAt(0) == ',') {
            inputControl.setValue(rs.substring(1, rs.length));
        }
        inputControl.setValue(rs);
    } catch (e) {

    }
};

var ReloadStoreDetail = function () {
    var tab = pnlYeuCauTuyenDung.getActiveTab();
    if (tab == null)
        return;
    var tabTitle = tab.title;
    switch (tabTitle) {
        case "Các khoản chi phí":
            stChiPhiTuyenDung.reload();
            break;
        case "Các môn thi tuyển":
            stSubjectList.reload();
            break;
        case "Hội đồng tuyển dụng":
            stCouncilRecruitment.reload();
            break;
    }
};
var CheckWdCacKhoanChiPhi = function () {
    if (txtTenKhoanChiPhi.getValue().trim() == '') {
        alert('Bạn chưa nhập vào tên khoản chi');
        txtTenKhoanChiPhi.focus();
        return false;
    }
    if ((dfNgayChi.getValue() != '') && (ValidateDateField(dfNgayChi) == false)) {
        alert('Định dạng ngày chi không đúng');
        dfNgayChi.focus();
        return false;
    }
    if (CheckNumber('0'+txtSoTienChiPhi.getValue()) == true) {
        alert('Định dạng số tiền không đúng');
        txtSoTienChiPhi.focus();
        return false;
    }

    return true;
}
var setValueWdCacKhoanChiPhi = function () {
    var data = RowSelectionModel_CPTD.getSelected().data;
    if (data == null) {
        return;
    }
    txtTenKhoanChiPhi.setValue(data.TenChiPhi);
    txtNguonChi.setValue(data.NguonChi);
    txtSoTienChiPhi.setValue(data.SoTien);
    txtGhiChuCacKhoanChi.setValue(data.GhiChu);
    dfNgayChi.setValue(RenderDate(data.NgayChi, null, null));
}
var resetWdCacKhoanChiPhi = function () {
    btnCapNhatChiPhi.show();
    btnCapNhatVaDongLaiChiPhi.show();
    btnEditCapNhatChiPhi.hide();
    txtTenKhoanChiPhi.reset();
    txtNguonChi.reset();
    txtSoTienChiPhi.reset();
    dfNgayChi.reset();
    txtGhiChuCacKhoanChi.reset();
    wdCacKhoanChiPhi.setTitle("Thêm mới các khoản chi phí");
    txtTenKhoanChiPhi.focus();
}
var CheckNumber = function (value) {
    var a = isNaN(value);
    return a;
}
var checkInputWdMonThi = function () {
    if (hdfMaMonThi.getValue() == '') {
        alert('Bạn chưa chọn môn thi');
        cbMaMonThi.focus();
        return false;
    }
    if (txt_TrongSo.getValue() == '') {
        alert('Bạn chưa nhập trọng số của môn thi');
        txt_TrongSo.focus();
        return false;
    }
    if (CheckNumber(txt_TrongSo.getValue()) == true) {
        alert('Định dạng trọng số không đúng');
        txt_TrongSo.focus();
        return false;
    } 
    if (txt_DiemDat.getValue() == '') {
        alert('Bạn chưa nhập vào điểm yêu cầu của môn thi');
        txt_DiemDat.focus();
        return false;
    }
    if (CheckNumber(txt_DiemDat.getValue()) == true) {
        alert('Định dạng điểm đạt không đúng');
        txt_DiemDat.focus();
        return false;
    }
    if (cbb_NguoiChamThi.getValue() == '') {
        alert('Bạn chưa chọn cán bộ chấm thi');
        cbb_NguoiChamThi.focus();
        return false;
    }
    if (txt_Vong.getValue() == '') {
        alert('Bạn chưa nhập vào môn thi này diễn ra ở vòng thi nào');
        txt_Vong.focus();
        return false;
    }

    return true;
}
var resetWdMonThi = function () {
    cbMaMonThi.reset();
    txt_TrongSo.reset();
    txt_DiemDat.reset();
    txt_Vong.reset();
    cbb_NguoiChamThi.reset();
    txt_GhiChuMonThi.reset();
    hdfMaMonThi.reset();
    hdfNguoiChamThi.reset();
    btnAddSubjectList.show();
    btnEditSubjectList.hide();
    btnAddAndCloseSubjectList.show();
    cbMaMonThi.focus();
}
var setValueWdMonThi = function () {
    var data = RowSelectionModel2.getSelected().data;
    if (data == null) {
        return;
    }
    cbMaMonThi.setValue(data.TenMon);
    txt_TrongSo.setValue(data.TrongSo);
    txt_DiemDat.setValue(data.DiemDat);
    txt_GhiChuMonThi.setValue(data.GhiChu);
    txt_Vong.setValue(data.Vong);
    cbb_NguoiChamThi.setValue(data.HO_TEN);
    hdfMaMonThi.setValue(data.MaMonThi);
    hdfNguoiChamThi.setValue(data.NguoiCham);
}
var checkInputWdHoiDong = function () {
    if (hdfGiamKhao.getValue() == '') {
        alert('Bạn chưa chọn tên giám khảo');
        cbx_GiamKhao.focus();
        return false;
    }
}
var resetWdHoiDong = function () {
    cbx_GiamKhao.reset();
    txt_VongCham.reset();
    txtNoteHoiDong.reset();
    hdfGiamKhao.reset();
    btnAddGiamKhao.show();
    btnAddAndCloseGiamKhao.show();
    btnEditGiamKhao.hide();
    cbx_GiamKhao.focus();
}
var setValueWdHoiDong = function () {
    var data = RowSelectionModel1.getSelected().data;
    if (data == null) {
        return;
    }
    cbx_GiamKhao.setValue(data.HO_TEN);
    txt_VongCham.setValue(data.VongThi);
    txtNoteHoiDong.setValue(data.Note);
    hdfGiamKhao.setValue(data.PrKeyHoSo);
}
var resetButtonAfterDelete = function () {
    btnEditKHTD.disable();
    btnDeleteKHTD.disable();
    btnAddRequest.disable();
    btnAddChiPhi.disable();
    btnEditChiPhi.disable();
    btnDeleteChiPhi.disable();
    btnAddCouncilRecruitment.disable();
    btnEditCouncilRecruitment.disable();
    btnDeleteCouncilRecruitment.disable();
    btnAddSubject.disable();
    btnEditSubject.disable();
    btnDeleteSubject.disable();
    hdfRecordID.reset();
    LoadTableRelation();
}
var resetButtonAfterDeleteSubject = function () {
    btnEditSubject.disable();
    btnDeleteSubject.disable();
    hdfCacMonThiTuyen.reset();
}
var resetButtonAfterDeleteHoiDong = function () {
    hdfCouncilRecruitment.reset();
    btnEditCouncilRecruitment.disable();
    btnDeleteCouncilRecruitment.disable();
}
var resetButtonAfterDeleteChiPhi = function () {
    btnEditChiPhi.disable();
    btnDeleteChiPhi.disable();
    hdfChiPhiID.reset();
}
var onKeyUp = function (field) {
    var v = this.processValue(this.getRawValue()),
                field;
    if (this.startDateField) {
        field = Ext.getCmp(this.startDateField);
        field.setMaxValue();
        this.dateRangeMax = null;
    } else if (this.endDateField) {
        field = Ext.getCmp(this.endDateField);
        field.setMinValue();
        this.dateRangeMin = null;
    }
    field.validate();
};