var resetForm = function () {
    cbonhanvien.reset(); dfNgayTamUng.reset();
    dfNgayTamUng.setMaxValue(); dfNgayTamUng.setMinValue();
//    dfThoiHanTamUng.reset(); dfThoiHanTamUng.setMaxValue();
//    dfThoiHanTamUng.setMinValue(); txtLyDoTamUng.reset();
    txtSoTien.reset();
    txtSoTienDaTra.reset();
}
var checkInput = function () {
    if (!cbonhanvien.getValue()) {
        alert('Bạn chưa chọn cán bộ');
        cbonhanvien.focus();
        return false;
    }
    if (!dfNgayTamUng.getValue()) {
        alert('Bạn chưa chọn ngày tạm ứng');
        dfNgayTamUng.focus();
        return false;
    }
//    if (!dfThoiHanTamUng.getValue()) {
//        alert('Bạn chưa chọn thời hạn thanh toán');
//        dfThoiHanTamUng.focus();
//        return false;
//    }
    if (!txtSoTien.getValue()) {
        alert('Bạn chưa nhập số tiền');
        txtSoTien.focus();
        return false;
    }
    if (txtSoTienDaTra.getValue() * 1 > txtSoTien.getValue() * 1) {
        alert('Số tiền đã trả lớn hơn số tiền tạm ứng');
        txtSoTien.focus();
        return false;
    }
    return true;
}

var getSelectedIndexRow = function () {
    var record = grpListEmployee.getSelectionModel().getSelected();
    var index = grpListEmployee.store.indexOf(record);
    if (index == -1)
        return 0;
    return index;
}

var addRecord = function (pr_keyhoso, ma_cb, ho_ten, ten_donvi, ngaytamung, thanhtoan, lydotamung, sotien, datra) {
    var rowindex = getSelectedIndexRow();
    grpListEmployee.insertRecord(rowindex, {
        PrkeyHoSo: pr_keyhoso,
        MA_CB: ma_cb,
        HO_TEN: ho_ten,
        TEN_DONVI: ten_donvi,
        NgayTamUng: ngaytamung,
        NgayThanhToan: thanhtoan,
        LyDoTamUng: lydotamung,
        SoTien: sotien,
        SoTienDaTra: datra
    });
    grpListEmployee.getView().refresh();
    grpListEmployee.getSelectionModel().selectRow(rowindex);
    grpListEmployeeStore.commitChanges();
}

addUpdatedRecord = function (pr_keyhoso, ma_cb, ho_ten, ten_donvi, ngaytamung, thanhtoan, lydotamung, sotien, datra) {
    var rowindex = getSelectedIndexRow();
    var prkey = 0;
    //xóa bản ghi cũ
    var s = grpListEmployee.getSelectionModel().getSelections();
    for (var i = 0, r; r = s[i]; i++) {
        prkey = r.data.PR_KEY;
        grpListEmployeeStore.remove(r);
    }
    //Thêm bản ghi đã update
    grpListEmployee.insertRecord(rowindex, {
        PrkeyHoSo: pr_keyhoso,
        MA_CB: ma_cb,
        HO_TEN: ho_ten,
        TEN_DONVI: ten_donvi,
        NgayTamUng: ngaytamung,
        NgayThanhToan: thanhtoan,
        LyDoTamUng: lydotamung,
        SoTien: sotien,
        SoTienDaTra: datra
    });
    grpListEmployee.getView().refresh();
    grpListEmployee.getSelectionModel().selectRow(rowindex);
}

var deleteEmployee = function (grid) {
    var s = grid.getSelectionModel().getSelections();
    if (s.length == 0) {
        alert('Bạn chưa chọn cán bộ nào');
        return false;
    }
    var count = 0;
    var num = hdfSelectedEmployee.getValue();
    for (var i = 0, r; r = s[i]; i++) {
        grid.store.remove(s[i]);
        count++;
    }
    num -= count;
    hdfSelectedEmployee.setValue(num);
    return true;
}
var setRecord = function (columnName, value) {
    var total = hdfSelectedEmployee.getValue();
    if (total == 0) {
        alert('Bạn chưa chọn cán bộ nào');
        return;
    }
    if (value == null || value == '') {
        alert('Bạn chưa nhập giá trị');
        return;
    }
    for (var i = 0; i < total; i++) {
        grpListEmployee.getSelectionModel().selectRow(i, true);
        var record = grpListEmployee.getSelectionModel().getSelected();
        // update data for record
        record.set(columnName, value);
    }
}

var updateRecord = function (grid) {
    if (dfNgayTamUngHL.getValue() == null || dfNgayTamUngHL.getValue() == '') {
        alert('Bạn chưa nhập ngày tạm ứng');
        dfNgayTamUngHL.focus();
        return false;
    }
    if (dfNgayThanhToanHL.getValue() == null || dfNgayThanhToanHL.getValue() == '') {
        alert('Bạn chưa nhập hạn thanh toán');
        dfNgayThanhToanHL.focus();
        return false;
    }
    if (txtSoTienHL.getValue() == '') {
        alert('Bạn chưa nhập số tiền');
        txtSoTienHL.focus();
        return false;
    }
    if (txtDaTra.getValue() != '' && txtDaTra.getValue() > txtSoTienHL.getValue()) {
        alert('Số tiền thanh toán không được lớn hơn số tiền phải trả');
        txtDaTra.focus();
        return false;
    }
    var soTien = txtSoTienHL.getValue();
    var daThanhToan = txtDaTra.getValue();
    var lyDoTU = txtLyDoHL.getValue();

    // datetime
    var tmp = new Date(dfNgayTamUngHL.getValue());
    var ngayTamUng;
    if (!isNaN(tmp))
        ngayTamUng = tmp;
    else
        ngayTamUng = 0;
    var tmp2 = new Date(dfNgayThanhToanHL.getValue());
    var ngayThanhToan;
    if (!isNaN(tmp2))
        ngayThanhToan = tmp2;
    else
        ngayThanhToan = 0;
    try {
        // update data
        var record = grid.getSelectionModel().getSelected();
        // update data for record
        addUpdatedRecord(record.data.PrkeyHoSo, record.data.MA_CB, record.data.HO_TEN, record.data.TEN_DONVI, ngayTamUng, ngayThanhToan, lyDoTU, soTien, daThanhToan);
    }
    catch (e) {
        alert('Bạn chưa chọn cán bộ nào');
    }
}

var updateAllRecord = function (grid) {
    if (dfNgayTamUngHL.getValue() == null || dfNgayTamUngHL.getValue() == '') {
        alert('Bạn chưa nhập ngày tạm ứng');
        dfNgayTamUngHL.focus();
        return false;
    }
    if (dfNgayThanhToanHL.getValue() == null || dfNgayThanhToanHL.getValue() == '') {
        alert('Bạn chưa nhập hạn thanh toán');
        dfNgayThanhToanHL.focus();
        return false;
    }
    if (txtSoTienHL.getValue() == '') {
        alert('Bạn chưa nhập số tiền');
        txtSoTienHL.focus();
        return false;
    }
    if (txtDaTra.getValue() != '' && txtDaTra.getValue() > txtSoTienHL.getValue()) {
        alert('Số tiền thanh toán không được lớn hơn số tiền phải trả');
        txtDaTra.focus();
        return false;
    }
    Ext.Msg.confirm('Xác nhận', 'Thông tin tạm ứng sẽ được cập nhật cho tất cả cán bộ trong danh sách. Bạn có chắc chắn muốn thực hiện không?', function (btn) {
        if (btn == "yes") {
            var soTien = txtSoTienHL.getValue();
            var daThanhToan = txtDaTra.getValue();
            var lyDoTU = txtLyDoHL.getValue();

            // datetime
            var tmp = new Date(dfNgayTamUngHL.getValue());
            var ngayTamUng;
            if (!isNaN(tmp))
                ngayTamUng = tmp;
            else
                ngayTamUng = 0;
            var tmp2 = new Date(dfNgayThanhToanHL.getValue());
            var ngayThanhToan;
            if (!isNaN(tmp2))
                ngayThanhToan = tmp2;
            else
                ngayThanhToan = 0;
            // update data
            var total = hdfSelectedEmployee.getValue() * 1;
            try {
                for (var i = 0; i < total; i++) {
                    grid.getSelectionModel().selectRow(i, true);
                    var record = grid.getSelectionModel().getSelected();
                    // update data for record
                    addUpdatedRecord(record.data.PrkeyHoSo, record.data.MA_CB, record.data.HO_TEN, record.data.TEN_DONVI, ngayTamUng, ngayThanhToan, lyDoTU, soTien, daThanhToan);
                }
            }
            catch (e) {
                alert('Bạn chưa chọn cán bộ nào');
            }
        }
    });
}