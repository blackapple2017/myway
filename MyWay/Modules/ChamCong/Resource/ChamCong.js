var GetGioVao = function (value, p, record) {
    if (value == '' || value == null) {
        return "<span style='color:black;'>" + hdfBatDauLamSang.getValue() + "</span>";
    }
    var h = value.split(':')[0] * 1;
    var m = value.split(':')[1] * 1;
    //gio chuan
    var _h = hdfBatDauLamSang.getValue().split(':')[0] * 1;
    var _m = hdfBatDauLamSang.getValue().split(':')[1] * 1;
    if ((m > _m && h == _h) || h > _h) {
        return "<span style='color:red;'>" + value + "</span>";
    }
    else if (hdfChoPhepLamThemDauGio.getValue() == 'True' && (h < _h || (h == _h && m < _m))) {
        return "<span style='color:blue;'>" + value + "</span>";
    }
    return value;
}
var GetGioRaGiuaCa = function (value, p, record) {
    if (value == '' || value == null) {
        return "<span style='color:black;'>" + hdfKetThucLamSang.getValue() + "</span>";
    }
    var h = value.split(':')[0] * 1;
    var m = value.split(':')[1] * 1;
    //gio chuan
    var _h = hdfKetThucLamSang.getValue().split(':')[0] * 1;
    var _m = hdfKetThucLamSang.getValue().split(':')[1] * 1;
    if ((m > _m && h == _h) || h > _h) {
        return "<span style='color:red;'>" + value + "</span>";
    }
    else if (hdfChoPhepLamThemDauGio.getValue() == 'True' && (h < _h || (h == _h && m < _m))) {
        return "<span style='color:blue;'>" + value + "</span>";
    }
    return value;
}
var GetGioBatDauLamChieu = function (value, p, record) {
    if (value == '' || value == null) {
        return "<span style='color:black;'>" + hdfBatDauLamChieu.getValue() + "</span>";
    }
    var h = value.split(':')[0] * 1;
    var m = value.split(':')[1] * 1;
    //gio chuan
    var _h = hdfBatDauLamChieu.getValue().split(':')[0] * 1;
    var _m = hdfBatDauLamChieu.getValue().split(':')[1] * 1;
    if ((m > _m && h == _h) || h > _h) {
        return "<span style='color:red;'>" + value + "</span>";
    }
    else if (hdfChoPhepLamThemDauGio.getValue() == 'True' && (h < _h || (h == _h && m < _m))) {
        return "<span style='color:blue;'>" + value + "</span>";
    }
    return value;
}

var GetGioRa = function (value, p, record) {
    if (value == '' || value == null) {
        return "<span style='color:black;'>" + hdfKetThucLamChieu.getValue() + "</span>";
    }
    var h = value.split(':')[0] * 1;
    var m = value.split(':')[1] * 1;
    //gio ve chuan
    var hv = hdfKetThucLamChieu.getValue().split(':')[0] * 1;
    var mv = hdfKetThucLamChieu.getValue().split(':')[1] * 1;
    if (h < hv || (h == hv && m < mv)) {
        return "<span style='color:red;'>" + value + "</span>";
    }
    else if ((h == hv && m > mv) || h > hv) {
        return "<span style='color:blue;'>" + value + "</span>";
    }
    return value;
}
var GetTimeNow = function () {
    var h = new Date().getHours();
    var m = new Date().getMinutes();
    if (m < 10) {
        return h + ":0" + m;
    }
    return h + ":" + m;
} 