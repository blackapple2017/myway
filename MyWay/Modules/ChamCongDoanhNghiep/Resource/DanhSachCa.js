var CheckInputDanhSachCaLamViec = function () {
    if (txtMaCa.getValue() == '') {
        alert('Bạn chưa nhập mã ca');
        txtMaCa.focus();
        return false;
    }
    if (txtTenCa.getValue() == '') {
        alert('Bạn chưa nhập tên ca');
        txtTenCa.focus();
        return false;
    }
    //if (txtTongSoGio.getValue() == '') {
    //    alert('Bạn chưa nhập tổng số giờ');
    //    txtTongSoGio.focus();
    //    return false;
    //}
    if (cbxLoaiCa.getValue() == '' || cbxLoaiCa.getValue() == null) {
        alert('Bạn chưa nhập loại ca làm việc');
        cbxLoaiCa.focus();
        return false;
    }
    if (tfBatDauCa.getValue() == '') {
        alert('Bạn chưa nhập giờ vào ca');
        tfBatDauCa.focus();
        return false;
    }
    if (tfKetThucCaSau.getValue() == '') {
        alert('Bạn chưa nhập giờ kết thúc ca');
        tfKetThucCaSau.focus();
        return false;
    }
    //if (tfDauCaTu.getValue() == '') {
    //    alert('Bạn chưa nhập giờ quẹt thẻ đầu ca');
    //    tfDauCaTu.focus();
    //    return false;
    //}
    //if (tfDauCaDen.getValue() == '') {
    //    alert('Bạn chưa nhập giờ quẹt thẻ đầu ca');
    //    tfDauCaDen.focus();
    //    return false;
    //}
    //if (tfCuoiCaTu.getValue() == '') {
    //    alert('Bạn chưa nhập giờ quẹt thẻ cuối ca');
    //    tfCuoiCaTu.focus();
    //    return false;
    //}
    //if (tfCuoiCaDen.getValue() == '') {
    //    alert('Bạn chưa nhập giờ quẹt thẻ cuối ca');
    //    tfCuoiCaDen.focus();
    //    return false;
    //}
    return true;
}
var compareTime
var resetForm = function () {
    txtMaCa.reset(); txtTenCa.reset(); txtPhuCapCa.reset(); txtLuongCuaCa.reset();
    tfBatDauCa.reset(); tfNghiNuaCaDau.reset();
    // tfBatDauLamThemDauGio.reset();
    tfBatDauCaSau.reset(); tfKetThucCaSau.reset();
    //tfBatDauLamThemCuoiGio.reset();
    chkRaNgoaiKhongBiTruGio.reset(); tfDauCaTu.reset(); tfDauCaDen.reset();
    tfGiuaCaRaTu.reset(); tfGiuaCaRaDen.reset(); tfGiuaCaVaoTu.reset();
    tfGiuaCaVaoDen.reset(); tfCuoiCaTu.reset(); tfCuoiCaDen.reset();
    txtSoPhutChoPhepDiMuon.reset(); txtSoPhutChoPhepVeSom.reset(); chkDangSuDung.reset();
    txtMaCa.enable(); txtTongSoGio.reset();
    cbxLoaiCa.reset();
}
var CheckInputQuyTacChamCong = function () {
    if (tfTuGio.getValue() == '') {
        alert('Bạn chưa nhập giờ bắt đầu');
        tfTuGio.focus();
        return false;
    }
    if (tfDenGio.getValue() == '') {
        alert('Bạn chưa nhập giờ kết thúc');
        tfDenGio.focus();
        return false;
    }
    if (cbxLoaiNgay.getValue() == '') {
        alert('Bạn chưa chọn loại ngày làm việc');
        cbxLoaiNgay.focus();
        return false;
    }
    if (txtHeSoLuong.getValue().trim() == '') {
        alert('Bạn chưa nhập hệ số lương');
        txtHeSoLuong.focus();
        return false;
    }
    if (txtOrder.getValue() == '') {
        alert('Bạn chưa nhập vào thứ tự ca trong ngày');
        txtOrder.focus();
        return false;
    }
    return true;
}
var ResetQuyTacLamThemGio = function () {
    tfTuGio.reset(); tfDenGio.reset(); cbxLoaiNgay.reset(); txtHeSoLuong.reset(); txtOrder.reset();
}
var ResetWdConfig = function () {
    chkGioVao.reset(); chkGioRa.reset(); chkSoGioLam.reset(); chkChoPhepDiMuon.reset();
    chkChoPhepVeSom.reset(); chkBatDauTinhLamThemDauGio.reset(); chkBatDauTinhLamThemCuoiGio.reset();
    chkApDungTuNgay.reset(); chkApDungDenNgay.reset(); chkQuetTheDauCa.reset(); chkLoaiCa.reset();
    chkQuetTheNghiDauCa.reset(); chkQuetTheVaoCaSau.reset(); chkQuetTheCuoiCa.reset();
    chkPhuCapCa.reset(); chkMucLuongCa.reset(); chkNgayApDung.reset(); chkNgayTao.reset();
}
var RenderTime = function (batDau, ketThuc) {
    var rs = '';
    if (batDau != '') {
        rs += '<span style="color:blue;font-weight : bold;">' + batDau.replace(':', 'h') + '</span>';
    }
    if (ketThuc != '') {
        rs += ' đến <span style="color:blue;font-weight : bold;">' + ketThuc.replace(':', 'h') + '</span>';
    }
    return rs;
}
var RenderPhut = function (value) {
    if (value == null || value == '')
        return 0;
    return value + ' phút';
}
var RenderGio = function (value) {
    if (value != '')
        return value.replace(':', 'h');
}
var RenderVND = function (value, p, record) {
    if (value == null || value.length == 0)
        return "";
    var l = (value + "").length;
    var s = value + "";
    var rs = "";
    var count = 0;
    for (var i = l - 1; i > 0; i--) {
        count++;
        if (count == 3) {
            rs = "." + s.charAt(i) + rs;
            count = 0;
        }
        else {
            rs = s.charAt(i) + rs;
        }
    }
    rs = s.charAt(0) + rs;
    if (rs.replace(".", "").trim() * 1 == 0) {
        return "";
    }
    return rs + " VNĐ";
}
var RenderMultiDataGrid = function (value, p, record) {
    var rs = '', num = 0;
    if (value == '' || value == null)
        return '';
    var arr = value.split('##');
    for (var i = 0; i < arr.length - 1; i++) {
        if (num == (arr.length - 2)) {
            rs += "<div class='last_template'>" + arr[i] + "</div>";
        }
        else {
            rs += "<div class='first_template'>" + arr[i] + "</div>"; ;
        }
        num++;
    }
    return rs;
}
var enterKeyPressHandler = function (f, e) {
    if (e.getKey() == e.ENTER) {
        grp_DanhSachCa_Store.reload();
    }
}
var RemoveItemOnGrid = function (grid, Store) {
    Ext.Msg.confirm('Xác nhận', 'Bạn có chắc chắn muốn xóa không ?', function (btn) {
        if (btn == "yes") {
            try {
                grid.getRowEditor().stopEditing();
            } catch (e) {

            }
            var s = grid.getSelectionModel().getSelections();
            for (var i = 0, r; r = s[i]; i++) {
                Store.remove(r);
                Store.commitChanges();
                Ext.net.DirectMethods.DeleteRecord(r.data.ID);
                try {
                    btnSua.disable();
                    btnXoa.disable();
                }
                catch (e) { }
            }
        }
    });
}
var RemoveItemOnGridQuyTac = function (grid, Store) {
    Ext.Msg.confirm('Xác nhận', 'Bạn có chắc chắn muốn xóa không ?', function (btn) {
        if (btn == "yes") {
            try {
                grid.getRowEditor().stopEditing();
            } catch (e) {

            }
            var s = grid.getSelectionModel().getSelections();
            for (var i = 0, r; r = s[i]; i++) {
                Store.remove(r);
                Store.commitChanges();
                Ext.net.DirectMethods.DeleteRecordQuyTac(r.data.ID);
                try {
                    btnSua.disable();
                    btnXoa.disable();
                }
                catch (e) { }
            }
        }
    });
}

var CheckSelectedRow = function (grid) {
    debugger;
    var s = grid.getSelectionModel().getSelections();
    var count = 0;
    for (var i = 0, r; r = s[i]; i++) {
        count++;
    }
    if (count == 0) {
        alert('Bạn chưa chọn bản ghi nào!');
        return false;
    }
    return true;
}
var CheckSelectedRows = function (grid) {
    var s = grid.getSelectionModel().getSelections();
    var count = 0;
    for (var i = 0, r; r = s[i]; i++) {
        count++;
    }
    if (count == 0) {
        alert('Bạn chưa chọn bản ghi nào nào!');
        return false;
    }
    if (count > 1) {
        alert('Bạn chỉ được chọn một bản ghi');
        return false;
    }
    return true;
}
var rendererLoaiNgay = function (value, p, record) {
    switch (value) {
        case 'EveryDay':
            return 'Ngày thường';
            break;
        case 'Saturday':
            return 'Thứ 7';
            break;
        case 'Sunday':
            return 'Chủ nhật';
            break;
        case 'Holiday':
            return 'Ngày lễ';
            break;
    }
}
var afterEdit = function (e) {
    grp_QuyTacLamThemGio_Store.commitChanges();
    if (e.field == 'LoaiNgay') {
        Ext.net.DirectMethods.AfterEdit_QuyTacLamThemGio(e.record.data.ID, e.value);
    }
    // Ext.net.DirectMethods.LoadTotalInDay();
};