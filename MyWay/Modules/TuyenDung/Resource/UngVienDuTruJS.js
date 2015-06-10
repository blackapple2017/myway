var ChuanHoaTenHSUV = function () {
    if (uscTuyenDung_HoSoUngVien1_txt_tenungvien.getValue() != '') {
        var hoten = uscTuyenDung_HoSoUngVien1_txt_tenungvien.getValue().toLowerCase().trim();
        var arrStr = hoten.split(' ');
        var rs = '';
        for (var i = 0; i < arrStr.length; i++) {
            var item = arrStr[i].trim();
            if (item != '') {
                var firstChar = item.substring(0, 1);
                rs += firstChar.toUpperCase() + item.slice(1, item.length) + ' ';
            }
        }
        uscTuyenDung_HoSoUngVien1_txt_tenungvien.setValue(rs.trim());
    }
}
var ValidateDateField = function (idDateField) {
    reg = /^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/;
    testdf = reg.test(idDateField.getRawValue());
    if (!testdf && idDateField.getRawValue() != '' && idDateField.getRawValue() != null) {
        idDateField.focus();
        return false;
    }
    return true;
}
var CheckSelectedRecordPrint = function (grid, Store)
 {
     if (hdfRecordID.getValue() == '') 
    {
        alert('Bạn chưa chọn ứng viên nào');
        return false;
    }

    var s = grid.getSelectionModel().getSelections();
    var count = 0;
    for (var i = 0, r; r = s[i]; i++) {
        count++;
    }
    if (count > 1) {
        alert('Bạn chỉ được chọn một nhân viên');
        return false;
    }
    return true;
}
var isEmail = function(email) {
    var isValid = false;
    var regex = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    if(regex.test(email)) {
        isValid = true;
    }
    return isValid;
}
var CheckSelectedRecord = function (grid, Store) {
    if (hdfRecordID.getValue() == '') {
        alert('Bạn chưa chọn ứng viên nào');
        return false;
    }
}

var ShowReportAction = function ()
 {

    wdShowReport.setTitle('Báo cáo hồ sơ ứng viên chi tiết');
    pnReportPanel.remove(0); addHomePage(pnReportPanel, 'Homepage', '../Report/BaoCao_Main.aspx?type=BaoCaoHoSoUngVienChiTiet&MaUngVien=' + hdfRecordID.getValue(),
                                                               'Báo cáo hồ sơ ứng viên chi tiết');
}
var ChuanHoaTen = function () {
    if (uscTuyenDung_HoSoUngVien1_txt_tenungvien.getValue() != '') {
        var hoten = uscTuyenDung_HoSoUngVien1_txt_tenungvien.getValue().toLowerCase().trim();
        var arrStr = hoten.split(' ');
        var rs = '';
        for (var i = 0; i < arrStr.length; i++) {
            var item = arrStr[i].trim();
            if (item != '') {
                var firstChar = item.substring(0, 1);
                rs += firstChar.toUpperCase() + item.slice(1, item.length) + ' ';
            }
        }
        uscTuyenDung_HoSoUngVien1_txt_tenungvien.setValue(rs.trim());
    }
    return '';
}
var KiemTraDuLieuLichHenPV = function () {
    if (df_NgayPhongVan.getValue() == '' || df_NgayPhongVan.getRawValue() == null) {
        alert('Bạn chưa nhập ngày phỏng vấn');
        df_NgayPhongVan.focus();
        return false;
    }   
    if (txt_VongPhongVan.getValue().trim() == '' || txt_VongPhongVan.getValue() == null) {
        alert('Bạn chưa nhập vòng phỏng vấn !');
        txt_VongPhongVan.focus();
        return false;
    }    
    return true;
}
var KiemTraDuLieuChuyenLyDo = function () {
    if (cbx_Chuyen_LyDo.getValue() == '' || cbx_Chuyen_LyDo.getRawValue() == null) {
        alert('Bạn chưa chọn lý do');
        df_NgayPhongVan.focus();
        return false;
    }
    return true;
}
var checkNgaySinh = function (value) {
    var check = true;
    var today = new Date();
    if (value.getValue() >= today) {
        check = false;                
    }
    return check;
}

var KiemTraDuLieuDauVao = function () {
    if (uscTuyenDung_HoSoUngVien1_txt_tenungvien.getValue().trim() == '' || uscTuyenDung_HoSoUngVien1_txt_tenungvien.getValue() == null) {
        alert('Bạn chưa nhập họ tên !');
        uscTuyenDung_HoSoUngVien1_txt_tenungvien.focus();
        return false;
    }
    if (uscTuyenDung_HoSoUngVien1_df_ngaysinh.getRawValue() == '' || uscTuyenDung_HoSoUngVien1_df_ngaysinh.getRawValue() == null) {
        alert('Bạn chưa nhập ngày sinh');
        uscTuyenDung_HoSoUngVien1_df_ngaysinh.focus();
        return false;
    }
    if (ValidateDateField(uscTuyenDung_HoSoUngVien1_df_ngaysinh) == false) {
        alert('Định dạng ngày sinh không đúng');
        uscTuyenDung_HoSoUngVien1_df_ngaysinh.focus();
        return false;
    }
    if (checkNgaySinh(uscTuyenDung_HoSoUngVien1_df_ngaysinh) == false) {
        alert('Ngày sinh phải trước ngày hiện tại!');
        uscTuyenDung_HoSoUngVien1_df_ngaysinh.focus();
        return false;
    }
    if (uscTuyenDung_HoSoUngVien1_txt_noisinh.getValue().trim() == '' || uscTuyenDung_HoSoUngVien1_txt_noisinh.getValue() == null) {
        alert('Bạn chưa nhập nơi sinh !');
        uscTuyenDung_HoSoUngVien1_txt_noisinh.focus(); 
        return false;
    }
    if (uscTuyenDung_HoSoUngVien1_cbx_congviec.getValue() == '' || uscTuyenDung_HoSoUngVien1_cbx_congviec.getValue() == null) {
        alert('Bạn chưa chọn Công việc');
        uscTuyenDung_HoSoUngVien1_cbx_congviec.focus();
        return false;
    }
    if (uscTuyenDung_HoSoUngVien1_cbx_dottuyendung.getValue() == '' || uscTuyenDung_HoSoUngVien1_cbx_dottuyendung.getValue() == null) {
        alert('Bạn chưa chọn Đợt tuyển dụng');
        uscTuyenDung_HoSoUngVien1_cbx_dottuyendung.focus();
        return false;
    }
    if (uscTuyenDung_HoSoUngVien1_cbx_quoctich.getValue() == '' || uscTuyenDung_HoSoUngVien1_cbx_quoctich.getValue() == null) {
        alert('Bạn chưa chọn Quốc tịch');
        uscTuyenDung_HoSoUngVien1_cbx_quoctich.focus();
        return false;
    }
    if (uscTuyenDung_HoSoUngVien1_cbx_dantoc.getValue() == '' || uscTuyenDung_HoSoUngVien1_cbx_dantoc.getValue() == null) {
        alert('Bạn chưa chọn dân tộc');
        uscTuyenDung_HoSoUngVien1_cbx_dantoc.focus();
        return false;
    }
    if (uscTuyenDung_HoSoUngVien1_txt_socmnd.getValue() == '' || uscTuyenDung_HoSoUngVien1_txt_socmnd.getValue() == null) {
        alert('Bạn chưa nhập Số CMND');
        uscTuyenDung_HoSoUngVien1_txt_socmnd.focus();
        return false;
    }
    if (ValidateDateField(uscTuyenDung_HoSoUngVien1_df_ngaycapcmnd) == false) {
        alert('Định dạng ngày cấp CMND không đúng');
        uscTuyenDung_HoSoUngVien1_df_ngaycapcmnd.focus();
        return false;
    }
    if (checkNgaySinh(uscTuyenDung_HoSoUngVien1_df_ngaycapcmnd) == false) {
        alert('Ngày cấp CMND phải trước ngày hiện tại!');
        uscTuyenDung_HoSoUngVien1_df_ngaycapcmnd.focus();
        return false;
    }
    if (ValidateDateField(uscTuyenDung_HoSoUngVien1_df_ngaynophs) == false) {
        alert('Định dạng ngày nộp hồ sơ không đúng');
        uscTuyenDung_HoSoUngVien1_df_ngaynophs.focus();
        return false;
    }
    if (ValidateDateField(uscTuyenDung_HoSoUngVien1_df_ngaycothedilam) == false) {
        alert('Định dạng ngày có thể đi làm không đúng');
        uscTuyenDung_HoSoUngVien1_df_ngaycothedilam.focus();
        return false;
    }
    if ((uscTuyenDung_HoSoUngVien1_df_ngaysinh.getValue() > uscTuyenDung_HoSoUngVien1_df_ngaycapcmnd.getValue()) && uscTuyenDung_HoSoUngVien1_df_ngaycapcmnd.getValue() != '') {
        alert('Ngày sinh phải trước ngày cấp CMND!');
        uscTuyenDung_HoSoUngVien1_df_ngaysinh.focus();
        return false;
    }
    if ((isEmail(uscTuyenDung_HoSoUngVien1_txt_email.getValue()) == false) && uscTuyenDung_HoSoUngVien1_txt_email.getValue().trim() != '') {
        alert('Địa chỉ Email không đúng!');
        uscTuyenDung_HoSoUngVien1_txt_email.focus();
        return false;
    } 
    if ((isEmail(uscTuyenDung_HoSoUngVien1_txt_emailnguoilh.getValue()) == false) && uscTuyenDung_HoSoUngVien1_txt_emailnguoilh.getValue().trim() != '') {
        alert('Địa chỉ Email người liên hệ không đúng!');
        uscTuyenDung_HoSoUngVien1_txt_emailnguoilh.focus();
        return false;
    }

    return true;
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
var enterKeyPressHandler = function (f, e) {
    if (e.getKey() == e.ENTER) {
        PagingToolbar1.pageIndex = 0;
        PagingToolbar1.doLoad();
        GridPanel1.getSelectionModel().clearSelections();
        hdfRecordID.setValue('');
        grpGridPanel1_Store.reload();
    }
    if (UngVienDuTru_txtSearchKey.getValue() != '')
        this.triggers[0].show();
}
var ResetwdChuyenLichHenPV = function () {
    df_NgayPhongVan.reset();
    cbx_VongPhongVan.reset();
    txt_ThuTuPhongVan.reset();
    tf_GioPhongVan.reset();
    txt_ghichu.reset();
}
var ResetwdChuyenLyDo = function () {
    cbx_Chuyen_LyDo.reset();
    txt_Chuyen_GhiChu.reset();
}
var ResetWdAddUngVien = function () {
    uscTuyenDung_HoSoUngVien1_Tab.setActiveTab(uscTuyenDung_HoSoUngVien1_thongtinchung);
    if ((uscTuyenDung_HoSoUngVien1_hdfType.getValue() == 'black') || (uscTuyenDung_HoSoUngVien1_hdfType.getValue() == 'store'))
    { uscTuyenDung_HoSoUngVien1_anhdaidien.setImageUrl("../NhanSu/ImageNhanSu/No_person.jpg"); }
    else
    { uscTuyenDung_HoSoUngVien1_anhdaidien.setImageUrl("../../NhanSu/ImageNhanSu/No_person.jpg"); }
    uscTuyenDung_HoSoUngVien1_txt_tenungvien.reset();
    uscTuyenDung_HoSoUngVien1_txt_socmnd.reset();
    uscTuyenDung_HoSoUngVien1_df_ngaysinh.reset();
    uscTuyenDung_HoSoUngVien1_cbx_gioitinh.reset();
    uscTuyenDung_HoSoUngVien1_txt_hokhau.reset();
    uscTuyenDung_HoSoUngVien1_txt_noisinh.reset();
    uscTuyenDung_HoSoUngVien1_cbx_tt_honnhan.reset();
    uscTuyenDung_HoSoUngVien1_cbx_tt_suckhoe.reset();
    uscTuyenDung_HoSoUngVien1_cbx_quoctich.reset();
    uscTuyenDung_HoSoUngVien1_txt_didong.reset();
    uscTuyenDung_HoSoUngVien1_df_ngaycapcmnd.reset();
    uscTuyenDung_HoSoUngVien1_cbx_tinhthanh.reset();
    uscTuyenDung_HoSoUngVien1_cbx_dantoc.reset();
    uscTuyenDung_HoSoUngVien1_txt_email.reset();
    uscTuyenDung_HoSoUngVien1_cbx_tongiao.reset();
    uscTuyenDung_HoSoUngVien1_cbx_noicapcmnd.reset();
    uscTuyenDung_HoSoUngVien1_txt_diachilhe.reset();
    uscTuyenDung_HoSoUngVien1_txt_kinhnghiem.reset();
    uscTuyenDung_HoSoUngVien1_txt_mucluongmongmuon.reset();
    uscTuyenDung_HoSoUngVien1_txt_mucluongtoithieu.reset();
    uscTuyenDung_HoSoUngVien1_cbx_trinhdovanhoa.reset();
    uscTuyenDung_HoSoUngVien1_cbx_trinhdotinhoc.reset();
    uscTuyenDung_HoSoUngVien1_mcb_KhaNang.reset();
    uscTuyenDung_HoSoUngVien1_cbx_trinhdongoaingu.reset();
    uscTuyenDung_HoSoUngVien1_cbx_ChuyenNganh.reset();
    uscTuyenDung_HoSoUngVien1_cbx_TruongDaoTao.reset();
    uscTuyenDung_HoSoUngVien1_cbx_trinhdo.reset();
    uscTuyenDung_HoSoUngVien1_cbx_dottuyendung.reset();
    uscTuyenDung_HoSoUngVien1_cbx_congviec.reset();    
    uscTuyenDung_HoSoUngVien1_txt_sothich.reset();
    uscTuyenDung_HoSoUngVien1_txt_uudiem.reset();
    uscTuyenDung_HoSoUngVien1_txt_nhuocdiem.reset();
    try{
        uscTuyenDung_HoSoUngVien1_cbx_LyDo.reset();
    }    
    catch (ex) {
    }
    uscTuyenDung_HoSoUngVien1_txt_dienthoaicodinh.reset();
    uscTuyenDung_HoSoUngVien1_cbNhommau.reset();
    uscTuyenDung_HoSoUngVien1_txt_chieucao.reset();
    uscTuyenDung_HoSoUngVien1_txt_cannang.reset();
    uscTuyenDung_HoSoUngVien1_txt_ghichu.reset();
    uscTuyenDung_HoSoUngVien1_txt_nguoilienhe.reset();
    uscTuyenDung_HoSoUngVien1_txt_sdtnguoilh.reset();
    uscTuyenDung_HoSoUngVien1_txt_diachinguoilienhe.reset();
    uscTuyenDung_HoSoUngVien1_txt_emailnguoilh.reset();
    uscTuyenDung_HoSoUngVien1_txt_MoiQH.reset();
    uscTuyenDung_HoSoUngVien1_df_ngaycothedilam.reset();
    uscTuyenDung_HoSoUngVien1_df_ngaynophs.reset();
    uscTuyenDung_HoSoUngVien1_btn_EditUngVien.hide();
    uscTuyenDung_HoSoUngVien1_btn_UpdateandCloseUngVien.show();
    uscTuyenDung_HoSoUngVien1_btn_UpdateUngVien.show();
    uscTuyenDung_HoSoUngVien1_hdfImageFolder.reset();
    uscTuyenDung_HoSoUngVien1_hdfDotTuyenDung.reset();
    uscTuyenDung_HoSoUngVien1_hdfCongViec.reset();
    uscTuyenDung_HoSoUngVien1_hdfTinhTrangHN.reset();
    uscTuyenDung_HoSoUngVien1_hdfTinhTrangSK.reset();
    uscTuyenDung_HoSoUngVien1_hdfNhomMau.reset();
    uscTuyenDung_HoSoUngVien1_hdfLyDo.reset();
    uscTuyenDung_HoSoUngVien1_hdfQuocTich.reset();
    uscTuyenDung_HoSoUngVien1_hdfTinhThanh.reset();
    uscTuyenDung_HoSoUngVien1_hdfDanToc.reset();
    uscTuyenDung_HoSoUngVien1_hdfTonGiao.reset();
    uscTuyenDung_HoSoUngVien1_hdfNoiCapCMND.reset();
    uscTuyenDung_HoSoUngVien1_hdfTrinhDoVanHoa.reset();
    uscTuyenDung_HoSoUngVien1_hdfTruongDaoTao.reset();
    uscTuyenDung_HoSoUngVien1_hdfChuyenNganh.reset();
    uscTuyenDung_HoSoUngVien1_hdfTrinhDo.reset();
    uscTuyenDung_HoSoUngVien1_hdfTrinhDoTinHoc.reset();
    uscTuyenDung_HoSoUngVien1_hdfTrinhDoNgoaiNgu.reset();
    uscTuyenDung_HoSoUngVien1_hdfRecordID.reset();
    uscTuyenDung_HoSoUngVien1_hdfType.reset();
    uscTuyenDung_HoSoUngVien1_fufUploadControl.reset();
    uscTuyenDung_HoSoUngVien1_hdfImageFolder.reset();
    uscTuyenDung_HoSoUngVien1_hdfAnhDaiDien.reset();

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
var setValueUpLoadImage = function (a) {
    var data = a.getSelected().data;
    if (data == null) {
        return;
    }
    uscTuyenDung_HoSoUngVien1_hdfAnhDaiDien.setValue('hsuv');
    uscTuyenDung_HoSoUngVien1_hdfRecordID.setValue(data.MA_UNG_VIEN);
}
var setValueWdAddUngVien = function (a, lydo) {
    var data = a.getSelected().data;
    if (data == null) {
        return;
    }
    if (lydo == 1) {
        uscTuyenDung_HoSoUngVien1_cbx_LyDo.setValue(data.LY_DO);
        uscTuyenDung_HoSoUngVien1_hdfLyDo.setValue(data.MA_LY_DO);
    }
    if ((a.getSelected().data.ANH != null) && ((uscTuyenDung_HoSoUngVien1_hdfType.getValue() == 'black') || (uscTuyenDung_HoSoUngVien1_hdfType.getValue() == 'store')))
    {
        uscTuyenDung_HoSoUngVien1_anhdaidien.setImageUrl(a.getSelected().data.ANH.replace('~/Modules', '..'));
    }
    else {
        if (a.getSelected().data.ANH != null)
        uscTuyenDung_HoSoUngVien1_anhdaidien.setImageUrl(a.getSelected().data.ANH.replace('~/Modules', '../..'));
    }
    uscTuyenDung_HoSoUngVien1_hdfCongViec.setValue(data.MA_VI_TRI);
    uscTuyenDung_HoSoUngVien1_hdfDotTuyenDung.setValue(data.MA_DOT_TUYEN_DUNG);
    uscTuyenDung_HoSoUngVien1_hdfImageFolder.setValue(data.ANH);
    uscTuyenDung_HoSoUngVien1_hdfTinhTrangHN.setValue(data.MA_TTHN);
    uscTuyenDung_HoSoUngVien1_hdfTinhTrangSK.setValue(data.MA_TT_SUCKHOE);
    uscTuyenDung_HoSoUngVien1_hdfNhomMau.setValue(data.NHOM_MAU);
    uscTuyenDung_HoSoUngVien1_hdfQuocTich.setValue(data.MA_QUOC_TICH);
    uscTuyenDung_HoSoUngVien1_hdfTinhThanh.setValue(data.MA_TINHTHANH);
    uscTuyenDung_HoSoUngVien1_hdfDanToc.setValue(data.MA_DAN_TOC);
    uscTuyenDung_HoSoUngVien1_hdfTonGiao.setValue(data.MA_TON_GIAO);
    uscTuyenDung_HoSoUngVien1_hdfNoiCapCMND.setValue(data.MA_NOI_CAP_CMT);
    uscTuyenDung_HoSoUngVien1_hdfTrinhDoVanHoa.setValue(data.MA_TRINH_DO_VH);
    uscTuyenDung_HoSoUngVien1_hdfTruongDaoTao.setValue(data.MA_TRUONG_DT);
    uscTuyenDung_HoSoUngVien1_hdfChuyenNganh.setValue(data.MA_CHUYEN_NGANH);
    uscTuyenDung_HoSoUngVien1_hdfTrinhDo.setValue(data.MA_TRINH_DO_HV);
    uscTuyenDung_HoSoUngVien1_hdfTrinhDoTinHoc.setValue(data.MA_TRINH_DO_TIN_HOC);
    uscTuyenDung_HoSoUngVien1_hdfTrinhDoNgoaiNgu.setValue(data.MA_TRINH_DO_NN);        
    uscTuyenDung_HoSoUngVien1_hdfRecordID.setValue(data.MA_UNG_VIEN);
    uscTuyenDung_HoSoUngVien1_hdfType.setValue(data.BLACK_OR_STORE);    
    uscTuyenDung_HoSoUngVien1_hdfKhaNang.setValue(data.MA_KHA_NANG);
    uscTuyenDung_HoSoUngVien1_anhdaidien.ImageUrl = data.ANH;
    uscTuyenDung_HoSoUngVien1_txt_tenungvien.setValue(data.HO_TEN);
    uscTuyenDung_HoSoUngVien1_txt_socmnd.setValue(data.CMT);
    uscTuyenDung_HoSoUngVien1_df_ngaysinh.setValue(RenderDate(data.NGAY_SINH, null, null));
    uscTuyenDung_HoSoUngVien1_cbx_gioitinh.setValue(data.GIOI_TINH);
    uscTuyenDung_HoSoUngVien1_txt_hokhau.setValue(data.HKTT);
    uscTuyenDung_HoSoUngVien1_txt_noisinh.setValue(data.NOI_SINH);
    uscTuyenDung_HoSoUngVien1_cbx_tt_honnhan.setValue(data.TEN_TTHN);
    uscTuyenDung_HoSoUngVien1_cbx_tt_suckhoe.setValue(data.TEN_TT_SUCKHOE);
    uscTuyenDung_HoSoUngVien1_cbNhommau.setValue(data.TEN_NHOM_MAU);
    uscTuyenDung_HoSoUngVien1_cbx_quoctich.setValue(data.TEN_QUOC_TICH);
    uscTuyenDung_HoSoUngVien1_txt_didong.setValue(data.DI_DONG);
    uscTuyenDung_HoSoUngVien1_df_ngaycapcmnd.setValue(RenderDate(data.NGAY_CAP_CMT, null, null));
    uscTuyenDung_HoSoUngVien1_cbx_tinhthanh.setValue(data.TEN_TINHTHANH);
    uscTuyenDung_HoSoUngVien1_cbx_dantoc.setValue(data.TEN_DAN_TOC);
    uscTuyenDung_HoSoUngVien1_txt_email.setValue(data.EMAIL);
    uscTuyenDung_HoSoUngVien1_cbx_tongiao.setValue(data.TEN_TON_GIAO);
    uscTuyenDung_HoSoUngVien1_cbx_noicapcmnd.setValue(data.NOI_CAP_CMT);
    uscTuyenDung_HoSoUngVien1_txt_diachilhe.setValue(data.DIA_CHI_LH);
    uscTuyenDung_HoSoUngVien1_txt_kinhnghiem.setValue(data.KINH_NGHIEM);
    uscTuyenDung_HoSoUngVien1_txt_mucluongmongmuon.setValue(data.MUC_LUONG_MONG_MUON);
    uscTuyenDung_HoSoUngVien1_txt_mucluongtoithieu.setValue(data.MUC_LUONG_TOI_THIEU);
    uscTuyenDung_HoSoUngVien1_cbx_trinhdovanhoa.setValue(data.TEN_TRINH_DO_VH);
    uscTuyenDung_HoSoUngVien1_cbx_trinhdotinhoc.setValue(data.TEN_TRINH_DO_TIN_HOC);
    uscTuyenDung_HoSoUngVien1_cbx_trinhdongoaingu.setValue(data.TEN_TRINH_DO_NN);
    uscTuyenDung_HoSoUngVien1_cbx_ChuyenNganh.setValue(data.TEN_CHUYEN_NGANH);
    uscTuyenDung_HoSoUngVien1_cbx_TruongDaoTao.setValue(data.TEN_TRUONG_DT);
    uscTuyenDung_HoSoUngVien1_cbx_trinhdo.setValue(data.TEN_TRINH_DO_HV);
    uscTuyenDung_HoSoUngVien1_cbx_dottuyendung.setValue(data.TEN_DOT_TUYEN_DUNG);
    uscTuyenDung_HoSoUngVien1_cbx_congviec.setValue(data.VI_TRI); 
    //Set value for multicombo
    set_multicombo(data.MA_KHA_NANG);
    uscTuyenDung_HoSoUngVien1_txt_sothich.setValue(data.SO_THICH);
    uscTuyenDung_HoSoUngVien1_txt_uudiem.setValue(data.UU_DIEM);
    uscTuyenDung_HoSoUngVien1_txt_nhuocdiem.setValue(data.NHUOC_DIEM);
    uscTuyenDung_HoSoUngVien1_txt_dienthoaicodinh.setValue(data.DT_CO_DINH);
    uscTuyenDung_HoSoUngVien1_cbNhommau.setValue(data.NHOM_MAU);
    uscTuyenDung_HoSoUngVien1_txt_chieucao.setValue(data.CHIEU_CAO);
    uscTuyenDung_HoSoUngVien1_txt_cannang.setValue(data.CAN_NANG);
    uscTuyenDung_HoSoUngVien1_txt_ghichu.setValue(data.GHI_CHU);
    uscTuyenDung_HoSoUngVien1_txt_nguoilienhe.setValue(data.NGUOI_LIEN_HE);
    uscTuyenDung_HoSoUngVien1_txt_sdtnguoilh.setValue(data.DIEN_THOAI_NGUOI_LIEN_HE);
    uscTuyenDung_HoSoUngVien1_txt_diachinguoilienhe.setValue(data.DIA_CHI_NGUOI_LIEN_HE);
    uscTuyenDung_HoSoUngVien1_txt_emailnguoilh.setValue(data.EMAIL_NGUOI_LIEN_HE);
    uscTuyenDung_HoSoUngVien1_txt_MoiQH.setValue(data.QUAN_HE_VOI_UNG_VIEN);
    uscTuyenDung_HoSoUngVien1_df_ngaycothedilam.setValue(RenderDate(data.NGAY_COTHEDILAM, null, null));
    uscTuyenDung_HoSoUngVien1_df_ngaynophs.setValue(RenderDate(data.NGAY_NOP_HO_SO, null, null));    
    uscTuyenDung_HoSoUngVien1_btn_EditUngVien.show();
    uscTuyenDung_HoSoUngVien1_btn_UpdateandCloseUngVien.hide();
    uscTuyenDung_HoSoUngVien1_btn_UpdateUngVien.hide();
}
var reloadPanel = function () {
    GridPanel1.Reload();
}
var set_multicombo = function (values) {
    var items = values.split(',');
    uscTuyenDung_HoSoUngVien1_mcb_KhaNang.setValue(items);
}