//Lấy ngày hôm nay, tùy theo định dạng Quốc tế hay việt nam
var GetTodayTime = function (culture) {
    if (culture == "vi") {
        return "'" + new Date().getDate() + '-' + (new Date().getMonth() + 1) + '-' + new Date().getFullYear() + "'";
    }
    else {
        return "'" + (new Date().getMonth() + 1) + '-' + new Date().getDate() + '-' + new Date().getFullYear() + "'";
    }
    // return '01-01-2011';
}