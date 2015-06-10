var enterKeyPressHandler = function (f, e) {
    if (e.getKey() == e.ENTER) {
        hdfMaDonVi.reset();
        hdfMaPhong.reset();
        PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad(); Store1.reload();
    }
}


var AlignRight = function (value, p, record) {
    if (value == "" || value == null) {
        return "<span style='color:#fff;'>.</span>";
    }
    return "<span style='float:right;'>" + value + "</span>";
}

var GetHienCo = function(value, p, record) {
    if (value == "" || value == null) {
        return "<span style='color:red;float:right;'>0</span>";
    }
    return "<span style='float:right;'>" + value + "</span>";
};

var ValidateFormwdChonPhong = function () {
  
    if (cbDonViList.getValue() == '' && chkAllDepartments.checked == false) {
        alert('Bạn chưa chọn phòng ban');
        return false;
    }
    if (cbCongViecList.getValue() == '' && chkAllWorks.checked == false) {
        alert('Bạn chưa chọn công việc');
        return false;
    }
    if (dfDatetime.getValue() == '') {
        alert('Bạn chưa chọn ngày');
        
    return false;
}
};

var SaveData = function (e) {

    var data = e.record.data;
    if (e.value.toString().length > 0 && e.originalValue != e.value) {

        if (e.field == "SoLuongTuyenMoi") {
            e.record.data.SoLuongDinhBien = parseInt(e.value) + parseInt(e.record.data.SoLuongNhanSu);
            customPost('UpdateGrid', e.record.data.ID, 'SoLuongDinhBien', e.record.data.SoLuongDinhBien);
        } else if (e.field == "SoLuongDinhBien") {
            e.record.data.SoLuongTuyenMoi = parseInt(e.value) - parseInt(e.record.data.SoLuongNhanSu);
            customPost('UpdateGrid', e.record.data.ID, 'SoLuongTuyenMoi', e.record.data.SoLuongTuyenMoi);
        } 

        var totalTuyenMoi = (data.Thang1) + (data.Thang2) + (data.Thang3) + (data.Thang4) + (data.Thang5) + (data.Thang6) + (data.Thang7) + (data.Thang8) + (data.Thang9) + (data.Thang10) + (data.Thang11) + (data.Thang12);
        if (totalTuyenMoi > data.SoLuongDinhBien) 
        {
            Ext.net.Notification.show({
                                    iconCls  : 'icon-information',
                                    pinEvent : 'click',
                                    html: 'Tống số nhân viên đang lớn hơn số lượng định biên ở dòng '+(e.row +1)+' !',
                                    title    : 'Cảnh báo'
                                    });
        }



        
        customPost('UpdateGrid', e.record.data.ID, e.field, e.value);
        Store1.commitChanges();
        //        var html = document.getElementById("divSql").innerHTML;
        //        document.getElementById("divSql").innerHTML = html + "   update [TuyenDung].DinhBienNhanSu set " + e.field + " = " + e.value + " where ID = " + e.record.data.ID + ";";
        //        // Ext.net.DirectMethods.SaveInputedData(e.field, e.value * 1, e.record.data.ID * 1);

    }
};


var customPost = function(type,id,column,value) {
    $.ajax({
        url: '../../Modules/TuyenDung/DinhBienNhanSuHandler.ashx',
        type: 'POST',
        data: {
            Type: type,
            Id: id,
            Column: column,
            Value: value
        },
        success: function (doc) {

        },
        error: function (e) {
            alert('there was an error while fetching events!');
        }
    });
};


var ValidateForm = function() {
    if (cbDonVi.getValue() == '') {
        alert("Bạn chưa chọn đơn vị");
        return false;
    }
    if (cbChucVuList.getValue() == '') {
        alert("Bạn chưa chọn chức vụ");
        return false;
    }

    if (MaCongViec.getValue() == '') {
        alert("Bạn chưa nhập mã công việc");
        return false;
    }
    if (TenCongViec.getValue() == '') {
        alert("Bạn chưa nhập tên công việc");
        return false;
    }

    if (txtDinhBien.getValue() == '') {
        alert("Bạn chưa nhập mức định biện nhân sự");
        return false;
    }
    return true;
};

var ResetForm = function () {

    MaCongViec.reset();
    TenCongViec.reset();
    txtDinhBien.reset();
    cbChucVuList.reset();
    cbDonVi.reset();
    thang1.reset();
    thang2.reset();
    thang3.reset();
    thang4.reset();
    thang5.reset();
    thang6.reset();
    thang7.reset();
    thang8.reset();
    thang9.reset();
    thang10.reset(); 
    thang11.reset();
    thang12.reset();

};