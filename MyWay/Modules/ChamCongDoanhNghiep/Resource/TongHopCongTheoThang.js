ChangeTitle = function () {
    txtTenBangChamCong.setValue("Bảng tổng hợp công tháng " + cbMonth.getValue() + "/" + txtYear.getValue());
}
var RenderSoLan = function (value, p, record) {
    if (value == '' || value == null || value == 0)
        return '';
    return value + ' lần';
}
var RenderSoPhut = function (value, p, record) {
    if (value == '' || value == null || value == 0)
        return '';
    if (value % 60 == 0)
        return (value / 60) + ' giờ';
    return parseInt(value / 60) + ' giờ ' + (value % 60) + ' phút';
}
var RenderGio = function (value, p, record) {
    if (value == '' || value == null || value == 0)
        return '';
    return parseInt(value) + ' giờ';
}
var RenderNumber = function (value, p, record) {
    if (value == '' || value == null || value == 0)
        return '';
    return value;
}
var enterKeyPressHandler = function (f, e) {
    if (e.getKey() == e.ENTER) {
        grpTongHopCongStore.reload();
    }
}
var CheckSelectedRow = function (grid) {
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
var afterEdit = function (e) {
    Ext.net.DirectMethods.AfterEdit(e.record.data.ID, e.field, e.originalValue, e.value, e.record.data);
};
var saveData = function () {
    var innerHTML = document.getElementById("sqlQuery").innerHTML;
    if (innerHTML.length != 0) {
        Ext.net.DirectMethods.SaveData(innerHTML);
    }
}
var clearSQL = function () {
    document.getElementById("sqlQuery").innerHTML = "";
    document.getElementById("maCBChange").innerHTML = "";
}
var getRowClass = function (record) {
    if (hdfIsLocked.getValue() == 'true') {
        return "colored";
    }
    return "nothing";
}