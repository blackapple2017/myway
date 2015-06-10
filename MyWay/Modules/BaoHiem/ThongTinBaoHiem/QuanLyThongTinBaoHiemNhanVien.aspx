<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QuanLyThongTinBaoHiemNhanVien.aspx.cs"
    Inherits="Modules_BaoHiem_QuanLyThongTinBaoHiemNhanVien" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register Src="~/Modules/ChooseEmployee/ucChooseEmployee.ascx" TagPrefix="uc1"
    TagName="ucChooseEmployee" %>
<%@ Register Src="~/Modules/Base/ImportExcelFile/ImportExcelFile.ascx" TagPrefix="uc1"
    TagName="ImportExcelFile" %>
<%--<%@ Register Src="../Base/ImportExcelFile/ImportExcelFile.ascx" TagName="ImportExcelFile"
    TagPrefix="uc2" %>--%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        div#Panel1-xsplit
        {
            border: 1px solid #98C0F4;
            border-bottom: none;
            border-top: none;
        }
        
        .list-item
        {
            font: normal 11px tahoma, arial, helvetica, sans-serif;
            padding: 3px 10px 3px 10px;
            border: 1px solid #fff;
            border-bottom: 1px solid #ddd;
            white-space: normal;
            color: #000;
        }
        
        .x-layout-collapsed-west
        {
            background: url(../../../Resource/images/LocTheoPhongBan.png) no-repeat center !important;
        }
        
        div#TreeCoCauToChuc .x-panel-body
        {
            background: #fff !important;
        }
        /*#pnReportPanel1__Homepage
        {
            display: none !important;
        }*/
        div#pnReportPanel1 .x-tab-panel-header, div#TabPanel2 .x-tab-panel-header
        {
            display: none !important;
        }
    </style>
    <script src="../../../Resource/js/Extcommon.js" type="text/javascript"></script>
    <script src="../../../Resource/js/global.js" type="text/javascript"></script>
    <script src="../../../Resource/js/RenderJS.js" type="text/javascript"></script>
    <script type="text/javascript">

        var keyEnterPress = function (f, e) {

            if (e.getKey() == e.ENTER) {
                PagingToolbar1.pageIndex = 0;
                PagingToolbar1.doLoad();
                //                grpQuanLyThongTinBaoHiem_store.reload();
                if (this.getValue() == '') {
                    this.triggers[0].hide();
                }
            }
            if (this.getValue() != '') {
                this.triggers[0].show();
            }
        }

        var RenderSoNam = function (value, p, record) {

            if (value == null || value == "") {
                return "0" + " tháng";
            }
            var nam = parseInt(value / 12);
            var sothang = value % 12;
            if (nam == 0) {
                value = sothang + " tháng";
            }
            else {
                value = nam + " năm " + sothang + " tháng";
            }
            return value;
        }

        var SuaThongTinNhanVienBaoHiem = function (grid, Store) {
            var s = grid.getSelectionModel().getSelections();
            for (var i = 0, r; r = s[i]; i++) {
                Store.commitChanges();
                hdfIDNhanVienBaoHiem.setValue(r.data.MaNhanVien.toString());
                Ext.net.DirectMethods.SuaThongTinNhanVien(hdfIDNhanVienBaoHiem.getValue().toString());
            }
        }
        var GetIdToKhaiNhanVienBaoHiem = function (grid, Store) {
            var s = grid.getSelectionModel().getSelections();
            for (var i = 0, r; r = s[i]; i++) {
                Store.commitChanges();
                hdfIDNhanVienBaoHiem.setValue(r.data.MaNhanVien.toString());
            }
        }
        var checktokhai = function () {
            if (hdfIDNhanVienBaoHiem.getValue() == "") {
                alert('Bạn chưa chọn nhân viên nào');
                return false;
            }
            wdShowReport.show();
        }

        var SinhNoiDung = function () {
            var noidung = "Thay đổi thông tin: ";
            var check;
            if (txtHoTenMoi.getValue() != txtHoTenCu.getValue() && txtHoTenMoi.getValue()) {
                check = true;
                noidung = noidung + "Họ tên từ \"" + txtHoTenCu.getValue() + "\" thành \"" + txtHoTenMoi.getValue() + "\". ";
            }
            if (nfNgayMoi.getValue() && nfThangMoi.getValue() && nfNamMoi.getValue()) {
                if (nfNgayMoi.getValue().toString() + nfThangMoi.getValue() + nfNamMoi.getValue() != nfNgayCu.getValue().toString() + nfThangCu.getValue().toString() + nfNamCu.getValue().toString()) {
                    noidung = noidung + "Ngày sinh từ \"" + (nfNamCu.getValue() ? (nfNgayCu.getValue() + "/" + nfThangCu.getValue() + "/" + nfNamCu.getValue()) : "") +
                                "\" thành \"" + nfNgayMoi.getValue() + "/" + nfThangMoi.getValue() + "/" + nfNamMoi.getValue() + "\". ";
                }
            }
            if (cbbGioiTinhCu.getValue() && cbbGioiTinhMoi.getValue()) {
                if (cbbGioiTinhCu.getValue() != cbbGioiTinhMoi.getValue()) {
                    check = true;
                    noidung = noidung + "Giới tính từ \"" + ((cbbGioiTinhCu.getValue() == 0) ? "Nữ" : "Nam") + "\" thành \"" +
                        ((cbbGioiTinhMoi.getValue() == 0) ? "Nữ" : "Nam") + "\". ";
                }
            }
            if (txtSoCMNDCu.getValue() != txtSoCMNDMoi.getValue() && txtSoCMNDMoi.getValue()) {

                check = true;
                noidung = noidung + "Số CMND từ \"" + txtSoCMNDCu.getValue() + "\" thành \"" + txtSoCMNDMoi.getValue() + "\". ";
            }
            if (nfNgayCapMoi.getValue() &&
                nfThangCapMoi.getValue() &&
                nfNamCapMoi.getValue()) {
                if (nfNamCapCu.getValue().toString() + nfThangCapCu.getValue() + nfNgayCapMoi.getValue() != nfNamCapMoi.getValue() + nfThangCapMoi.getValue() + nfNgayCapMoi.getValue()) {
                    check = true;
                    noidung = noidung + "Ngày cấp CMND từ \"" + (!nfNamCapCu.getValue() ? "" : (nfNgayCapCu.getValue() + "/" + nfThangCapCu.getValue() + "/" + nfNamCapCu.getValue())) +
                                    "\" thành \"" + nfNgayCapMoi.getValue() + "/" + nfThangCapMoi.getValue() + "/" + nfNamCapMoi.getValue() + "\". ";
                }
            }
            if (cbbNoiCapCMNDCu.getValue() != cbbNoiCapCMNDMoi.getText() && cbbNoiCapCMNDMoi.getValue()) {
                check = true;
                noidung = noidung + "Nơi cấp CMND từ \"" + cbbNoiCapCMNDCu.getValue() + "\" thành \"" + cbbNoiCapCMNDMoi.getText() + "\". ";
            }
            if (txtDiaChiCu.getValue() != txtDiaChiMoi.getValue() && txtDiaChiMoi.getValue()) {
                check = true;
                noidung = noidung + "Địa chỉ từ \"" + txtDiaChiCu.getValue() + "\" thành \"" + txtDiaChiMoi.getValue() + "\". ";
            }
            if ((txtNoiDangKyKCBCu.getValue() != txtNoiDangKyKCBMoi.getValue()) && txtNoiDangKyKCBMoi.getValue()) {
                check = true;
                noidung = noidung + "Nơi đăng ký khám chữa bệnh từ \"" + txtNoiDangKyKCBCu.getValue() + "\" thành \"" + txtNoiDangKyKCBMoi.getText() + "\". ";
            }
            if (check) {
                txtNoiDungThayDoi.setValue(noidung);
            }
            else txtNoiDungThayDoi.setValue("");
            // Ext.net.DirectMethods.SinhNoiDungThayDoi();
        }

        var ValidateFormThem = function () {
            if (txtMaCanBo.getValue() == "") {
                alert("Bạn chưa chọn cán bộ");
                nfLuongBaoHiem.focus();
                return false;
            }
            if (chkBHXH.checked == false && chkBHYT.checked == false && chkBHTN.checked == false) {
                alert("Cán bộ này không được đóng bảo hiểm");
                return false;
            }
            if (!(nfLuongBaoHiem.getValue() > 0)) {
                alert("Lương đóng bảo hiểm phải >0");
                nfLuongBaoHiem.focus();
                return false;
            }
            if (hdfTrangThaiCapSo.getValue() == '') {
                alert("Bạn chưa chọn trạng thái cấp sổ");
                cbbTrangthaiCapSo.focus();
                return false;
            }
            if (hdfTrangThaiCapThe.getValue() == '') {
                alert("Bạn chưa chọn trạng thái cấp thẻ");
                cbbTrangThaiCapThe.focus();
                return false;
            }
            if (chkDongBHXH.getValue = 1 && (nfSoThangDongTruocThem.getValue() == "" || nfSoNamDongTruocThem.getValue() == "")) {
                alert("Bạn phải nhập thời gian đóng bảo hiểm trước khi vào công ty");
                nfSoThangDongTruocThem.focus();
                return false;
            }
            if (chkBHXH.getValue()) {
                if (!cbbThangBHXH.getValue() || !spinNamBHXH.getValue()) {
                    alert("Bạn chưa nhập tháng năm đăng ký");
                    cbbThangBHXH.focus();
                    return false;
                }
            }
            return true;
        }

        var ValidateFormSua = function () {
            if (hdfTrangThaiCapSoSua.getValue() == '' || hdfTrangThaiCapThe.getValue() == '') {
                alert('Ban chưa chọn trạng thái cấp sổ hoặc trạng thái cấp thẻ');
                return false;
            }
            if (true) {

            }
            return true;
        }

        var resetFormSua = function () {
            txtHoTenCu.reset(); nfNgayCu.reset();
            nfThangCu.reset(); nfNamCu.reset();
            cbbGioiTinhCu.reset(); txtSoCMNDCu.reset();
            nfNgayCapCu.reset(); nfThangCapCu.reset();
            nfNamCapCu.reset(); cbbNoiCapCMNDCu.reset(); txtDiaChiCu.reset();
            txtNoiDangKyKCBCu.reset(); txtHoTenMoi.reset(); nfNgayMoi.reset();
            nfThangMoi.reset(); nfNamMoi.reset(); cbbGioiTinhMoi.reset();
            txtSoCMNDMoi.reset(); nfNgayCapMoi.reset(); nfThangCapMoi.reset();
            nfNamCapMoi.reset(); cbbNoiCapCMNDMoi.reset(); txtDiaChiMoi.reset();
            txtNoiDangKyKCBMoi.reset(); txtNoiDungThayDoi.reset();
            chkDongBHYT.reset(); chkDongBHXH.reset(); chkDongBHTN.reset();
            txtLuongBaoHiemSua.reset(); txtPhuCapCVSua.reset(); txtPhuCapTNVKSua.reset();
            txtPhuCapTNNgheSua.reset(); txtPhuCapKhacSua.reset(); cboTrangThaiCapThe.reset();
            cbbTuThangBHYTSua.reset(); spinTuNamBHYTSua.reset(); txtSoTheBHYTSua.reset();
            cbbDenThangBHYTSua.reset(); spinDenNamBHYTSua.reset(); chkDaDangKyCQBHSua.reset();
            cbbTrangThaiCapSoSua.reset(); hdfTrangThaiCapSoSua.reset();
            txtSoSoBHXHSua.reset(); cbbThangDangKyBHXHSua.reset();
            spinNamDangKyBHXHSua.reset(); txtNoiCapSoBHXHSua.reset(); txtNoiCapSoBHXHSua.clearValue(); dfNgayCapSoBHXHSua.reset();
            dfNgayCapSoBHXHSua.setMaxValue(); dfNgayCapSoBHXHSua.setMinValue();
            nfSoNamDongTruocSua.reset(); nfSoThangDongTruocSua.reset();
            hdfNoiCapSoBHXHSua.reset();
        }
        var resetFormThem = function () {
            txtMaCanBo.reset();
            txtPhongBan.reset(); txtSoCMND.reset(); dfNgaySinh.reset();
            dfNgaySinh.setMaxValue(); dfNgaySinh.setMinValue(); txtGioiTinh.reset();
            txtLoaiHopDong.reset(); chkBHXH.reset(); chkBHYT.reset(); chkBHTN.reset();
            txtHoTen.reset(); txtChucVu.reset(); txtNoiCapCMND.reset(); txtDiaChi.reset();
            nfLuongBaoHiem.reset(); nfTongPhuCap.reset();
            ddfNoiDangKyKhamChuaBenh.reset(); cbbTrangThaiCapThe.reset(); hdfTrangThaiCapThe.reset();
            cbbTuThangBHYT.reset(); spinTuNamBHYT.reset(); txtSoTheBHYT.reset(); cbbDenThangBHYT.reset();
            spinDenNamBHYT.reset(); chkTrangThaiDangKy.reset(); cbbTrangthaiCapSo.reset(); hdfTrangThaiCapSo.reset();
            txtSoSoBHXH.reset(); cbbThangBHXH.reset(); spinNamBHXH.reset();
            txtNoiCapSoBHXH.reset(); dfNgayCapSo.reset(); dfNgayCapSo.setMaxValue();
            dfNgayCapSo.setMinValue(); nfSoThangDongTruocThem.reset(); nfSoNamDongTruocThem.reset();
            hdfPhuCap.reset();
            nfSoThangDongTruocThem.setValue(0);
            nfSoNamDongTruocThem.setValue(0);
            setDisableBHXH();
            setDisableBHYT();
        }
        var setDisableBHXH = function () {
            chkTrangThaiDangKy.setDisabled(true); cbbThangBHXH.setDisabled(true);
            spinNamBHXH.setDisabled(true); cbbTrangthaiCapSo.setDisabled(true);
            txtSoSoBHXH.setDisabled(true); txtNoiCapSoBHXH.setDisabled(true);
            dfNgayCapSo.setDisabled(true); nfSoThangDongTruocThem.setDisabled(true);
            nfSoNamDongTruocThem.setDisabled(true);
        }
        var setDisableBHYT = function () {
            txtSoTheBHYT.setDisabled(true); cbbTrangThaiCapThe.setDisabled(true);
            cbbTuThangBHYT.setDisabled(true); cbbDenThangBHYT.setDisabled(true);
            spinTuNamBHYT.setDisabled(true); spinDenNamBHYT.setDisabled(true);
        }
        var setEnableBHXH = function () {
            chkTrangThaiDangKy.setDisabled(false); cbbThangBHXH.setDisabled(false);
            spinNamBHXH.setDisabled(false); cbbTrangthaiCapSo.setDisabled(false);
            txtSoSoBHXH.setDisabled(false); txtNoiCapSoBHXH.setDisabled(false);
            dfNgayCapSo.setDisabled(false); nfSoThangDongTruocThem.setDisabled(false);
            nfSoNamDongTruocThem.setDisabled(false);
        }
        var setEnableBHYT = function () {
            txtSoTheBHYT.setDisabled(false); cbbTrangThaiCapThe.setDisabled(false);
            cbbTuThangBHYT.setDisabled(false); cbbDenThangBHYT.setDisabled(false);
            spinTuNamBHYT.setDisabled(false); spinDenNamBHYT.setDisabled(false);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager runat="server" ID="RM">
        </ext:ResourceManager>
        <ext:Store runat="server" ID="cbx_noikcb_Store" AutoLoad="True" OnRefreshData="cbx_noikcb_Store_OnRefreshData">
            <Reader>
                <ext:JsonReader IDProperty="MA">
                    <Fields>
                        <ext:RecordField Name="MA" />
                        <ext:RecordField Name="TEN" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        <ext:Hidden runat="server" ID="hdfMaDonVi" />
        <ext:Hidden runat="server" ID="hdfIDNhanVienBaoHiem" />
        <%--<ext:Hidden runat="server" ID="hdfSoThangDongTruocSua" />--%>
        <%--<ext:Hidden runat="server" ID="hdfSoThangDongTruocThem" />--%>
        <ext:Hidden runat="server" ID="hdfPhuCap" />
        <ext:Menu ID="RowContextMenu" runat="server">
            <Items>
                <ext:MenuItem runat="server" Text="Thêm" Icon="Add">
                    <Listeners>
                        <Click Handler="resetFormThem();wdThongTinDongBHNhanVien.show();" />
                    </Listeners>
                </ext:MenuItem>
                <ext:MenuItem runat="server" Text="Sửa" Icon="Pencil">
                    <Listeners>
                        <Click Handler="cbx_noicapcmnd_Store.reload();SuaThongTinNhanVienBaoHiem(grpQuanLyThongTinBaoHiem,grpQuanLyThongTinBaoHiem_store);" />
                    </Listeners>
                </ext:MenuItem>
                <ext:MenuItem runat="server" Text="In tờ khai" Icon="Script">
                    <Listeners>
                        <Click Handler=" return checktokhai(); " />
                    </Listeners>
                </ext:MenuItem>
            </Items>
        </ext:Menu>
        <ext:Store ID="grpQuanLyThongTinBaoHiem_store" runat="server" GroupField="TrangThai">
            <Proxy>
                <ext:HttpProxy Method="GET" Url="HandlerQuanLyThongTinBaoHiem.ashx" />
            </Proxy>
            <AutoLoadParams>
                <ext:Parameter Name="start" Value="={0}" />
                <ext:Parameter Name="limit" Value="={15}" />
            </AutoLoadParams>
            <BaseParams>
                <ext:Parameter Name="SearchKey" Value="txtSearchKey.getValue()" Mode="Raw" />
                <ext:Parameter Name="MaDonVi" Value="hdfMaDonVi.getValue()" Mode="Raw" />
            </BaseParams>
            <Reader>
                <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="MaNhanVien">
                    <Fields>
                        <ext:RecordField Name="MaNhanVien" />
                        <ext:RecordField Name="HoTen" />
                        <ext:RecordField Name="PhongBan" />
                        <ext:RecordField Name="LuongBaoHiem" />
                        <ext:RecordField Name="PhuCapCV" />
                        <ext:RecordField Name="PhuCapVuotKhung" />
                        <ext:RecordField Name="PhuCapNghe" />
                        <ext:RecordField Name="PhuCapKhac" />
                        <ext:RecordField Name="NgayDangKyBHXH" />
                        <ext:RecordField Name="SoSoBHXH" />
                        <ext:RecordField Name="ThoiGianDongBaoHiem" />
                        <ext:RecordField Name="DangDongBHXH" />
                        <ext:RecordField Name="DangDongBHYT" />
                        <ext:RecordField Name="DangDongBHTN" />
                        <ext:RecordField Name="SoTheBHYT" />
                        <ext:RecordField Name="TuThangBHYT" />
                        <ext:RecordField Name="DenThangBHYT" />
                        <ext:RecordField Name="BHXHTrangThaiDangKyCQBH" />
                        <ext:RecordField Name="TrangThai" />
                        <ext:RecordField Name="NoiCapBHXH" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        <ext:Window Modal="true" Hidden="true" runat="server" Layout="BorderLayout" ID="wdShowReport"
            Title="Báo cáo thông tin nhân viên đóng bảo hiểm xã hội, bảo hiểm y tế" Maximized="true"
            Icon="Printer">
            <Items>
                <ext:TabPanel ID="pnReportPanel1" Region="Center" AnchorVertical="100%" Border="false"
                    runat="server">
                </ext:TabPanel>
            </Items>
            <Listeners>
                <BeforeShow Handler="#{pnReportPanel1}.remove(0);addHomePage(#{pnReportPanel1},'Homepage','../../Report/BHQuanLyToKhaiThongTinNhanVien.aspx?prkey='+#{hdfIDNhanVienBaoHiem}.getValue(), 'Báo cáo thông tin nhân viên bảo hiểm')" />
            </Listeners>
            <Buttons>
                <ext:Button ID="Button5" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdShowReport}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Window Modal="true" Hidden="true" runat="server" Layout="BorderLayout" ID="wdShowDonDeNghi"
            Title="Báo cáo thông tin nhân viên đóng bảo hiểm xã hội, bảo hiểm y tế" Maximized="true"
            Icon="Printer">
            <Items>
                <ext:TabPanel ID="TabPanel2" Region="Center" AnchorVertical="100%" Border="false"
                    runat="server">
                </ext:TabPanel>
            </Items>
            <Listeners>
                <BeforeShow Handler="#{TabPanel2}.remove(0);addHomePage(#{TabPanel2},'Homepage','../../Report/BHDonDeNghi.aspx?prkey='+#{hdfIDNhanVienBaoHiem}.getValue(), 'Báo cáo thông tin nhân viên bảo hiểm')" />
            </Listeners>
            <Buttons>
                <ext:Button ID="Button1" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdShowDonDeNghi}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <uc1:ucChooseEmployee runat="server" ID="ucChooseEmployee1" DisplayWorkingStatus="DangLamViec"
            ChiChonMotCanBo="true" />
        <ext:Window runat="server" ID="wdThongTinDongBHNhanVien" Modal="true" Layout="FormLayout"
            Padding="6" Constrain="false" Title="Nhập thông tin nhân viên" Hidden="true"
            Width="651" Icon="Add" AutoHeight="true">
            <Items>
                <ext:FieldSet ID="fs_ThongTinDongBH" runat="server" Title="Thông tin đóng bảo hiểm của CBCNV"
                    AutoHeight="true" Border="true">
                    <Items>
                        <ext:Container runat="server" Height="180" Layout="ColumnLayout">
                            <Items>
                                <ext:Container ID="Container16" runat="server" AutoHeight="true" ColumnWidth=".5"
                                    Layout="FormLayout">
                                    <Items>
                                        <ext:TriggerField runat="server" ID="txtMaCanBo" AnchorHorizontal="99%" AllowBlank="false"
                                            FieldLabel="Mã cán bộ<span style='color:red'>*</span>" Editable="false">
                                            <Triggers>
                                                <ext:FieldTrigger Icon="SimpleMagnify" />
                                            </Triggers>
                                            <Listeners>
                                                <TriggerClick Handler="resetFormThem(); ucChooseEmployee1_wdChooseUser.show();" />
                                            </Listeners>
                                        </ext:TriggerField>
                                        <ext:TextField runat="server" ID="txtPhongBan" AnchorHorizontal="99%" Disabled="true"
                                            FieldLabel="Tên phòng ban" />
                                        <ext:TextField runat="server" ID="txtSoCMND" AnchorHorizontal="99%" Disabled="true"
                                            FieldLabel="Số CMND" />
                                        <ext:DateField runat="server" ID="dfNgaySinh" AnchorHorizontal="99%" Disabled="true"
                                            FieldLabel="Ngày sinh" MaskRe="/[0-9\/]/" Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/"
                                            RegexText="Định dạng ngày sinh không đúng" />
                                        <ext:TextField runat="server" ID="txtGioiTinh" AnchorHorizontal="99%" Disabled="true"
                                            FieldLabel="Giới tính" />
                                        <ext:TextField runat="server" ID="txtLoaiHopDong" AnchorHorizontal="99%" Disabled="true"
                                            FieldLabel="Loại hợp đồng" />
                                        <ext:CheckboxGroup ID="CheckboxGroup1" runat="server" FieldLabel="Tham gia BH" AnchorHorizontal="99%">
                                            <Items>
                                                <ext:Checkbox runat="server" ID="chkBHYT" BoxLabel="BHYT">
                                                    <Listeners>
                                                        <Check Handler="if(chkBHYT.getValue()) setEnableBHYT(); else setDisableBHYT();">
                                                        </Check>
                                                    </Listeners>
                                                </ext:Checkbox>
                                                <ext:Checkbox runat="server" ID="chkBHXH" BoxLabel="BHXH">
                                                    <Listeners>
                                                        <Check Handler="if(chkBHXH.getValue()) setEnableBHXH(); else setDisableBHXH();">
                                                        </Check>
                                                    </Listeners>
                                                </ext:Checkbox>
                                                <ext:Checkbox runat="server" ID="chkBHTN" BoxLabel="BHTN" />
                                            </Items>
                                        </ext:CheckboxGroup>
                                    </Items>
                                </ext:Container>
                                <ext:Container ID="Container17" runat="server" AutoHeight="true" ColumnWidth=".5"
                                    Layout="FormLayout" LabelWidth="109">
                                    <Items>
                                        <ext:TextField runat="server" ID="txtHoTen" AnchorHorizontal="99%" Disabled="true"
                                            AllowBlank="false" FieldLabel="Họ tên" />
                                        <ext:TextField runat="server" ID="txtChucVu" AnchorHorizontal="99%" Disabled="true"
                                            FieldLabel="Chức vụ" />
                                        <ext:TextField runat="server" ID="txtNoiCapCMND" AnchorHorizontal="99%" Disabled="true"
                                            FieldLabel="Nơi cấp CMND" />
                                        <ext:TextField runat="server" ID="txtDiaChi" AnchorHorizontal="99%" Disabled="true"
                                            FieldLabel="Địa chỉ" />
                                        <ext:TextField runat="server" ID="ddfNoiDangKyKhamChuaBenh" AnchorHorizontal="99%"
                                            FieldLabel="Nơi đăng ký KCB" LabelAlign="Right" Disabled="true" />
                                        <ext:NumberField runat="server" ID="nfLuongBaoHiem" AnchorHorizontal="99%" FieldLabel="Lương bảo hiểm<span style='color:red'>*</span>"
                                            CtCls="requiredData" AllowNegative="false" MaxLength="12" MaskRe="/[0-9]/" AllowDecimals="false" />
                                        <ext:NumberField runat="server" ID="nfTongPhuCap" AnchorHorizontal="99%" FieldLabel="Tổng phụ cấp BH"
                                            AllowNegative="false" AllowDecimals="false" MaxLength="12" Disabled="true" Hidden="true" />
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:FieldSet>
                <ext:FieldSet ID="FieldSet1" runat="server" Title="BHYT" Layout="ColumnLayout" Height="80"
                    Border="true">
                    <Items>
                        <ext:Container ID="Container1" runat="server" ColumnWidth=".5" Layout="FormLayout">
                            <Items>
                                <ext:Hidden runat="server" ID="hdfTrangThaiCapThe" />
                                <ext:ComboBox runat="server" ID="cbbTrangThaiCapThe" FieldLabel="Trạng thái thẻ<span style='color:red'>*</span>"
                                    CtCls="requiredData" LabelSeparator="" EmptyText="Trạng thái cấp thẻ" Editable="false"
                                    AnchorHorizontal="99%" LabelWidth="105">
                                    <Items>
                                        <ext:ListItem Value="ChuaCapThe" Text="Chưa cấp thẻ" />
                                        <ext:ListItem Value="DaCapThe" Text="Đã cấp thẻ" />
                                        <ext:ListItem Value="DaTraThe" Text="Đã trả thẻ" />
                                        <ext:ListItem Value="DaNopThe" Text="Đã nộp thẻ" />
                                        <ext:ListItem Value="ChuaNopThe" Text="Chưa nộp thẻ" />
                                    </Items>
                                    <Listeners>
                                        <Select Handler="hdfTrangThaiCapThe.setValue(cbbTrangThaiCapThe.getValue()); if(hdfTrangThaiCapThe.getValue()=='ChuaCapThe') txtSoTheBHYT.setValue();" />
                                    </Listeners>
                                </ext:ComboBox>
                                <ext:Container ID="Container6" runat="server" Layout="HBoxLayout" Height="25">
                                    <Items>
                                        <ext:ComboBox runat="server" FieldLabel="Từ tháng" LabelWidth="100" Editable="false"
                                            ID="cbbTuThangBHYT" EmptyText="Tháng" Width="190">
                                            <Items>
                                                <ext:ListItem Text="Tháng 1" Value="1" />
                                                <ext:ListItem Text="Tháng 2" Value="2" />
                                                <ext:ListItem Text="Tháng 3" Value="3" />
                                                <ext:ListItem Text="Tháng 4" Value="4" />
                                                <ext:ListItem Text="Tháng 5" Value="5" />
                                                <ext:ListItem Text="Tháng 6" Value="6" />
                                                <ext:ListItem Text="Tháng 7" Value="7" />
                                                <ext:ListItem Text="Tháng 8" Value="8" />
                                                <ext:ListItem Text="Tháng 9" Value="9" />
                                                <ext:ListItem Text="Tháng 10" Value="10" />
                                                <ext:ListItem Text="Tháng 11" Value="11" />
                                                <ext:ListItem Text="Tháng 12" Value="12" />
                                            </Items>
                                        </ext:ComboBox>
                                        <ext:DisplayField ID="DisplayField1" runat="server" FieldLabel="Năm" Width="30" LabelWidth="0" />
                                        <ext:SpinnerField ID="spinTuNamBHYT" runat="server" Width="60" MinValue="1900" MaxValue="2100"
                                            CtCls="requiredData" />
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:Container>
                        <ext:Container ID="Container2" runat="server" ColumnWidth=".5" Layout="FormLayout">
                            <Items>
                                <ext:TextField runat="server" ID="txtSoTheBHYT" AnchorHorizontal="99%" FieldLabel="Số thẻ BHYT" />
                                <ext:Container ID="Container7" runat="server" Layout="HBoxLayout">
                                    <Items>
                                        <ext:ComboBox runat="server" FieldLabel="Đến tháng" LabelWidth="100" Editable="false"
                                            LabelAlign="Right" ID="cbbDenThangBHYT" Width="190" EmptyText="Tháng">
                                            <Items>
                                                <ext:ListItem Text="Tháng 1" Value="1" />
                                                <ext:ListItem Text="Tháng 2" Value="2" />
                                                <ext:ListItem Text="Tháng 3" Value="3" />
                                                <ext:ListItem Text="Tháng 4" Value="4" />
                                                <ext:ListItem Text="Tháng 5" Value="5" />
                                                <ext:ListItem Text="Tháng 6" Value="6" />
                                                <ext:ListItem Text="Tháng 7" Value="7" />
                                                <ext:ListItem Text="Tháng 8" Value="8" />
                                                <ext:ListItem Text="Tháng 9" Value="9" />
                                                <ext:ListItem Text="Tháng 10" Value="10" />
                                                <ext:ListItem Text="Tháng 11" Value="11" />
                                                <ext:ListItem Text="Tháng 12" Value="12" />
                                            </Items>
                                        </ext:ComboBox>
                                        <ext:DisplayField ID="DisplayField2" runat="server" FieldLabel="Năm" Width="30" LabelWidth="0" />
                                        <ext:SpinnerField ID="spinDenNamBHYT" runat="server" Width="60" MinValue="1900" MaxValue="2100" />
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:FieldSet>
                <ext:FieldSet ID="FieldSet2" runat="server" Title="BHXH" Layout="FormLayout" Height="130"
                    Border="true">
                    <Items>
                        <ext:Container runat="server" Layout="ColumnLayout" Height="80">
                            <Items>
                                <ext:Container ID="Container3" runat="server" AutoHeight="true" ColumnWidth=".5"
                                    Layout="FormLayout">
                                    <Items>
                                        <ext:Checkbox runat="server" ID="chkTrangThaiDangKy" FieldLabel="Trạng thái" AnchorHorizontal="99%"
                                            BoxLabel="Đã đăng ký với cơ quan BH" />
                                        <ext:Hidden runat="server" ID="hdfTrangThaiCapSo" />
                                        <ext:ComboBox runat="server" ID="cbbTrangthaiCapSo" AnchorHorizontal="99%" FieldLabel="Trạng thái sổ<span style='color:red'>*</span>"
                                            CtCls="requiredData" EmptyText="Trạng thái cấp sổ">
                                            <Items>
                                                <ext:ListItem Text="Chưa cấp sổ" Value="ChuaCapSo" />
                                                <ext:ListItem Text="Đã cấp sổ" Value="DaCapSo" />
                                                <ext:ListItem Text="Đã trả sổ" Value="DaTraSo" />
                                                <ext:ListItem Text="Đã nộp sổ" Value="DaNopSo" />
                                                <ext:ListItem Text="Chưa nộp sổ" Value="ChuaNopSo" />
                                            </Items>
                                            <Listeners>
                                                <Select Handler="hdfTrangThaiCapSo.setValue(cbbTrangthaiCapSo.getValue()); if(hdfTrangThaiCapSo.getValue()=='ChuaCapSo') txtSoSoBHXH.setValue();" />
                                            </Listeners>
                                        </ext:ComboBox>
                                        <ext:TextField runat="server" ID="txtSoSoBHXH" AnchorHorizontal="99%" FieldLabel="Số Sổ BHXH" />
                                    </Items>
                                </ext:Container>
                                <ext:Container ID="Container4" runat="server" AutoHeight="true" ColumnWidth=".5"
                                    Layout="FormLayout">
                                    <Items>
                                        <ext:Container ID="Container5" runat="server" Layout="HBoxLayout" Height="25">
                                            <Items>
                                                <ext:ComboBox runat="server" FieldLabel="Tháng đăng ký<span style='color:red'>*</span>"
                                                    CtCls="requiredData" LabelWidth="100" Editable="false" ID="cbbThangBHXH" Width="190"
                                                    EmptyText="Tháng">
                                                    <Items>
                                                        <ext:ListItem Text="Tháng 1" Value="1" />
                                                        <ext:ListItem Text="Tháng 2" Value="2" />
                                                        <ext:ListItem Text="Tháng 3" Value="3" />
                                                        <ext:ListItem Text="Tháng 4" Value="4" />
                                                        <ext:ListItem Text="Tháng 5" Value="5" />
                                                        <ext:ListItem Text="Tháng 6" Value="6" />
                                                        <ext:ListItem Text="Tháng 7" Value="7" />
                                                        <ext:ListItem Text="Tháng 8" Value="8" />
                                                        <ext:ListItem Text="Tháng 9" Value="9" />
                                                        <ext:ListItem Text="Tháng 10" Value="10" />
                                                        <ext:ListItem Text="Tháng 11" Value="11" />
                                                        <ext:ListItem Text="Tháng 12" Value="12" />
                                                    </Items>
                                                </ext:ComboBox>
                                                <ext:DisplayField ID="DisplayField14" runat="server" FieldLabel="Năm" Width="30"
                                                    LabelWidth="0" />
                                                <ext:SpinnerField ID="spinNamBHXH" runat="server" Width="60" MinValue="1900" MaxValue="2100" />
                                            </Items>
                                        </ext:Container>
                                        <%--<ext:TextField runat="server" ID="txtNoiCapSoBHXH" AnchorHorizontal="99%" FieldLabel="Nơi cấp sổ BHXH" />--%>
                                        <ext:ComboBox runat="server" ID="txtNoiCapSoBHXH" CtCls="requiredData" FieldLabel="Nơi cấp sổ BHXH"
                                            DisplayField="TEN" ValueField="MA" AnchorHorizontal="99%" TabIndex="50" Editable="false"
                                            ListWidth="200" ItemSelector="div.list-item">
                                            <Triggers>
                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                            </Triggers>
                                            <Template ID="Template22" runat="server">
                                                <Html>
                                                    <tpl for=".">
						                                                        <div class="list-item"> 
							                                                        {TEN}
						                                                        </div>
					                                                        </tpl>
                                                </Html>
                                            </Template>
                                            <Store>
                                                <ext:Store runat="server" ID="cbx_noicapbhxh_Store" AutoLoad="false" OnRefreshData="cbx_noicapbhxh_Store_OnRefreshData">
                                                    <Reader>
                                                        <ext:JsonReader IDProperty="MA">
                                                            <Fields>
                                                                <ext:RecordField Name="MA" />
                                                                <ext:RecordField Name="TEN" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                            <Listeners>
                                                <Expand Handler="if(cbx_noicapbhxh_Store.getCount()==0) cbx_noicapbhxh_Store.reload();" />
                                                <Select Handler="this.triggers[0].show();" />
                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                            </Listeners>
                                        </ext:ComboBox>
                                        <ext:DateField runat="server" ID="dfNgayCapSo" AnchorHorizontal="99%" FieldLabel="Ngày cấp sổ"
                                            MaskRe="/[0-9\/]/" Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/"
                                            RegexText="Định dạng ngày sinh không đúng" />
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:Container>
                        <ext:Container ID="Container19" runat="server" AnchorHorizontal="99%" AutoHeight="true"
                            Layout="HBoxLayout" Height="25">
                            <Items>
                                <ext:CompositeField ID="CompositeField6" runat="server" AnchorHorizontal="99%" FieldLabel="Thời gian đóng BHXH trước khi vào công ty<span style='color:red'>*</span>"
                                    Height="25" LabelWidth="250">
                                    <Items>
                                        <ext:TextField Width="30" MinValue="0" MaxValue="60" runat="server" ID="nfSoNamDongTruocThem"
                                            AllowBlank="false" MaskRe="/[0-9\.]/" />
                                        <ext:DisplayField ID="DisplayField15" runat="server" Text="Năm" />
                                        <ext:TextField Width="50" MaxLength="2" MinValue="0" MaxValue="12" runat="server"
                                            ID="nfSoThangDongTruocThem" AllowBlank="false" MaskRe="/[0-9\.]/" />
                                        <ext:DisplayField ID="DisplayField16" Text="Tháng" runat="server" />
                                    </Items>
                                </ext:CompositeField>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:FieldSet>
            </Items>
            <Buttons>
                <ext:Button ID="btnLuuVaThem" runat="server" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return ValidateFormThem();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnLuuThem_Click">
                            <EventMask ShowMask="true" />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="False">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnLuuVaDong" runat="server" Text="Cập nhật & đóng lại" Icon="Disk">
                    <Listeners>
                        <Click Handler="return ValidateFormThem();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnLuuThem_Click">
                            <%--<EventMask ShowMask="true" />--%>
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="True">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnDong" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdThongTinDongBHNhanVien}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="#{hdfIDNhanVienBaoHiem}.setValue('');resetFormThem();" />
            </Listeners>
        </ext:Window>
        <ext:Window runat="server" ID="wdThayDoiThongTin" Modal="true" Layout="FormLayout"
            Width="700" Padding="6" Constrain="false" Title="Sửa thông tin đóng bảo hiểm của nhân viên"
            Hidden="true" Icon="Pencil" AutoHeight="true">
            <Items>
                <ext:FormPanel ID="BasicForm" runat="server" Border="false" MonitorValid="true">
                    <Items>
                        <ext:TabPanel ID="TabPanel1" runat="server" Border="false">
                            <Items>
                                <ext:Panel ID="pnlThongTinChung" runat="server" Title="Thông tin chung">
                                    <Items>
                                        <ext:Container ID="Container8" runat="server" Layout="ColumnLayout" Height="265">
                                            <Items>
                                                <ext:Hidden runat="server" ID="hdfTrangThaiCapSoSua" />
                                                <ext:Hidden runat="server" ID="hdfNoiCapSoBHXHSua" />
                                                <ext:FieldSet ID="FieldSet3" runat="server" Title="Thông tin cũ" Layout="FormLayout"
                                                    Height="260" ColumnWidth=".5" Border="true">
                                                    <Items>
                                                        <ext:TextField runat="server" ID="txtHoTenCu" FieldLabel="Họ tên" AnchorHorizontal="99%">
                                                        </ext:TextField>
                                                        <ext:CompositeField ID="CompositeField1" runat="server" FieldLabel="Ngày sinh" AnchorHorizontal="95%">
                                                            <Items>
                                                                <ext:NumberField Width="42" MaxLength="2" MinValue="1" MaxValue="31" EmptyText="Ngày"
                                                                    runat="server" ID="nfNgayCu">
                                                                </ext:NumberField>
                                                                <ext:DisplayField ID="DisplayField6" Text="-" runat="server" />
                                                                <ext:NumberField Width="45" EmptyText="Tháng" MaxLength="2" MinValue="1" MaxValue="12"
                                                                    runat="server" ID="nfThangCu">
                                                                </ext:NumberField>
                                                                <ext:DisplayField ID="DisplayField7" Text="-" runat="server" />
                                                                <ext:NumberField Width="41" EmptyText="Năm" MinLength="4" MaxLength="4" runat="server"
                                                                    ID="nfNamCu">
                                                                </ext:NumberField>
                                                            </Items>
                                                        </ext:CompositeField>
                                                        <ext:ComboBox runat="server" ID="cbbGioiTinhCu" FieldLabel="Giới tính" AnchorHorizontal="99%">
                                                            <Items>
                                                                <ext:ListItem Text="Nữ" Value="0" />
                                                                <ext:ListItem Text="Nam" Value="1" />
                                                            </Items>
                                                        </ext:ComboBox>
                                                        <ext:TextField runat="server" ID="txtSoCMNDCu" FieldLabel="Số CMND" AnchorHorizontal="99%">
                                                        </ext:TextField>
                                                        <ext:CompositeField ID="CompositeField3" runat="server" FieldLabel="Ngày cấp CMND"
                                                            AnchorHorizontal="95%">
                                                            <Items>
                                                                <ext:NumberField Width="42" MaxLength="2" MinValue="1" MaxValue="31" EmptyText="Ngày"
                                                                    runat="server" ID="nfNgayCapCu">
                                                                </ext:NumberField>
                                                                <ext:DisplayField ID="DisplayField10" Text="-" runat="server" />
                                                                <ext:NumberField Width="45" EmptyText="Tháng" MaxLength="2" MinValue="1" MaxValue="12"
                                                                    runat="server" ID="nfThangCapCu">
                                                                </ext:NumberField>
                                                                <ext:DisplayField ID="DisplayField11" Text="-" runat="server" />
                                                                <ext:NumberField Width="41" EmptyText="Năm" MinLength="4" MaxLength="4" runat="server"
                                                                    ID="nfNamCapCu">
                                                                </ext:NumberField>
                                                            </Items>
                                                        </ext:CompositeField>
                                                        <ext:TextField runat="server" ID="cbbNoiCapCMNDCu" FieldLabel="Nơi cấp CMND" AnchorHorizontal="99%">
                                                        </ext:TextField>
                                                        <ext:TextArea runat="server" ID="txtDiaChiCu" FieldLabel="Địa chỉ" AnchorHorizontal="99%"
                                                            Height="40">
                                                        </ext:TextArea>
                                                        <ext:TextField runat="server" ID="txtNoiDangKyKCBCu" FieldLabel="Nơi đăng ký KCB"
                                                            AnchorHorizontal="99%">
                                                        </ext:TextField>
                                                    </Items>
                                                </ext:FieldSet>
                                                <ext:FieldSet ID="FieldSet4" runat="server" Title="Thông tin mới" Layout="FormLayout"
                                                    Height="260" ColumnWidth=".5" Border="true">
                                                    <Items>
                                                        <ext:TextField runat="server" ID="txtHoTenMoi" FieldLabel="Họ tên" AnchorHorizontal="99%"
                                                            TabIndex="1" EnableKeyEvents="true">
                                                            <Listeners>
                                                                <Blur Handler="ChuanHoaTen(#{txtHoTenMoi});" />
                                                                <KeyUp Handler="SinhNoiDung();" />
                                                            </Listeners>
                                                        </ext:TextField>
                                                        <ext:CompositeField ID="CompositeField2" runat="server" FieldLabel="Ngày sinh" AnchorHorizontal="95%">
                                                            <Items>
                                                                <ext:NumberField Width="42" MaxLength="2" MinValue="1" MaxValue="31" EmptyText="Ngày"
                                                                    TabIndex="2" runat="server" ID="nfNgayMoi" EnableKeyEvents="true">
                                                                    <Listeners>
                                                                        <KeyUp Handler="SinhNoiDung();" />
                                                                    </Listeners>
                                                                </ext:NumberField>
                                                                <ext:DisplayField ID="DisplayField8" Text="-" runat="server" />
                                                                <ext:NumberField Width="45" EmptyText="Tháng" MaxLength="2" MinValue="1" MaxValue="12"
                                                                    TabIndex="3" runat="server" ID="nfThangMoi" EnableKeyEvents="true">
                                                                    <Listeners>
                                                                        <KeyUp Handler="SinhNoiDung();" />
                                                                    </Listeners>
                                                                </ext:NumberField>
                                                                <ext:DisplayField ID="DisplayField9" Text="-" runat="server" />
                                                                <ext:NumberField Width="41" EmptyText="Năm" MinLength="4" MaxLength="4" runat="server"
                                                                    TabIndex="4" ID="nfNamMoi" EnableKeyEvents="true">
                                                                    <Listeners>
                                                                        <KeyUp Handler="SinhNoiDung();" />
                                                                    </Listeners>
                                                                </ext:NumberField>
                                                            </Items>
                                                        </ext:CompositeField>
                                                        <ext:ComboBox runat="server" ID="cbbGioiTinhMoi" FieldLabel="Giới tính" AnchorHorizontal="99%"
                                                            TabIndex="5" Editable="false">
                                                            <Items>
                                                                <ext:ListItem Text="Nữ" Value="0" />
                                                                <ext:ListItem Text="Nam" Value="1" />
                                                            </Items>
                                                            <Listeners>
                                                                <Select Handler="SinhNoiDung();" />
                                                            </Listeners>
                                                        </ext:ComboBox>
                                                        <ext:TextField runat="server" ID="txtSoCMNDMoi" FieldLabel="Số CMND" AnchorHorizontal="99%"
                                                            TabIndex="6" EnableKeyEvents="true">
                                                            <Listeners>
                                                                <KeyUp Handler="SinhNoiDung();" />
                                                            </Listeners>
                                                        </ext:TextField>
                                                        <ext:CompositeField ID="CompositeField4" runat="server" FieldLabel="Ngày cấp CMND"
                                                            AnchorHorizontal="95%">
                                                            <Items>
                                                                <ext:NumberField Width="42" MaxLength="2" MinValue="1" MaxValue="31" EmptyText="Ngày"
                                                                    TabIndex="7" runat="server" ID="nfNgayCapMoi" EnableKeyEvents="true">
                                                                    <Listeners>
                                                                        <KeyUp Handler="SinhNoiDung();" />
                                                                    </Listeners>
                                                                </ext:NumberField>
                                                                <ext:DisplayField ID="DisplayField12" Text="-" runat="server" />
                                                                <ext:NumberField Width="45" EmptyText="Tháng" MaxLength="2" MinValue="1" MaxValue="12"
                                                                    TabIndex="8" runat="server" ID="nfThangCapMoi" EnableKeyEvents="true">
                                                                    <Listeners>
                                                                        <KeyUp Handler="SinhNoiDung();" />
                                                                    </Listeners>
                                                                </ext:NumberField>
                                                                <ext:DisplayField ID="DisplayField13" Text="-" runat="server" />
                                                                <ext:NumberField Width="41" EmptyText="Năm" MinLength="4" MaxLength="4" runat="server"
                                                                    TabIndex="9" ID="nfNamCapMoi" EnableKeyEvents="true">
                                                                    <Listeners>
                                                                        <KeyUp Handler="SinhNoiDung();" />
                                                                    </Listeners>
                                                                </ext:NumberField>
                                                            </Items>
                                                        </ext:CompositeField>
                                                        <%--<ext:ComboBox runat="server" ID="cbbNoiCapCMNDMoi" FieldLabel="Nơi cấp CMND" DisplayField="TEN"
                                                            TabIndex="10" ValueField="MA" Editable="false" ListWidth="200" AnchorHorizontal="99%"
                                                            ItemSelector="div.list-item">
                                                            <Triggers>
                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                            </Triggers>
                                                            <Store>
                                                                <ext:Store runat="server" ID="cbx_noicapcmnd_Store" AutoLoad="false" OnRefreshData="cbx_noicapcmnd_Store_OnRefreshData">
                                                                    <Reader>
                                                                        <ext:JsonReader IDProperty="MA">
                                                                            <Fields>
                                                                                <ext:RecordField Name="MA" />
                                                                                <ext:RecordField Name="TEN" />
                                                                            </Fields>
                                                                        </ext:JsonReader>
                                                                    </Reader>
                                                                </ext:Store>
                                                            </Store>
                                                            <Template ID="Template2" runat="server">
                                                                <Html>
                                                                    <tpl for=".">
						                                                <div class="list-item"> 
							                                                {TEN}
						                                                </div>
					                                                </tpl>
                                                                </Html>
                                                            </Template>
                                                            <Listeners>
                                                                <Expand Handler="if(cbbNoiCapCMNDMoi.store.getCount()==0) cbx_noicapcmnd_Store.reload();" />
                                                                <Select Handler="this.triggers[0].show();SinhNoiDung();" />
                                                                <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                                                            </Listeners>
                                                        </ext:ComboBox>--%>
                                                        <ext:ComboBox runat="server" ID="cbbNoiCapCMNDMoi" FieldLabel="Nơi cấp CMND" DisplayField="TEN"
                                                            ValueField="MA" AnchorHorizontal="98%" TabIndex="58" Editable="true" ListWidth="200"
                                                            MinChars="1" ItemSelector="div.list-item" PageSize="15" LoadingText="Đang tải dữ liệu..."
                                                            EmptyText="Gõ để tìm kiếm">
                                                            <Triggers>
                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                            </Triggers>
                                                            <Template ID="Template25" runat="server">
                                                                <Html>
                                                                    <tpl for=".">
						                                                        <div class="list-item"> 
							                                                        {TEN}
						                                                        </div>
					                                                        </tpl>
                                                                </Html>
                                                            </Template>
                                                            <Store>
                                                                <ext:Store ID="cbx_noicapcmnd_Store" runat="server" AutoLoad="false">
                                                                    <Proxy>
                                                                        <ext:HttpProxy Method="POST" Url="../../HoSoNhanSu/SearchDanhMucHandler.ashx" />
                                                                    </Proxy>
                                                                    <BaseParams>
                                                                        <ext:Parameter Name="table" Value="DM_NOICAP_CMND" Mode="Value" />
                                                                        <ext:Parameter Name="ma" Value="MA_NOICAP_CMND" Mode="Value" />
                                                                        <ext:Parameter Name="ten" Value="TEN_NOICAP_CMND" Mode="Value" />
                                                                    </BaseParams>
                                                                    <Reader>
                                                                        <ext:JsonReader Root="plants" TotalProperty="total">
                                                                            <Fields>
                                                                                <ext:RecordField Name="MA" />
                                                                                <ext:RecordField Name="TEN" />
                                                                            </Fields>
                                                                        </ext:JsonReader>
                                                                    </Reader>
                                                                </ext:Store>
                                                            </Store>
                                                            <ToolTips>
                                                                <ext:ToolTip runat="server" ID="ToolTip4" Title="Hướng dẫn" Html="Nhập tên nơi cấp CMND để tìm kiếm. Nhập <span style='color:red;'>*</span> nếu muốn tìm tất cả." />
                                                            </ToolTips>
                                                            <Listeners>
                                                                <Expand Handler="cbx_noicapcmnd_Store.reload();" />
                                                                <Select Handler="this.triggers[0].show(); SinhNoiDung();" />
                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                            </Listeners>
                                                        </ext:ComboBox>
                                                        <ext:TextArea runat="server" ID="txtDiaChiMoi" FieldLabel="Địa chỉ" AnchorHorizontal="99%"
                                                            TabIndex="11" Height="40" EnableKeyEvents="true">
                                                            <Listeners>
                                                                <KeyUp Handler="SinhNoiDung();" />
                                                            </Listeners>
                                                        </ext:TextArea>
                                                        <ext:Hidden runat="server" ID="hdfNoiDungKyKCBMoi" />
                                                        <ext:ComboBox runat="server" ID="txtNoiDangKyKCBMoi" FieldLabel="Nơi đăng ký KCB"
                                                            DisplayField="TEN" ValueField="MA" AnchorHorizontal="99%" Editable="false" ListWidth="200"
                                                            TabIndex="12" ItemSelector="div.list-item" StoreID="cbx_noikcb_Store">
                                                            <Triggers>
                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                            </Triggers>
                                                            <Template ID="Template23" runat="server">
                                                                <Html>
                                                                    <tpl for=".">
						                                                        <div class="list-item"> 
							                                                        {TEN}
						                                                        </div>
					                                                        </tpl>
                                                                </Html>
                                                            </Template>
                                                            <Listeners>
                                                                <Expand Handler="if(this.store.getCount()==0) cbx_noikcb_Store.reload();" />
                                                                <Select Handler="this.triggers[0].show();SinhNoiDung(); hdfNoiDungKyKCBMoi.setValue(txtNoiDangKyKCBMoi.getValue());" />
                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();SinhNoiDung(); hdfNoiDungKyKCBMoi.reset();}" />
                                                            </Listeners>
                                                        </ext:ComboBox>
                                                    </Items>
                                                </ext:FieldSet>
                                            </Items>
                                        </ext:Container>
                                        <ext:FieldSet ID="FieldSet7" runat="server" Title="Nội dung thay đổi" Layout="FormLayout"
                                            AutoHeight="true" Border="true">
                                            <Items>
                                                <ext:TextArea runat="server" ID="txtNoiDungThayDoi" Grow="true" GrowMax="60" GrowMin="40"
                                                    TabIndex="13" AnchorHorizontal="99%">
                                                </ext:TextArea>
                                            </Items>
                                        </ext:FieldSet>
                                    </Items>
                                </ext:Panel>
                                <ext:Panel ID="Panel3" runat="server" Title="Thông tin lương, sổ, thẻ">
                                    <Items>
                                        <ext:FieldSet runat="server" Title="Thông tin lương" Layout="ColumnLayout" Height="105">
                                            <Items>
                                                <ext:Container runat="server" ColumnWidth=".5" Layout="FormLayout">
                                                    <Items>
                                                        <ext:NumberField runat="server" ID="txtLuongBaoHiemSua" FieldLabel="Lương bảo hiểm"
                                                            AllowNegative="false" AllowDecimals="false" MaxLength="12" MaskRe="/[0-9]/" AnchorHorizontal="99%">
                                                        </ext:NumberField>
                                                        <ext:NumberField runat="server" ID="txtPhuCapCVSua" FieldLabel="Phụ cấp chức vụ"
                                                            AnchorHorizontal="99%" AllowNegative="false" MaxLength="12">
                                                        </ext:NumberField>
                                                        <ext:NumberField runat="server" ID="txtPhuCapTNVKSua" FieldLabel="Phụ cấp TNVK" AnchorHorizontal="99%"
                                                            AllowNegative="false" MaxLength="12">
                                                        </ext:NumberField>
                                                    </Items>
                                                </ext:Container>
                                                <ext:Container runat="server" ColumnWidth=".5" LabelWidth="105" Layout="FormLayout">
                                                    <Items>
                                                        <ext:NumberField runat="server" ID="txtPhuCapTNNgheSua" FieldLabel="Phụ cấp TN Nghề"
                                                            AllowNegative="false" MaxLength="12" AnchorHorizontal="99%">
                                                        </ext:NumberField>
                                                        <ext:NumberField runat="server" ID="txtPhuCapKhacSua" FieldLabel="Phụ cấp khác" AnchorHorizontal="99%"
                                                            AllowNegative="false" MaxLength="12">
                                                        </ext:NumberField>
                                                        <ext:CompositeField runat="server" AnchorHorizontal="99%" FieldLabel="Đang đóng">
                                                            <Items>
                                                                <ext:Checkbox runat="server" ID="chkDongBHXH" BoxLabel="BHXH">
                                                                </ext:Checkbox>
                                                                <ext:Checkbox runat="server" ID="chkDongBHYT" BoxLabel="BHYT">
                                                                </ext:Checkbox>
                                                                <ext:Checkbox runat="server" ID="chkDongBHTN" BoxLabel="BHTN">
                                                                </ext:Checkbox>
                                                            </Items>
                                                        </ext:CompositeField>
                                                    </Items>
                                                </ext:Container>
                                            </Items>
                                        </ext:FieldSet>
                                        <ext:FieldSet ID="FieldSet5" runat="server" Title="BHYT" Layout="ColumnLayout" Height="80"
                                            Border="true">
                                            <Items>
                                                <ext:Container ID="Container9" runat="server" ColumnWidth=".5" Layout="FormLayout">
                                                    <Items>
                                                        <ext:ComboBox runat="server" ID="cboTrangThaiCapThe" FieldLabel="Trạng thái thẻ<span style='color:red'>*</span>"
                                                            CtCls="requiredData" LabelSeparator="" EmptyText="Trạng thái cấp thẻ" Editable="false"
                                                            AnchorHorizontal="99%">
                                                            <Items>
                                                                <ext:ListItem Value="ChuaCapThe" Text="Chưa cấp thẻ" />
                                                                <ext:ListItem Value="DaCapThe" Text="Đã cấp thẻ" />
                                                                <ext:ListItem Value="DaTraThe" Text="Đã trả thẻ" />
                                                                <ext:ListItem Value="DaNopThe" Text="Đã nộp thẻ" />
                                                                <ext:ListItem Value="ChuaNopThe" Text="Chưa nộp thẻ" />
                                                            </Items>
                                                            <Listeners>
                                                                <Select Handler="if(cboTrangThaiCapThe.getValue()=='ChuaCapThe') txtSoTheBHYTSua.setValue();" />
                                                            </Listeners>
                                                        </ext:ComboBox>
                                                        <ext:Container ID="Container10" runat="server" Layout="HBoxLayout" Height="25">
                                                            <Items>
                                                                <ext:ComboBox runat="server" FieldLabel="Từ tháng<span style='color:red'>*</span>"
                                                                    LabelWidth="100" Editable="false" EmptyText="Tháng" ID="cbbTuThangBHYTSua" Width="190">
                                                                    <Items>
                                                                        <ext:ListItem Text="Tháng 1" Value="1" />
                                                                        <ext:ListItem Text="Tháng 2" Value="2" />
                                                                        <ext:ListItem Text="Tháng 3" Value="3" />
                                                                        <ext:ListItem Text="Tháng 4" Value="4" />
                                                                        <ext:ListItem Text="Tháng 5" Value="5" />
                                                                        <ext:ListItem Text="Tháng 6" Value="6" />
                                                                        <ext:ListItem Text="Tháng 7" Value="7" />
                                                                        <ext:ListItem Text="Tháng 8" Value="8" />
                                                                        <ext:ListItem Text="Tháng 9" Value="9" />
                                                                        <ext:ListItem Text="Tháng 10" Value="10" />
                                                                        <ext:ListItem Text="Tháng 11" Value="11" />
                                                                        <ext:ListItem Text="Tháng 12" Value="12" />
                                                                    </Items>
                                                                </ext:ComboBox>
                                                                <ext:DisplayField ID="DisplayField3" runat="server" FieldLabel="Năm" Width="50" LabelWidth="0"
                                                                    LabelAlign="Right">
                                                                </ext:DisplayField>
                                                                <ext:SpinnerField ID="spinTuNamBHYTSua" runat="server" Width="80" MinValue="1900"
                                                                    MaxValue="2100">
                                                                </ext:SpinnerField>
                                                            </Items>
                                                        </ext:Container>
                                                    </Items>
                                                </ext:Container>
                                                <ext:Container ID="Container11" runat="server" ColumnWidth=".5" Layout="FormLayout">
                                                    <Items>
                                                        <ext:TextField runat="server" ID="txtSoTheBHYTSua" AnchorHorizontal="99%" FieldLabel="Số thẻ BHYT"
                                                            LabelAlign="Right">
                                                        </ext:TextField>
                                                        <ext:Container ID="Container12" runat="server" Layout="HBoxLayout">
                                                            <Items>
                                                                <ext:ComboBox runat="server" FieldLabel="Đến tháng" LabelWidth="100" Editable="false"
                                                                    LabelAlign="Right" ID="cbbDenThangBHYTSua" Width="190">
                                                                    <Items>
                                                                        <ext:ListItem Text="Tháng 1" Value="1" />
                                                                        <ext:ListItem Text="Tháng 2" Value="2" />
                                                                        <ext:ListItem Text="Tháng 3" Value="3" />
                                                                        <ext:ListItem Text="Tháng 4" Value="4" />
                                                                        <ext:ListItem Text="Tháng 5" Value="5" />
                                                                        <ext:ListItem Text="Tháng 6" Value="6" />
                                                                        <ext:ListItem Text="Tháng 7" Value="7" />
                                                                        <ext:ListItem Text="Tháng 8" Value="8" />
                                                                        <ext:ListItem Text="Tháng 9" Value="9" />
                                                                        <ext:ListItem Text="Tháng 10" Value="10" />
                                                                        <ext:ListItem Text="Tháng 11" Value="11" />
                                                                        <ext:ListItem Text="Tháng 12" Value="12" />
                                                                    </Items>
                                                                </ext:ComboBox>
                                                                <ext:DisplayField ID="DisplayField4" runat="server" FieldLabel="Năm" Width="50" LabelWidth="0"
                                                                    LabelAlign="Right">
                                                                </ext:DisplayField>
                                                                <ext:SpinnerField ID="spinDenNamBHYTSua" runat="server" Width="80" MinValue="1900"
                                                                    MaxValue="2100">
                                                                </ext:SpinnerField>
                                                            </Items>
                                                        </ext:Container>
                                                    </Items>
                                                </ext:Container>
                                            </Items>
                                        </ext:FieldSet>
                                        <ext:FieldSet ID="FieldSet6" runat="server" Title="BHXH" Height="130" Layout="FormLayout"
                                            Border="true">
                                            <Items>
                                                <ext:Container ID="Container13" runat="server" Layout="ColumnLayout" Height="80">
                                                    <Items>
                                                        <ext:Container ID="Container14" runat="server" AutoHeight="true" ColumnWidth=".5"
                                                            Layout="FormLayout">
                                                            <Items>
                                                                <ext:Checkbox runat="server" ID="chkDaDangKyCQBHSua" FieldLabel="Trạng thái<span style='color:red'>*</span>"
                                                                    AnchorHorizontal="99%" BoxLabel="Đã đăng ký với cơ quan bảo hiểm">
                                                                </ext:Checkbox>
                                                                <ext:ComboBox runat="server" ID="cbbTrangThaiCapSoSua" AnchorHorizontal="99%" FieldLabel="Trạng thái sổ"
                                                                    CtCls="requiredData" EmptyText="Trạng thái cấp sổ" Editable="false">
                                                                    <Items>
                                                                        <ext:ListItem Text="Chưa cấp sổ" Value="ChuaCapSo" />
                                                                        <ext:ListItem Text="Đã cấp sổ" Value="DaCapSo" />
                                                                        <ext:ListItem Text="Đã trả sổ" Value="DaTraSo" />
                                                                        <ext:ListItem Text="Đã nộp sổ" Value="DaNopSo" />
                                                                        <ext:ListItem Text="Chưa nộp sổ" Value="ChuaNopSo" />
                                                                    </Items>
                                                                    <Listeners>
                                                                        <Select Handler="hdfTrangThaiCapSoSua.setValue(cbbTrangThaiCapSoSua.getValue());  
                                                                                        if(hdfTrangThaiCapSoSua.getValue()=='ChuaCapSo') txtNoiCapSoBHXHSua.reset(); hdfNoiCapSoBHXHSua.reset();" />
                                                                    </Listeners>
                                                                </ext:ComboBox>
                                                                <ext:TextField runat="server" ID="txtSoSoBHXHSua" AnchorHorizontal="99%" FieldLabel="Số Sổ BHXH">
                                                                </ext:TextField>
                                                            </Items>
                                                        </ext:Container>
                                                        <ext:Container ID="Container15" runat="server" AutoHeight="true" ColumnWidth=".5"
                                                            Layout="FormLayout">
                                                            <Items>
                                                                <ext:Container ID="Container18" runat="server" Layout="HBoxLayout" Height="25">
                                                                    <Items>
                                                                        <ext:ComboBox runat="server" FieldLabel="Tháng đăng ký" LabelWidth="100" Editable="false"
                                                                            ID="cbbThangDangKyBHXHSua" Width="190">
                                                                            <Items>
                                                                                <ext:ListItem Text="Tháng 1" Value="1" />
                                                                                <ext:ListItem Text="Tháng 2" Value="2" />
                                                                                <ext:ListItem Text="Tháng 3" Value="3" />
                                                                                <ext:ListItem Text="Tháng 4" Value="4" />
                                                                                <ext:ListItem Text="Tháng 5" Value="5" />
                                                                                <ext:ListItem Text="Tháng 6" Value="6" />
                                                                                <ext:ListItem Text="Tháng 7" Value="7" />
                                                                                <ext:ListItem Text="Tháng 8" Value="8" />
                                                                                <ext:ListItem Text="Tháng 9" Value="9" />
                                                                                <ext:ListItem Text="Tháng 10" Value="10" />
                                                                                <ext:ListItem Text="Tháng 11" Value="11" />
                                                                                <ext:ListItem Text="Tháng 12" Value="12" />
                                                                            </Items>
                                                                        </ext:ComboBox>
                                                                        <ext:DisplayField ID="DisplayField5" runat="server" FieldLabel="Năm" Width="30" LabelWidth="0">
                                                                        </ext:DisplayField>
                                                                        <ext:SpinnerField ID="spinNamDangKyBHXHSua" runat="server" Width="60" MinValue="1900"
                                                                            MaxValue="2100">
                                                                        </ext:SpinnerField>
                                                                    </Items>
                                                                </ext:Container>
                                                                <%--<ext:TextField runat="server" ID="txtNoiCapSoBHXHSua" AnchorHorizontal="99%" FieldLabel="Nơi cấp sổ BHXH">
                                                                    </ext:TextField>--%>
                                                                <ext:ComboBox runat="server" ID="txtNoiCapSoBHXHSua" CtCls="requiredData" FieldLabel="Nơi cấp sổ BHXH"
                                                                    DisplayField="TEN" ValueField="MA" AnchorHorizontal="99%" Editable="false" ListWidth="200"
                                                                    ItemSelector="div.list-item">
                                                                    <Triggers>
                                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                    </Triggers>
                                                                    <Template ID="Template1" runat="server">
                                                                        <Html>
                                                                            <tpl for=".">
						                                                        <div class="list-item"> 
							                                                        {TEN}
						                                                        </div>
					                                                        </tpl>
                                                                        </Html>
                                                                    </Template>
                                                                    <Store>
                                                                        <ext:Store runat="server" ID="Store1" AutoLoad="false" OnRefreshData="txtNoiCapSoBHXHSua_Store_OnRefreshData">
                                                                            <Reader>
                                                                                <ext:JsonReader IDProperty="MA">
                                                                                    <Fields>
                                                                                        <ext:RecordField Name="MA" />
                                                                                        <ext:RecordField Name="TEN" />
                                                                                    </Fields>
                                                                                </ext:JsonReader>
                                                                            </Reader>
                                                                        </ext:Store>
                                                                    </Store>
                                                                    <Listeners>
                                                                        <Expand Handler="Store1.reload();" />
                                                                        <Select Handler="this.triggers[0].show(); hdfNoiCapSoBHXHSua.setValue(txtNoiCapSoBHXHSua.getValue());" />
                                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();hdfNoiCapSoBHXHSua.reset(); }" />
                                                                    </Listeners>
                                                                </ext:ComboBox>
                                                                <ext:DateField runat="server" ID="dfNgayCapSoBHXHSua" AnchorHorizontal="99%" FieldLabel="Ngày cấp sổ"
                                                                    MaskRe="/[0-9\/]/" Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/"
                                                                    RegexText="Định dạng ngày sinh không đúng">
                                                                </ext:DateField>
                                                            </Items>
                                                        </ext:Container>
                                                    </Items>
                                                </ext:Container>
                                                <ext:Container ID="Container20" runat="server" AnchorHorizontal="99%" AutoHeight="true"
                                                    Layout="HBoxLayout" Height="25">
                                                    <Items>
                                                        <ext:CompositeField ID="CompositeField5" runat="server" AnchorHorizontal="99%" FieldLabel="Thời gian đóng BHXH trước khi vào công ty"
                                                            Height="25" LabelWidth="278">
                                                            <Items>
                                                                <ext:NumberField Width="41" MinValue="0" MaxValue="60" runat="server" ID="nfSoNamDongTruocSua"
                                                                    MaxLength="3" AllowBlank="false">
                                                                </ext:NumberField>
                                                                <ext:DisplayField ID="DisplayField17" runat="server" Text="Năm">
                                                                </ext:DisplayField>
                                                                <ext:NumberField Width="60" MaxLength="2" MinValue="0" MaxValue="12" runat="server"
                                                                    ID="nfSoThangDongTruocSua" AllowBlank="false">
                                                                </ext:NumberField>
                                                                <ext:DisplayField ID="DisplayField18" Text="Tháng" runat="server">
                                                                </ext:DisplayField>
                                                            </Items>
                                                        </ext:CompositeField>
                                                    </Items>
                                                </ext:Container>
                                            </Items>
                                        </ext:FieldSet>
                                    </Items>
                                </ext:Panel>
                            </Items>
                        </ext:TabPanel>
                    </Items>
                    <Listeners>
                        <ClientValidation Handler="#{btnLuuSuaThongTin}.setDisabled(!valid);" />
                    </Listeners>
                </ext:FormPanel>
            </Items>
            <Buttons>
                <ext:Button ID="btnInToKhaiSua" runat="server" Text="In tờ khai" Icon="Script">
                    <Listeners>
                        <Click Handler="Ext.net.DirectMethods.GetThongTinMoi(); #{wdShowDonDeNghi}.show();" />
                    </Listeners>
                </ext:Button>
                <ext:Button ID="btnLuuSuaThongTin" runat="server" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return ValidateFormSua();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnSuaThongTin_Click">
                            <EventMask ShowMask="true" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="Button8" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdThayDoiThongTin}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="resetFormSua();" />
            </Listeners>
        </ext:Window>
        <%--   <uc2:ImportExcelFile ID="ImportExcelFile1" runat="server" ExcelStoreFolder="../BaoHiem/FileUpload"
            ExcelTemplateUrl="../BaoHiem/FileMauExcel/Mau_ThongTinNhanVienBaoHiem.xls" MathRuleXmlUrl="../BaoHiem/BaoHiemMathRule.xml"
            MaxRecord="1000" PrimaryKeyName="IDNhanVien_BaoHiem" PrKeyIsAutoIncrement="true"
            ListCategoriesTableName="" DeleteExcelAfterInsert="true" TableName="BHNHANVIEN_BAOHIEM" />--%>
        <uc1:ImportExcelFile runat="server" ID="ImportExcelFile1" ExcelStoreFolder="../../BaoHiem/FileUpload"
            ExcelTemplateUrl="../../BaoHiem/FileMauExcel/Mau_ThongTinNhanVienBaoHiem.xls"
            MathRuleXmlUrl="../../BaoHiem/BaoHiemMathRule.xml" MaxRecord="1000" PrimaryKeyName="IDNhanVien_BaoHiem"
            PrKeyIsAutoIncrement="true" ListCategoriesTableName="" DeleteExcelAfterInsert="true"
            TableName="BHNHANVIEN_BAOHIEM" />
        <ext:Viewport runat="server" ID="vp">
            <Items>
                <ext:BorderLayout runat="server" ID="br">
                    <Center>
                        <ext:Panel ID="Panel2" Height="200" runat="server" Border="false" AnchorVertical="100%"
                            Layout="BorderLayout">
                            <Items>
                                <ext:GridPanel runat="server" ID="grpQuanLyThongTinBaoHiem" StoreID="grpQuanLyThongTinBaoHiem_store"
                                    Border="false" Region="Center" AutoExpandColumn="colTenCanBo" AutoExpandMin="150">
                                    <TopBar>
                                        <ext:Toolbar ID="Toolbar2" runat="server">
                                            <Items>
                                                <ext:Button runat="server" ID="btnThem" Icon="Add" Text="Thêm">
                                                    <Listeners>
                                                        <Click Handler="resetFormThem();wdThongTinDongBHNhanVien.show();" />
                                                    </Listeners>
                                                </ext:Button>
                                                <ext:Button runat="server" ID="btnSua" Icon="Pencil" Text="Sửa" Disabled="true">
                                                    <Listeners>
                                                        <Click Handler="cbx_noicapcmnd_Store.reload();SuaThongTinNhanVienBaoHiem(grpQuanLyThongTinBaoHiem,grpQuanLyThongTinBaoHiem_store);" />
                                                    </Listeners>
                                                </ext:Button>
                                                <ext:Button runat="server" ID="btnXoa" Icon="Delete" Text="Xóa" Disabled="true">
                                                    <Listeners>
                                                        <Click Handler="return CheckSelectedRow(grpQuanLyThongTinBaoHiem);" />
                                                    </Listeners>
                                                    <DirectEvents>
                                                        <Click OnEvent="btnXoa_Click">
                                                            <Confirmation Title="Thông báo từ hệ thống" Message="Bạn có chắc chắn muốn xóa?"
                                                                ConfirmRequest="true" />
                                                            <EventMask ShowMask="true" />
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:Button>
                                                <ext:ToolbarSeparator>
                                                </ext:ToolbarSeparator>
                                                <%--  <ext:Button runat="server" ID="btnBienDong" Icon="ArrowRefresh" Text="Biến động">
                                                </ext:Button>
                                                <ext:Button runat="server" ID="btnDangKy" Icon="Key" Text="Đăng ký">
                                                </ext:Button>--%>
                                                <ext:Button runat="server" ID="btnToKhai" Icon="Script" Text="Tờ khai" Disabled="true">
                                                    <Listeners>
                                                        <Click Handler=" return checktokhai(); " />
                                                    </Listeners>
                                                </ext:Button>
                                                <%--  <ext:Button runat="server" ID="btnImport" Icon="PageExcel" Text="Nhập từ Excel">
                                                        <Listeners>
                                                            <Click Handler="ImportExcelFile1_wdImportDataFromExcel.show();" />
                                                        </Listeners>
                                                    </ext:Button>
                                                    <ext:Button runat="server" ID="btnExport" Icon="PageExcel" Text="Xuất ra Excel">
                                                    </ext:Button>--%>
                                                <ext:ToolbarFill runat="server" ID="tbfill" />
                                                <ext:TriggerField runat="server" Width="250" EnableKeyEvents="true" EmptyText="Tìm kiếm theo mã, tên, số sổ, số thẻ"
                                                    ID="txtSearchKey">
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Listeners>
                                                        <KeyPress Fn="keyEnterPress" />
                                                        <TriggerClick Handler="this.clear(); this.triggers[0].hide(); PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad();" />
                                                    </Listeners>
                                                </ext:TriggerField>
                                                <ext:Button Text="Tìm kiếm" Icon="Zoom" runat="server" ID="btnSearch">
                                                    <Listeners>
                                                        <Click Handler=" PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad(); #{grpQuanLyThongTinBaoHiem}.reload();" />
                                                    </Listeners>
                                                </ext:Button>
                                            </Items>
                                        </ext:Toolbar>
                                    </TopBar>
                                    <ColumnModel ID="ColumnModel1" runat="server">
                                        <Columns>
                                            <ext:RowNumbererColumn Header="STT" Width="35" />
                                            <ext:Column ColumnID="colMaCanBo" Width="90" DataIndex="MaNhanVien" Header="Mã cán bộ"
                                                Locked="true">
                                            </ext:Column>
                                            <ext:Column ColumnID="colTenCanBo" Width="200" DataIndex="HoTen" Header="Họ tên"
                                                Locked="true">
                                            </ext:Column>
                                            <ext:Column ColumnID="colTenPhongBan" Width="200" DataIndex="PhongBan" Header="Bộ phận"
                                                Locked="true">
                                            </ext:Column>
                                            <ext:Column ColumnID="colLuongBaoHiem" Width="105" DataIndex="LuongBaoHiem" Header="Lương bảo hiểm"
                                                Align="Right">
                                                <Renderer Fn="RenderVND" />
                                            </ext:Column>
                                            <ext:Column ColumnID="colPhuCapChucVu" Width="80" DataIndex="PhuCapCV" Header="Phụ cấp chức vụ"
                                                Align="Right">
                                                <Renderer Fn="RenderVND" />
                                            </ext:Column>
                                            <ext:Column ColumnID="colPhuCapTNVuotKhung" Width="90" DataIndex="PhuCapVuotKhung"
                                                Header="Phụ cấp TN vượt khung" Align="Right">
                                                <Renderer Fn="RenderVND" />
                                            </ext:Column>
                                            <ext:Column ColumnID="colPhuCapTNNghe" Width="90" DataIndex="PhuCapNghe" Header="Phụ cấp TN nghề"
                                                Align="Right">
                                                <Renderer Fn="RenderVND" />
                                            </ext:Column>
                                            <ext:Column ColumnID="colPhuCapKhac" Width="90" DataIndex="PhuCapKhac" Header="Phụ cấp khác"
                                                Align="Right">
                                                <Renderer Fn="RenderVND" />
                                            </ext:Column>
                                            <ext:DateColumn ColumnID="colNgayHieuLuc" Width="95" DataIndex="NgayDangKyBHXH" Header="Ngày đăng ký BHXH"
                                                Format="MM/yyyy" Align="Center">
                                            </ext:DateColumn>
                                            <ext:Column ColumnID="colSoSoBHXH" Width="95" Header="Số sổ BHXH" DataIndex="SoSoBHXH"
                                                Align="Left">
                                            </ext:Column>
                                            <ext:Column ColumnID="colThoiGianDong" Width="100" Header="Thời gian đóng BHXH (tháng)"
                                                DataIndex="ThoiGianDongBaoHiem" Align="Right">
                                                <Renderer Fn="RenderSoNam" />
                                            </ext:Column>
                                            <ext:CheckColumn ColumnID="colBHXH" Width="50" Header="BHXH" DataIndex="DangDongBHXH">
                                            </ext:CheckColumn>
                                            <ext:CheckColumn ColumnID="colBHYT" Width="50" Header="BHYT" DataIndex="DangDongBHYT">
                                            </ext:CheckColumn>
                                            <ext:CheckColumn ColumnID="colBHTN" Width="50" Header="BHTN" DataIndex="DangDongBHTN">
                                            </ext:CheckColumn>
                                            <ext:Column ColumnID="colSoTheBHYT" Width="100" Header="Số thẻ BHYT" DataIndex="SoTheBHYT"
                                                Align="Left">
                                            </ext:Column>
                                            <ext:DateColumn ColumnID="colTuThang" Width="85" DataIndex="TuThangBHYT" Header="BHYT từ tháng"
                                                Format="MM/yyyy" Align="Center">
                                            </ext:DateColumn>
                                            <ext:DateColumn ColumnID="colDenThang" Width="85" DataIndex="DenThangBHYT" Header="BHYT đến tháng"
                                                Format="MM/yyyy" Align="Center">
                                            </ext:DateColumn>
                                            <ext:CheckColumn ColumnID="colTrangThaiDangKyCQBH" Width="100" DataIndex="BHXHTrangThaiDangKyCQBH"
                                                Header="Đã đăng ký với CQBH" Align="Center">
                                            </ext:CheckColumn>
                                            <ext:Column Header="Nơi cấp sổ BHXH" DataIndex="NoiCapBHXH" Align="Left" Width="100" />
                                            <ext:Column ColumnID="colTrangThai" Width="150" DataIndex="TrangThai" Header="Trạng thái" />
                                        </Columns>
                                    </ColumnModel>
                                    <SelectionModel>
                                        <ext:RowSelectionModel ID="checkboxSelection" runat="server">
                                            <Listeners>
                                                <RowSelect Handler="#{btnXoa}.enable();#{btnSua}.enable();#{btnToKhai}.enable(); GetIdToKhaiNhanVienBaoHiem(grpQuanLyThongTinBaoHiem,grpQuanLyThongTinBaoHiem_store);" />
                                                <RowDeselect Handler="#{btnSua}.disable();#{btnToKhai}.disable(); hdfIDNhanVienBaoHiem.reset();" />
                                            </Listeners>
                                        </ext:RowSelectionModel>
                                    </SelectionModel>
                                    <View>
                                        <ext:GroupingView ID="GroupingView1" runat="server" MarkDirty="false" ShowGroupName="false"
                                            EnableNoGroups="true" HideGroupedColumn="true">
                                            <%--<HeaderRows>
                                                    <ext:HeaderRow>
                                                        <Columns>
                                                            <ext:HeaderColumn AutoWidthElement="false">
                                                                <Component>
                                                                    <ext:TextField ID="filterMaCanBo" AutoWidth="true" runat="server">
                                                                        <Listeners>
                                                                            <KeyPress Fn="enterKeyPressHandler1" />
                                                                        </Listeners>
                                                                    </ext:TextField>
                                                                </Component>
                                                            </ext:HeaderColumn>
                                                            <ext:HeaderColumn AutoWidthElement="false">
                                                                <Component>
                                                                    <ext:TextField ID="filterTenCanBo" AutoWidth="true" runat="server">
                                                                        <Listeners>
                                                                            <KeyPress Fn="enterKeyPressHandler1" />
                                                                        </Listeners>
                                                                    </ext:TextField>
                                                                </Component>
                                                            </ext:HeaderColumn>
                                                            <ext:HeaderColumn AutoWidthElement="false">
                                                                <Component>
                                                                    <ext:ComboBox runat="server" ID="filterLuongBaoHiem" DisplayField="TenLuongBaoHiem" ValueField="MaLuongBaoHiem"
                                                                        AutoWidth="true" Editable="false" StoreID="filterLuongBaoHiem_Store" ListWidth="150">
                                                                        <Triggers>
                                                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                        </Triggers>
                                                                        <Listeners>
                                                                            <Expand Handler="if(filterLuongBaoHiem.store.getCount()==0 filterLuongBaoHiem_Store.reload();" />
                                                                            <Select Handler="this.triggers[0].show(); "
                                                                        </Listeners>
                                                                    </ext:ComboBox>
                                                                </Component>
                                                            </ext:HeaderColumn>
                                                            <ext:HeaderColumn AutoWidthElement="false">
                                                            </ext:HeaderColumn>
                                                            <ext:HeaderColumn AutoWidthElement="false">
                                                            </ext:HeaderColumn>
                                                            <ext:HeaderColumn AutoWidthElement="false">
                                                            </ext:HeaderColumn>
                                                            <ext:HeaderColumn AutoWidthElement="false">
                                                            </ext:HeaderColumn>
                                                            <ext:HeaderColumn AutoWidthElement="false">
                                                            </ext:HeaderColumn>
                                                            <ext:HeaderColumn AutoWidthElement="false">
                                                            </ext:HeaderColumn>
                                                            <ext:HeaderColumn AutoWidthElement="false">
                                                            </ext:HeaderColumn>
                                                            <ext:HeaderColumn AutoWidthElement="false">
                                                            </ext:HeaderColumn>
                                                            <ext:HeaderColumn AutoWidthElement="false">
                                                            </ext:HeaderColumn>
                                                            <ext:HeaderColumn AutoWidthElement="false">
                                                            </ext:HeaderColumn>
                                                        </Columns>
                                                    </ext:HeaderRow>
                                                </HeaderRows>--%>
                                        </ext:GroupingView>
                                    </View>
                                    <BottomBar>
                                        <ext:PagingToolbar ID="PagingToolbar1" EmptyMsg="Hiện không có dữ liệu" NextText="Trang sau"
                                            PageSize="15" PrevText="Trang trước" LastText="Trang cuối cùng" FirstText="Trang đầu tiên"
                                            DisplayMsg="Dòng {0} đến dòng {1} / {2} dòng" runat="server">
                                            <Items>
                                                <ext:Label ID="Label1" runat="server" Text="Số bản ghi trên 1 trang:" />
                                                <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                                <ext:ComboBox ID="ComboBoxPaging" runat="server" Width="80">
                                                    <Items>
                                                        <ext:ListItem Text="15" />
                                                        <ext:ListItem Text="30" />
                                                        <ext:ListItem Text="50" />
                                                        <ext:ListItem Text="70" />
                                                        <ext:ListItem Text="100" />
                                                    </Items>
                                                    <Listeners>
                                                        <Select Handler="#{PagingToolbar1}.pageSize = parseInt(this.getValue()); #{PagingToolbar1}.doLoad();" />
                                                    </Listeners>
                                                    <SelectedItem Value="15" />
                                                </ext:ComboBox>
                                            </Items>
                                        </ext:PagingToolbar>
                                    </BottomBar>
                                    <LoadMask ShowMask="true" />
                                    <Listeners>
                                        <RowDblClick Handler="cbx_noicapcmnd_Store.reload();SuaThongTinNhanVienBaoHiem(grpQuanLyThongTinBaoHiem,grpQuanLyThongTinBaoHiem_store);" />
                                        <RowContextMenu Handler="e.preventDefault(); #{RowContextMenu}.dataRecord = this.store.getAt(rowIndex);#{RowContextMenu}.showAt(e.getXY());#{grpQuanLyThongTinBaoHiem}.getSelectionModel().selectRow(rowIndex);" />
                                    </Listeners>
                                </ext:GridPanel>
                            </Items>
                        </ext:Panel>
                    </Center>
                </ext:BorderLayout>
            </Items>
        </ext:Viewport>
    </div>
    </form>
</body>
</html>
