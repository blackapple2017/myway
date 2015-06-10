var enterKeyPressHandler = function (f, e) {
    if (e.getKey() == e.ENTER) {
        PagingToolbar1.pageIndex = 0;
        PagingToolbar1.doLoad();
        RowSelectEvent.clearSelections();
        if (this.getValue() == '') {
            this.triggers[0].hide();
        }
    }
    if (this.getValue() != '') {
        this.triggers[0].show();
    }
}
var keyEnterPress3 = function (f, e) {
    if (e.getKey() == e.ENTER) {
        PagingToolbar2.pageIndex = 0;
        PagingToolbar2.doLoad();
        RowSelectionModelBangLuongChamCong.clearSelections();
        if (this.getValue() == '') {
            this.triggers[0].hide();
        }
    }
    if (this.getValue() != '') {
        this.triggers[0].show();
    }
}
//Render cột ngày hôm nay ở bên trái
RenderTodayleft = function (value, metaData, record) {
    if (value == null)
        return "";
    else
        return value;
}
var checkInputClick = function () {
    if (ddfDonvi.getValue() == '') { alert('Bạn chưa chọn đơn vị sử dụng bảng chấm công'); return false; }
    if (txtYear.getValue() == '') { alert('Bạn chưa nhập năm sử dụng bảng chấm công'); txtYear.focus(); return false; }
    if (txtTenBangChamCong.getValue() == '') { alert('Bạn chưa nhập tiêu đề bảng chấm công'); txtTenBangChamCong.focus(); return false; }
}
RenderNgayCong = function (value, p, record) {
    return "<span style='color:blue;'>" + value + " ngày</span>";
}
RenderNumber = function (value, p, record) {
    if (value == null) {
        return "";
    }
    if (value * 1 > 0) {
        return "<span style='float:right;padding-right:5px;color:red;font-weight:bold;'>" + value + "</span>";
    }
    return "<span style='float:right;padding-right:5px;'>" + value + "</span>";
}
ChangeTitle = function () {
    if (ddfDonvi.getText() != '') {
        var donvi = ddfDonvi.getText().replace("[", "").replace("]", "");
        while (donvi.contains("-")) {
            donvi = donvi.replace("-", "");
        }
        donvi = donvi.trim();
        txtTenBangChamCong.setValue("Bảng chấm công tháng " + cbMonth.getValue() + "/" + txtYear.getValue() + " tại " + donvi);
    }
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

var RenderHightLight = function (value, p, record) {
    var keyword = document.getElementById("txtSearchKey").value;
    if (keyword == "" || keyword == "Nhập từ khóa tìm kiếm...")
        return value;

    var rs = "<p>" + value + "</p>";
    var keys = keyword.split(" ");
    for (i = 0; i < keys.length; i++) {
        if ($.trim(keys[i]) != "") {
            var o = { words: keys[i] };
            rs = highlight(o, rs);
        }
    }
    return rs;
}
function highlight(options, content) {
    var o = {
        words: '',
        caseSensitive: false,
        wordsOnly: true,
        template: '$1<span class="highlight">$2</span>$3'
    }, pattern;
    $.extend(true, o, options || {});

    if (o.words.length == 0) { return; }
    pattern = new RegExp('(>[^<.]*)(' + o.words + ')([^<.]*)', o.caseSensitive ? "" : "ig");

    return content.replace(pattern, o.template);
}

var GetChamCongValue = function (gridPanel) {
    debugger;
    var s = gridPanel.getSelectionModel().getSelections();
    var rs = "";
    for (var i = 0, r; r = s[i]; i++) {
        try {
            rs += r.data.KYHIEU_TT_LAMVIEC + ",";
        } catch (e) {}
    }
    rs = rs.substring(0, rs.length-1);
    return rs;
}
//Loại bỏ nhân viên khỏi bảng chấm công
var RemoveEmployee = function () {
    var grid = GridPanel1;
    var Store = Store1;
    Ext.Msg.confirm('Xác nhận', 'Bạn có chắc chắn muốn xóa không ?', function (btn) {
        if (btn == "yes") {
            var s = grid.getSelectionModel().getSelections();
            for (var i = 0, r; r = s[i]; i++) {
                Store.remove(r);
                btnDeleteUser.disable();
            }
        }
    });
}

var CheckInputChamCongTheoKhoangThoiGian = function () {
    if (FromDate.getValue() == '') {
        alert("Bạn chưa chọn ngày bắt đầu");
        FromDate.focus();
        return false;
    }
    if (ToDate.getValue() == '') {
        alert("Bạn chưa chọn ngày kết thúc");
        ToDate.focus();
        return false;
    }
    if (cbTinhTrangLamViec.getValue() == '' && chkSaturday.checked == false && chkSunday.checked == false) {
        alert("Bạn chưa chọn tình trạng làm việc");
        cbTinhTrangLamViec.focus();
        return false;
    }
    if (chkSaturday.checked) {
        if (MultiComboSaturday.getValue() == '') {
            alert("Bạn chưa chọn tình trạng làm việc cho thứ 7");
            MultiComboSaturday.focus();
            return false;
        }
    }
    if (chkSunday.checked) {
        if (MultiComboSunday.getValue() == '') {
            alert("Bạn chưa chọn tình trạng làm việc cho chủ nhật");
            MultiComboSunday.focus();
            return false;
        }
    }
    return true;
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

