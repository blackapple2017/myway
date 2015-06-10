var GetBooleanIconHSUV = function (value, p, record) {
    var sImageCheck = "<img  src='../../../Resource/Images/check.png'>"
    var sImageUnCheck = "<img src='../../../Resource/Images/uncheck.gif'>"
    if (value == "1") {
        return sImageCheck;
    } else if (value == "0") {
        return sImageUnCheck;
    }
    return "";
}
var RenderDate = function (value) {
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
function checkExtension(value) {
    if (value.match("\.txt$") != null ||
               value.match("\.pdf$") != null) {
        return true;
    }
    return "Incorrect file type";
}

var ResetwdChuyenLyDo = function () {
    cbx_Chuyen_LyDo.reset();
    txt_Chuyen_GhiChu.reset();
    hdfChuyen_LyDo.reset();
}
var ResetWdChungChi = function () {
    df_NgayCap.reset();
    df_NgayHetHan.reset();
    cbx_tenchungchi.reset();
    cbx_NoiDaoTao.reset();
    cbx_XepLoaiChungChi.reset();
    txtGhiChuChungChi.reset();
}
var setValuewdAddChungChi = function () {
    var data = RowSelectionModel_ChungChi.getSelected().data;
    if (data == null) {
        return;
    }
    hdfTenChungChi.setValue(data.MA_CHUNG_CHI);
    hdfTenXepLoai.setValue(data.MA_XEP_LOAI);
    cbx_tenchungchi.setValue(data.TEN_CHUNG_CHI);
    cbx_XepLoaiChungChi.setValue(data.TEN_XEP_LOAI);
    cbx_NoiDaoTao.setValue(data.NOI_DAO_TAO);
    df_NgayCap.setValue(RenderDate(data.NGAY_CAP));
    df_NgayHetHan.setValue(RenderDate(data.NGAY_HET_HAN));
    txtGhiChuChungChi.setValue(data.GHI_CHU);
    btnEditChungChi.show();
    btnUpdateChungChi.hide();
    btnUpdateandCloseChungChi.hide();
}
var ResetWdKinhNghiemLamViec = function () {
    txtGhiChuKinhNghiemLamViec.reset();
    txtLyDoThoiViec.reset();
    nbfMucLuong.reset();
    txtThanhTichTrongCongViec.reset();
    txt_vitricongviec.reset();
    dfKNLVDenNgay.reset();
    txt_noilamviec.reset();
    dfKNLVTuNgay.reset();
}
var setValuewdKinhNghiemLamViec = function () {
    var data = RowSelectionModel_KinhNghiemLamViec.getSelected().data;
    if (data == null) {
        return;
    }
    txtGhiChuKinhNghiemLamViec.setValue(data.GhiChu);
    txtLyDoThoiViec.setValue(data.LyDoThoiViec);
    nbfMucLuong.setValue(data.MucLuong);
    txtThanhTichTrongCongViec.setValue(data.KinhNghiemDatDuoc);
    txt_vitricongviec.setValue(data.ViTriCongViec);
    dfKNLVDenNgay.setValue(RenderDate(data.DenThangNam));
    txt_noilamviec.setValue(data.NoiLamViec);
    dfKNLVTuNgay.setValue(RenderDate(data.TuThangNam));
    btnEditKinhNghiem.show();
    btnUpdateKinhNghiem.hide();
    btnUpdateAndCloseKinhNghiem.hide();
}
var ResetWdAddBangCap = function () {
    hdfMaTruongDaoTao.reset();
    cbx_NoiDaoTaoBangCap.reset();
    hdfHinhThucDaoTao.reset();
    cbx_hinhthucdaotaobang.reset();
    txt_khoa.reset();
    Chk_DaTotNghiep.reset();
    hdfXepLoaiBangCap.reset();
    cbx_xeploaiBangCap.reset();
    hdfMaChuyenNganh.reset();
    cbx_ChuyenNganhBangCap.reset();
    hdfTrinhDoBangCap.reset();
    cbx_trinhdobangcap.reset();
    txtTuNam.reset();
    txtDenNam.reset();
    txtNamNhanBang.reset();

}
var setValueWdAddBangCap = function () {
    var data = RowSelectionModel_BangCap.getSelected().data;
    if (data == null) {
        return;
    }
    hdfMaTruongDaoTao.setValue(data.MA_TRUONG_DAOTAO);
    cbx_NoiDaoTaoBangCap.setValue(data.TEN_TRUONG_DAOTAO);
    hdfHinhThucDaoTao.setValue(data.MA_HT_DAOTAO);
    cbx_hinhthucdaotaobang.setValue(data.TEN_HT_DAOTAO);
    txt_khoa.setValue(data.KHOA);
    if (data.DA_TN)
        Chk_DaTotNghiep.setValue(true);
    else
        Chk_DaTotNghiep.setValue(false);
    hdfXepLoaiBangCap.setValue(data.MA_XEPLOAI);
    cbx_xeploaiBangCap.setValue(data.TEN_XEPLOAI);
    hdfMaChuyenNganh.setValue(data.MA_CHUYENNGANH);
    cbx_ChuyenNganhBangCap.setValue(data.TEN_CHUYENNGANH);
    hdfTrinhDoBangCap.setValue(data.MA_TRINHDO);
    cbx_trinhdobangcap.setValue(data.TEN_TRINHDO);
    txtTuNam.setValue(data.TU_NGAY.replace(/-01-01T00:00:00/g, ''));
    txtDenNam.setValue(data.DEN_NGAY.replace(/-01-01T00:00:00/g, ''));
    if (data.NGAY_NHANBANG)
        txtNamNhanBang.setValue(data.NGAY_NHANBANG.replace(/-01-01T00:00:00/g, ''));
    btnEditBangCap.show();
    btnUpdateBangCap.hide();
    btnUpdateAndCloseBangCap.hide();
}

var GetFileNameUpload = function () {
    var fullPath = file_cv.getValue();
    var arrStr = fullPath.split('.');
    if (arrStr.length >= 2) {
        txtFileName.setValue(arrStr[arrStr.length - 2]);
    }
    else {
        txtFileName.setValue(fullPath);
    }
}
var ResetWdAttachFile = function () {
    txtFileName.reset();
    txtGhiChu.reset();
    file_cv.reset();
}

var ResetwdChamDiemNhanXet = function () {
    txtDiemSo.reset();
    txtNhanXet.reset();
    txt_vongPV.reset();
    cboMonThi.reset();
    cbb_NguoiChamThi.reset();
    dfNgayThiTuyen.reset();
    hdfNguoiChamThi.reset();
    hdfMonThi.reset();
}
var setValuewdChamDiemNhanXet = function () {
    var data = RowSelectionModel_KetQuaPV.getSelected().data;
    if (data == null) {
        return;
    }
    txt_vongPV.setValue(data.VONG_THI);
    dfNgayThiTuyen.setValue(RenderDate(data.NGAY_THI));
    cboMonThi.setValue(data.TEN_MON_THI);
    hdfMonThi.setValue(data.MA_MON_THI);
    //txtDiemSo.setValue(data.DIEM / data.TRONG_SO);
    txtDiemSo.setValue(data.DIEM);
    txtNhanXet.setValue(data.NHAN_XET);
    hdfNguoiChamThi.setValue(data.MA_NGUOI_CHAM)
    cbb_NguoiChamThi.setValue(data.TEN_NGUOI_CHAM);
    btnUpdateChamDiem.hide();
    btnEditChamDiem.show();
    btnUpdateAndCloseChamDiem.hide();
}

var ReloadStoreOfTabIndex = function () {
    btnNext.enable();
    btnEdit.enable();
    btnDelete.enable();
    btnPrint.enable();
    btn_Add_ChungChi.enable();
    btn_Add_KNLV.enable();
    btn_Add_QuaTrinhHocTap.enable();
    btn_Add_File.enable();
    btn_Add_KetQuaPV.enable();
    var data = checkboxSelection.getSelected().data;
    if (data == null) {
        return;
    }
    img_anhdaidien.enable();
    if (data.ANH != null) {
        img_anhdaidien.setImageUrl(data.ANH.replace('~/Modules', '../..'));
    }
    else {
        img_anhdaidien.setImageUrl("../../NhanSu/ImageNhanSu/No_person.jpg");
    }
    lblHoTen.setValue(data.HO_TEN);
    lblGioiTinh.setValue(RenderGenderNoColor(data.GIOI_TINH));
    lblTTHN.setValue(data.TEN_TTHN);
    lblEmail.setValue(data.EMAIL);
    lblTuoi.setValue(data.TUOI);
    lblQuocGia.setValue(data.TEN_QUOC_TICH);
    lblDanToc.setValue(data.TEN_DAN_TOC);
    lblTinhThanh.setValue(data.TEN_TINHTHANH);
    lblTonGiao.setValue(data.TEN_TON_GIAO);
    lblNoiOHienNay.setValue(data.DIA_CHI_LH);
    lblChuyenNganh.setValue(data.TEN_CHUYEN_NGANH);
    lblTruongDaoTao.setValue(data.TEN_TRUONG_DT);
    lblKinhNghiem.setValue(data.KINH_NGHIEM);
    lblUuDiem.setValue(data.UU_DIEM);
    lblNhuocDiem.setValue(data.NHUOC_DIEM);
    //if (checkboxSelection.getSelected().data.ANH != null) {
    //    hsImage.setImageUrl(checkboxSelection.getSelected().data.ANH.replace('~/Modules', '..'));
    //}
    //else {
    //    hsImage.setImageUrl("../../NhanSu/ImageNhanSu/No_person.jpg");
    //} 
    //refresh lại store
    var tabID = tpThongTinUngVien.getActiveTab().id;
    switch (tabID) {
        case "pnlBangCapCC":
            Store_BangCapChungChi.reload();
            btn_Edit_ChungChi.disable();
            btn_Delete_ChungChi.disable();
            RowSelectionModel_ChungChi.clearSelections();
            break;
        case "pnlKinhNghiemLV":
            Store_KinhNghiemLamViec.reload();
            btn_Edit_KNLV.disable();
            btn_Delete_KNLV.disable();
            RowSelectionModel_KinhNghiemLamViec.clearSelections();
            break;
        case "Panel_QuaTrinhHocTap":
            Store_BangCap.reload();
            btn_Edit_QuaTrinhHocTap.disable();
            btn_Delete_QuaTrinhHocTap.disable();
            RowSelectionModel_BangCap.clearSelections();
            break;
        case "pnlTepTinDinhKem":
            Store_TepTinDinhKem.reload();
            btn_Download_File.disable();
            btn_Delete_File.disable();
            RowSelectionModel_TepTinDinhKem.clearSelections();
            break;
        case "pnlKetQuaPhongVan":
            Store_KetQuaPV.reload();
            btn_Edit_KetQuaPV.disable();
            btn_Delete_KetQuaPV.disable();
            RowSelectionModel_KetQuaPV.clearSelections();
            break;
    }
}

var CheckInputAttachFile = function (el) {
    if (txtFileName.getValue().trim() == '') {
        alert('Bạn chưa nhập tên hiển thị');
        txtFileName.focus();
        return false;
    }
    if (file_cv.getValue().trim() == '') {
        alert('Bạn chưa chọn file đính kèm');
        file_cv.focus();
        return false;
    }
    var size = 0;
    for (var num1 = 0; num1 < el.files.length; num1++) {
        var file = el.files[num1];
        size += file.size;
    }
    if (size > 10485760) {
        alert('Phần mềm chỉ hỗ trợ các tệp tin đính kèm nhỏ hơn 10MB');
        file_cv.reset(); txtFileName.reset();
        return false;
    }
    return true;
}

var CheckInputBangCap = function () {
    if (hdfMaTruongDaoTao.getValue() == '' || hdfMaTruongDaoTao.getValue() == null) {
        alert('Bạn chưa chọn nơi đào tạo');
        cbx_NoiDaoTaoBangCap.focus();
        return false;
    }
    if (cbx_hinhthucdaotaobang.getValue() == '' || cbx_hinhthucdaotaobang.getValue() == null) {
        alert('Bạn chưa chọn hình thức đào tạo');
        cbx_hinhthucdaotaobang.focus();
        return false;
    }
    if (hdfMaChuyenNganh.getValue().trim() == '') {
        alert('Bạn chưa chọn chuyên ngành đào tạo');
        cbx_ChuyenNganhBangCap.focus();
        return false;
    }
    if (cbx_trinhdobangcap.getValue() == '' || cbx_trinhdobangcap.getValue() == null) {
        alert('Bạn chưa chọn trình độ đào tạo');
        cbx_trinhdobangcap.focus();
        return false;
    }
    if (txtTuNam.getValue() != '' && txtTuNam.getValue().length != 4) {
        alert('Định dạng từ năm không đúng');
        txtTuNam.focus();
        return false;
    }
    if (txtDenNam.getValue() != '' && txtDenNam.getValue().length != 4) {
        alert('Định dạng đến năm không đúng');
        txtDenNam.focus();
        return false;
    }
    if (txtNamNhanBang.getValue() != '' && txtNamNhanBang.getValue().length != 4) {
        alert('Năm nhận bằng không đúng định dạng');
        txtNamNhanBang.focus();
        return false;
    }
    if (txtTuNam.getValue() > txtDenNam.getValue()) {
        alert('Đến năm phải sau Từ năm');
        txtDenNam.focus();
        return false;
    }
    if (txtNamNhanBang.getValue() < txtDenNam.getValue() && Chk_DaTotNghiep.checked == true) {
        alert('Đến năm phải trước hoặc trong Năm nhận bằng');
        txtNamNhanBang.focus();
        return false;
    }
    return true;
}
var CheckInputChungChi = function () {
    if (cbx_tenchungchi.getValue().trim() == '') {
        alert('Bạn chưa chọn chứng chỉ');
        cbx_tenchungchi.focus();
        return false;
    }
    if (cbx_XepLoaiChungChi.getValue().trim() == '') {
        alert('Bạn chưa chọn xếp loại');
        cbx_XepLoaiChungChi.focus();
        return false;
    }
    ///////
    if (ValidateDateField(df_NgayCap) == false) {
        alert('Định dạng ngày cấp không đúng');
        df_NgayCap.focus();
        return false;
    }
    if (ValidateDateField(df_NgayHetHan) == false) {
        alert('Định dạng ngày hết hạn không đúng');
        df_NgayHetHan.focus();
        return false;
    }
    if ((df_NgayCap.getValue() != '' && df_NgayHetHan.getValue() != '') && (df_NgayCap.getValue() > df_NgayHetHan.getValue())) {
        alert('Ngày cấp phải trước ngày hết hạn');
        df_NgayCap.focus();
        return false;
    }
    return true;
}
var checkbangcapungvien = function () {
    if (txt_khoa.getValue().trim() == '') {
        alert('Bạn chưa nhập Tên khoa');
        txt_khoa.focus();
        return false;
    }
    if (cbx_NoiDaoTaoBangCap_cbBox.getValue().trim() == '') {
        alert('Bạn chưa chọn nơi đào tạo');
        cbx_NoiDaoTaoBangCap_cbBox.focus();
        return false;
    }
    if (cbx_hinhthucdaotaobang_cbBox.getValue().trim() == '') {
        alert('Bạn chưa chọn hình thức');
        cbx_hinhthucdaotaobang_cbBox.focus();
        return false;
    }
    if (cbx_ChuyenNganhBangCap_cbBox.getValue().trim() == '') {
        alert('Bạn chưa chọn chuyên ngành');
        cbx_ChuyenNganhBangCap_cbBox.focus();
        return false;
    }
    if (cbx_trinhdobangcap_cbBox.getValue().trim() == '') {
        alert('Bạn chưa chọn trình độ');
        cbx_trinhdobangcap_cbBox.focus();
        return false;
    }
    if (cbx_xeploaiBangCap_cbBox.getValue().trim() == '') {
        alert('Bạn chưa chọn xếp loại');
        cbx_xeploaiBangCap_cbBox.focus();
        return false;
    }
    return true;
}
var CheckInputKinhNghiemLamViec = function () {
    if (txt_noilamviec.getValue().trim() == '') {
        alert('Bạn chưa nhập nơi làm việc');
        txt_noilamviec.focus();
        return false;
    }
    if (txt_vitricongviec.getValue().trim() == '') {
        alert('Bạn chưa nhập vị trí công việc');
        txt_vitricongviec.focus();
        return false;
    }
    if (dfKNLVTuNgay.getValue() == '' || dfKNLVTuNgay.getValue() == null) {
        alert('Bạn chưa nhập từ ngày');
        dfKNLVTuNgay.focus();
        return false;
    }
    // validate datefield
    if (ValidateDateField(dfKNLVTuNgay) == false) {
        alert('Định dạng từ ngày không đúng');
        dfKNLVTuNgay.focus();
        return false;
    }
    if (ValidateDateField(dfKNLVDenNgay) == false) {
        alert('Định dạng đến ngày không đúng');
        dfKNLVDenNgay.focus();
        return false;
    }
    if ((dfKNLVTuNgay.getValue() != '' && dfKNLVDenNgay.getValue() != '') && (dfKNLVTuNgay.getValue() > dfKNLVDenNgay.getValue())) {
        alert('Từ ngày phải trước đến ngày');
        dfKNLVTuNgay.focus();
        return false;
    }
    return true;
}

var CheckInputDate = function (df) {
    if (df.getValue() == '') {
        Ext.Msg.alert('Thông báo', 'Bạn chưa chọn ngày đi làm !');
        return false;
    }
    return true;
}
var CheckDuLieuDauVao = function () {
    reg1 = /^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$/;
    testmail = reg1.test(txt_email.getValue());
    if (txt_tenungvien.getValue().trim() == '') {
        alert('Bạn chưa nhập họ tên');
        txt_tenungvien.focus();
        return false;
    }
    if (cbx_dottuyendung.getValue().toString().trim() == '') {
        alert('Bạn chưa chọn đợt tuyển dụng');
        return false;
        cbx_dottuyendung.focus();
    }
    if (cbx_tt_honnhan.getValue().trim() == '') {
        alert('Bạn chưa chọn tình trạng hôn nhân');
        return false;
        cbx_tt_honnhan.focus();
    }
    if (!testmail && txt_email.getValue().trim() != '') {
        alert('Định dạng Email chưa đúng !');
        txt_email.focus();
        return false;
    }
    return true;
}

var CheckInputngaypv = function (pv) {
    if (pv.getValue().toString().trim() == '') {
        alert('Bạn chưa chọn ngày hẹn phỏng vấn!');
        return false;
    }
    return true;
}

var CheckInputDiemPhongVan = function () {
    if (txtDiemSo.getValue() == '' || cboMonThi.getValue() == '') {
        Ext.Msg.alert('Thông báo', 'Bạn bắt buộc phải nhập thông tin điểm số và môn thi !');
        return false;
    }
    if (cbb_NguoiChamThi.getValue() == '') {
        Ext.Msg.alert('Thông báo', 'Bạn chưa chọn người chấm thi!');
        return false;
    }
    return true;
}


var RenderResult = function (value, p, record) {
    if (value == "1") {
        return "<span style='color:blue'>Đỗ</span>";
    }
    else if (value == "0") {
        return "<span style='color:red'>Trượt</span>";
    }
    return "Chưa có";
}

var RenderAttachFile = function (value, p, record) {
    if (value == null) {
        return "";
    }
    if (value.trim() == "") {
        return "";
    }
    return "<img src='../../Resource/icon/attach.png'/>";
}

var HSUVenterKeyPressHandler = function (f, e) {
    if (e.getKey() == e.ENTER) {
        PagingToolbar1.pageIndex = 0;
        PagingToolbar1.doLoad();
        GridPanel1.getSelectionModel().clearSelections();
        hdfRecordID.setValue('');
        Store1.reload();
    }
    if (HoSoUngVien_txtSearchKey.getValue() != '')
        this.triggers[0].show();
}


