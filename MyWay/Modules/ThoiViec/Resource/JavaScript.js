var ValidateDateField = function (idDateField) {
    reg = /^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/;
    testdf = reg.test(idDateField.getRawValue());
    if (!testdf && idDateField.getRawValue() != '' && idDateField.getRawValue() != null) {
        idDateField.focus();
        return false;
    }
    return true;
}
var checkHoanTatThucTuc = function (rowselectionModel, checkbox)
{ 
    if (checkbox.checked) {
        if (rowselectionModel.getSelected().data.HoanTatCongNo == '0') {
            checkbox.setValue('false');
            alert('Nhân viên ' + rowselectionModel.getSelected().data.HoTen + ' chưa bàn giao hết công nợ !');
            return false;
        }
        if (rowselectionModel.getSelected().data.BanGiaoTaiSan == '0') {
            checkbox.setValue('false');
            alert('Nhân viên ' + rowselectionModel.getSelected().data.HoTen + ' chưa bàn giao hết tài sản !');
            return false;
        }
    }
    return true;
}

var enterKeyPressHandler = function (f, e) {
    if (e.getKey() == e.ENTER) {
       PagingToolbar1.pageIndex=0;PagingToolbar1.doLoad();
    }
    if (txtSearch.getValue() != '') {
        this.triggers[0].show();
    } else {
        this.triggers[0].hide();
    }
}

var GetBlackListComment = function (value, p, record) {
    if (value == "1") {
        return "<span style='color:blue;'>Không cho phép ứng tuyển lại</span>";
    }
    return "";
}

var RenderCongNo = function (value, p, record) {
    if (value == 1) {
        return "<span style='color:black;'>Đã thanh toán</span>";
    }
    return "<span style='color:black;'>Chưa thanh toán</span>";
}

var RenderDatra = function (value, p, record) {
    if (value == "1") {
        return "<span style='color:black;'>Đã trả</span>";
    }
    return "<span style='color:black;'>Chưa trả</span>";
}

var RenderThuTuc = function (value, p, record) {
    if (value == "1") {
        return "<span style='color:blue;'>Hoàn tất thủ tục</span>";
    }
    return "<span style='color:red;'>Chưa làm thủ tục</span>";
}

var RenderTrangThaiBanGiao = function (value, p, record) {
    if (value == "1") {
        return "Đã bàn giao";
    }
    return "<b style='color:red;'>Chưa bàn giao</b>";
}

var RenderThanhToan = function (value, p, record) {
    if (value == "1") {
        return "Đã trả";
    }
    return "<b style='color:red;'>Còn nợ</b>";
}

var SetDetailData = function () {
    txtLyDoNghi.setValue(checkboxSelection.getSelected().data.LyDoNghi);
    txtDiaChiLienHe.setValue(checkboxSelection.getSelected().data.DiaChiLienHe);
    txtEmail.setValue(checkboxSelection.getSelected().data.Email);
    txtDiDong.setValue(checkboxSelection.getSelected().data.DiDong);
    txtViTriCongViec.setValue(checkboxSelection.getSelected().data.ViTriCongViec);
    txtChucVu.setValue(checkboxSelection.getSelected().data.ChucVu);
    txtNgayLamChinhThuc.setValue(RenderDate(checkboxSelection.getSelected().data.NgayLamChinhThuc, null, null));
    txtNgayThuViec.setValue(RenderDate(checkboxSelection.getSelected().data.NgayThuViec, null, null));
    txtFullName.setValue(checkboxSelection.getSelected().data.HoTen);
    txtMaCB.setValue(checkboxSelection.getSelected().data.MaCB);
    txtNgaySinh.setValue(RenderDate(checkboxSelection.getSelected().data.NgaySinh, null, null));
    if (checkboxSelection.getSelected().data.GioiTinh == "F") {
        txtGioiTinh.setValue("Nữ");
    }
    else
        txtGioiTinh.setValue("Nam");
    txtNguoiDuyetNghi.setValue(checkboxSelection.getSelected().data.CanBoDuyetNghi);
    if (checkboxSelection.getSelected().data.Photo != null)
        document.getElementById("hsImage").setAttribute("src", checkboxSelection.getSelected().data.Photo.replace("~/Modules", ".."));
}
  
//Đức Anh. check input tài sản
var CheckInputTaiSan = function () {
    if (cbbLoaiTaiSan.getValue() == '') {
        alert("Bạn chưa chọn loại tài sản");
        cbbLoaiTaiSan.focus();
        return false;
    }
}

 
var ResetFormTaiSan = function () {
    cbbLoaiTaiSan.reset(); txtGhiChu.reset(); dfNgayHoanThanh.reset(); chkTrangThai.reset();
}

//lấy chỉ số dòng được chọn trên grid quản lý các khoản công nợ
var getSelectedIndexRow = function (grid) {
    var record = grid.getSelectionModel().getSelected();
    var index = grid.store.indexOf(record);
    if (index == -1)
        return 0;
    return index;
}
//Cập nhật lại bản ghi trên grid quản lý các khoản công nợ
addUpdatedRecord = function (id, tenKhoanCongNo) {
    var rowindex = getSelectedIndexRow(grpDanhSachCongNo);
    //xóa bản ghi cũ
    var s = grpDanhSachCongNo.getSelectionModel().getSelections();
    for (var i = 0, r; r = s[i]; i++) {
        cbLoaiCongNoStore.remove(r);
        cbLoaiCongNoStore.commitChanges();
    }
    //Thêm bản ghi đã update
    grpDanhSachCongNo.insertRecord(rowindex, {
        ID: id,
        NgayTao: (new Date()).clearTime(),
        TenCongNo: tenKhoanCongNo
    });
    grpDanhSachCongNo.getView().refresh();
    grpDanhSachCongNo.getSelectionModel().selectRow(rowindex);
    cbLoaiCongNoStore.commitChanges();
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

var SaveLoaiCongNo = function (value) {
    Ext.net.DirectMethods.SaveLoaiCongNo(value);
    cbLoaiCongNoStore.commitChanges();
} 
var LoadDataInSouthPanel = function () {
    var tab = tabPanel.getActiveTab();
    if (tab == null)
        return;
    var tabid = tab.id;
    switch (tabid) {
        case "pnlCongNoNhanVien":
            grpCongNoNhanVienStore.reload();
            break;
        case "pnlBanGiaoTaiSan":
            grpBanGiaoTaiSanStore.reload();
            break;
    }
}

var RemoveItemOnGrid = function () {
    grid = grpCongNoNhanVien;
    Store = grpCongNoNhanVienStore;
    var s = grid.getSelectionModel().getSelections();
    for (var i = 0, r; r = s[i]; i++) {
        Store.remove(r);
        Store.commitChanges();
    }
}

var CheckNumberRow = function (grid, Store) {
    var count = 0;
    var s = grid.getSelectionModel().getSelections();
    for (var i = 0, r; r = s[i]; i++) {
        count++;
        IDBanGiaoTaiSan.setValue(r.data.ID);
    }
    if (count == 0) {
        alert('Bạn chưa chọn dòng nào');
        return false;
    }
    if (count > 1) {
        alert('Bạn chỉ được chọn 1 dòng');
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
        alert('Bạn chưa chọn cán bộ nào');
        return false;
    }
    if (count > 1) {
        alert('Bạn chỉ được chọn một cán bộ');
        return false;
    }
    return true;
}
var CheckInputThuTuc = function (el) {
    if (dfNgayNghi.getValue() == '') {
        alert('Bạn chưa chọn ngày thôi việc cho cán bộ');
        dfNgayNghi.focus();
        return false;
    }
    if (dfNgayNghi.getValue() != '' && cbx_lydonghi.getValue() == '') {
        alert('Bạn chưa chọn lý do thôi việc');
        cbx_lydonghi.focus();
        return false;
    }
    if (cbTraTheBHYT.getValue() == 'True' && dfNgayTraThe.getValue() == '') {
        alert('Bạn chưa nhập ngày trả thẻ bảo hiểm y tế');
        dfNgayTraThe.focus();
        return false;
    }
    if (cbSoBHXH.getValue() == 'True' && dfNgayTraSo.getValue() == '') {
        alert('Bạn chưa nhập ngày trả sổ bảo hiểm xã hội');
        dfNgayTraSo.focus();
        return false;
    }
    if (ValidateDateField(dfNgayNghi) == false) {
        alert('Định dạng ngày nghỉ không đúng');
        dfNgayNghi.focus();
        return false;
    }
    if (ValidateDateField(dfNgayTraThe) == false) {
        alert('Định dạng ngày trả thẻ không đúng');
        dfNgayTraThe.focus();
        return false;
    }
    if (ValidateDateField(dfNgayTraSo) == false) {
        alert('Định dạng ngày trả sổ không đúng');
        dfNgayTraSo.focus();
        return false;
    }
    var size = 0;
    for (var num1 = 0; num1 < el.files.length; num1++) {
        var file = el.files[num1];
        size += file.size;
    }
    if (size > 10485760) {
        alert('Phần mềm chỉ hỗ trợ các tệp tin đính kèm nhỏ hơn 10MB');
        hdfTepTinDinhKem.reset(); fufTepTinDinhKem.reset();
        return false;
    }
    //if (chkThemVaoDsHanChe.checked && cbxLyDoHanChe.getValue() == '') {
    //    alert('Bạn chưa chọn lý do đưa cán bộ vào danh sách hạn chế');
    //    cbxLyDoHanChe.focus();
    //    return false;
    //}
    //if (cbxDaHoanThanhThuTuc.getValue() == 'true' && (chkDaTraThe.checked == false || chkDaTraSo.checked == false)) {
    //    alert('Bạn chưa hoàn thành các thủ tục cần thiết');
    //    cbxDaHoanThanhThuTuc.focus();
    //    return false;
    //}
    return true;
}
var GetTooltips = function (re_LyDoNghiViec) {
    var html = "<div style='padding:5px;position:relative;z-index:10000;'>";
    html += "<fieldset style='padding:4px;border-bottom:none;border-left:none;border-right:none;border-top:1px solid #99bbe8;'><legend><b>Lý do thôi việc</b></legend>";
    if (re_LyDoNghiViec != null && re_LyDoNghiViec != "")
        html += re_LyDoNghiViec + "</fieldset>";
    else
        html += "Không có dữ liệu</fieldset>";
    return html + "</div>";
}

var checkDeleteAttackFile = function (el) {
    var size = 0;
    for (var num1 = 0; num1 < el.files.length; num1++) {
        var file = el.files[num1];
        size += file.size;
    }
    if (size > 10485760) {
        hdfTepTinDinhKem.reset(); fufTepTinDinhKem.reset();
        return false;
    }
    return true;
}