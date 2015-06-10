//Sinh tiêu đề bảng phân ca tự động
ChangeTitle = function () {
    txtTenBangPhanCa.setValue("Bảng phân ca trong năm " + txtYear.getValue() + " tại " + ddfDonVi.getText().replace("[", "").replace("]", ""));
}

//var getValues = function (tree) {
//    var msg = [],
//            selNodes = tree.getChecked();

//    Ext.each(selNodes, function (node) {
//        msg.push(node.id);
//    });
//    hdfID.setValue(msg.join(","));
//    return msg.join(",");
//};

var getText = function (tree) {
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

//Reset window tạo bảng phân ca
var resetForm = function () {
    //hdfID.reset();
    ddfDonVi.reset();
   // TreePanelDonVi.reset();
    cbChonCa.reset();
    txtTenBangPhanCa.reset();
    ResetNodeChecked(this.TreePanelDonVi, this.hdfStringAllMaDonVi);
    hdfStringMaDonVi.reset();
}


var resetFormPhanCaNhanh = function () {
    cbTuThang1.reset(); cbDenThang1.reset(); cbChonCa1.reset();
    cbTuThang2.reset(); cbDenThang2.reset(); cbChonCa2.reset();
    cbTuThang3.reset(); cbDenThang3.reset(); cbChonCa3.reset();
    cbTuThang4.reset(); cbDenThang4.reset(); cbChonCa4.reset();
    cbTuThang5.reset(); cbDenThang5.reset(); cbChonCa5.reset();
    cbTuThang6.reset(); cbDenThang6.reset(); cbChonCa6.reset();
    chkChiApDungChoNhanVienDuocChon.reset();
    chkAll.reset();
    //hide các trigger
    cbTuThang1.triggers[0].hide(); cbDenThang1.triggers[0].hide(); cbChonCa1.triggers[0].hide();
    cbTuThang2.triggers[0].hide(); cbDenThang2.triggers[0].hide(); cbChonCa2.triggers[0].hide();
    cbTuThang3.triggers[0].hide(); cbDenThang3.triggers[0].hide(); cbChonCa3.triggers[0].hide();
    cbTuThang4.triggers[0].hide(); cbDenThang4.triggers[0].hide(); cbChonCa4.triggers[0].hide();
    cbTuThang5.triggers[0].hide(); cbDenThang5.triggers[0].hide(); cbChonCa5.triggers[0].hide();
    cbTuThang6.triggers[0].hide(); cbDenThang6.triggers[0].hide(); cbChonCa6.triggers[0].hide();
    //disable các control
    cbDenThang1.disable(); cbChonCa1.disable();
    cbDenThang2.disable(); cbChonCa2.disable();
    cbDenThang3.disable(); cbChonCa3.disable();
    cbDenThang4.disable(); cbChonCa4.disable();
    cbDenThang5.disable(); cbChonCa5.disable();
    cbDenThang6.disable(); cbChonCa6.disable();
}

var validateFormPhanCaNhanh = function () {
    if (chkChiApDungChoNhanVienDuocChon.checked == false && chkAll.checked == false) {
        alert("Bạn chưa chọn đối tượng áp dụng");
        return false;
    }

    if (cbTuThang1.getValue() == '' && cbDenThang1.getValue() == '' &&
        cbTuThang2.getValue() == '' && cbDenThang2.getValue() == '' &&
        cbTuThang3.getValue() == '' && cbDenThang3.getValue() == '' &&
        cbTuThang4.getValue() == '' && cbDenThang4.getValue() == '' &&
        cbTuThang5.getValue() == '' && cbDenThang5.getValue() == '' &&
        cbTuThang6.getValue() == '' && cbDenThang6.getValue() == '') {
        alert("Bạn chưa chọn thông tin phân ca");
        return false;
    }

    //if (cbDenThang1.getValue() * 1 >= cbTuThang2.getValue()*1
    //    || cbDenThang2.getValue() * 1 >= cbTuThang3.getValue()
    //    || cbDenThang3.getValue() * 1 >= cbTuThang4.getValue()
    //    || cbDenThang4.getValue() * 1 >= cbTuThang5.getValue()
    //    || cbDenThang5.getValue() * 1 >= cbTuThang6.getValue())
    //{
    //    alert("Các khoảng thời gian nhập vào không hợp lệ");
    //    return false;
    //}

    return true;
}

//kiểm tra tính hợp lệ của khoảng thời gian
var CheckRangeValide = function (cbTuThang, cbDenThang, chonCa) {
    if (cbTuThang.getValue() != '' && cbDenThang.getValue() != '') {
        if (cbTuThang.getValue() * 1 > cbDenThang.getValue() * 1) {
            Ext.Msg.alert("Cảnh báo", "Khoảng thời gian bạn chọn không hợp lệ, yêu cầu bạn chọn lại");
            cbDenThang.reset();
            cbDenThang.triggers[0].hide();
            chonCa.disable();
            return false;
        }
    }
    return true;
}
//Kiểm tra tính hợp lệ của đến tháng trước đến đầu tháng sau
var CheckRangeValideCa = function (cbDenThang, cbTuThang, chonCa) {
    if (cbTuThang.getValue() != '' && cbDenThang.getValue() != '') {
        if (cbTuThang.getValue() * 1 <= cbDenThang.getValue() * 1) {
            Ext.Msg.alert("Cảnh báo", "Đến tháng của mục trước phải nhỏ hơn từ tháng của mục sau, yêu cầu bạn chọn lại");
            cbTuThang.reset();
            cbTuThang.triggers[0].hide();
            chonCa.disable();
            return false;
        }
    }
    return true;
}
var enterKeyPressHandler = function (f, e) {
    if (e.getKey() == e.ENTER) {
        PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad();
        Store1.reload();
    }
}

var resetFormThietLapCaTuDong = function () {
    cbChonCaTuDong.reset();
    cbFromMonth.reset();
    cbToMonth.reset();
    rdKhongLuanChuyen.reset();
    spnSoThangLuanChuyenCa.reset();
}

var validateFormThietLapCaTuDong = function () {
    if (cbChonCaTuDong.getValue() == '') {
        alert("Bạn chưa chọn ca làm việc");
        cbChonCaTuDong.focus();
        return false;
    }
    if (cbFromMonth.getValue() == '') {
        alert("Bạn chưa chọn khoảng thời gian để phân ca");
        cbFromMonth.expand();
        return false;
    }
    if (cbToMonth.getValue() == '') {
        alert("Bạn chưa chọn khoảng thời gian để phân ca");
        cbToMonth.expand();
        return false;
    }
    return true;
}

var resetCheckedMonths = function () {
    chkThang1.reset();
    chkThang2.reset();
    chkThang3.reset();
    chkThang4.reset();
    chkThang5.reset();
    chkThang6.reset();
    chkThang7.reset();
    chkThang8.reset();
    chkThang9.reset();
    chkThang10.reset();
    chkThang11.reset();
    chkThang12.reset();
}

var getCheckedMonths = function () {
    if (RowSelectionModel1.getSelected().data.Thang1 != '') {
        chkThang1.setValue(true);
    }
    if (RowSelectionModel1.getSelected().data.Thang2 != '') {
        chkThang2.setValue(true);
    }
    if (RowSelectionModel1.getSelected().data.Thang3 != '') {
        chkThang3.setValue(true);
    }
    if (RowSelectionModel1.getSelected().data.Thang4 != '') {
        chkThang4.setValue(true);
    }
    if (RowSelectionModel1.getSelected().data.Thang5 != '') {
        chkThang5.setValue(true);
    }
    if (RowSelectionModel1.getSelected().data.Thang6 != '') {
        chkThang6.setValue(true);
    }
    if (RowSelectionModel1.getSelected().data.Thang7 != '') {
        chkThang7.setValue(true);
    }
    if (RowSelectionModel1.getSelected().data.Thang8 != '') {
        chkThang8.setValue(true);
    }
    if (RowSelectionModel1.getSelected().data.Thang9 != '') {
        chkThang9.setValue(true);
    }
    if (RowSelectionModel1.getSelected().data.Thang10 != '') {
        chkThang10.setValue(true);
    }
    if (RowSelectionModel1.getSelected().data.Thang11 != '') {
        chkThang11.setValue(true);
    }
    if (RowSelectionModel1.getSelected().data.Thang12 != '') {
        chkThang12.setValue(true);
    }
}

var ValidateTaoMoiBangPhanCa = function () {
    if (txtYear.getValue() == '') {
        alert('Chưa có thông tin năm sử dụng bảng phân ca');
        txtYear.focus();
        return false;
    }
    if (txtTenBangPhanCa.getValue() == '') {
        alert('Bạn chưa nhập tiêu đề bảng phân ca');
        txtTenBangChamCong.focus();
        return false;
    }
    if (txtTenBangPhanCa.getValue().length>500) {
        alert('Tiêu đề bảng chấm công quá dài');
        txtTenBangChamCong.focus();
        return false;
    }
    if (hdfStringMaDonVi.getValue() == "")
    {
        alert('Bạn chưa chọn bộ phận để tạo bảng phân ca');
        ddfDonVi.focus();
        return false;
    }

    return true;
}


var ChuyenNhanVien = function (grid, Store) {
            try {
                grid.getRowEditor().stopEditing();
            } catch (e) {

            }
            var s = grid.getSelectionModel().getSelections();
            for (var i = 0, r; r = s[i]; i++) {
                Ext.net.DirectMethods.btnChuyenNhanVien_Click(r.data.ID, r.data.MaCB, r.data.HoTen);
            }
  
}
    //grid.getRowEditor().stopEditing();