var RenderVND = function (value, p, record) {
    if (value == null || value.length == 0)
        return "";
    var am = value < 0;
    value = Math.round(value);
    if (value < 0)
        value = value * -1;
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
    if (am)
        return "<span style='float:right;'>(" + rs + ")</span>"; // + " VNĐ";
    else
        return "<span style='float:right;'>" + rs + "</span>"; // + " VNĐ";
}
var RenderNumber = function (value, p, record) {
    if (value == null || value.length == 0)
        return "";
    return "<span style='float:right;'>" + value + "</span>";
}
var RenderVNDBold = function (value, p, record) {
    if (value == null || value.length == 0)
        return "";
    value = Math.round(value);
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
    return "<span style='float:right;'><b>" + rs + "</b></span>"; // + " VNĐ";
}
var RenderVND0 = function (value, p, record) {
    value = Math.round(value);
    if (value == null || value.length == 0)
        return "<span style='float:right;'>0</span>";
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
        return "<span style='float:right;'>0</span>";
    }
    return "<span style='float:right;'>" + rs + "</span>"; // + " VNĐ";
}
var RenderPercent = function (value, p, record) {
    if (value == null || value == "") {
        return "";
    }
    return "<span style='float:right;'>" + value + " %</span>";
}

var GetBooleanIcon = function (value, p, record) {
    var sImageCheck = "<img  src='../../Resource/Images/check.png'>"
    var sImageUnCheck = "<img src='../../Resource/Images/uncheck.gif'>"
    if (value == "1") {
        return sImageCheck;
    } else if (value == "0") {
        return sImageUnCheck;
    }
    return "";
}
var GetMirrorBooleanIcon = function (value, p, record) { //Giống với GetBooleanIcon nhưng Icon thì trái ngược
    var sImageCheck = "<img  src='../../Resource/Images/check.png'>"
    var sImageUnCheck = "<img src='../../Resource/Images/uncheck.gif'>"
    if (value == "1") {
        return sImageUnCheck;
    } else {
        return sImageCheck;
    }
}
var GetGender = function (value, p, record) {
    var nam = "<span style='color:blue'>Nam</span>";
    var nu = "<span style='color:red'>Nữ</span>";
    if (value == 'M')
        return nam;
    else
        return nu;
}

var GetGenderTrueFalse = function (value, p, record) {
    var nam = "<span style='color:blue'>Nam</span>";
    var nu = "<span style='color:red'>Nữ</span>";
    if (value == 'true')
        return nam;
    else
        return nu;
}
var GetGenderBoolean = function (value, p, record) {
    var nam = "<span style='color:blue'>Nam</span>";
    var nu = "<span style='color:red'>Nữ</span>";
    if (value == '1')
        return nam;
    else if (value == '0')
        return nu;
    else
        return '';
}
/*
Lấy giới tính
*/
var RenderGender = function (value, p, record) {
    var nam = "<span style='color:blue'>Nam</span>";
    var nu = "<span style='color:red'>Nữ</span>";
    if (value == 'M')
        return nam;
    //   else if (value == 'F')
    //      return nu;
    else
        return nu;
}
var RenderGenderNoColor = function (value, p, record) {
    var nam = "Nam";
    var nu = "Nữ";
    if (value == 'M')
        return nam;
    //   else if (value == 'F')
    //      return nu;
    else
        return nu;
}
var GetGenderChar = function (value, p, record) {
    if (value == "M")
        return "<span style='color:blue'>Nam</span>";
    else
        return "<span style='color:red'>Nữ</span>";
}

var RenderDate = function (value, p, record) {
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
