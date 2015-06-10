var ValidateAddSalaryBoard = function () {
    if (!txtTenBangTinhLuong.getValue()) {
        alert('Bạn chưa nhập tiêu đề bảng lương');
        txtTenBangTinhLuong.focus();
        return false;
    }
    return true;
}
var ResetFormAddSalaryBoard = function () {
    txtTenBangTinhLuong.reset();
    txtDescription.reset();
    
    //Field3.reset();
    //TreePanel1.getNodes.removeChildren();
    hdfMaDonVi.reset();
    cbChonPhongBan.reset();
    $('#jqxTree').jqxTree('uncheckAll');
}
var enterKeyPressHandler = function (f, e) {
    if (e.getKey() == e.ENTER) {
        StaticPagingToolbar.pageIndex = 0;
        StaticPagingToolbar.doLoad();
        grpSalaryBoard.getSelectionModel().clearSelections();
        hdfRecordID.setValue('');
    }
    if (txtSearch.getValue() != '')
        this.triggers[0].show();
}
var getTasks = function (tree) {
    var msg = [],
                selNodes = tree.getChecked();
    msg.push("[");

    Ext.each(selNodes, function (node) {
        if (msg.length > 1) {
            msg.push(",");
        }

        msg.push(node.text);
    });

    msg.push("]");

    return msg.join("");
};
var getCheckedID = function (tree) {
    var msg = [],
                selNodes = tree.getChecked();
    msg.push("");

    Ext.each(selNodes, function (node) {
        if (msg.length > 1) {
            msg.push(",");
        }

        msg.push(node.id);
    });

    msg.push("");

    return msg.join("");
};
var ValidateAjustment = function () {
    if (!cbxSelectColumn.getValue()) {
        alert('Bạn chưa chọn cột áp dụng');
        cbxSelectColumn.focus();
        return false;
    }
    if (!txtValueAdjustment.getValue()) {
        alert('Bạn chưa nhập giá trị điều chỉnh');
        txtValueAdjustment.focus();
        return false;
    }
    if (chkApplySelectedEmployee.getValue() == false && chkApplyForAll.getValue() == false) {
        alert('Bạn chưa chọn hình thức áp dụng');
        return false;
    }
    return true;
}
var ResetAjustmentWindow = function () {
    cbxSelectColumn.reset();
    txtValueAdjustment.reset();
    chkApplySelectedEmployee.reset();
    chkApplyForAll.reset();
}
var afterEdit = function (e) {
    Ext.net.DirectMethods.AfterEdit(e.record.data.ID, e.field, e.originalValue, e.value, e.record.data);
};
var RenderVNDGroupHeader = function (value) {
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
    return "<span style='float:right;padding-right: 3px;'><b>" + rs + "</b></span>";
}