var changeGridpanelTitle = function (text) {
    $("div#grpDanhSachBangPhanCaThang .x-panel-header-text").html(text);
}
var validateForm = function () {
    if (spfYear.getValue() == '') {
        alert("Bạn chưa nhập thông tin năm");
        spfYear.focus();
        return false;
    }
    if (hdfMaDonVi.getValue() == '') {
        alert("Bạn chưa chọn bộ phận");
        ddfDonVi.focus();
        return false;
    }

    if (txtTenBangPhanCa.getValue() == '') {
        alert("Bạn chưa nhập tên bảng phân ca tháng");
        txtTenBangPhanCa.focus();
        return false;
    }
    return true;
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

var resetTaoBangPhanCa = function () {
    ddfDonvi.reset(); cbThang.reset(); spfYear.reset(); chkLayTuThangTruoc.reset(); txtTenBangPhanCa.reset();
    hdfStringMaDonVi.reset();
}
var keyEnterPress = function (f, e) {
    if (e.getKey() == e.ENTER) {
        PagingToolbar1.pageIndex = 0;
        PagingToolbar1.doLoad();
        grpDanhSachBangPhanCaThangStore.reload();
    }
}


var validateFormThietLapNhanh = function () {
    try {
        
    } catch (e) {

    }
}