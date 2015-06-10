var CheckInputDiemPhongVan = function () {
    if (txtDiemSo.getValue() == '' && txtDiemSo.getValue() == '' &&
    cboMonThi.getValue() == '') {
        Ext.Msg.alert('Thông báo', 'Bạn bắt buộc phải nhập thông tin điểm số và môn thi !');
        return false;
    }
    return true;
}

var getDiemDat = function (value, store) {
    var r = store.getById(value);

    if (Ext.isEmpty(r)) {
        return "";
    }
    return r.data.DIEM_DAT;
}
// stop
var triggerHandler = function (el, trigger, index) {
    switch (index) {
        case 0:
            triggerMark.triggers[0].hide();
            triggerMark.setValue('');
            break;
        case 1:
            alert('Hiện ra dialog nhập điểm số, >,<');
            // Window1.show();
            break;
    }
}
var enterKeyPressHandler = function (f, e) {
    if (e.getKey() == e.ENTER) {
        Store1.reload();
    }
}
var ResetwdChuyenLichHenPV = function () {
    df_NgayPhongVan.reset();
    //cbx_VongPhongVan.reset();
    txt_ThuTuPhongVan.reset();
    tf_GioPhongVan.reset();
    txt_ghichu.reset();
}
var ResetwdChamDiemNhanXet = function () {
    var data = RowSelectionModel1.getSelected().data;
    if (data == null) {
        return;
    }
    txtDiemSo.reset();
    txtNhanXet.reset();
    txt_VongPhongVan.setValue(data.VONG_PV);
    cboMonThi.reset();
    cbb_NguoiChamThi.reset();
    dfNgayThiTuyen.reset();
    hdfNguoiChamThi.reset();
    hdfTrangThaiLuaChon.reset();
    txt_VongPhongVan.disabled = true;
}
var KiemTraDuLieuLichHenPV = function () {
    if (df_NgayPhongVan.getValue() == '' || df_NgayPhongVan.getRawValue() == null) {
        alert('Bạn chưa nhập ngày phỏng vấn');
        df_NgayPhongVan.focus();
        return false;
    }
    //if (cbx_VongPhongVan.getValue().trim() == '') {
    //    alert('Bạn chưa chọn vòng phỏng vấn !');
    //    cbx_VongPhongVan.focus();
    //    return false;
    //}
}
var CheckInPutDoiLichPhongVan = function () {
    if (txtRoiLich_VongThi.getValue() == '' || numfGio.getValue() == '' ||
    txtRoiLich_ThuTuPhongVan.getValue() == '') {
        Ext.Msg.alert('Thông báo', 'Bạn bắt buộc phải nhập tất cả thông tin');
        return false;
    }
    return true;

}
var CheckSelectedRecordPrint = function (grid, Store) {
    if (hdfRecordID.getValue() == '') {
        alert('Bạn chưa chọn ứng viên nào');
        return false;
    }

    var s = grid.getSelectionModel().getSelections();
    var count = 0;
    for (var i = 0, r; r = s[i]; i++) {
        count++;
    }
    if (count > 1) {
        alert('Bạn chỉ được chọn một nhân viên');
        return false;
    }
    return true;
}
var RenderDate = function (value) {
    try {
        if (value == null) return "";
        // kiểm tra có phải kiểu ngày tháng VN ko 
        if (value.indexOf("SA") != -1 || value.indexOf("CH") != -1) {
            var d = value.split(' ')[0];
            var year = d.split('/')[2];
            if (year == "0001" || year == "1900") {
                return "";
            }
            return d;
        }
        //nếu ko phải thì render bình thường
        value = value.replace(" ", "T");
        var temp = value.split("T");
        var date = temp[0].split("-");
        var dateStr = date[2] + "/" + date[1] + "/" + date[0];
        if (date[0] == "1900" || date[0] == "0001") {
            return "";
        }
        if (dateStr != "") {
            return dateStr;
        }
    } catch (e) {

    }
}
var setValuewdChuyenLichHenPV = function () {
        var data = RowSelectionModel1.getSelected().data;
        if (data == null) {
            return;
        }
        df_NgayPhongVan.setValue(RenderDate(data.NGAY_HEN));
        tf_GioPhongVan.setValue(data.GIO_HEN);
        txt_ThuTuPhongVan.setValue(data.THU_TU_PV);
        txt_ghichu.setValue(data.GHI_CHU);    
}
var setValuewdChamDiemNhanXet = function () {
    var data = RowSelectionModel2.getSelected().data;
    if (data == null) {
        return;
    }    
    txt_VongPhongVan.setValue(data.VONG_PV);
    dfNgayThiTuyen.setValue(RenderDate(data.NGAY_THI));
    cboMonThi.setValue(data.MA_MON_THI); 
    txtDiemSo.setValue(data.DIEM); 
    txtNhanXet.setValue(data.NHAN_XET);
    hdfNguoiChamThi.setValue(data.MA_NGUOI_CHAM)
    cbb_NguoiChamThi.setValue(data.TEN_NGUOI_CHAM);    
}