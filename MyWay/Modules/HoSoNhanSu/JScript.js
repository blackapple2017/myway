var CheckSelectedRecord = function (grid, Store) {
    if (hdfRecordID.getValue() == '') {
        alert('Bạn chưa chọn nhân viên nào');
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
var checkInputCategory = function () {
    if (txtMaDM.getValue().trim() == '') {
        alert("Bạn chưa nhập mã danh mục");
        txtMaDM.focus();
        return false;
    }
    if (txtTenDM.getValue().trim() == '') {
        alert("Bạn chưa nhập tên danh mục");
        txtTenDM.focus();
        return false;
    }
    return true;
}
var addRecordCategory = function (ma, ten) {
    grpCategory.insertRecord(0, {
        MA: ma,
        TEN: ten
    });
    stCategory.commitChanges();
}
var resetInputCategory = function () {
    btnCancel.hide();
    btnSave.hide();
    txtTenDM.hide();
    txtTenDM.reset();
    txtMaDM.hide();
    txtMaDM.reset();
    btnAddCategory.enable();
}
var afterEditCategory = function (e) {
    Ext.net.DirectMethods.AfterEdit(e.record.data.MA, e.originalValue, e.value);
}
var showWdAddCategory = function (name) {
    switch (name) {
        case "DanToc":
            hdfTableDM.setValue("DM_DANTOC");
            hdfColMa.setValue("MA_DANTOC");
            hdfColTen.setValue("TEN_DANTOC");
            break;
        case "TonGiao":
            hdfTableDM.setValue("DM_TONGIAO");
            hdfColMa.setValue("MA_TONGIAO");
            hdfColTen.setValue("TEN_TONGIAO");
            break;
        case "ThanhPhanBanThan":
            hdfTableDM.setValue("DM_TP_BANTHAN");
            hdfColMa.setValue("MA_TP_BANTHAN");
            hdfColTen.setValue("TEN_TP_BANTHAN");
            break;
        case "ThanhPhanGiaDinh":
            hdfTableDM.setValue("DM_TP_GIADINH");
            hdfColMa.setValue("MA_TP_GIADINH");
            hdfColTen.setValue("TEN_TP_GIADINH");
            break;
        case "ChucVu":
            hdfTableDM.setValue("DM_CHUCVU");
            hdfColMa.setValue("MA_CHUCVU");
            hdfColTen.setValue("TEN_CHUCVU");
            break;
        case "TrinhDoVanHoa":
            hdfTableDM.setValue("DM_TD_VANHOA");
            hdfColMa.setValue("MA_TD_VANHOA");
            hdfColTen.setValue("TEN_TD_VANHOA");
            break;
        case "TrinhDo":
            hdfTableDM.setValue("DM_TRINHDO");
            hdfColMa.setValue("MA_TRINHDO");
            hdfColTen.setValue("TEN_TRINHDO");
            break;
        case "TrinhDoChinhTri":
            hdfTableDM.setValue("DM_TD_CHINHTRI");
            hdfColMa.setValue("MA_TD_CHINHTRI");
            hdfColTen.setValue("TEN_TD_CHINHTRI");
            break;
        case "TrinhDoQuanLy":
            hdfTableDM.setValue("DM_TD_QUANLY");
            hdfColMa.setValue("MA_TD_QUANLY");
            hdfColTen.setValue("TEN_TD_QUANLY");
            break;
        case "NgoaiNgu":
            hdfTableDM.setValue("DM_NGOAINGU");
            hdfColMa.setValue("MA_NGOAINGU");
            hdfColTen.setValue("TEN_NGOAINGU");
            break;
        case "TinHoc":
            hdfTableDM.setValue("DM_TINHOC");
            hdfColMa.setValue("MA_TINHOC");
            hdfColTen.setValue("TEN_TINHOC");
            break;
        case "ChucVuDang":
            hdfTableDM.setValue("DM_CHUCVU_DANG");
            hdfColMa.setValue("MA_CHUCVU_DANG");
            hdfColTen.setValue("TEN_CHUCVU_DANG");
            break;
        case "ChucVuDoan":
            hdfTableDM.setValue("DM_CHUCVU_DOAN");
            hdfColMa.setValue("MA_CHUCVU_DOAN");
            hdfColTen.setValue("TEN_CHUCVU_DOAN");
            break;
        case "ChucVuQuanDoi":
            hdfTableDM.setValue("DM_CHUCVU_QDOI");
            hdfColMa.setValue("MA_CHUCVU_QDOI");
            hdfColTen.setValue("TEN_CHUCVU_QDOI");
            break;
        case "CapBacQuanDoi":
            hdfTableDM.setValue("DM_CAPBAC_QDOI");
            hdfColMa.setValue("MA_CAPBAC_QDOI");
            hdfColTen.setValue("TEN_CAPBAC_QDOI");
            break;
        case "TinhTrangSucKhoe":
            hdfTableDM.setValue("DM_TT_SUCKHOE");
            hdfColMa.setValue("MA_TT_SUCKHOE");
            hdfColTen.setValue("TEN_TT_SUCKHOE");
            break;
        case "ChinhSach":
            hdfTableDM.setValue("DM_LOAI_CS");
            hdfColMa.setValue("MA_LOAI_CS");
            hdfColTen.setValue("TEN_LOAI_CS");
            break;
        case "NoiCapCMND":
            hdfTableDM.setValue("DM_NOICAP_CMND");
            hdfColMa.setValue("MA_NOICAP_CMND");
            hdfColTen.setValue("TEN_NOICAP_CMND");
            break;
        case "ChucDanh":
            hdfTableDM.setValue("DM_CONGVIEC");
            hdfColMa.setValue("MA_CONGVIEC");
            hdfColTen.setValue("TEN_CONGVIEC");
            break;
        case 'TruongDaoTao':
            hdfTableDM.setValue("DM_TRUONG_DAOTAO");
            hdfColMa.setValue("MA_TRUONG_DAOTAO")
            hdfColTen.setValue("TEN_TRUONG_DAOTAO");
            break;
        case "ChuyenNganh":
            hdfTableDM.setValue("DM_CHUYENNGANH");
            hdfColMa.setValue("MA_CHUYENNGANH")
            hdfColTen.setValue("TEN_CHUYENNGANH");
            break;
        case "CongViec":
            hdfTableDM.setValue("DM_CONGVIEC");
            hdfColMa.setValue("MA_CONGVIEC")
            hdfColTen.setValue("TEN_CONGVIEC");
            break;
        case "DiaDiemLamViec":
            hdfTableDM.setValue("DM_DIADIEMLAMVIEC");
            hdfColMa.setValue("MA_DIADIEM")
            hdfColTen.setValue("TEN_DIADIEM");
            break;
        case "QuocTich":
            hdfTableDM.setValue("DM_NUOC");
            hdfColMa.setValue("MA_NUOC")
            hdfColTen.setValue("TEN_NUOC");
            break;
        case "TinhThanh":
            hdfTableDM.setValue("DM_TINHTHANH");
            hdfColMa.setValue("MA_TINHTHANH")
            hdfColTen.setValue("TEN_TINHTHANH");
            break;
        case "TinhTrangHonNhan":
            hdfTableDM.setValue("DM_TT_HN");
            hdfColMa.setValue("MA_TT_HN")
            hdfColTen.setValue("TEN_TT_HN");
            break;
        case "XepLoai":
            hdfTableDM.setValue("DM_XEPLOAI");
            hdfColMa.setValue("MA_XEPLOAI")
            hdfColTen.setValue("TEN_XEPLOAI");
            break;
        case "HuongChinhSach":
            hdfTableDM.setValue("DM_LOAI_CS");
            hdfColMa.setValue("MA_LOAI_CS")
            hdfColTen.setValue("TEN_LOAI_CS");
            break;
        case "NoiCapHoChieu":
            hdfTableDM.setValue("DM_NOICAP_HOCHIEU");
            hdfColMa.setValue("MA_NOICAP_HOCHIEU")
            hdfColTen.setValue("TEN_NOICAP_HOCHIEU");
            break;
        case "Ngach":
            hdfTableDM.setValue("DM_NGACH");
            hdfColMa.setValue("MA_NGACH")
            hdfColTen.setValue("TEN_NGACH");
            break;
        case "TrinhDoQuanLyKT":
            hdfTableDM.setValue("DM_TD_QLKT");
            hdfColMa.setValue("MA_TD_QLKT")
            hdfColTen.setValue("TEN_TD_QLKT");
            break;
        case "NganHang":
            hdfTableDM.setValue("DM_NH");
            hdfColMa.setValue("MA_NH")
            hdfColTen.setValue("TEN_NH");
            break;
        case "TTSucKhoe":
            hdfTableDM.setValue("DM_TT_SUCKHOE");
            hdfColMa.setValue("MA_TT_SUCKHOE")
            hdfColTen.setValue("TEN_TT_SUCKHOE");
            break;
        case "NoiKhamChuaBenh":
            hdfTableDM.setValue("DM_NOI_KCB");
            hdfColMa.setValue("MA_NOI_KCB")
            hdfColTen.setValue("TEN_NOI_KCB");
            break;
        case "NoiCapBHXH":
            hdfTableDM.setValue("DM_NOICAP_BHXH");
            hdfColMa.setValue("MA_NOICAP_BHXH")
            hdfColTen.setValue("TEN_NOICAP_BHXH");
            break;
        case "HTTuyenDung":
            hdfTableDM.setValue("DM_HT_TUYENDUNG");
            hdfColMa.setValue("MA_HT_TUYENDUNG")
            hdfColTen.setValue("TEN_HT_TUYENDUNG");
            break;
        case "LyDoNghiViec":
            hdfTableDM.setValue("DM_LYDO_NGHI");
            hdfColMa.setValue("MA_LYDO_NGHI")
            hdfColTen.setValue("TEN_LYDO_NGHI");
            break;

    }
    wdAddCategory.show();
}
var selectedCategory = function () {
    var data = RowSelectionModelCategory.getSelected().data;
    if (data == null) {
        return;
    }
    switch (hdfCurrentCategory.getValue()) {
        case "DM_LYDO_NGHI":
            hdfLyDoNghiViec.setValue(data.MA);
            cbx_lydonghi.setValue(data.TEN);
            cbx_lydonghi.triggers[0].show();
            break;
        case "DM_HT_TUYENDUNG":
            hdfHTTuyenDung.setValue(data.MA);
            cbx_httuyen.setValue(data.TEN);
            cbx_httuyen.triggers[0].show();
            break;
        case "DM_NOICAP_BHXH":
            hdfNoiCapBHXH.setValue(data.MA);
            cbx_noicapbhxh.setValue(data.TEN);
            cbx_noicapbhxh.triggers[0].show();
            break;
        case "DM_NOI_KCB":
            hdfNoiKhamChuaBenh.setValue(data.MA);
            cbx_noikcb.setValue(data.TEN);
            cbx_noikcb.triggers[0].show();
            break;
        case "DM_TT_SUCKHOE":
            hdfTTSucKhoe.setValue(data.MA);
            cbx_ttsuckhoe.setValue(data.TEN);
            cbx_ttsuckhoe.triggers[0].show();
            break;
        case "DM_NH":
            hdfNganHang.setValue(data.MA);
            cbx_nganhang.setValue(data.TEN);
            cbx_nganhang.triggers[0].show();
            break;
        case "DM_TD_QLKT":
            hdfTrinhDoQLKT.setValue(data.MA);
            cbx_trinhdoquanlykt.setValue(data.TEN);
            cbx_trinhdoquanlykt.triggers[0].show();
            break;
        case "DM_NGACH":
            hdfNgach.setValue(data.MA);
            cbx_ngach.setValue(data.TEN);
            cbx_ngach.triggers[0].show();
            break;
        case "DM_NOICAP_HOCHIEU":
            hdfNoiCapHoChieu.setValue(data.MA);
            cbx_noicaphc.setValue(data.TEN);
            cbx_noicaphc.triggers[0].show();
            break;
        case "DM_LOAI_CS":
            hdfHuongChinhSach.setValue(data.MA);
            cbx_huongcs.setValue(data.TEN);
            cbx_huongcs.triggers[0].show();
            break;
        case "DM_XEPLOAI":
            hdfXepLoai.setValue(data.MA);
            cbx_xeploai.setValue(data.TEN);
            cbx_xeploai.triggers[0].show();
            break;
        case "DM_TT_HN":
            hdfHonNhan.setValue(data.MA);
            cbx_tthonnhan.setValue(data.TEN);
            cbx_tthonnhan.triggers[0].show();
            break;
        case "DM_TINHTHANH":
            hdfTinhThanh.setValue(data.MA);
            cbx_tinhthanh.setValue(data.TEN);
            cbx_tinhthanh.triggers[0].show();
            break;
        case "DM_NUOC":
            hdfQuocTich.setValue(data.MA);
            cbx_quoctich.setValue(data.TEN);
            cbx_quoctich.triggers[0].show();
            break;
        case "DM_DIADIEMLAMVIEC":
            hdfBiDanh.setValue(data.MA);
            txt_bidanh.setValue(data.TEN);
            txt_bidanh.triggers[0].show();
            break;
        case "DM_CONGVIEC":
            hdfViTriCongViec.setValue(data.MA);
            cbx_congviec.setValue(data.TEN);
            cbx_congviec.triggers[0].show();
            break;
        case "DM_CHUYENNGANH":
            hdfMaChuyenNganh.setValue(data.MA);
            cbxChuyenNganh.setValue(data.TEN);
            cbxChuyenNganh.triggers[0].show();
            break;
        case "DM_TRUONG_DAOTAO":
            hdfMaTruongDaoTao.setValue(data.MA);
            cbxTruongDaoTao.setValue(data.TEN);
            cbxTruongDaoTao.triggers[0].show();
            break;
        case "DM_DANTOC":
            hdfDanToc.setValue(data.MA);
            cbx_dantoc.setValue(data.TEN);
            cbx_dantoc.triggers[0].show();
            break;
        case "DM_TONGIAO":
            hdfTonGiao.setValue(data.MA);
            cbx_tongiao.setValue(data.TEN);
            cbx_tongiao.triggers[0].show();
            break;
        case "DM_TP_BANTHAN":
            hdfThanhPhanBanThan.setValue(data.MA);
            cbx_tpbanthan.setValue(data.TEN);
            cbx_tpbanthan.triggers[0].show();
            break;
        case "DM_TP_GIADINH":
            hdfThanhPhanGiaDinh.setValue(data.MA);
            cbx_tpgiadinh.setValue(data.TEN);
            cbx_tpgiadinh.triggers[0].show();
            break;
        case "DM_CHUCVU":
            hdfChucVu.setValue(data.MA);
            cbx_chucvu.setValue(data.TEN);
            cbx_chucvu.triggers[0].show();
            break;
        case "DM_TD_VANHOA":
            tdVanHoa.setValue(data.MA);
            cbx_tdvanhoa.setValue(data.TEN);
            cbx_tdvanhoa.triggers[0].show();
            break;
        case "DM_TRINHDO":
            hdfTrinhDo.setValue(data.MA);
            cbx_trinhdo.setValue(data.TEN);
            cbx_trinhdo.triggers[0].show();
            break;
        case "DM_TD_CHINHTRI":
            hdfLyLuanChinhTri.setValue(data.MA);
            cbx_trinhdochinhtri.setValue(data.TEN);
            cbx_trinhdochinhtri.triggers[0].show();
            break;
        case "DM_TD_QUANLY":
            hdfQuanLyNhaNuoc.setValue(data.MA);
            cbx_trinhdoquanly.setValue(data.TEN);
            cbx_trinhdoquanly.triggers[0].show();
            break;
        case "DM_NGOAINGU":
            hdfNgoaiNgu.setValue(data.MA);
            cbx_ngoaingu.setValue(data.TEN);
            cbx_ngoaingu.triggers[0].show();
            break;
        case "DM_TINHOC":
            hdfTinHoc.setValue(data.MA);
            cbx_tinhoc.setValue(data.TEN);
            cbx_tinhoc.triggers[0].show();
            break;
        case "DM_CHUCVU_DANG":
            hdfChucVuDang.setValue(data.MA);
            cbx_chuvudang.setValue(data.TEN);
            cbx_chuvudang.triggers[0].show();
            break;
        case "DM_CHUCVU_DOAN":
            hdfChucVuDoan.setValue(data.MA);
            cbx_chucvudoan.setValue(data.TEN);
            cbx_chucvudoan.triggers[0].show();
            break;
        case "DM_CAPBAC_QDOI":
            hdfQuanHamCaoNhat.setValue(data.MA);
            cbx_bacquandoi.setValue(data.TEN);
            cbx_bacquandoi.triggers[0].show();
            break;
        case "DM_TT_SUCKHOE":
            hdfTinhTrangSucKhoe.setValue(data.MA);
            cbx_ttsuckhoe.setValue(data.TEN);
            cbx_ttsuckhoe.triggers[0].show();
            break;
        case "DM_LOAI_CS":
            hdfChinhSach.setValue(data.MA);
            cbx_huongcs.setValue(data.TEN);
            cbx_huongcs.triggers[0].show();
            break;
        case "DM_NOICAP_CMND":
            hdfNoiCapCMND.setValue(data.MA);
            cbx_noicapcmnd.setValue(data.TEN);
            cbx_noicapcmnd.triggers[0].show();
            break;
        case "DM_NOICAP_CMND":
            hdfNoiCapCMND.setValue(data.MA);
            cbx_noicapcmnd.setValue(data.TEN);
            cbx_noicapcmnd.triggers[0].show();
            break;
        case "DM_CONGVIEC":
            hdfChucDanh.setValue(data.MA);
            cbxChucDanh.setValue(data.TEN);
            cbxChucDanh.triggers[0].show();
            break;
        case "DM_CHUCVU_QDOI":
            hdfChucVuQuanDoi.setValue(data.MA);
            cbx_chucvuquandoi.setValue(data.TEN);
            cbx_chucvuquandoi.triggers[0].show();
            break;
    }
    wdAddCategory.hide();
}
var beforeShowWdCategory = function () {
    if (hdfCurrentCategory.getValue() != hdfTableDM.getValue()) {
        stCategory.removeAll();
        RowSelectionModelCategory.clearSelections();
        PagingToolbar2.pageIndex = 0;
        PagingToolbar2.doLoad();
        hdfCurrentCategory.setValue(hdfTableDM.getValue());
    }
}
var CheckSelectedRows = function (grid) {
    var s = grid.getSelectionModel().getSelections();
    var count = 0;
    for (var i = 0, r; r = s[i]; i++) {
        count++;
    }
    if (count == 0) {
        alert('Bạn chưa chọn bản ghi nào!');
        return false;
    }
    if (count > 1) {
        alert('Bạn chỉ được chọn một bản ghi');
        return false;
    }
    return true;
}
var ShowReportAction = function () {
    var type = hdfTypeReport.getValue();
    switch (type) {
        case 'HoSo':
            wdShowReport.setTitle('Báo cáo hồ sơ nhân viên');
            pnReportPanel.remove(0); addHomePage(pnReportPanel, 'Homepage', '../Report/Baocao_Nhansu_Chitiet.aspx?prkey=' + hdfRecordID.getValue(), 'Báo cáo hồ sơ nhân viên');
            break;
        case 'TaiSan':
            wdShowReport.setTitle('Báo cáo tài sản cấp phát cho nhân viên');
            pnReportPanel.remove(0); addHomePage(pnReportPanel, 'Homepage', '../Report/BaoCao_Main.aspx?type=DanhSachTaiSanCapPhatChoNhanVien&prkey=' + hdfRecordID.getValue(), 'Báo cáo tài sản cấp phát cho nhân viên');
            break;
        case 'DanhSachNhanSu':
            wdShowReport.setTitle('Báo cáo danh sách nhân viên');
            pnReportPanel.remove(0); addHomePage(pnReportPanel, 'Homepage', '../Report/BaoCao_Main.aspx?type=DanhSachNhanVien&' + hdfQueryReport.getValue(), 'Báo cáo danh sách nhân viên');
            break;
    }
}
var enterKeyPressHandler = function (f, e) {
    if (e.getKey() == e.ENTER) {
        PagingToolbar1.pageIndex = 0;
        PagingToolbar1.doLoad();
        grp_HoSoNhanSu.getSelectionModel().clearSelections();
        hdfRecordID.setValue('');
        store_HoSoNhanSu.reload();
    }
    if (txtSearch.getValue() != '')
        this.triggers[0].show();
}

var RenderGender = function (value, p, record) {
    var nam = "<span style='color:blue'>Nam</span>";
    var nu = "<span style='color:red'>Nữ</span>";
    if (value == 'M')
        return nam;
    else
        return nu;
}
var enterKeyPressHandler1 = function (f, e) {
    if (e.getKey() == e.ENTER) {
        Ext.net.DirectMethods.SetValueQuery();
    }
}

var GetAge = function (birthday) {
    if (birthday == null) return "";
    birthday = birthday.replace(" ", "T");
    var temp = birthday.split("T");
    var date = temp[0].split("-");
    return new Date().getFullYear() * 1 - (date[0] * 1);
}

var getSelectedIndexRow = function () {
    var record = grp_HoSoNhanSu.getSelectionModel().getSelected();
    var index = grp_HoSoNhanSu.store.indexOf(record);
    if (index == -1)
        return 0;
    return index;
}

addUpdatedRecord = function (ma_cb, ho_ten, ten_gioitinh, ngay_sinh, ten_bophan, ten_chucvu, ten_trinhdo, ten_chuyennganh, ten_ngach, ten_loai_hdong, dia_chi_lh, di_dong, email,
        bi_danh, ngaycap_hochieu, ngay_tuyen_dtien, ngay_tuyen_chinhthuc, ngaycap_cmnd, noi_cap_hc, noi_cap_cmnd, dt_cq, dt_nha) {
    var rowindex = getSelectedIndexRow();
    var prkey = 0;
    //xóa bản ghi cũ
    var s = grp_HoSoNhanSu.getSelectionModel().getSelections();
    for (var i = 0, r; r = s[i]; i++) {
        prkey = r.data.PR_KEY;
        store_HoSoNhanSu.remove(r);
        store_HoSoNhanSu.commitChanges();
    }
    //Thêm bản ghi đã update
    grp_HoSoNhanSu.insertRecord(rowindex, {
        PR_KEY: prkey,
        MA_CB: ma_cb,
        HO_TEN: ho_ten,
        MA_GIOITINH: ten_gioitinh,
        NGAY_SINH: ngay_sinh,
        TEN_BOPHAN: ten_bophan,
        TEN_CHUCVU: ten_chucvu,
        TEN_TRINHDO: ten_trinhdo,
        TEN_CHUYENNGANH: ten_chuyennganh,
        TEN_NGACH: ten_ngach,
        TEN_LOAI_HDONG: ten_loai_hdong,
        DIA_CHI_LH: dia_chi_lh,
        DI_DONG: di_dong,
        EMAIL: email,
        TUOI: 25,
        BI_DANH: bi_danh,
        NGAYCAP_HOCHIEU: ngaycap_hochieu,
        NGAY_TUYEN_DTIEN: ngay_tuyen_dtien,
        NGAY_TUYEN_CHINHTHUC: ngay_tuyen_chinhthuc,
        NGAYCAP_CMND: ngaycap_cmnd,
        TEN_NOICAP_HOCHIEU: noi_cap_hc,
        TEN_NOICAP_CMND: noi_cap_cmnd,
        DT_NHA: dt_nha,
        DT_CQUAN: dt_cq
    });
    grp_HoSoNhanSu.getView().refresh();
    grp_HoSoNhanSu.getSelectionModel().selectRow(rowindex);
    store_HoSoNhanSu.commitChanges();
}

var addRecord = function (ma_cb, ho_ten, ten_gioitinh, ngay_sinh, ten_bophan, ten_chucvu, ten_trinhdo, ten_chuyennganh, ten_ngach, ten_loai_hdong, dia_chi_lh, di_dong, email,
        bi_danh, ngaycap_hochieu, ngay_tuyen_dtien, ngay_tuyen_chinhthuc, ngaycap_cmnd, noi_cap_hc, noi_cap_cmnd, dt_cq, dt_nha) {
    var rowindex = getSelectedIndexRow();
    grp_HoSoNhanSu.insertRecord(rowindex, {
        MA_CB: ma_cb,
        HO_TEN: ho_ten,
        MA_GIOITINH: ten_gioitinh,
        NGAY_SINH: ngay_sinh,
        TEN_PHONG: ten_bophan,
        TEN_CHUCVU: ten_chucvu,
        TEN_TRINHDO: ten_trinhdo,
        TEN_CHUYENNGANH: ten_chuyennganh,
        TEN_NGACH: ten_ngach,
        TEN_LOAI_HDONG: ten_loai_hdong,
        DIA_CHI_LH: dia_chi_lh,
        DI_DONG: di_dong,
        EMAIL: email,
        TUOI: 25,
        BI_DANH: bi_danh,
        NGAYCAP_HOCHIEU: ngaycap_hochieu,
        NGAY_TUYEN_DTIEN: ngay_tuyen_dtien,
        NGAY_TUYEN_CHINHTHUC: ngay_tuyen_chinhthuc,
        NGAYCAP_CMND: ngaycap_cmnd,
        TEN_NOICAP_HOCHIEU: noi_cap_hc,
        TEN_NOICAP_CMND: noi_cap_cmnd,
        DT_NHA: dt_nha,
        DT_CQUAN: dt_cq
    });
    grp_HoSoNhanSu.getView().refresh();
    grp_HoSoNhanSu.getSelectionModel().selectRow(rowindex);
    store_HoSoNhanSu.commitChanges();
}

var RemoveItemOnGrid = function (grid, Store) {
    Ext.Msg.confirm('Xác nhận', 'Bạn có chắc chắn muốn xóa không ?', function (btn) {
        if (btn == "yes") {
            Ext.net.DirectMethods.DeleteRecord();
        }
    });
}
var ReloadStoreOfTabIndex = function () {
    //Fill đầy đủ các thông tin chung
    var record = grp_HoSoNhanSu.getSelectionModel().getSelections();
    SouthHoSoNhanSu1_txtMaCB.setValue(record[0].data.MA_CB);
    SouthHoSoNhanSu1_txtFullName.setValue(record[0].data.HO_TEN);
    SouthHoSoNhanSu1_txtNgach.setValue(record[0].data.TEN_NGACH);
    if (checkboxSelection.getSelected().data.PHOTO != null && checkboxSelection.getSelected().data.PHOTO != '') {
        SouthHoSoNhanSu1_hsImage.setImageUrl(checkboxSelection.getSelected().data.PHOTO.replace('~/Modules', '..'));
    }
    else {
        SouthHoSoNhanSu1_hsImage.setImageUrl("../NhanSu/ImageNhanSu/No_person.jpg");
    }

    SouthHoSoNhanSu1_txtMaCB.setValue(checkboxSelection.getSelected().data.MA_CB);
    SouthHoSoNhanSu1_txtFullName.setValue(checkboxSelection.getSelected().data.HO_TEN);
    SouthHoSoNhanSu1_txtBiDanh.setValue(checkboxSelection.getSelected().data.BI_DANH);
    SouthHoSoNhanSu1_txtNgayThuViec.setValue(RenderDate(checkboxSelection.getSelected().data.NGAY_TUYEN_DTIEN, null, null));
    SouthHoSoNhanSu1_txtNgayNhan.setValue(RenderDate(checkboxSelection.getSelected().data.NGAY_TUYEN_CHINHTHUC, null, null));
    SouthHoSoNhanSu1_txtNgach.setValue(checkboxSelection.getSelected().data.TEN_NGACH);

    SouthHoSoNhanSu1_txtSoCMND.setValue(checkboxSelection.getSelected().data.SO_CMND);
    SouthHoSoNhanSu1_txtNgayCapCMND.setValue(RenderDate(checkboxSelection.getSelected().data.NGAYCAP_CMND, null, null));
    SouthHoSoNhanSu1_txtNoiCapCMND.setValue(checkboxSelection.getSelected().data.TEN_NOICAP_CMND);
    SouthHoSoNhanSu1_txtNguoiLienHe.setValue(checkboxSelection.getSelected().data.NguoiLienHe);
    SouthHoSoNhanSu1_txtMoiQuanHe.setValue(checkboxSelection.getSelected().data.QuanHeVoiCanBo);
    SouthHoSoNhanSu1_txtSDTNguoiLienHe.setValue(checkboxSelection.getSelected().data.SDTNguoiLienHe);

    SouthHoSoNhanSu1_txtDTCoQuan.setValue(checkboxSelection.getSelected().data.DT_CQUAN);
    SouthHoSoNhanSu1_txtDTNha.setValue(checkboxSelection.getSelected().data.DT_NHA);
    SouthHoSoNhanSu1_txtSoHoChieu.setValue(checkboxSelection.getSelected().data.SO_HOCHIEU);
    SouthHoSoNhanSu1_txtNgayCapHC.setValue(RenderDate(checkboxSelection.getSelected().data.NGAYCAP_HOCHIEU, null, null));
    SouthHoSoNhanSu1_txtNoiCapHC.setValue(checkboxSelection.getSelected().data.TEN_NOICAP_HOCHIEU);
    SouthHoSoNhanSu1_txtLoaiHD.setValue(checkboxSelection.getSelected().data.TEN_LOAI_HDONG);

    //refresh lại store
    var tabTitle = SouthHoSoNhanSu1_TabPanelBottom.getActiveTab().id;
    switch (tabTitle) {
        case "SouthHoSoNhanSu1_panelHoSoTuyenDung":
            SouthHoSoNhanSu1_StoreHoSoTuyenDung.reload();
            break;
        case "SouthHoSoNhanSu1_panelQuaTrinhDaoTao":
            SouthHoSoNhanSu1_StoreQuaTrinhDaoTao.reload();
            break;
        case "SouthHoSoNhanSu1_panelBaoHiem":
            SouthHoSoNhanSu1_StoreBaoHiem.reload();
            break;
        case "SouthHoSoNhanSu1_panelDaiBieu":
            SouthHoSoNhanSu1_StoreDaiBieu.reload();
            break;
        case "SouthHoSoNhanSu1_panelDanhGia":
            SouthHoSoNhanSu1_StoreDanhGia.reload();
            break;
        case "SouthHoSoNhanSu1_panelDienBienLuong":
            SouthHoSoNhanSu1_StoreDienBienLuong.reload();
            break;
        case "SouthHoSoNhanSu1_panelDeTai":
            SouthHoSoNhanSu1_StoreDetai.reload();
            break;
        case "SouthHoSoNhanSu1_panelHopDong":
            SouthHoSoNhanSu1_StoreHopDong.reload();
            break;
        case "SouthHoSoNhanSu1_panelKhaNang":
            SouthHoSoNhanSu1_StoreKhaNang.reload();
            break;
        case "SouthHoSoNhanSu1_panelKhenThuong":
            SouthHoSoNhanSu1_StoreKhenThuong.reload();
            break;
        case "SouthHoSoNhanSu1_panelKiLuat":
            SouthHoSoNhanSu1_StoreKyLuat.reload();
            break;
        case "SouthHoSoNhanSu1_panelQuanHeGiaDinh":
            SouthHoSoNhanSu1_StoreQHGD.reload();
            break;
        case "SouthHoSoNhanSu1_panelQuaTrinhCongTac":
            SouthHoSoNhanSu1_StoreQuaTrinhCongTac.reload();
            break;
        case "SouthHoSoNhanSu1_panelQuaTrinhDieuChuyen":
            SouthHoSoNhanSu1_StoreQuaTrinhDieuChuyen.reload();
            break;
        case "SouthHoSoNhanSu1_panelTaiSan":
            SouthHoSoNhanSu1_StoreTaiSan.reload();
            break;
        case "SouthHoSoNhanSu1_panelTaiNanLaoDong":
            SouthHoSoNhanSu1_StoreTaiNanLaoDong.reload();
            break;
        case "SouthHoSoNhanSu1_panelTepDinhKem":
            SouthHoSoNhanSu1_grpTepTinDinhKemStore.reload();
            break;
        case "SouthHoSoNhanSu1_panelBangCapChungChi":
            SouthHoSoNhanSu1_Store_BangCapChungChi.reload();
            break;
        case "SouthHoSoNhanSu1_panelKinhNghiemLamViec":
            SouthHoSoNhanSu1_StoreKinhNghiemLamViec.reload();
            break;
        case "SouthHoSoNhanSu1_panelQuaTrinhHocTap":
            SouthHoSoNhanSu1_Store_BangCap.reload();
            break;
        case "SouthHoSoNhanSu1_panelTheNganHang":
            SouthHoSoNhanSu1_hdf_PrKeyHoSo.setValue(SouthHoSoNhanSu1_hdfRecordID.getValue());
            SouthHoSoNhanSu1_StoregrpATM.reload();
            break;
    }
}
var GetMirrorBooleanIcon = function (value, p, record) {
    var sImageCheck = "<img  src='../../Resource/Images/check.png'>"
    var sImageUnCheck = "<img src='../../Resource/Images/uncheck.gif'>"
    if (value == "1") {
        return sImageUnCheck;
    }
    else if (value == "0") {
        return sImageCheck;
    }
    return "";
}
var ResetControl = function () {
    txt_sohieucbccvc.reset(); txt_hoten.reset();
    txt_bidanh.reset(); dfNgaySinh.reset(); cbx_gioitinh.reset(); hdfQuocTich.reset();
    txt_machamcong.reset(); txt_quequan.reset(); txt_noisinh.reset(); cbx_quoctich.reset();
    cbx_tinhthanh.reset(); hdfTinhThanh.reset(); cbx_dantoc.reset(); cbx_tongiao.reset(); cbx_tthonnhan.reset(); hdfHonNhan.reset();
    cbx_tpbanthan.reset(); cbx_tpgiadinh.reset(); txt_didong.reset(); txt_dtcoquan.reset();
    txt_email.reset(); txt_dtnha.reset(); txt_hokhau.reset(); txt_diachilienhe.reset(); hdfChucVu.reset(); hdfXepLoai.reset();
    hdfMaTruongDaoTao.reset(); cbxTruongDaoTao.reset(); hdfMaChuyenNganh.reset(); cbxChuyenNganh.reset(); cbx_xeploai.reset(); tf_namtotnghiep.reset();
    cbx_tinhoc.reset(); hdfTinHoc.reset(); cbx_ngoaingu.reset(); hdfNgoaiNgu.reset(); cbx_trinhdo.reset(); cbx_tdvanhoa.reset(); tdVanHoa.reset();
    cbx_bophan.reset(); hdfBoPhan.reset(); date_tuyendau.reset(); date_tuyendau.setMaxValue(); date_ngaynhanct.reset();
    date_ngaynhanct.setMinValue(); date_ngaynhanct.setMaxValue(); txt_emailkhac.reset(); hdfTrinhDo.reset();
    cbx_chucvu.reset(); cbx_congviec.reset(); txtSoNgayHocViec.reset(); txtThoiGianThuViec.reset();
    txt_sothebhyt.reset(); dfNgayDongBHYT.reset(); hdfHinhThucLamViec.reset();
    cbx_noikcb.reset(); txt_tiledongbh.reset(); txt_sothebhxh.reset(); cbx_noicapbhxh.reset();
    dfNgayCapBHXH.reset(); cbx_huongcs.reset(); hdfDanToc.reset();
    dfNgayHetHanBHYT.reset(); cbxHinhThucLamViec.reset();
    date_ketthucbh.reset(); txt_socmnd.reset(); date_capcmnd.reset(); cbx_noicapcmnd.reset();
    txt_sohochieu.reset(); date_ngaycaphc.reset(); date_ngaycaphc.setMaxValue();
    date_hethanhc.reset(); date_hethanhc.setMinValue(); cbx_noicaphc.reset();
    date_ngayvaodoan.reset(); cbx_chucvudoan.reset(); txt_noiketnapdoan.reset(); date_vaocongdoan.reset();
    txt_chucvucongdoan.reset(); cbx_trinhdochinhtri.reset(); date_thamgiacm.reset();
    chkLaDangVien.reset(); date_vaodang.reset(); date_vaodang.setMaxValue(); date_ngayvaodangct.reset();
    date_ngayvaodangct.setMinValue(); txt_noiketnapdang.reset(); cbx_chuvudang.reset();
    txt_noisinhhoatdang.reset(); chkDaThamGiaQuanDoi.reset(); date_nhapngu.reset(); date_nhapngu.setMaxValue();
    date_xuatngu.reset(); date_xuatngu.setMinValue(); cbx_bacquandoi.reset(); cbx_chucvuquandoi.reset();

    cbx_httuyen.reset(); date_bonhiemcv.reset(); cbx_ngach.reset(); date_bnngach.reset();
    cbx_trinhdoquanly.reset(); cbx_trinhdoquanlykt.reset(); txt_username.reset();
    txt_sotaikhoan.reset(); cbx_nganhang.reset(); txt_masothuecanhan.reset(); chk_danghi.reset();
    date_nghi.reset(); date_nghi.setMinValue(); cbx_lydonghi.reset(); txt_nguoilienhe.reset(); txt_sdtnguoilh.reset();
    txtMoiQH.reset(); txt_emailnguoilh.reset(); txt_diachinguoilienhe.reset(); cbNhommau.reset();
    txt_chieucao.reset(); txt_cannang.reset(); cbx_ttsuckhoe.reset(); txtSOTHICH.reset(); txt_UuDiem.reset();
    txt_NhuocDiem.reset(); chkLaThuongBinh.reset(); txt_HangThuongTat.reset(); txt_SoThuongTat.reset();
    txt_HinhThucThuongTat.reset(); cbx_congtrinh.reset();
    hdfCommandButton.setValue('Insert');
    Ext.net.DirectMethods.ResetWindowTitle();
    hdfMaCB.reset(); hdfQuocTich.reset(); hdfTinhThanh.reset(); hdfDanToc.reset();
    hdfTonGiao.reset(); hdfHonNhan.reset(); hdfThanhPhanBanThan.reset();
    hdfThanhPhanGiaDinh.reset(); hdfMaTruongDaoTao.reset(); hdfMaChuyenNganh.reset();
    hdfXepLoai.reset(); hdfTinHoc.reset(); hdfNgoaiNgu.reset(); hdfTrinhDo.reset(); tdVanHoa.reset();
    hdfBoPhan.reset(); hdfChucVu.reset(); hdfHinhThucLamViec.reset();
    hdfViTriCongViec.reset(); hdfBiDanh.reset(); hdfNoiKhamChuaBenh.reset(); hdfNoiCapBHXH.reset(); hdfHuongChinhSach.reset();
    hdfNoiCapCMND.reset(); hdfNoiCapHoChieu.reset(); hdfChucVuDoan.reset();
    hdfLyLuanChinhTri.reset(); hdfChucVuDang.reset(); hdfQuanHamCaoNhat.reset(); hdfChucVuQuanDoi.reset();
    hdfNgach.reset(); hdfQuanLyNhaNuoc.reset(); hdfTrinhDoQLKT.reset(); hdfNganHang.reset(); hdfTTSucKhoe.reset(); hdfHTTuyenDung.reset();
    txt_macb.enable();
}
var RenderHightLight = function (value, p, record) {
    if (value == null || value == "") {
        return "";
    }
    var keyword = document.getElementById("txtSearch").value;
    if (keyword == "" || keyword == "Nhập tên hoặc mã cán bộ")
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