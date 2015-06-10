var CheckSelectedRecord = function (grid, Store) { 
    var s = grid.getSelectionModel().getSelections();
    var count = 0;
    for (var i = 0, r; r = s[i]; i++) {
        count++;
    }
    if (count > 1) {
        alert('Bạn chỉ được chọn một dòng');
        return false;
    }
    if (count == 0) {
        alert('Bạn chưa chọn dòng nào');
        return false;
    } 
    return true;
}

var enterKeyPressHandler = function (f, e) {
    if (e.getKey() == e.ENTER) {
        PagingToolbar1.pageIndex = 0;
        GridPanel1.getSelectionModel().clearSelections();
        hdfRecordID.setValue('');
        Store1.reload();
    }
}
var RenderTinhTrang = function (value, p, record) {
    if (value == "ChoDuyet") {
        return "Chờ duyệt";
    }
    else if (value == "DaDuyet") {
        return "<span style='color:blue;'>Đã duyệt</span>";
    }
    else if (value == "KhongDuyet")
        return "<span style='color:red;'>Không duyệt</span>";
    return value;
}
var RendererPhanTram = function (value) {
    if (value != null) {
        return value + " %";
    }
    return "";
}
var GetDataFromStore = function (storeid) {
    var jsonData = storeid.data.items;
    var selectedItem = cbLoaiPhuCap.getValue();
    for (var i = 0; i < jsonData.length; i++) {
        if (selectedItem == jsonData[i].data.ID) {
            txtHeSoPhuCap.setValue(jsonData[i].data.HeSo);
            txtSoTien.setValue(jsonData[i].data.SoTien);
            txtPhanTram.setValue(jsonData[i].data.PhanTram);
        }
    }
}
var updateRecord = function (grid) {
    //try {
    //    if (txtHeSoLuongHL.getValue() == '') {
    //        alert('Bạn chưa nhập hệ số lương');
    //        txtHeSoLuongHL.focus();
    //        return false;
    //    }
    //} catch (e) { }
    try {
        if (txtMucLuongHL.getValue() == '') {
            alert('Bạn chưa nhập lương chức vụ');
            txtMucLuongHL.focus();
            return false;
        }
    } catch (e) { }
    try {
        if (txtLuongDongBHHL.getValue() == '') {
            alert('Bạn chưa nhập lương đóng BH (lương CB)');
            txtLuongDongBHHL.focus();
            return false;
        }
    } catch (e) { }
    //try {
    //    if (cbxLoaiLuongHL.getValue() == '' || cbxLoaiLuongHL.getValue() == null) {
    //        alert('Bạn chưa nhập loại lương');
    //        cbxLoaiLuongHL.focus();
    //        return false;
    //    }
    //} catch (e) { }
    try {
        var maNgach = cbxNgachHL.getValue();
    } catch (e) { }
    try {
        var heSoLuong = txtHeSoLuongHL.getValue();
    } catch (e) { }
    try {
        var luongDongBH = txtLuongDongBHHL.getValue();
    } catch (e) { }
    try {
        var bacLuongNB = txtBacLuongNBHL.getValue();
    } catch (e) { }
    try {
        var phanTramHL = txtPhanTramHuongLuongHL.getValue();
    } catch (e) { }
    try {
        var luongTrachNhiem = txtLuongTrachNhiem.getValue();
    } catch (e) { }
    try {
        var bacLuong = cbxBacLuongHL.getValue();
    } catch (e) { }
    try {
        var mucLuong = txtMucLuongHL.getValue();
    } catch (e) { }
    // datetime
    try {
        var tmp = new Date(dfNgayHuongLuongHL.getValue());
    } catch (e) { }
    var ngayHL;
    if (!isNaN(tmp))
        ngayHL = tmp;
    else
        ngayHL = 0;
    try {
        var tmp2 = new Date(dfNgayHuongLuongNBHL.getValue());
    } catch (e) { }
    var ngayHLNB;
    if (!isNaN(tmp2))
        ngayHLNB = tmp2;
    else
        ngayHLNB = 0;
    try {
        var loaiLuong = cbxLoaiLuongHL.getValue();
    } catch (e) { }
    try {
        // update data
        var record = grid.getSelectionModel().getSelected();
        // update data for record
        addUpdatedRecord(record.data.PR_KEY, record.data.MA_CB, record.data.HO_TEN, record.data.TEN_DONVI, record.data.TEN_CHUCVU, maNgach, bacLuong, heSoLuong,
                        mucLuong, luongDongBH, ngayHL, bacLuongNB, ngayHLNB, phanTramHL, luongTrachNhiem, loaiLuong, record.data.TrangThai);
    }
    catch (e) {
        alert('Bạn chưa chọn cán bộ nào');
    }
};

var updateAllRecord = function (grid) {
    //try {
    //    if (txtHeSoLuongHL.getValue() == '') {
    //        alert('Bạn chưa nhập hệ số lương');
    //        txtHeSoLuongHL.focus();
    //        return false;
    //    }
    //} catch (e) { }
    try {
        if (txtMucLuongHL.getValue() == '') {
            alert('Bạn chưa nhập lương chức vụ');
            txtMucLuongHL.focus();
            return false;
        }
    } catch (e) { }
    try {
        if (txtLuongDongBHHL.getValue() == '') {
            alert('Bạn chưa nhập lương đóng BH (lương CB)');
            txtLuongDongBHHL.focus();
            return false;
        }
    } catch (e) { }
    //try {
    //    if (cbxLoaiLuongHL.getValue() == '' || cbxLoaiLuongHL.getValue() == null) {
    //        alert('Bạn chưa nhập loại lương');
    //        cbxLoaiLuongHL.focus();
    //        return false;
    //    } 
    //} catch (e) { }
    Ext.Msg.confirm('Xác nhận', 'Thông tin lương sẽ được cập nhật cho tất cả cán bộ trong danh sách. Bạn có chắc chắn muốn thực hiện không?', function (btn) {
        if (btn == "yes") {
            // get salary information
            try {
                var maNgach = cbxNgachHL.getValue();
            } catch (e) { }
            try {
                var heSoLuong = isNaN(parseFloat(txtHeSoLuongHL.getValue())) == false ? parseFloat(txtHeSoLuongHL.getValue()) : '';
            } catch (e) { }
            try {
                var luongDongBH = isNaN(parseFloat(txtLuongDongBHHL.getValue())) == false ? parseFloat(txtLuongDongBHHL.getValue()) : '';
            } catch (e) { }
            try {
                var bacLuongNB = txtBacLuongNBHL.getValue();
            } catch (e) { }
            try {
                var phanTramHL = isNaN(parseFloat(txtPhanTramHuongLuongHL.getValue())) == false ? parseFloat(txtPhanTramHuongLuongHL.getValue()) : '';
            } catch (e) { }
            try {
                var bacLuong = cbxBacLuongHL.getValue();
            } catch (e) { }
            try {
                var mucLuong = isNaN(parseFloat(txtMucLuongHL.getValue())) == false ? parseFloat(txtMucLuongHL.getValue()) : '';
            } catch (e) { }
            try {
                var luongTrachNhiem = isNaN(parseFloat(txtLuongTrachNhiem.getValue())) == false ? parseFloat(txtLuongTrachNhiem.getValue()) : '';
            } catch (e) { }
            // datetime
            try {
                var tmp = new Date(dfNgayHuongLuongHL.getValue());
            } catch (e) { }
            var ngayHL;
            if (!isNaN(tmp))
                ngayHL = tmp;
            else
                ngayHL = 0;
            try {
                var tmp2 = new Date(dfNgayHuongLuongNBHL.getValue());
            } catch (e) { }
            var ngayHLNB;
            if (!isNaN(tmp2))
                ngayHLNB = tmp2;
            else
                ngayHLNB = 0;
            try {
                var loaiLuong = cbxLoaiLuongHL.getValue();
            } catch (e) { }
            // update data
            //var total = hdfTotalRecord.getValue() * 1;
            var total = grp_DanhSachQuyetDinh_Store.getCount();
            try {
                for (var i = 0; i < total; i++) {
                    grid.getSelectionModel().selectRow(i, true);
                    var record = grid.getSelectionModel().getSelected();
                    // update data for record
                    addUpdatedRecord(record.data.PR_KEY, record.data.MA_CB, record.data.HO_TEN, record.data.TEN_DONVI, record.data.TEN_CHUCVU, maNgach, bacLuong, heSoLuong,
                        mucLuong, luongDongBH, ngayHL, bacLuongNB, ngayHLNB, phanTramHL, luongTrachNhiem, loaiLuong, record.data.TrangThai);
                }
            }
            catch (e) {
                alert('Bạn chưa chọn cán bộ nào');
            }
        }
    });
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

var ngachRenderer = function (value) {
    try {
        var r = cbxNgachCu_Store.getById(value);

        if (Ext.isEmpty(r)) {
            return "";
        }

        return r.data.TEN;
    }
    catch (e)
    { return "" }
};
var loaiLuongRenderer = function (value) {
    try {
        var r = cbxLoaiLuongCu_Store.getById(value);

        if (Ext.isEmpty(r)) {
            return "";
        }

        return r.data.TEN_LOAI_LUONG;
    }
    catch (e)
    { return ""; }
};

var ValidateWdTaoQuyetDinhLuong = function () {
    try {
        if (cbxChonCanBo.getValue() == '') {
            alert('Bạn chưa chọn cán bộ nhận quyết định lương');
            cbxChonCanBo.focus();
            return false;
        }
    } catch (e) { }
    //try {
    //    if (txtSoQDMoi.getValue() == '') {
    //        alert('Bạn chưa nhập số quyết định');
    //        txtSoQDMoi.focus();
    //        return false;
    //    }
    //} catch (e) { }
    try {
        if (txtTenQDMoi.getValue() == '') {
            alert('Bạn chưa nhập tên quyết định');
            txtTenQDMoi.focus();
            return false;
        }
    } catch (e) { }
    try {
        if ((dfNgayHieuLucMoi.getValue() == '' || dfNgayHieuLucMoi.getValue() == null)) {
            alert('Bạn chưa chọn ngày hiệu lực');
            dfNgayHieuLucMoi.focus();
            return false;
        }
    } catch (e) { }
    //try {
    //    if (hdfNguoiQuyetDinh.getValue() == '') {
    //        alert('Bạn chưa nhập người quyết định');
    //        cbxChonNguoiQuyetDinh.focus();
    //        return false;
    //    }
    //} catch (e) { }
    try {
        if (cbHopDongLoaiHopDongMoi.getValue() == '') {
            alert('Bạn chưa chọn hợp đồng tương ứng với quyết định');
            cbHopDongLoaiHopDongMoi.focus();
            return false;
        }
    } catch (e) { }
    //if (cbTrangThaiMoi.getValue() == '' || cbTrangThaiMoi.getValue() == null) {
    //    alert('Bạn chưa chọn trạng thái quyết định');
    //    cbTrangThaiMoi.focus();
    //    return false;
    //}
    //try {
    //    if (txtHeSoLuongMoi.getValue() == '') {
    //        alert('Bạn chưa nhập hệ số lương');
    //        txtHeSoLuongMoi.focus();
    //        return false;
    //    }
    //} catch (e) { }
    try {
        if (txtLuongDongBHMoi.getValue() == '') {
            alert('Bạn chưa nhập lương đóng BH (lương CB)');
            txtLuongDongBHMoi.focus();
            return false;
        }
    } catch (e) { }
    try {
        if (txtMucLuongMoi.getValue() == '') {
            alert('Bạn chưa nhập lương chức vụ');
            txtMucLuongMoi.focus();
            return false;
        }
    } catch (e) { }
    //try {
    //    if (txtLuongTrachNhiemMoi.getValue() == '') {
    //        alert('Bạn chưa nhập lương trách nhiệm');
    //        txtLuongTrachNhiemMoi.focus();
    //        return false;
    //    }
    //} catch (e) { }
    //try {
    //    if (cbLoaiLuong.getValue() == '' || cbLoaiLuong.getValue() == null) {
    //        alert('Bạn chưa nhập loại lương');
    //        cbLoaiLuong.focus();
    //        return false;
    //    }
    //} catch (e) { }
    // validate datefield
    try {
        if (ValidateDateField(dfNgayQDMoi) == false) {
            alert('Định dạng ngày quyết định không đúng');
            return false;
        }
    } catch (e) { }
    try {
        if (ValidateDateField(dfNgayHieuLucMoi) == false) {
            alert('Định dạng ngày hiệu lực không đúng');
            return false;
        }
    } catch (e) { }
    try {
        if (ValidateDateField(dfNgayHetHieuLucMoi) == false) {
            alert('Định dạng ngày hết hiệu lực không đúng');
            return false;
        }
    } catch (e) { }
    try {
        if (dfNgayHetHieuLucMoi.getValue() != '' && dfNgayHieuLucMoi.getValue() != '' && (dfNgayHieuLucMoi.getValue() > dfNgayHetHieuLucMoi.getValue())) {
            alert('Ngày hiệu lực phải trước hoặc trong ngày hết hiệu lực!');
            dfNgayHieuLucMoi.focus();
            return false;
        }
    } catch (e) { }
    try {
        if (ValidateDateField(dfNgayHLMoi) == false) {
            alert('Định dạng ngày hưởng lương không đúng');
            return false;
        }
    } catch (e) { }
    try {
        if (dfNgayHLMoi.getValue() != '' && dfNgayHieuLucMoi.getValue() != '' && (dfNgayHieuLucMoi.getValue() > dfNgayHLMoi.getValue())) {
            alert('Ngày hiệu lực phải trước hoặc trong ngày hưởng lương!');
            dfNgayHieuLucMoi.focus();
            return false;
        }
    } catch (e) { }
    try {
        if (ValidateDateField(dfNgayHLNBMoi) == false) {
            alert('Định dạng ngày hưởng lương nội bộ không đúng');
            return false;
        }
    } catch (e) { }
    try {
        if (dfNgayHLNBMoi.getValue() != '' && dfNgayHieuLucMoi.getValue() != '' && (dfNgayHieuLucMoi.getValue() > dfNgayHLNBMoi.getValue())) {
            alert('Ngày hiệu lực phải trước hoặc trong ngày hưởng lương nội bộ!');
            dfNgayHieuLucMoi.focus();
            return false;
        }
    } catch (e) { }
    return true;
}
var checkInputThongTinLuongBeforeUpdate = function () {
    var records = grp_DanhSachQuyetDinh_Store.getRange();
    var rs = '';
    for (var i = 0; i < records.length; i++) {
        if (records[i].data.LuongCung == '') {
            alert('Bạn chưa nhập đầu đủ thông tin lương cho cán bộ!');
            txtMucLuongHL.focus();
            return false;
        }
    }
    return true;
}

var ValidateWdTaoQuyetDinhLuongHangLoat = function () {
    //try {
    //    if (txtSoQDHL.getValue() == '') {
    //        alert('Bạn chưa nhập số quyết định');
    //        txtSoQDHL.focus();
    //        return false;
    //    }
    //} catch (e) { }
    try {
        if (txtTenQDHL.getValue() == '') {
            alert('Bạn chưa nhập tên quyết định');
            txtTenQDHL.focus();
            return false;
        }
    } catch (e) { }
    try {
        if ((dfNgayHieuLucHL.getValue() == '' || dfNgayHieuLucHL.getValue() == null)) {
            alert('Bạn chưa nhập ngày có hiệu lực');
            dfNgayHieuLucHL.focus();
            return false;
        }
    }
    catch (e) { }
    //try {
    //    if ((cbxNguoiQuyetDinhHL.getValue() == '' || cbxNguoiQuyetDinhHL.getValue() == null)) {
    //        alert('Bạn chưa nhập người quyết định');
    //        cbxNguoiQuyetDinhHL.focus();
    //        return false;
    //    }
    //} catch (e) { }
    try {
        if (cbHopDongLoaiHopDongMoiHL.getValue() == '') {
            alert('Bạn chưa chọn hợp đồng tương ứng với quyết định');
            cbHopDongLoaiHopDongMoiHL.focus();
            return false;
        }
    } catch (e) { }
    try {
        if (grp_DanhSachQuyetDinh_Store.getCount() == 0) {
            alert('Bạn chưa chọn cán bộ nhận quyết định');
            ucChooseEmployee1_wdChooseUser.show();
            return false;
        }
    } catch (e) { }
    //Kiểm tra thông tin lương đã được nhập đầy đủ hay chưa
    if (checkInputThongTinLuongBeforeUpdate() == false) {
        return false;
    }
    // validate datefield
    try {
        if (ValidateDateField(dfNgayQDHL) == false) {
            alert('Định dạng ngày quyết định không đúng');
            return false;
        }
    } catch (e) { }
    try {
        if (ValidateDateField(dfNgayHieuLucHL) == false) {
            alert('Định dạng ngày hiệu lực không đúng');
            return false;
        }
    } catch (e) { } 
    try {
        if (ValidateDateField(dfNgayHetHieuLucHL) == false) {
            alert('Định dạng ngày hết hiệu lực không đúng');
            return false;
        }
    } catch (e) { }
    try {
        if (dfNgayHetHieuLucHL.getValue() != '' && dfNgayHieuLucHL.getValue() != '' && (dfNgayHieuLucHL.getValue() > dfNgayHetHieuLucHL.getValue())) {
            alert('Ngày hiệu lực phải trước hoặc trong ngày hết hiệu lực!');
            dfNgayHieuLucHL.focus();
            return false;
        }
    } catch (e) { }
    try {
        if (ValidateDateField(dfNgayHuongLuongHL) == false) {
            alert('Định dạng ngày hưởng lương không đúng');
            return false;
        }
    } catch (e) { }
    try {
        if (dfNgayHuongLuongHL.getValue() != '' && dfNgayHieuLucHL.getValue() != '' && (dfNgayHieuLucHL.getValue() > dfNgayHuongLuongHL.getValue())) {
            alert('Ngày hiệu lực phải trước hoặc trong ngày hưởng lương!');
            dfNgayHieuLucHL.focus();
            return false;
        }
    } catch (e) { }
    try {
        if (ValidateDateField(dfNgayHuongLuongNBHL) == false) {
            alert('Định dạng ngày hưởng lương nội bộ không đúng');
            return false;
        }
    } catch (e) { }
    try {
        if (dfNgayHuongLuongNBHL.getValue() != '' && dfNgayHieuLucHL.getValue() != '' && (dfNgayHieuLucHL.getValue() > dfNgayHuongLuongNBHL.getValue())) {
            alert('Ngày hiệu lực phải trước hoặc trong ngày hưởng lương nội bộ!');
            dfNgayHieuLucHL.focus();
            return false;
        }
    } catch (e) { }
    return true;
}

var ResetWdTaoQuyetDinhLuong = function () {
    hdfChonCanBo.reset(); cbxChonCanBo.reset(); cbx_bophan.reset(); txtChucVu.reset(); txtCongViec.reset();
    try { txtSoQDCu.reset(); } catch (e) { } try { txtTenQDCu.reset(); } catch (e) { } try { dfNgayQDCu.reset(); } catch (e) { }
    try { txtNguoiQDCu.reset(); } catch (e) { } try { dfNgayCoHieuLucCu.reset(); } catch (e) { } try { cbxNgachCu.reset(); } catch (e) { }
    try { txtBacLuongCu.reset(); } catch (e) { } try { txtHeSoLuongCu.reset(); } catch (e) { } try { txtMucLuongCu.reset(); } catch (e) { }
    try { txtLuongDongBHCu.reset(); } catch (e) { } try { txtPhanTramHLCu.reset(); } catch (e) { }
    try { cbxLoaiLuongCu.reset(); } catch (e) { } try { txtSoQDMoi.reset(); } catch (e) { } try { dfNgayQDMoi.reset(); } catch (e) { }
    try { txtTenQDMoi.reset(); } catch (e) { } try { dfNgayHieuLucMoi.reset(); } catch (e) { } try { hdfNguoiQuyetDinh.reset(); } catch (e) { }
    try { cbxChonNguoiQuyetDinh.reset(); } catch (e) { } try { dfNgayHetHieuLucMoi.reset(); } catch (e) { } try { hdfTepTinDinhKem.reset(); } catch (e) { }
    try { fufTepTinDinhKem.reset(); } catch (e) { } try { txtGhiChuMoi.reset(); } catch (e) { } try { cbx_ngachMoi.reset(); } catch (e) { }
    try { txtHeSoLuongMoi.reset(); } catch (e) { } try { txtLuongDongBHMoi.reset(); } catch (e) { } try { txtBacLuongNBMoi.reset(); } catch (e) { }
    try { txtPhanTramHLMoi.reset(); } catch (e) { } try { cbxBacMoi.reset(); } catch (e) { } try { txtMucLuongMoi.reset(); } catch (e) { }
    try { dfNgayHLMoi.reset(); } catch (e) { } try { dfNgayHLNBMoi.reset(); } catch (e) { } try { cbLoaiLuong.reset(); } catch (e) { }
    try { txtLuongTrachNhiemMoi.reset(); } catch (e) { } try { cbTrangThaiMoi.reset(); } catch (e) { }
    try { cbHopDongLoaiHopDongMoi.reset(); } catch (e) { }
    try { cbHopDongLoaiHopDongCu.reset(); } catch (e) { }
}

var ResetWdTaoQuyetDinhLuongHangLoat = function () {
    try { grp_DanhSachQuyetDinh_Store.removeAll(); } catch (e) { }
    try { fpTTQD.getForm().reset(); } catch (e) { }
    try { fpn_QDLuongHL.getForm().reset(); } catch (e) { }
    try { hdfNguoiQuyetDinhHL.reset(); } catch (e) { }
    try { hdfTepTinDinhKemHL.reset(); } catch (e) { }
    try { btnXoaCanBo.disable(); } catch (e) { }
}

var ResetWdConfig = function () {
    chkLuongCung.reset(); chkHeSoLuong.reset(); chkPhanTramHL.reset(); chkLoaiLuong.reset();
    chkLuongDongBHXH.reset(); chkBacLuong.reset(); chkBacLuongNB.reset(); chkNgayHL.reset();
    chkNgayHLNB.reset(); chkSoQD.reset(); chkNgayQD.reset(); chkNgayHieuLuc.reset();
    chkNgayHetHieuLuc.reset(); chkNguoiQD.reset();
}
var checkChooseEmployeeFirst = function () {
    if (grp_DanhSachQuyetDinh_Store.getCount() == 0) {
        alert('Bạn phải chọn cán bộ nhận quyết định trước');
        ucChooseEmployee1_wdChooseUser.show();
        return false;
    }
}
var ValidateForm = function () {
    if (cbLoaiPhuCap.getValue() == '' || cbLoaiPhuCap.getValue() == null) {
        alert("Bạn chưa chọn loại phụ cấp");
        cbLoaiPhuCap.focus();
        return false;
    }
    if (txtHeSoPhuCap.getValue() == '' && txtSoTien.getValue() == '') {
        alert("Bạn phải nhập hệ số phụ cấp hoặc số tiền");
        txtHeSoPhuCap.focus();
        return false;
    }
    if (dfNgayHieuLucPhuCap.getValue() == '') {
        alert("Bạn chưa chọn ngày hiệu lực");
        return false;
    }
    // validate datefield
    if (ValidateDateField(dfNgayQuyetDinhPhuCap) == false) {
        alert('Định dạng ngày quyết định không đúng');
        return false;
    } 
    if (ValidateDateField(dfNgayHieuLucPhuCap) == false) {
        alert('Định dạng ngày hiệu lực không đúng');
        return false;
    }
    if (ValidateDateField(dfHetHieuLucPhuCap) == false) {
        alert('Định dạng ngày hết hiệu lực không đúng');
        return false;
    } 
    if (dfNgayHieuLucPhuCap.getValue() != '' && dfHetHieuLucPhuCap.getValue() != '' && (dfNgayHieuLucPhuCap.getValue() > dfHetHieuLucPhuCap.getValue())) {
        alert('Ngày hiệu lực phải trước hoặc trong ngày hết hiệu lực!');
        dfNgayHieuLucPhuCap.focus();
        return false;
    }
    return true;
}

var resetFormQuyetDinhLuong = function () {
    txtSoQuyetDinh.reset();
    dfNgayQuyetDinh.reset();
    dfNgayHieuLuc.reset();
    txtTenQuyetDinh.reset();
    cbNguoiQuyetDinh.reset();
    dfHetHieuLuc.reset();
    txtHeSoLuong.reset();
    txtBacLuong.reset();
    dfNgayHuongLuong.reset();
    nbfPhanTramHuongLuong.reset();
    cbLoaiLuong.reset();
    cbHoTenNhanVien.reset();
    txtLuongCung.reset();
    txtBacLuongNB.reset();
    dfNgayHuongLuongNB.reset();
    txtLuongDongBH.reset();
    hdfHoTenNhanVien.reset();
    hdfNguoiQuyetDinh.reset();
    cbTrangThai.reset();
}

var resetFormPhuCap = function () {
    cbLoaiPhuCap.reset();
    txtHeSoPhuCap.reset();
    dfNgayQuyetDinhPhuCap.reset();
    dfNgayHieuLucPhuCap.reset();
    // cbTrangThaiPhuCap.reset();
    txtSoTien.reset();
    cbNguoiQuyetDinhPhuCap.reset();
    dfHetHieuLucPhuCap.reset();
    hdfNguoiQuyetDinhPhuCap.reset();
}

var getSelectedIndexRow = function () {
    var record = grp_DanhSachQuyetDinh.getSelectionModel().getSelected();
    var index = grp_DanhSachQuyetDinh.store.indexOf(record);
    if (index == -1)
        return 0;
    return index;
}

var addRecord = function (pr_keyhoso, ma_cb, ho_ten, ten_donvi, ten_chucvu, mangach, bacluong, hesoluong, luongcung, luongdongbhxh, ngayhuongluong,
        bacluongnb, ngayhuongluongnb, phantramhuongluong, maloailuong, trangthai) {
    var rowindex = getSelectedIndexRow();
    grp_DanhSachQuyetDinh.insertRecord(rowindex, {
        PR_KEY: pr_keyhoso,
        MA_CB: ma_cb,
        HO_TEN: ho_ten,
        TEN_DONVI: ten_donvi,
        TEN_CHUCVU: ten_chucvu,
        MaNgach: mangach,
        BacLuong: bacluong,
        HeSoLuong: hesoluong,
        LuongCung: luongcung,
        LuongDongBHXH: luongdongbhxh,
        NgayHuongLuong: ngayhuongluong,
        BacLuongNB: bacluongnb,
        NgayHuongLuongNB: ngayhuongluongnb,
        PhanTramHuongLuong: phantramhuongluong,
        MaLoaiLuong: maloailuong,
        TrangThai: trangthai
    });
    grp_DanhSachQuyetDinh.getView().refresh();
    grp_DanhSachQuyetDinh.getSelectionModel().selectRow(rowindex);
    grp_DanhSachQuyetDinh_Store.commitChanges();
}

addUpdatedRecord = function (pr_keyhoso, ma_cb, ho_ten, ten_donvi, ten_chucvu, mangach, bacluong, hesoluong, luongcung, luongdongbhxh, ngayhuongluong,
        bacluongnb, ngayhuongluongnb, phantramhuongluong, luongTrachNhiem, maloailuong, trangthai) {
    var rowindex = getSelectedIndexRow();
    var prkey = 0;
    //xóa bản ghi cũ
    var s = grp_DanhSachQuyetDinh.getSelectionModel().getSelections();
    for (var i = 0, r; r = s[i]; i++) {
        prkey = r.data.PR_KEY;
        grp_DanhSachQuyetDinh_Store.remove(r);
        //grp_DanhSachQuyetDinh_Store.commitChanges();
    }
    //Thêm bản ghi đã update
    grp_DanhSachQuyetDinh.insertRecord(rowindex, {
        PR_KEY: pr_keyhoso,
        MA_CB: ma_cb,
        HO_TEN: ho_ten,
        TEN_DONVI: ten_donvi,
        TEN_CHUCVU: ten_chucvu,
        MaNgach: mangach,
        BacLuong: bacluong,
        HeSoLuong: hesoluong,
        LuongCung: luongcung,
        LuongDongBHXH: luongdongbhxh,
        NgayHuongLuong: ngayhuongluong,
        BacLuongNB: bacluongnb,
        NgayHuongLuongNB: ngayhuongluongnb,
        PhanTramHuongLuong: phantramhuongluong,
        LuongTrachNhiem: luongTrachNhiem,
        MaLoaiLuong: maloailuong,
        TrangThai: trangthai
    });
    grp_DanhSachQuyetDinh.getView().refresh();
    grp_DanhSachQuyetDinh.getSelectionModel().selectRow(rowindex);
    //store_HoSoNhanSu.commitChanges();
}
var RenderTepTinDinhKem = function (value, p, record) {
    if (value != null && value != '') {
        return "<img style='height:13px;' src='../../../Resource/images/attach.png' title='Bản ghi có tệp tin đính kèm'>";
    }
    return '';
}
var prepare = function (grid, command, record, row, col, value) {
    if (record.data.TepTinDinhKem == '' && command.command == "Download") {
        command.hidden = true;
        command.hideMode = "visibility";
    }
}