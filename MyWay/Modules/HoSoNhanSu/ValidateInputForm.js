var ValidateInput = function () {
    reg1 = /^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$/;
    testmail = reg1.test(txt_email.getValue());
    testmail2 = reg1.test(txt_emailnguoilh.getValue());
    testmailkhac = reg1.test(txt_emailkhac.getValue());

    maskRe = /[0-9\.]/;
    if (txt_macb.getValue().trim() == '' || txt_macb.getValue() == null) {
        alert('Bạn chưa nhập mã cán bộ !');
        txt_macb.focus();
        return false;
    }
    if (txt_hoten.getValue().trim() == '' || txt_hoten.getValue() == null) {
        alert('Bạn chưa nhập họ tên !');
        txt_hoten.focus();
        return false;
    }
    if (dfNgaySinh.getValue() == '' || dfNgaySinh.getValue() == null) {
        alert('Bạn chưa nhập ngày sinh');
        dfNgaySinh.focus();
        return false;
    }
    if (ValidateDateField(dfNgaySinh) == false) {
        alert('Định dạng ngày sinh không đúng');
        dfNgaySinh.focus();
        return false;
    }
    if (cbx_quoctich.getValue() == '' || cbx_quoctich.getValue() == null) {
        alert('Bạn chưa chọn quốc tịch');
        cbx_quoctich.focus();
        return false;
    }
    if (cbx_dantoc.getValue() == '' || cbx_dantoc.getValue() == null) {
        alert('Bạn chưa chọn dân tộc');
        cbx_dantoc.focus();
        return false;
    }
    if (cbx_tthonnhan.getValue() == '' || cbx_tthonnhan.getValue() == null) {
        alert('Bạn chưa chọn tình trạng hôn nhân !');
        cbx_tthonnhan.focus();
        return false;
    }
    if (cbx_bophan.getValue() == '' || cbx_bophan.getValue() == null) {
        alert('Bạn chưa chọn bộ phận !');
        cbx_bophan.focus();
        return false;
    }
    if (cbx_bophan.getValue() <= 0) {
        alert('Bạn không có quyền thao tác với bộ phận này!');
        cbx_bophan.focus();
        return false;
    }
    //if (cbx_congviec.getValue() == '' || cbx_congviec.getValue() == null) {
    //    alert('Bạn chưa chọn vị trí công việc !');
    //    cbx_congviec.focus();
    //    return false;
    //}
    if (cbxHinhThucLamViec.getValue() == '' || cbxHinhThucLamViec.getValue() == null) {
        alert('Bạn chưa nhập hình thức làm việc');
        cbxHinhThucLamViec.focus();
        return false;
    }
    if (!testmail && txt_email.getValue().trim() != '' && txt_email.getValue() != null) {
        alert('Định dạng email chưa đúng !');
        txt_email.focus();
        return false;
    }
    if (!testmailkhac && txt_emailkhac.getValue().trim() != '' && txt_emailkhac.getValue() != null) {
        alert('Định dạng email khác không đúng');
        txt_emailkhac.focus();
        return false;
    }
    if (!testmail2 && txt_emailnguoilh.getValue() != '' && txt_emailnguoilh.getValue() != null) {
        alert('Định dạng email người liên hệ chưa đúng');
        txt_emailnguoilh.focus();
        return false;
    }
    // bắt lỗi các trường datefield
    if (date_tuyendau.getValue() != '' && ValidateDateField(date_tuyendau) == false) {
        alert('Định dạng ngày thử việc không đúng');
        date_tuyendau.focus();
        return false;
    }
    if (date_ngaynhanct.getValue() != '' && ValidateDateField(date_ngaynhanct) == false) {
        alert('Định dạng ngày chính thức không đúng');
        date_ngaynhanct.focus();
        return false;
    }
    if (dfNgayDongBHYT.getValue() != '' && ValidateDateField(dfNgayDongBHYT) == false) {
        alert('Định dạng ngày đóng BHYT không đúng');
        dfNgayDongBHYT.focus();
        return false;
    }
    if (dfNgayHetHanBHYT.getValue() != '' && ValidateDateField(dfNgayHetHanBHYT) == false) {
        alert('Định dạng ngày hết hạn BHYT không đúng');
        dfNgayHetHanBHYT.focus();
        return false;
    }
    if (dfNgayCapBHXH.getValue() != '' && ValidateDateField(dfNgayCapBHXH) == false) {
        alert('Định dạng ngày cấp BHXH không đúng');
        dfNgayCapBHXH.focus();
        return false;
    }
    if (date_ketthucbh.getValue() != '' && ValidateDateField(date_ketthucbh) == false) {
        alert('Định dạng ngày kết thúc bảo hiểm không đúng');
        date_ketthucbh.focus();
        return false;
    }
    if (date_capcmnd.getValue() != '' && ValidateDateField(date_capcmnd) == false) {
        alert('Định dạng ngày cấp CMND không đúng');
        date_capcmnd.focus();
        return false;
    }
    if (date_ngaycaphc.getValue() != '' && ValidateDateField(date_ngaycaphc) == false) {
        alert('Định dạng ngày cấp hộ chiếu không đúng');
        date_ngaycaphc.focus();
        return false;
    }
    if (date_hethanhc.getValue() != '' && ValidateDateField(date_hethanhc) == false) {
        alert('Định dạng ngày hết hạn hộ chiếu không đúng');
        date_hethanhc.focus();
        return false;
    }
    if (date_ngayvaodoan.getValue() != '' && ValidateDateField(date_ngayvaodoan) == false) {
        alert('Định dạng ngày vào Đoàn không đúng');
        date_ngayvaodoan.focus();
        return false;
    }
    if (date_vaocongdoan.getValue() != '' && ValidateDateField(date_vaocongdoan) == false) {
        alert('Định dạng ngày vào công đoàn không đúng');
        date_vaocongdoan.focus();
        return false;
    }
    if (date_thamgiacm.getValue() != '' && ValidateDateField(date_thamgiacm) == false) {
        alert('Định dạng ngày tham gia cách mạng không đúng');
        date_thamgiacm.focus();
        return false;
    }
    if (date_vaodang.getValue() != '' && ValidateDateField(date_vaodang) == false) {
        alert('Định dạng ngày vào Đảng không đúng');
        date_vaodang.focus();
        return false;
    }
    if (date_ngayvaodangct.getValue() != '' && ValidateDateField(date_ngayvaodangct) == false) {
        alert('Định dạng ngày vào Đảng chính thức không đúng');
        date_ngayvaodangct.focus();
        return false;
    }
    if (date_nhapngu.getValue() != '' && ValidateDateField(date_nhapngu) == false) {
        alert('Định dạng ngày nhập ngũ không đúng');
        date_nhapngu.focus();
        return false;
    }
    if (date_xuatngu.getValue() != '' && ValidateDateField(date_xuatngu) == false) {
        alert('Định dạng ngày xuất ngũ không đúng');
        date_xuatngu.focus();
        return false;
    }
    if (date_bonhiemcv.getValue() != '' && ValidateDateField(date_bonhiemcv) == false) {
        alert('Định dạng ngày bổ nhiệm chức vụ không đúng');
        date_bonhiemcv.focus();
        return false;
    }
    if (date_bnngach.getValue() != '' && ValidateDateField(date_bnngach) == false) {
        alert('Định dạng ngày bổ nhiệm ngạch không đúng');
        date_bnngach.focus();
        return false;
    }
    if (date_tuyendau.getValue() != '' && date_ngaynhanct.getValue() != '' && (date_tuyendau.getValue() > date_ngaynhanct.getValue())) {
        alert('Ngày thử việc phải trước ngày chính thức vào làm');
        date_tuyendau.focus();
        return false;
    }
    if (dfNgayDongBHYT.getValue() != '' && dfNgayHetHanBHYT.getValue() != '' && (dfNgayDongBHYT.getValue() > dfNgayHetHanBHYT.getValue())) {
        alert('Ngày đóng BHYT phải trước ngày hết hạn BHYT');
        dfNgayDongBHYT.focus();
        return false;
    }
    if (dfNgayCapBHXH.getValue() != '' && date_ketthucbh.getValue() != '' && (dfNgayCapBHXH.getValue() > date_ketthucbh.getValue())) {
        alert('Ngày cấp BHXH phải trước ngày hết hạn BHXH');
        dfNgayCapBHXH.focus();
        return false;
    }
    if (date_ngaycaphc.getValue() != '' && date_capcmnd.getValue() != '' && (date_capcmnd.getValue() > date_ngaycaphc.getValue())) {
        alert('Ngày cấp CMND phải trước ngày cấp Hộ chiếu');
        date_capcmnd.focus();
        return false;
    }
    if (date_ngaycaphc.getValue() == '' && date_hethanhc.getValue() != '') {
        alert('Bạn chưa nhập ngày cấp Hộ chiếu');
        date_ngaycaphc.focus();
        return false;
    }
    if (date_ngaycaphc.getValue() != '' && date_hethanhc.getValue() != '' && (date_ngaycaphc.getValue() > date_hethanhc.getValue())) {
        alert('Ngày cấp Hộ chiếu phải trước ngày hết hạn Hộ chiếu');
        date_ngaycaphc.focus();
        return false;
    }
    if (date_ngayvaodoan.getValue() != '' && date_vaocongdoan.getValue() != '' && (date_ngayvaodoan.getValue() > date_vaocongdoan.getValue())) {
        alert('Ngày vào Đoàn phải trước ngày vào Công đoàn');
        date_ngayvaodoan.focus();
        return false;
    }
    if (date_vaodang.getValue() != '' && date_ngayvaodangct.getValue() != '' && (date_vaodang.getValue() > date_ngayvaodangct.getValue())) {
        alert('Ngày vào Đảng phải trước ngày vào Đảng chính thức');
        date_vaodang.focus();
        return false;
    }
    if (date_nhapngu.getValue() != '' && date_xuatngu.getValue() != '' && (date_nhapngu.getValue() > date_xuatngu.getValue())) {
        alert('Ngày Nhập ngũ phải trước ngày Xuất ngũ');
        date_nhapngu.focus();
        return false;
    }
    if (date_bnngach.getValue() != '' && date_bonhiemcv.getValue() != '' && (date_bonhiemcv.getValue() > date_bnngach.getValue())) {
        alert('Ngày Bổ nhiệm chức vụ phải trước ngày Bổ nhiệm ngạch');
        date_bonhiemcv.focus();
        return false;
    }
    if (date_nghi.getValue() != '' && date_bonhiemcv.getValue() != '' && (date_bonhiemcv.getValue() > date_nghi.getValue())) {
        alert('Ngày Bổ nhiệm chức vụ phải trước ngày nghỉ việc');
        date_bonhiemcv.focus();
        return false;
    }

    return true;
}