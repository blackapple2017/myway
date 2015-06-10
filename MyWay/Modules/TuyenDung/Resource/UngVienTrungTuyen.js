var ValidateDateField = function (idDateField) {
    reg = /^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/;
    testdf = reg.test(idDateField.getRawValue());
    if (!testdf && idDateField.getRawValue() != '' && idDateField.getRawValue() != null) {
        idDateField.focus();
        return false;
    }
    return true;
}
var RenderTinhTrangDiLam = function (value, p, record) {
    if (value == "1")
        return "<span style='color:blue;'>Đã xác nhận đi làm</span>";
    if (value == "0")
        return "<span style='color:red;'>Từ chối đi làm</span>"
    return "";
}

var GetDateFromString = function (value) {
    var arr = (value + "").split(" ");
    var date = arr[2] + "/";
    switch (arr[1]) {
        case "Jan":
            date += "01/";
            break;
        case "Feb":
            date += "02/";
            break;
        case "Mar":
            date += "03/";
            break;
        case "Apr":
            date += "04/";
            break;
        case "May":
            date += "05/";
            break;
        case "Jul":
            date += "07/";
            break;
        case "Jun":
            date += "06/";
            break;
        case "Aug":
            date += "08/";
            break;
        case "Sep":
            date += "09/";
            break;
        case "Oct":
            date += "10/";
            break;
        case "Nov":
            date += "11/";
            break;
        case "Dec":
            date += "12/";
            break;
    }
    date += arr[3];
    return date;
}
var RenderVND = function (value, p, record) {
    if (value == null)
        return "";
    var l = (value + "").length;
    var s = value + "";
    var rs = "";
    var count = 0;
    for (var i = l - 1; i >= 0; i--) {
        count++;
        if (count == 3) {
            rs = "." + s.charAt(i) + rs;
            count = 0;
        }
        else {
            rs = s.charAt(i) + rs;
        }
    }
    return rs + " VNĐ";
}

var UVTTenterKeyPressHandler = function (f, e) {
    if (UngVienTrungTuyen_txtSearchKey.getValue() != '') {
        this.triggers[0].show();
    } else {
        this.triggers[0].hide();
    }
    if (e.getKey() == e.ENTER) {
        PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad();
    }
}
var GetIDKeHoacTuyenDung = function () {
    var rs = "";
    if (GridPanel2.getSelectionModel().getCount() == 0) {
        Ext.Msg.alert("Thông báo", "Bạn phải chọn đợt tuyển dụng !");
        return false;
    }
    else {
        var s = GridPanel2.getSelectionModel().getSelections();
        for (var i = 0, r; r = s[i]; i++) {
            try {
                rs += r.data.ID + ",";
            } catch (e) {

            }
        }
    }
    hdfIDKeHoachTuyenDung.setValue(rs);
}
var setValueWdForwardToHOSO = function () {
    txtMaCB.reset();
    dfNgayThuViec.reset();
    wdForwardToHOSO.show();
}

var CheckInputForwardToHOSO = function () {
    if (txtMaCB.getValue() == '') {
        alert('Bạn chưa nhập cán bộ');
        txtMaCB.focus();
        return false;
    }
    if (dfNgayThuViec.getValue() == '' || dfNgayThuViec.getRawValue() == null) {
        alert('Bạn chưa chọn ngày thử việc');
        dfNgayThuViec.focus();
        return false;
    }
    if (ValidateDateField(dfNgayThuViec) == false) {
        alert('Định dạng ngày thử việc không đúng');
        dfNgayThuViec.focus();
        return false;
    }
    return true;
}
var CheckInputDate = function () {
    if (DateTime1.getValue() == '' || DateTime1.getRawValue() == null) {
        alert('Bạn chưa chọn ngày đi làm');
        DateTime1.focus();
        return false;
    }
    if (ValidateDateField(DateTime1) == false) {
        alert('Định dạng ngày đi làm không đúng');
        DateTime1.focus();
        return false;
    }
    return true;
}