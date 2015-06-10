var getColor = function (value, p, record) {
    return "<span style='color:blue;'>" + value + "</span>";
}

var getDayNumber = function (value, p, record) {
    if (value == "" || value == 0) {
        return "<span style='float:right;'>0</span>";
    }
    return "<b style='float:right;color:blue;'>" + value + "</b>";
}
//Lấy số ngày phép được hưởng mỗi tháng
var getUsedDayPerMonth = function (value, p, record) {
    if (value == "" || value == 0) {
        return "";
    }
    return "<b style='float:right;color:red;'>" + value + "</b>";
}

//Lấy số ngày phép được hưởng mỗi năm
var getUsedDayPerYear = function (value, p, record) {
    if (value == "" || value == 0) {
        return "<span style='float:right;'>0</span>";
    }
    return "<b style='float:right;color:red;'>" + value + "</b>";
}

//Lấy tổng số ngày phép được hưởng
var getTotalDaysPerYear = function (value, p, record) {
    if (value == "" || value == 0) {
        return "<span style='float:right;'>0</span>";
    }
    return "<b style='float:right;color:blue;'>" + value + "</b>";
}

var enterKeyPressHandler = function (f, e) {
    if (e.getKey() == e.ENTER) {
        PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad(); Store1.reload();
    }
}

//Xóa các điều kiện lọc
var clearFilter = function () {
    txtMaCB.reset();
    txtHoTen.reset();
    cbPhongBan.reset();
    cbTo.reset();
    txtTongSoNgayPhep.reset();
    txtSoNgayDaSuDung.reset();
    txtSoNgayConLai.reset();
    txtCongDonNgayPhep.reset();
    txtThamNien.reset();
    PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad(); Store1.reload();
}

var ValidateNgayPhep = function () {
    if (nbfSoNgayPhep.getValue() == '') {
        alert("Bạn chưa nhập số ngày nghỉ phép năm nay");
        nbfSoNgayPhep.focus();
        return false;
    }
    if (nbfSoNgayPhepCongDonToiDaTrong1Thang.getValue() == '') {
        alert("Bạn chưa nhập số ngày phép được cộng dồn trong 1 tháng");
        nbfSoNgayPhepCongDonToiDaTrong1Thang.focus();
        return false;
    }
    if (nbfSoNgayPhepThuongThem.getValue() != '' && dfHanDungNgayPhepThuongThem.getValue() == '') {
        alert("Bạn chưa nhập hạn sử dụng ngày phép được thưởng thêm");
        return false;
    }
    if (chkNgayNghiPhepNamTruoc.checked == true && dfHanDungNgayPhepNamTruoc.getValue() == '') {
        alert("Bạn chưa nhập hạn dùng ngày nghỉ phép của năm trước");
        return false;
    }
    if (rdChiNhungNhanVienDuocChon.checked == false && rdApDungChoTatCaNhanVien.checked == false) {
        alert("Bạn chưa chọn đối tượng được tính ngày phép");
        return false;
    }
    return true;
}

var RenderSoNgayPhepDaSuDung = function (value, p, record) {
    if (value == "0" || value == null) {
        return "";
    }
    return value;
}
var ResetForm = function () {
    dfHanSuDungNPNamTruoc.reset();
    nbfSoNgayPhep.reset();
    nbfSoNgayPhepThuongThem.reset();
    chkNgayNghiPhepNamTruoc.reset();
    dfHanDungNgayPhepNamTruoc.reset();
    dfHanDungNgayPhepThuongThem.reset();
    nbfSoNgayPhepCongDonToiDaTrong1Thang.reset();
    rdApDungChoTatCaNhanVien.enable();
    rdChiNhungNhanVienDuocChon.setValue(false);
    rdApDungChoTatCaNhanVien.setValue(false);
}

var RenderThamNien = function (value, p, record) {
    var totalDay = value * 1;
    if (totalDay == 0) {
        return "";
    }
    var month = Math.floor(totalDay / 30);
    var remainDay = totalDay % 30;
    var year = 0;
    var remainMonth = 0;
    var rs = "";
    if (month >= 12) {
        year = Math.floor(month / 12);
        remainMonth = month % 12;
    }
    if (year > 0) {
        rs = year + " năm ";
        if (remainMonth > 0) {
            rs += remainMonth + " tháng";
        }
    }
    else {
        rs = month + " tháng ";
        if (remainDay > 0) {
            rs += remainDay + " ngày";
        }
    }
    return rs;
}
 