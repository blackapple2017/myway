var CheckNumber = function (value) {
    var a = isNaN(value);
    return a;
}
var checkDeleteAttackFile = function (el, hdf, fuf) {
    var size = 0;
    for (var num1 = 0; num1 < el.files.length; num1++) {
        var file = el.files[num1];
        size += file.size;
    }
    if (size > 10485760) {
        hdf.reset(); fuf.reset();
        return false;
    }
    return true;
}
var CheckSelectUser = function (hdf) {
    if (hdf.getValue() == '') {
        Ext.Msg.alert('Thông báo', 'Bạn chưa chọn nhân viên nào');
        return false;
    }
    return true;
}
var RenderTinhTrang = function (value, p, record) {
    if (value == "ChoDuyet") {
        return "Chờ duyệt";
    }
    else if (value == "DaDuyet") {
        return "<span style='color:blue;'>Đã duyệt</span>";
    }
    else if (value == "KhongDuyet")
        return "<span style='color:red;'>Không duyệt</span>";
    return value;
}
var SetSelectedKhoahoc = function (hiddenfield, gridPanel) {
    var s = gridPanel.getSelectionModel().getSelections();
    hiddenfield.reset();
    var t = "";
    for (var i = 0, r; r = s[i]; i++) {
        t += r.data.MaKeHoach + "," + r.data.KinhPhiCongTyHoTro + "," + r.data.KinhPhiNhanVienDong + "," + r.data.TenkeHoach + ";";
    }
    hiddenfield.setValue(t);
}

var CheckInputBaoHiem = function () {
    if (SouthHoSoNhanSu1_txtBHDonVi.getValue().trim() == '') {
        alert('Bạn chưa nhập đơn vị');
        SouthHoSoNhanSu1_txtBHDonVi.focus();
        return false;
    }
    if (SouthHoSoNhanSu1_cbBHCongViec.getValue().trim() == '') {
        alert('Bạn chưa chọn công việc');
        SouthHoSoNhanSu1_cbBHCongViec.focus();
        return false;
    }
    if (SouthHoSoNhanSu1_txtBHTyle.getValue() > 100 || SouthHoSoNhanSu1_txtBHTyle.getValue() < 0) {
        alert("Tỷ lệ bảo hiểm trong khoảng từ 0 -> 100%");
        SouthHoSoNhanSu1_txtBHTyle.focus();
        return false;
    }
    // bắt lỗi datefield
    if (ValidateDateField(SouthHoSoNhanSu1_dfBHTuNgay) == false) {
        alert('Định dạng từ ngày không đúng');
        return false;
    }
    if (ValidateDateField(SouthHoSoNhanSu1_dfBHDenNgay) == false) {
        alert('Định dạng đến ngày không đúng');
        return false;
    }

    var checkDecimal = '';
    if (SouthHoSoNhanSu1_txtBHHSLuong.getValue() != '')
        checkDecimal = SouthHoSoNhanSu1_txtBHHSLuong.getValue();
    var res = checkDecimal.split(".");
    if (res.length > 2) {
        alert('Định dạng hệ số lương không đúng');
        return false;
    }
    return true;
}

var CheckInputDaiBieu = function () {
    if (SouthHoSoNhanSu1_txtDBLoaiHinh.getValue().trim() == '') {
        alert('Bạn chưa nhập loại hình');
        SouthHoSoNhanSu1_txtDBLoaiHinh.focus();
        return false;
    }
    if (SouthHoSoNhanSu1_txtDBNhiemKy.getValue().trim() == '') {
        alert('Bạn chưa nhập nhiệm kỳ');
        SouthHoSoNhanSu1_txtDBNhiemKy.focus();
        return false;
    }
    // bắt lỗi datefield
    if (ValidateDateField(SouthHoSoNhanSu1_dfDBTuNgay) == false) {
        alert('Định dạng từ ngày không đúng');
        return false;
    }
    if (ValidateDateField(SouthHoSoNhanSu1_dfDBDenNgay) == false) {
        alert('Định dạng đến ngày không đúng');
        return false;
    }
    return true;
}

var CheckInputDeTai = function (el) {
    if (SouthHoSoNhanSu1_txtMaDeTai.getValue().trim() == '') {
        alert('Bạn chưa nhập mã đề tài');
        SouthHoSoNhanSu1_txtMaDeTai.focus();
        return false;
    }
    if (SouthHoSoNhanSu1_txtDeTaiTenDeTai.getValue().trim() == '') {
        alert('Bạn chưa nhập tên đề tài');
        SouthHoSoNhanSu1_txtDeTaiTenDeTai.focus();
        return false;
    }
    if (SouthHoSoNhanSu1_txtDeTaiCapDeTai.getValue().trim() == '') {
        alert('Bạn chưa nhập cấp đề tài');
        SouthHoSoNhanSu1_txtDeTaiCapDeTai.focus();
        return false;
    }
    // bắt lỗi datefield
    if (ValidateDateField(SouthHoSoNhanSu1_txtDeTaiTuNgay) == false) {
        alert('Định dạng từ ngày không đúng');
        SouthHoSoNhanSu1_txtDeTaiTuNgay.focus();
        return false;
    }
    if (ValidateDateField(SouthHoSoNhanSu1_txtDeTaiDenNgay) == false) {
        alert('Định dạng đến ngày không đúng');
        SouthHoSoNhanSu1_txtDeTaiDenNgay.focus();
        return false;
    }
    if ((SouthHoSoNhanSu1_txtDeTaiTuNgay.getValue() != '' && SouthHoSoNhanSu1_txtDeTaiDenNgay.getValue() != '') && (SouthHoSoNhanSu1_txtDeTaiTuNgay.getValue() > SouthHoSoNhanSu1_txtDeTaiDenNgay.getValue())) {
        alert('Từ ngày phải trước đến ngày!');
        SouthHoSoNhanSu1_txtDeTaiTuNgay.focus();
        return false;
    }
    var size = 0;
    for (var num1 = 0; num1 < el.files.length; num1++) {
        var file = el.files[num1];
        size += file.size;
    }
    if (size > 10485760) {
        alert('Phần mềm chỉ hỗ trợ các tệp tin đính kèm nhỏ hơn 10MB');
        return false;
    }
    return true;
}

var CheckInputHopDong = function (el) {
    if (SouthHoSoNhanSu1_txtHopDongSoHopDong.getValue().trim() == '') {
        alert('Bạn chưa nhập số hợp đồng');
        SouthHoSoNhanSu1_txtHopDongSoHopDong.focus();
        return false;
    }
    if (SouthHoSoNhanSu1_cbHopDongLoaiHopDong.getValue().trim() == '') {
        alert('Bạn chưa chọn loại hợp đồng');
        SouthHoSoNhanSu1_cbHopDongLoaiHopDong.focus();
        return false;
    }
    if (SouthHoSoNhanSu1_hdfViTriCongViec.getValue().trim() == '') {
        alert('Bạn chưa chọn công việc');
        SouthHoSoNhanSu1_cbx_congviec.focus();
        return false;
    }
    if (SouthHoSoNhanSu1_dfHopDongNgayHopDong.getValue() == '') {
        alert('Bạn chưa chọn ngày ký hợp đồng');
        SouthHoSoNhanSu1_dfHopDongNgayHopDong.focus();
        return false;
    }
    if (SouthHoSoNhanSu1_dfNgayCoHieuLuc.getValue() == '') {
        alert('Bạn chưa nhập ngày hợp đồng có hiệu lực');
        SouthHoSoNhanSu1_dfNgayCoHieuLuc.focus();
        return false;
    }
    //if (SouthHoSoNhanSu1_tgf_NguoiKyHD.getValue() == '') {
    //    alert('Bạn chưa nhập người đại diện đơn vị ký hợp đồng');
    //    SouthHoSoNhanSu1_tgf_NguoiKyHD.focus();
    //    return false;
    //}
    // bắt lỗi datefield
    if (ValidateDateField(SouthHoSoNhanSu1_dfHopDongNgayHopDong) == false) {
        alert('Định dạng ngày ký kết không đúng');
        return false;
    }
    if (ValidateDateField(SouthHoSoNhanSu1_dfNgayCoHieuLuc) == false) {
        alert('Định dạng ngày hiệu lực không đúng');
        return false;
    }
    if (ValidateDateField(SouthHoSoNhanSu1_dfHopDongNgayKiKet) == false) {
        alert('Định dạng ngày hết hợp đồng không đúng');
        return false;
    }
    if (SouthHoSoNhanSu1_dfNgayCoHieuLuc.getValue() != '' && SouthHoSoNhanSu1_dfHopDongNgayKiKet.getValue() != '' && (SouthHoSoNhanSu1_dfNgayCoHieuLuc.getValue() > SouthHoSoNhanSu1_dfHopDongNgayKiKet.getValue())) {
        alert('Ngày hiệu lực phải trước hoặc trong ngày hết hạn hợp đồng!');
        SouthHoSoNhanSu1_dfNgayCoHieuLuc.focus();
        return false;
    }
    var size = 0;
    for (var num1 = 0; num1 < el.files.length; num1++) {
        var file = el.files[num1];
        size += file.size;
    }
    if (size > 10485760) {
        alert('Phần mềm chỉ hỗ trợ các tệp tin đính kèm nhỏ hơn 10MB');
        return false;
    }
    return true;
}

var CheckInputKhaNang = function () {
    if (SouthHoSoNhanSu1_cbKhaNang.getValue().trim() == '') {
        alert('Bạn chưa chọn khả năng');
        SouthHoSoNhanSu1_cbKhaNang.focus();
        return false;
    }
    return true;
}

var CheckInputKhenThuong = function (el) {
    if (SouthHoSoNhanSu1_cbLyDoKhenThuong.getValue().trim() == '' && SouthHoSoNhanSu1_cbLyDoKhenThuong.getValue().trim() == '') {
        alert('Bạn chưa chọn lý do khen thưởng');
        SouthHoSoNhanSu1_cbLyDoKhenThuong.focus();
        return false;
    }
    if (SouthHoSoNhanSu1_cbHinhThucKhenThuong.getValue().trim() == '') {
        alert('Bạn chưa chọn hình thức khen thưởng');
        SouthHoSoNhanSu1_cbHinhThucKhenThuong.focus();
        return false;
    }
    //////
    if (ValidateDateField(SouthHoSoNhanSu1_dfKhenThuongNgayQuyetDinh) == false) {
        alert('Định dạng ngày quyết định không đúng');
        SouthHoSoNhanSu1_dfKhenThuongNgayQuyetDinh.focus();
        return false;
    }
    var size = 0;
    for (var num1 = 0; num1 < el.files.length; num1++) {
        var file = el.files[num1];
        size += file.size;
    }
    if (size > 10485760) {
        alert('Phần mềm chỉ hỗ trợ các tệp tin đính kèm nhỏ hơn 10MB');
        return false;
    }
    return true;
}

var CheckInputKyLuat = function (el) {
    if (SouthHoSoNhanSu1_cbLyDoKyLuat.getValue().trim() == '') {
        alert('Bạn chưa chọn lý do kỷ luật');
        SouthHoSoNhanSu1_cbLyDoKyLuat.focus();
        return false;
    }
    if (SouthHoSoNhanSu1_cbHinhThucKyLuat.getValue().trim() == '') {
        alert('Bạn chưa chọn hình thức kỷ luật');
        SouthHoSoNhanSu1_cbHinhThucKyLuat.focus();
        return false;
    }
    ///////
    if (ValidateDateField(SouthHoSoNhanSu1_dfKyLuatNgayQuyetDinh) == false) {
        alert('Định dạng ngày quyết định không đúng');
        SouthHoSoNhanSu1_dfKyLuatNgayQuyetDinh.focus();
        return false;
    }
    if (CheckNumber(SouthHoSoNhanSu1_txtKyLuatSoTien.getValue()) == true) {
        alert('Định dạng số tiền không đúng');
        SouthHoSoNhanSu1_txtKyLuatSoTien.focus();
        return false;
    }
    if (CheckNumber(SouthHoSoNhanSu1_nbfSoDiem.getValue()) == true) {
        alert('Định dạng điểm không đúng');
        SouthHoSoNhanSu1_nbfSoDiem.focus();
        return false;
    }
    var size = 0;
    for (var num1 = 0; num1 < el.files.length; num1++) {
        var file = el.files[num1];
        size += file.size;
    }
    if (size > 10485760) {
        alert('Phần mềm chỉ hỗ trợ các tệp tin đính kèm nhỏ hơn 10MB');
        return false;
    }
    return true;
}

var CheckInputQHGD = function () {
    if (SouthHoSoNhanSu1_txtQHGDHoTen.getValue().trim() == '') {
        alert('Bạn chưa nhập họ tên');
        SouthHoSoNhanSu1_txtQHGDHoTen.focus();
        return false;
    }
    if (SouthHoSoNhanSu1_cbQHGDGioiTinh.getValue().trim() == '') {
        alert('Bạn chưa chọn giới tính');
        SouthHoSoNhanSu1_cbQHGDGioiTinh.focus();
        return false;
    }
    if (SouthHoSoNhanSu1_cbQuanHeGiaDinh.getValue().trim() == '') {
        alert('Bạn chưa chọn quan hệ');
        SouthHoSoNhanSu1_cbQuanHeGiaDinh.focus();
        return false;
    }
    if (SouthHoSoNhanSu1_chkQHGDLaNguoiPhuThuoc.checked == true) {
        if (SouthHoSoNhanSu1_dfQHGDBatDauGiamTru.getValue() == '') {
            alert('Bạn chưa nhập ngày bắt đầu giảm trừ');
            SouthHoSoNhanSu1_dfQHGDBatDauGiamTru.focus();
            return false;
        }
        //        if (SouthHoSoNhanSu1_dfQHGDKetThucGiamTru.getValue() == '') {
        //            alert('Bạn chưa nhập ngày kết thúc giảm trừ');
        //            SouthHoSoNhanSu1_dfQHGDKetThucGiamTru.focus();
        //            return false;
        //        }
    }
    ////////
    if (ValidateDateField(SouthHoSoNhanSu1_dfQHGDBatDauGiamTru) == false) {
        alert('Định dạng ngày bắt đầu giảm trừ không đúng định dạng');
        SouthHoSoNhanSu1_dfQHGDBatDauGiamTru.focus();
        return false;
    }
    if (ValidateDateField(SouthHoSoNhanSu1_dfQHGDKetThucGiamTru) == false) {
        alert('Định dạng ngày kết thúc giảm trừ không đúng');
        return false;
    }

    if (SouthHoSoNhanSu1_dfQHGDBatDauGiamTru.getValue() != '' && SouthHoSoNhanSu1_dfQHGDKetThucGiamTru.getValue() != '' && (SouthHoSoNhanSu1_dfQHGDBatDauGiamTru.getValue() > SouthHoSoNhanSu1_dfQHGDKetThucGiamTru.getValue())) {
        alert('Ngày bắt đầu giảm trừ phải trước ngày kết thúc giảm trừ!');
        SouthHoSoNhanSu1_dfQHGDBatDauGiamTru.focus();
        return false;
    }
    return true;
}

var CheckInputQuaTrinhCongTac = function (el) {
    if (SouthHoSoNhanSu1_dfQTCTNgayBatDau.getValue() == '' || SouthHoSoNhanSu1_dfQTCTNgayBatDau.getValue() == null) {
        alert('Bạn chưa nhập ngày bắt đầu');
        SouthHoSoNhanSu1_dfQTCTNgayBatDau.focus();
        return false;
    }
    if (SouthHoSoNhanSu1_dfQTCTNgayKetThuc.getValue() == '' || SouthHoSoNhanSu1_dfQTCTNgayKetThuc.getValue() == null) {
        alert('Bạn chưa nhập ngày kết thúc');
        SouthHoSoNhanSu1_dfQTCTNgayKetThuc.focus();
        return false;
    }
    if (SouthHoSoNhanSu1_txtQTCTNoiDungCongViec.getValue() == '' || SouthHoSoNhanSu1_txtQTCTNoiDungCongViec.getValue() == null) {
        alert('Bạn chưa nhập nội dung công việc');
        SouthHoSoNhanSu1_txtQTCTNoiDungCongViec.focus();
        return false;
    }
    if (SouthHoSoNhanSu1_txtQTCTDiaDiemCT.getValue().trim() == '' || SouthHoSoNhanSu1_txtQTCTDiaDiemCT.getValue() == null) {
        alert('Bạn chưa nhập địa điểm công tác');
        SouthHoSoNhanSu1_txtQTCTDiaDiemCT.focus();
        return false;
    }
    ///////
    if (ValidateDateField(SouthHoSoNhanSu1_dfQTCTNgayBatDau) == false) {
        alert('Định dạng ngày bắt đầu không đúng');
        SouthHoSoNhanSu1_dfQTCTNgayBatDau.focus();
        return false;
    }
    if (ValidateDateField(SouthHoSoNhanSu1_dfQTCTNgayQuyetDinh) == false) {
        alert('Định dạng ngày quyết định không đúng');
        SouthHoSoNhanSu1_dfQTCTNgayQuyetDinh.focus();
        return false;
    }
    if (ValidateDateField(SouthHoSoNhanSu1_dfQTCTNgayKetThuc) == false) {
        alert('Định dạng ngày kết thúc không đúng');
        SouthHoSoNhanSu1_dfQTCTNgayKetThuc.focus();
        return false;
    }
    if ((SouthHoSoNhanSu1_dfQTCTNgayBatDau.getValue() != '' && SouthHoSoNhanSu1_dfQTCTNgayKetThuc.getValue() != '') && (SouthHoSoNhanSu1_dfQTCTNgayBatDau.getValue() > SouthHoSoNhanSu1_dfQTCTNgayKetThuc.getValue())) {
        alert('Ngày bắt đầu phải trước ngày kết thúc');
        SouthHoSoNhanSu1_dfQTCTNgayBatDau.focus();
        return false;
    }
    var size = 0;
    for (var num1 = 0; num1 < el.files.length; num1++) {
        var file = el.files[num1];
        size += file.size;
    }
    if (size > 10485760) {
        alert('Phần mềm chỉ hỗ trợ các tệp tin đính kèm nhỏ hơn 10MB');
        return false;
    }
    return true;
}

var CheckInputQuaTrinhDieuChuyen = function (el) {
    if (SouthHoSoNhanSu1_dfQTDCNgayQuyetDinh.getValue() == '') {
        alert('Bạn chưa chọn ngày quyết định');
        SouthHoSoNhanSu1_dfQTDCNgayQuyetDinh.focus();
        return false;
    }
    if (SouthHoSoNhanSu1_dfQTDCNgayCoHieuLuc.getValue() == '') {
        alert('Bạn chưa nhập ngày có hiệu lực');
        SouthHoSoNhanSu1_dfQTDCNgayCoHieuLuc.focus();
        return false;
    }
    if (SouthHoSoNhanSu1_hdfQTDCBoPhanMoi.getValue() == '') {
        alert('Bạn chưa nhập bộ phận mới');
        SouthHoSoNhanSu1_cbxQTDCBoPhanMoi.focus();
        return false;
    }
    ///////
    if (ValidateDateField(SouthHoSoNhanSu1_dfQTDCNgayCoHieuLuc) == false) {
        alert('Định dạng ngày hiệu lực không đúng');
        return false;
    }
    if (ValidateDateField(SouthHoSoNhanSu1_dfQTDCNgayQuyetDinh) == false) {
        alert('Định dạng ngày quyết định không đúng');
        return false;
    }
    if (ValidateDateField(SouthHoSoNhanSu1_dfQTDCNgayHetHieuLuc) == false) {
        alert('Định dạng ngày hết hiệu lực không đúng');
        return false;
    }
    var size = 0;
    for (var num1 = 0; num1 < el.files.length; num1++) {
        var file = el.files[num1];
        size += file.size;
    }
    if (size > 10485760) {
        alert('Phần mềm chỉ hỗ trợ các tệp tin đính kèm nhỏ hơn 10MB');
        return false;
    }

    if ((SouthHoSoNhanSu1_dfQTDCNgayQuyetDinh.getValue() != '' && SouthHoSoNhanSu1_dfQTDCNgayHetHieuLuc.getValue() != '') && (SouthHoSoNhanSu1_dfQTDCNgayQuyetDinh.getValue() > SouthHoSoNhanSu1_dfQTDCNgayHetHieuLuc.getValue())) {
        alert('Ngày hiệu lực phải nhỏ hơn ngày hết hiệu lực');
        SouthHoSoNhanSu1_dfQTDCNgayQuyetDinh.focus();
        return false;
    }
    return true;
}

var CheckInputTaiSan = function () {
    if (SouthHoSoNhanSu1_cbTaiSan.getValue().trim() == '') {
        alert('Bạn chưa chọn tài sản');
        SouthHoSoNhanSu1_cbTaiSan.focus();
        return false;
    }
    if (SouthHoSoNhanSu1_txtTaiSanSoLuong.getValue() == '' || SouthHoSoNhanSu1_txtTaiSanSoLuong.getValue() == null) {
        alert('Bạn chưa nhập số lượng tài sản');
        SouthHoSoNhanSu1_txtTaiSanSoLuong.focus();
        return false;
    }
    if (SouthHoSoNhanSu1_hdfDonViTinh.getValue() == '' || SouthHoSoNhanSu1_hdfDonViTinh.getValue() == null) {
        alert('Bạn chưa chọn đơn vị tính');
        SouthHoSoNhanSu1_cbxDonViTinh.focus();
        return false;
    }
    if (SouthHoSoNhanSu1_tsTxtinhTrang.getValue().trim() == '') {
        alert('Bạn chưa nhập tình trạng tài sản');
        SouthHoSoNhanSu1_tsTxtinhTrang.focus();
        return false;
    }
    if (ValidateDateField(SouthHoSoNhanSu1_tsDateField) == false) {
        alert('Định dạng ngày nhận không đúng');
        return false;
    }
    return true;
}

var CheckInputAttachFile = function () {
    if (SouthHoSoNhanSu1_txtFileName.getValue().trim() == '') {
        alert('Bạn chưa nhập tên hiển thị');
        SouthHoSoNhanSu1_txtFileName.focus();
        return false;
    }
    if (SouthHoSoNhanSu1_file_cv.getValue().trim() == '') {
        alert('Bạn chưa chọn file đính kèm');
        return false;
    }
    return true;
}

var CheckInputBangCap = function () {
    if (SouthHoSoNhanSu1_hdfMaTruongDaoTao.getValue() == '' || SouthHoSoNhanSu1_hdfMaTruongDaoTao.getValue() == null) {
        alert('Bạn chưa chọn trường đào tạo');
        SouthHoSoNhanSu1_cbx_NoiDaoTaoBangCap.focus();
        return false;
    }
    if (SouthHoSoNhanSu1_cbx_hinhthucdaotaobang.getValue() == '' || SouthHoSoNhanSu1_cbx_hinhthucdaotaobang.getValue() == null) {
        alert('Bạn chưa chọn hình thức đào tạo');
        SouthHoSoNhanSu1_cbx_hinhthucdaotaobang.focus();
        return false;
    }
    if (SouthHoSoNhanSu1_hdfMaChuyenNganh.getValue().trim() == '') {
        alert('Bạn chưa chọn chuyên ngành đào tạo');
        SouthHoSoNhanSu1_cbx_ChuyenNganhBangCap.focus();
        return false;
    }
    if (SouthHoSoNhanSu1_cbx_trinhdobangcap.getValue() == '' || SouthHoSoNhanSu1_cbx_trinhdobangcap.getValue() == null) {
        alert('Bạn chưa chọn trình độ đào tạo');
        SouthHoSoNhanSu1_cbx_trinhdobangcap.focus();
        return false;
    }
    if ((SouthHoSoNhanSu1_txtTuNam.getValue() != '' && SouthHoSoNhanSu1_txtTuNam.getValue().length != 4) || (CheckNumber(SouthHoSoNhanSu1_txtTuNam.getValue()) == true)) {
        alert('Định dạng từ năm không đúng');
        SouthHoSoNhanSu1_txtTuNam.focus();
        return false;
    }
    if ((SouthHoSoNhanSu1_txtDenNam.getValue() != '' && SouthHoSoNhanSu1_txtDenNam.getValue().length != 4) || (CheckNumber(SouthHoSoNhanSu1_txtDenNam.getValue()) == true)) {
        alert('Định dạng đến năm không đúng');
        SouthHoSoNhanSu1_txtDenNam.focus();
        return false;
    }
    if ((SouthHoSoNhanSu1_txtNamNhanBang.getValue() != '' && SouthHoSoNhanSu1_txtNamNhanBang.getValue().length != 4) || (CheckNumber(SouthHoSoNhanSu1_txtNamNhanBang.getValue()) == true)) {
        alert('Định dạng Năm nhận bằng không đúng');
        SouthHoSoNhanSu1_txtNamNhanBang.focus();
        return false;
    }
    if (SouthHoSoNhanSu1_txtTuNam.getValue() > SouthHoSoNhanSu1_txtDenNam.getValue()) {
        alert('Từ năm phải trước Đến năm');
        SouthHoSoNhanSu1_txtTuNam.focus();
        return false;
    }
    if (SouthHoSoNhanSu1_txtDenNam.getValue() > SouthHoSoNhanSu1_txtNamNhanBang.getValue()) {
        alert('Năm nhận bằng không được trước Đến năm');
        SouthHoSoNhanSu1_txtNamNhanBang.focus();
        return false;
    }
    return true;
}

var CheckInputKinhNghiemLamViec = function () {
    if (SouthHoSoNhanSu1_txt_noilamviec.getValue().trim() == '') {
        alert('Bạn chưa nhập nơi làm việc');
        SouthHoSoNhanSu1_txt_noilamviec.focus();
        return false;
    }
    if (SouthHoSoNhanSu1_txt_vitriconviec.getValue().trim() == '') {
        alert('Bạn chưa nhập vị trí công việc');
        SouthHoSoNhanSu1_txt_vitriconviec.focus();
        return false;
    }
    if (SouthHoSoNhanSu1_dfKNLVTuNgay.getValue() == '' || SouthHoSoNhanSu1_dfKNLVTuNgay.getValue() == null) {
        alert('Bạn chưa nhập từ ngày');
        SouthHoSoNhanSu1_dfKNLVTuNgay.focus();
        return false;
    }
    // validate datefield
    if (ValidateDateField(SouthHoSoNhanSu1_dfKNLVTuNgay) == false) {
        alert('Định dạng từ ngày không đúng');
        SouthHoSoNhanSu1_dfKNLVTuNgay.focus();
        return false;
    }
    if (ValidateDateField(SouthHoSoNhanSu1_dfKNLVDenNgay) == false) {
        alert('Định dạng đến ngày không đúng');
        SouthHoSoNhanSu1_dfKNLVDenNgay.focus();
        return false;
    }
    if ((SouthHoSoNhanSu1_dfKNLVTuNgay.getValue() != '' && SouthHoSoNhanSu1_dfKNLVDenNgay.getValue() != '') && (SouthHoSoNhanSu1_dfKNLVTuNgay.getValue() > SouthHoSoNhanSu1_dfKNLVDenNgay.getValue())) {
        alert('Từ ngày phải trước đến ngày');
        SouthHoSoNhanSu1_dfKNLVTuNgay.focus();
        return false;
    }
    if (CheckNumber(SouthHoSoNhanSu1_nbfMucLuong.getValue()) == true) {
        alert('Định dạng mức lương không đúng');
        SouthHoSoNhanSu1_nbfMucLuong.focus();
        return false;
    }
    return true;
}

var CheckInputChungChi = function () {
    if (SouthHoSoNhanSu1_cbx_tenchungchi.getValue().trim() == '') {
        alert('Bạn chưa chọn chứng chỉ');
        SouthHoSoNhanSu1_cbx_tenchungchi.focus();
        return false;
    }
    ///////
    if (ValidateDateField(SouthHoSoNhanSu1_df_NgayCap) == false) {
        alert('Định dạng ngày cấp không đúng');
        SouthHoSoNhanSu1_df_NgayCap.focus();
        return false;
    }
    if (ValidateDateField(SouthHoSoNhanSu1_df_NgayHetHan) == false) {
        alert('Định dạng ngày hết hạn không đúng');
        SouthHoSoNhanSu1_df_NgayHetHan.focus();
        return false;
    }
    if (SouthHoSoNhanSu1_df_NgayHetHan.getValue() != '' && SouthHoSoNhanSu1_df_NgayCap.getValue() != '' && (SouthHoSoNhanSu1_df_NgayHetHan.getValue() < SouthHoSoNhanSu1_df_NgayCap.getValue())) {
        alert('Ngày cấp phải trước ngày hết hạn');
        SouthHoSoNhanSu1_df_NgayCap.focus();
        return false;
    }
    return true;
}

var CheckInputTaiNanLaoDong = function () {
    if (SouthHoSoNhanSu1_TaiNan_txtLydo.getValue().trim() == '') {
        alert('Bạn chưa nhập nguyên nhân gây tai nạn');
        SouthHoSoNhanSu1_TaiNan_txtLydo.focus();
        return false;
    }
    if (SouthHoSoNhanSu1_TaiNan_txtDiaDiemXayRa.getValue().trim() == '') {
        alert('Bạn chưa nhập địa điểm xảy ra tai nạn');
        SouthHoSoNhanSu1_TaiNan_txtDiaDiemXayRa.focus();
        return false;
    }
    ///////
    if (ValidateDateField(SouthHoSoNhanSu1_TaiNan_dfNgayXayRa) == false) {
        alert('Định dạng ngày xảy ra tai nạn không đúng');
        SouthHoSoNhanSu1_TaiNan_dfNgayXayRa.focus();
        return false;
    }
    if (ValidateDateField(SouthHoSoNhanSu1_TaiNan_txtNgayBoiThuong) == false) {
        alert('Định dạng bồi thường không đúng');
        SouthHoSoNhanSu1_TaiNan_txtNgayBoiThuong.focus();
        return false;
    }
    if ((SouthHoSoNhanSu1_TaiNan_dfNgayXayRa.getValue() != '' && SouthHoSoNhanSu1_TaiNan_txtNgayBoiThuong.getValue() != '') && (SouthHoSoNhanSu1_TaiNan_dfNgayXayRa.getValue() > SouthHoSoNhanSu1_TaiNan_txtNgayBoiThuong.getValue())) {
        alert('Ngày xảy ra tai nạn phải trước ngày bồi thường');
        SouthHoSoNhanSu1_TaiNan_dfNgayXayRa.focus();
        return false;
    }
    return true;
}

var ConvertStringToDateFormat = function (value, p, record) {
    if (value == '' || value == null) return "";
    value = value.replace(" ", "T");
    var tmp = value.split("T");
    if (tmp[0] == '01/01/0001') return "";
    return tmp[0];
}

var ConvertStringToNumberFormart1 = function (inputControl) {
    try {
        var value = inputControl.getValue();
        if (value == null)
            return "";
        aler(inputControl.getValue());
        var l = (value + "").length - 3;
        var s = value + "";
        var rs = "";
        var count = 0;
        for (var i = l - 1; i >= 0; i--) {
            count++;
            if (count == 3) {
                rs = "," + s.charAt(i) + rs;
                count = 0;
            }
            else {
                rs = s.charAt(i) + rs;
            }
        }
        if (rs.charAt(0) == ',') {
            inputControl.setValue(rs.substring(1, rs.length));
        }
        inputControl.setValue(rs);
    } catch (e) {

    }
}
var ResetWdBaoHiem = function () {
    SouthHoSoNhanSu1_txtBHDonVi.reset(); SouthHoSoNhanSu1_dfBHTuNgay.reset(); SouthHoSoNhanSu1_txtBHPhuCap.reset();
    SouthHoSoNhanSu1_txtBHMucLuong.reset(); SouthHoSoNhanSu1_cbBHCongViec.reset(); SouthHoSoNhanSu1_dfBHDenNgay.reset();
    SouthHoSoNhanSu1_txtBHHSLuong.reset(); SouthHoSoNhanSu1_txtBHTyle.reset(); SouthHoSoNhanSu1_txtBHGhiChu.reset();
}
var ResetWdDaiBieu = function () {
    SouthHoSoNhanSu1_txtDBLoaiHinh.reset(); SouthHoSoNhanSu1_dfDBTuNgay.reset(); SouthHoSoNhanSu1_txtDBNhiemKy.reset();
    SouthHoSoNhanSu1_dfDBDenNgay.reset(); SouthHoSoNhanSu1_txtDBGhiChu.reset();
}
var ResetWdDeTai = function () {
    SouthHoSoNhanSu1_txtDeTaiTenDeTai.reset(); SouthHoSoNhanSu1_txtDeTaiCapDeTai.reset(); SouthHoSoNhanSu1_txtDeTaiChuNhiemDeTai.reset();
    SouthHoSoNhanSu1_txDeTaiTuCachThamGia.reset(); SouthHoSoNhanSu1_txtDeTaiTuNgay.reset();
    SouthHoSoNhanSu1_txtDeTaiDenNgay.reset(); SouthHoSoNhanSu1_txtDeTaiKetQua.reset(); SouthHoSoNhanSu1_txtDeTaiGhiChu.reset();
    SouthHoSoNhanSu1_txtMaDeTai.reset(); SouthHoSoNhanSu1_hdfDeTaiTepTinDinhKem.reset(); SouthHoSoNhanSu1_fufDeTaiTepTinDinhKem.reset();
}
var ResetWdHopDong = function () {
    SouthHoSoNhanSu1_txtHopDongSoHopDong.reset(); SouthHoSoNhanSu1_cbHopDongLoaiHopDong.reset(); SouthHoSoNhanSu1_cbHopDongTinhTrangHopDong.reset();
    SouthHoSoNhanSu1_cbx_congviec.reset(); try { SouthHoSoNhanSu1_hdfViTriCongViec.reset(); } catch (e) { } SouthHoSoNhanSu1_dfHopDongNgayHopDong.reset(); SouthHoSoNhanSu1_dfHopDongNgayKiKet.reset();
    SouthHoSoNhanSu1_dfNgayCoHieuLuc.reset(); SouthHoSoNhanSu1_hdfPrkeyNguoiKyHD.reset(); SouthHoSoNhanSu1_cbx_HopDongChucVu.reset();
    SouthHoSoNhanSu1_fufHopDongTepTin.reset(); SouthHoSoNhanSu1_cbx_HopDongTrangThai.reset(); SouthHoSoNhanSu1_txtHopDongGhiChu.reset();
    SouthHoSoNhanSu1_tgf_NguoiKyHD.reset(); SouthHoSoNhanSu1_hdfHopDongTepTinDK.reset();
}
var ResetWdKhaNang = function () {
    SouthHoSoNhanSu1_cbKhaNang.reset(); SouthHoSoNhanSu1_cbKhaNangXepLoai.reset(); SouthHoSoNhanSu1_txtKhaNangGhiChu.reset();
}
var ResetWdKhenThuong = function () {
    SouthHoSoNhanSu1_txtKhenThuongSoQuyetDinh.reset(); SouthHoSoNhanSu1_dfKhenThuongNgayQuyetDinh.reset(); SouthHoSoNhanSu1_cbLyDoKhenThuong.reset();
    SouthHoSoNhanSu1_cbHinhThucKhenThuong.reset(); SouthHoSoNhanSu1_txtKhenThuongSoTien.reset(); SouthHoSoNhanSu1_txtKhenThuongGhiCHu.reset();
    SouthHoSoNhanSu1_hdfKhenThuongNguoiQD.reset(); SouthHoSoNhanSu1_tgf_KhenThuong_NguoiRaQD.reset(); SouthHoSoNhanSu1_fufKhenThuongTepTinDinhKem.reset();
    SouthHoSoNhanSu1_hdfKhenThuongTepTinDinhKem.reset(); SouthHoSoNhanSu1_nbfSoDiemKhenThuong.reset(); SouthHoSoNhanSu1_hdfLyDoKTTemp.reset(); SouthHoSoNhanSu1_hdfIsDanhMuc.reset();
}
var ResetWdKyLuat = function () {
    SouthHoSoNhanSu1_txtKyLuatSoQD.reset(); SouthHoSoNhanSu1_dfKyLuatNgayQuyetDinh.reset(); SouthHoSoNhanSu1_cbLyDoKyLuat.reset();
    SouthHoSoNhanSu1_cbHinhThucKyLuat.reset(); SouthHoSoNhanSu1_txtKyLuatSoTien.reset(); SouthHoSoNhanSu1_txtKyLuatGhiChu.reset();
    SouthHoSoNhanSu1_tgfKyLuatNguoiQD.reset(); SouthHoSoNhanSu1_hdfKyLuatTepTinDinhKem.reset(); SouthHoSoNhanSu1_fufKyLuatTepTinDinhKem.reset();
    SouthHoSoNhanSu1_nbfSoDiem.reset(); SouthHoSoNhanSu1_hdfIsDanhMucKL.reset();
}
var ResetWdQuanHeGiaDinh = function () {
    SouthHoSoNhanSu1_txtQHGDHoTen.reset(); SouthHoSoNhanSu1_cbQHGDGioiTinh.reset(); SouthHoSoNhanSu1_txtQHGDNamSinh.reset();
    SouthHoSoNhanSu1_cbQuanHeGiaDinh.reset(); SouthHoSoNhanSu1_txtQHGDNgheNghiep.reset(); SouthHoSoNhanSu1_txtQHGDNoiLamViec.reset(); SouthHoSoNhanSu1_txtQHGDGhiChu.reset();
    SouthHoSoNhanSu1_chkQHGDLaNguoiPhuThuoc.reset(); SouthHoSoNhanSu1_dfQHGDBatDauGiamTru.reset(); SouthHoSoNhanSu1_dfQHGDKetThucGiamTru.reset();
    SouthHoSoNhanSu1_dfQHGDBatDauGiamTru.setMaxValue(); SouthHoSoNhanSu1_dfQHGDBatDauGiamTru.setMinValue(); SouthHoSoNhanSu1_dfQHGDKetThucGiamTru.setMaxValue(); SouthHoSoNhanSu1_dfQHGDKetThucGiamTru.setMinValue();
    SouthHoSoNhanSu1_txtSoCMT.reset();
}
var ResetWdQuaTrinhCongTac = function () {
    SouthHoSoNhanSu1_txtQTCTSoQD.reset(); SouthHoSoNhanSu1_hdfQTCTNguoiQuyetDinh.reset(); SouthHoSoNhanSu1_tgf_QTCTNguoiQuyetDinh.reset();
    SouthHoSoNhanSu1_dfQTCTNgayBatDau.reset(); SouthHoSoNhanSu1_dfQTCTNgayBatDau.setMinValue(); SouthHoSoNhanSu1_dfQTCTNgayBatDau.setMaxValue();
    SouthHoSoNhanSu1_cbCongTacQuocGia.reset();
    SouthHoSoNhanSu1_dfQTCTNgayQuyetDinh.reset(); SouthHoSoNhanSu1_dfQTCTNgayQuyetDinh.setMinValue(); SouthHoSoNhanSu1_dfQTCTNgayQuyetDinh.setMaxValue();
    SouthHoSoNhanSu1_dfQTCTNgayKetThuc.reset(); SouthHoSoNhanSu1_dfQTCTNgayKetThuc.setMinValue(); SouthHoSoNhanSu1_dfQTCTNgayKetThuc.setMaxValue()
    SouthHoSoNhanSu1_txtQTCTNoiDungCongViec.reset(); SouthHoSoNhanSu1_txtQTCTDiaDiemCT.reset(); SouthHoSoNhanSu1_txtQTCTNguoiLienQuan.reset();
    SouthHoSoNhanSu1_hdfQTCTTepTinDinhKem.reset(); SouthHoSoNhanSu1_fufQTCTTepTinDinhKem.reset(); SouthHoSoNhanSu1_txtCongTacGhiChu.reset();
}
var ResetWdQuaTrinhDieuChuyen = function () {
    SouthHoSoNhanSu1_txtQTDCSoQuyetDinh.reset(); SouthHoSoNhanSu1_hdfQTDCNguoiQuyetDinh.reset(); SouthHoSoNhanSu1_tgfQTDCNguoiQuyetDinh.reset();
    SouthHoSoNhanSu1_dfQTDCNgayCoHieuLuc.reset();
    SouthHoSoNhanSu1_dfQTDCNgayQuyetDinh.reset(); SouthHoSoNhanSu1_dfQTDCNgayHetHieuLuc.reset(); SouthHoSoNhanSu1_cbxQTDCBoPhanMoi.reset();
    SouthHoSoNhanSu1_cbxQTDCChucVuMoi.reset(); SouthHoSoNhanSu1_hdfQTDCTepTinDinhKem.reset(); SouthHoSoNhanSu1_fufQTDCTepTinDinhKem.reset();
    SouthHoSoNhanSu1_txtDieuChuyenGhiChu.reset();
    SouthHoSoNhanSu1_cbxCongViecMoi.reset();
    SouthHoSoNhanSu1_hdfQTDCBoPhanMoi.reset();
    SouthHoSoNhanSu1_hdfQTDCChucVuMoi.reset();
    SouthHoSoNhanSu1_hdfCongViecMoi.reset();
}
var ResetWdTaiSan = function () {
    SouthHoSoNhanSu1_cbTaiSan.reset(); SouthHoSoNhanSu1_tsDateField.reset(); SouthHoSoNhanSu1_tsTxtinhTrang.reset(); SouthHoSoNhanSu1_tsGhiChu.reset(); SouthHoSoNhanSu1_hdfDonViTinh.reset();
    SouthHoSoNhanSu1_txtTaiSanSoLuong.reset(); SouthHoSoNhanSu1_cbxDonViTinh.reset(); SouthHoSoNhanSu1_dfTSanHSD.reset();
}
var ResetWdAttachFile = function () {
    SouthHoSoNhanSu1_txtFileName.reset(); SouthHoSoNhanSu1_txtGhiChu.reset(); SouthHoSoNhanSu1_file_cv.reset();
}
var ResetWdBangCap = function () {
    SouthHoSoNhanSu1_txtNamNhanBang.reset(); SouthHoSoNhanSu1_cbx_NoiDaoTaoBangCap.reset(); SouthHoSoNhanSu1_cbx_hinhthucdaotaobang.reset();
    SouthHoSoNhanSu1_txt_khoa.reset(); SouthHoSoNhanSu1_Chk_DaTotNghiep.Checked = false; SouthHoSoNhanSu1_cbx_ChuyenNganhBangCap.reset();
    SouthHoSoNhanSu1_cbx_trinhdobangcap.reset(); SouthHoSoNhanSu1_cbx_xeploaiBangCap.reset(); SouthHoSoNhanSu1_txtTuNam.reset();
    SouthHoSoNhanSu1_txtDenNam.reset();
}
var ResetWdKinhNghiemLamViec = function () {
    SouthHoSoNhanSu1_txtGhiChuKinhNghiemLamViec.reset();
    SouthHoSoNhanSu1_txtLyDoThoiViec.reset();
    SouthHoSoNhanSu1_nbfMucLuong.reset();
    SouthHoSoNhanSu1_txtThanhTichTrongCongViec.reset();
    SouthHoSoNhanSu1_txt_vitriconviec.reset();
    SouthHoSoNhanSu1_dfKNLVDenNgay.reset();
    SouthHoSoNhanSu1_txt_noilamviec.reset();
    SouthHoSoNhanSu1_dfKNLVTuNgay.reset();
}
var ResetWdChungChi = function () {
    SouthHoSoNhanSu1_df_NgayCap.reset(); SouthHoSoNhanSu1_df_NgayHetHan.reset(); SouthHoSoNhanSu1_cbx_tenchungchi.reset();
    SouthHoSoNhanSu1_cbx_NoiDaoTao.reset(); SouthHoSoNhanSu1_cbx_XepLoaiChungChi.reset();
    SouthHoSoNhanSu1_txtGhiChuChungChi.reset();
}
var ResetWdTaiNanLaoDong = function () {
    SouthHoSoNhanSu1_TaiNan_dfNgayXayRa.reset(); SouthHoSoNhanSu1_TaiNan_txtLydo.reset(); SouthHoSoNhanSu1_TaiNan_txtDiaDiemXayRa.reset();
    SouthHoSoNhanSu1_TaiNan_txtThietHai.reset(); SouthHoSoNhanSu1_TaiNan_txtThuongTat.reset(); SouthHoSoNhanSu1_TaiNan_txtBoiThuong.reset();
    SouthHoSoNhanSu1_TaiNan_txtGhiChu.reset(); SouthHoSoNhanSu1_TaiNan_txtNgayBoiThuong.reset();
}

var resetWdTheNganHang = function () {
    SouthHoSoNhanSu1_nbf_ATMNumber.reset(); SouthHoSoNhanSu1_cb_BankID.reset(); SouthHoSoNhanSu1_chk_IsInUsed.reset(); SouthHoSoNhanSu1_txt_Note.reset();
    SouthHoSoNhanSu1_Button5.hide();
    SouthHoSoNhanSu1_btnUpdateTheNganHang.show();
    SouthHoSoNhanSu1_Button4.show();
}

var resetWdThuTuc = function () {
    SouthHoSoNhanSu1_txtTenThuTuc.reset(); SouthHoSoNhanSu1_chbHoanThanh.reset();

}
var validateWdTheNganHang = function () {
    if (SouthHoSoNhanSu1_nbf_ATMNumber.getValue() == '') {
        alert('Bạn chưa nhập số tài khoản');
        SouthHoSoNhanSu1_nbf_ATMNumber.focus();
        return false;
    }
    if (SouthHoSoNhanSu1_cb_BankID.getValue() == '') {
        alert('Bạn chưa chọn ngân hàng');
        SouthHoSoNhanSu1_cb_BankID.focus();
        return false;
    }
    return true;
}
var RenderTrangThaiHopDong = function (value, p, record) {
    if (value == 'DaDuyet')
        return '<span style="color:blue;"><b>Đã duyệt</b></span>';
    if (value == 'ChuaDuyet')
        return '<span style="color:red;"><b>Chưa duyệt</b></span>';
}
var RenderTepTinDinhKem = function (value, p, record) {
    if (value != null && value != '') {
        return "<img src='../../Resource/images/attach.png'>";
    }
    return '';
}
//Thêm mới đơn vị tính
var addDonViTinh = function () {
    var grid = SouthHoSoNhanSu1_grpDonViTinh;
    grid.getRowEditor().stopEditing();

    grid.insertRecord(0, {
        DATE_CREATE: (new Date()).clearTime(),
        TEN_DVT: "",
        MA_DVT: "0",
        GHI_CHU: ""
    });
    SouthHoSoNhanSu1_txtMaDonViTinh.enable();

    grid.getView().refresh();
    grid.getSelectionModel().selectRow(0);
    grid.getRowEditor().startEditing(0);
}
// sửa đơn vị tính
var editDonViTinh = function () {
    var grid = SouthHoSoNhanSu1_grpDonViTinh;
    grid.getRowEditor().stopEditing();
    var s = grid.getSelectionModel().getSelections();
    for (var i = 0, r; r = s[i]; i++) {
        grid.getView().refresh();
        grid.getSelectionModel().selectRow(r);
        grid.getRowEditor().startEditing(r);
        SouthHoSoNhanSu1_hdfMaDonViTinh.setValue(r.data.MA_DVT);
    }
    SouthHoSoNhanSu1_txtMaDonViTinh.disable();
}
// xóa đơn vị tính
var deleteDonViTinh = function (DirectMethods) {
    var grid = SouthHoSoNhanSu1_grpDonViTinh;
    var Store = SouthHoSoNhanSu1_grpDonViTinh_Store;
    if (SouthHoSoNhanSu1_hdfButton.getValue() == 'delete') {
        try {
            grid.getRowEditor().stopEditing();
        } catch (e) {
            alert(e.Message.toString());
        }
        var s = grid.getSelectionModel().getSelections();
        for (var i = 0, r; r = s[i]; i++) {
            Store.remove(r);
            Store.commitChanges();
            DirectMethods.DeleteDonViTinh(r.data.MA_DVT);
        }
    }
}
var RemoveCanceledRecord = function (grid, Store) {
    if (SouthHoSoNhanSu1_hdfButton.getValue() == 'insert') {
        try {
            grid.getRowEditor().stopEditing();
        } catch (e) {
            alert(e.Message.toString());
        }
        var s = grid.getSelectionModel().getSelections();
        for (var i = 0, r; r = s[i]; i++) {
            Store.remove(r);
        }
    }
}
var getSelectedIndexRow = function (grid) {
    var record = grid.getSelectionModel().getSelected();
    var index = grid.store.indexOf(record);
    if (index == -1)
        return 0;
    return index;
}
//Cập nhật lại bản ghi trên grid quản lý các đơn vị tính
addUpdatedRecord = function (maDVT, tenDVT, ghiChu) {
    var rowindex = getSelectedIndexRow(SouthHoSoNhanSu1_grpDonViTinh);
    //xóa bản ghi cũ
    var s = SouthHoSoNhanSu1_grpDonViTinh.getSelectionModel().getSelections();
    for (var i = 0, r; r = s[i]; i++) {
        SouthHoSoNhanSu1_cbxDonViTinh_Store.remove(r);
        SouthHoSoNhanSu1_cbxDonViTinh_Store.commitChanges();
    }
    //Thêm bản ghi đã update
    SouthHoSoNhanSu1_grpDonViTinh.insertRecord(rowindex, {
        MA_DVT: maDVT,
        TEN_DVT: tenDVT,
        GHI_CHU: ghiChu,
        DATE_CREATED: (new Date()).clearTime()
    });
    SouthHoSoNhanSu1_grpDonViTinh.getView().refresh();
    SouthHoSoNhanSu1_grpDonViTinh.getSelectionModel().selectRow(rowindex);
    SouthHoSoNhanSu1_grpDonViTinh_Store.commitChanges();
}
var SaveDonViTinh = function (maDVT, tenDVT, ghiChu, DirectMethods) {
    DirectMethods.SaveDonViTinh(maDVT, tenDVT, ghiChu);
    SouthHoSoNhanSu1_grpDonViTinh_Store.commitChanges();
}
var GetRenderGT = function (value, p, record) {
    if (value == 'Nam')
        return '<span style="color:blue;">Nam</span>';
    if (value == 'Nữ')
        return '<span style="color:red;">Nữ</span>';
}
var GetFileNameUpload = function () {
    var fullPath = SouthHoSoNhanSu1_file_cv.getValue();
    var arrStr = fullPath.split('.');
    if (arrStr.length >= 2) {
        SouthHoSoNhanSu1_txtFileName.setValue(arrStr[arrStr.length - 2]);
    }
    else {
        SouthHoSoNhanSu1_txtFileName.setValue(fullPath);
    }
}