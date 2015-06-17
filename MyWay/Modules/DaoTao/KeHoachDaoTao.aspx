<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KeHoachDaoTao.aspx.cs" Inherits="Modules_DaoTao_KeHoachDaoTao" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register Src="../ChooseEmployee/ucChooseEmployee.ascx" TagName="ucChooseEmployee"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../Resource/js/RenderJS.js" type="text/javascript"></script>
    <style type="text/css">
        .panelGeneralInformation .x-panel-body {
            background: #DFE8F6 !important;
        }

        div#grp_GiaoVienDaoTao .x-grid3-cell-inner, div#grp_GiaoVienDaoTao .x-grid3-hd-inner {
            white-space: nowrap !important;
        }

        div#grp_nhanVienThamGiaDaoTao .x-grid3-cell-inner, .x-grid3-hd-inner {
            white-space: nowrap !important;
        }
    </style>
    <script type="text/javascript">

        var CheckSelectedRecord = function (grid, Store) {
            if (hdfRecordID.getValue() == '') {
                alert('Bạn chưa chọn dòng nào');
                return false;
            }

            var s = grid.getSelectionModel().getSelections();
            var count = 0;
            for (var i = 0, r; r = s[i]; i++) {
                count++;
            }
            if (count > 1) {
                alert('Bạn chỉ được chọn một bản ghi');
                return false;
            }
            return true;
        }

        var CheckSelectedRows = function (grid) {
            var s = grid.getSelectionModel().getSelections();
            var count = 0;
            for (var i = 0, r; r = s[i]; i++) {
                count++;
            }
            if (count == 0) {
                alert('Bạn chưa chọn bản ghi nào nào!');
                return false;
            }
            if (count > 1) {
                alert('Bạn chỉ được chọn một bản ghi');
                return false;
            }
            return true;
        }
        var CheckInputDaoTaoinformation = function () {
            if (frm_txtMaKhoaDaoTao.getValue().trim() == '') {
                alert('Bạn chưa nhập mã kế hoạch đào tạo');
                frm_txtMaKhoaDaoTao.focus();
                return false;
            }
            if (frm_txtTenKhoaDaoTao.getValue().trim() == '') {
                alert('Bạn chưa nhập tên kế hoạch đào tạo');
                frm_txtTenKhoaDaoTao.focus();
                return false;
            }

            if (frm_dfBatDauDangKy.getValue() == '') {
                alert('Bạn chưa nhập bắt đầu đăng ký');
                frm_dfBatDauDangKy.focus();
                return false;
            }
            if (frm_dfHetHanDangKy.getValue() == '') {
                alert('Bạn chưa nhập hết hạn đăng ký');
                frm_dfHetHanDangKy.focus();
                return false;
            }
            if ((frm_dfBatDauDangKy.getValue() != '' && frm_dfHetHanDangKy.getValue() != '') && (frm_dfBatDauDangKy.getValue() > frm_dfHetHanDangKy.getValue())) {
                alert('Ngày bắt đầu đăng ký phải trước ngày hết hạn đăng ký');
                frm_dfBatDauDangKy.focus();
                return false;
            }
            if (frm_dfBatDauDaoTao.getValue() == '') {
                alert('Bạn chưa nhập bắt đầu đào tạo');
                frm_dfBatDauDaoTao.focus();
                return false;
            }

            if (frm_dfKetThucDaoTao.getValue() == '') {
                alert('Bạn chưa nhập hết hạn đào tạo');
                frm_dfKetThucDaoTao.focus();
                return false;
            }
            if ((frm_dfBatDauDaoTao.getValue() != '' && frm_dfKetThucDaoTao.getValue() != '') && (frm_dfBatDauDaoTao.getValue() > frm_dfKetThucDaoTao.getValue())) {
                alert('Ngày bắt đầu đào tạo phải trước ngày hết hạn đào tạo');
                frm_dfBatDauDaoTao.focus();
                return false;
            }
            //if (Date.parse(frm_dfBatDauDaoTao.getValue()) <= Date.parse(frm_dfHetHanDangKy.getValue())) {
            //    alert('Ngày bắt đầu đào tạo phải lớn hơn Ngày kết thúc đăng ký');
            //    frm_dfBatDauDaoTao.focus();
            //    return false;
            //}
            var currentStatus = hdfCurrentStatus.getValue();
            var newStatus = frm_cbTrangThai.getValue();
            switch (currentStatus) {
                case '1. Không được duyệt':
                    if (newStatus == '2. Chờ duyệt') {
                        alert('Không thể chuyển trạng thái Không được duyệt thành Chờ duyệt'); frm_cbTrangThai.setValue('1. Không được duyệt');
                        return false;
                    }
                    if (newStatus == '3. Đã duyệt') {
                        alert('Không thể chuyển trạng thái Không được duyệt thành Đã duyệt'); frm_cbTrangThai.setValue('1. Không được duyệt');
                        return false;
                    }
                    if (newStatus == '4. Chưa triển khai') {
                        alert('Không thể chuyển trạng thái Không được duyệt thành Chưa triển khai'); frm_cbTrangThai.setValue('1. Không được duyệt');
                        return false;
                    }
                    if (newStatus == '5. Đang triển khai') {
                        alert('Không thể chuyển trạng thái Không được duyệt thành Đang triển khai'); frm_cbTrangThai.setValue('1. Không được duyệt');
                        return false;
                    }
                    if (newStatus == '6. Đã hoàn thành') {
                        alert('Không thể chuyển trạng thái Không được duyệt thành Đã hoàn thành'); frm_cbTrangThai.setValue('1. Không được duyệt');
                        return false;
                    }
                    break;
                case '2. Chờ duyệt':
                    if (newStatus == '4. Chưa triển khai') {
                        alert('Không thể chuyển trạng thái Chờ duyệt thành Chưa triển khai'); frm_cbTrangThai.setValue('2. Chờ duyệt');
                        return false;
                    }
                    if (newStatus == '5. Đang triển khai') {
                        alert('Không thể chuyển trạng thái Chờ duyệt thành Đang triển khai'); frm_cbTrangThai.setValue('2. Chờ duyệt');
                        return false;
                    }
                    if (newStatus == '6. Đã hoàn thành') {
                        alert('Không thể chuyển trạng thái Chờ duyệt thành Đã hoàn thành'); frm_cbTrangThai.setValue('2. Chờ duyệt');
                        return false;
                    }
                    break;
                case '3. Đã duyệt':
                    if (newStatus == '2. Chờ duyệt') {
                        alert('Không thể chuyển trạng thái Đã duyệt thành Chờ duyệt'); frm_cbTrangThai.setValue('3. Đã duyệt');
                        return false;
                    }
                    if (newStatus == '1. Không được duyệt') {
                        alert('Không thể chuyển trạng thái Đã duyệt thành Không được duyệt'); frm_cbTrangThai.setValue('3. Đã duyệt');
                        return false;
                    }
                    break;
                case '5. Đang triển khai':
                    if (newStatus == '4. Chưa triển khai') {
                        alert('Không thể chuyển trạng thái Đang triển khai thành Chưa triển khai'); frm_cbTrangThai.setValue('5. Đang triển khai');
                        return false;
                    }
                    if (newStatus == '2. Chờ duyệt') {
                        alert('Không được chuyển Đang triển khai sang Chờ duyệt'); frm_cbTrangThai.setValue('5. Đang triển khai');
                        return false;
                    }
                    if (newStatus == '3. Đã duyệt') {
                        alert('Không được chuyển Đang triển khai sang Đã duyệt'); frm_cbTrangThai.setValue('5. Đang triển khai');
                        return false;
                    }
                    if (newStatus == '1. Không được duyệt') {
                        alert('Không được chuyển Đang triển khai sang Không được duyệt'); frm_cbTrangThai.setValue('5. Đang triển khai');
                        return false;
                    }
                    break;
                case '6. Đã hoàn thành':
                    if (newStatus == '2. Chờ duyệt') {
                        alert('Không thể chuyển trạng thái Đã hoàn thành thành Chờ duyệt'); frm_cbTrangThai.setValue('6. Đã hoàn thành');
                        return false;
                    }
                    if (newStatus == '3. Đã duyệt') {
                        alert('Không thể chuyển trạng thái Đã hoàn thành thành Đã duyệt'); frm_cbTrangThai.setValue('6. Đã hoàn thànht');
                        return false;
                    }
                    if (newStatus == '1. Không được duyệt') {
                        alert('Không thể chuyển Đã hoàn thành sang không được duyệt'); frm_cbTrangThai.setValue('6. Đã hoàn thành');
                    }
                    if (newStatus == '4. Chưa triển khai') {
                        alert('Không thể chuyển trạng thái Đã hoàn thành thành Chưa triển khai'); frm_cbTrangThai.setValue('6. Đã hoàn thành');
                        return false;
                    }
                    if (newStatus == '5. Đang triển khai') {
                        alert('Không thể chuyển trạng thái Đã hoàn thành sang Đang triển khai'); frm_cbTrangThai.setValue('6. Đã hoàn thành');
                    }
                    break;
            }
            return true;
        }

        var enterKeyPressHandler = function (f, e) {
            if (e.getKey() == e.ENTER) {
                Store1.reload();
            }
        }

        var RemoveItemOnGrid = function (grid, Store, id) {
            Ext.Msg.confirm('Xác nhận', 'Bạn có chắc chắn muốn xóa không ?', function (btn) {
                if (btn == "yes") {
                    try {
                        grid.getRowEditor().stopEditing();
                    } catch (e) {

                    }
                    var s = grid.getSelectionModel().getSelections();
                    for (var i = 0, r; r = s[i]; i++) {
                        switch (id) {
                            case '1':   // Main Grid
                                Ext.net.DirectMethods.DeleteRecord(r.data.MaKeHoach, id);
                                break;
                            case '2':
                                Ext.net.DirectMethods.DeleteRecord(r.data.MaGV, id);
                                break;
                            case '3':
                                Ext.net.DirectMethods.DeleteRecord(r.data.ID, id);
                                break;
                            case '4':
                                Ext.net.DirectMethods.DeleteRecord(r.data.ID, id);
                                break;
                        }
                    }
                    btnEdit.disable();
                    btnDelete.disable();
                    mnuNhanDoiDuLieu.disable();

                }
            });
        }

        var ResetValue = function () {
            frm_txtMaKhoaDaoTao.reset();
            frm_txtTenKhoaDaoTao.reset();
            frm_cbChungChi.reset();
            frm_txtKinhPhiDuKien.reset();
            frm_txtKinhPhiThucTe.reset();
            frm_txtCongTyHoTro.reset();
            frm_txtNhanVienDongGop.reset();
            frm_dfBatDauDaoTao.reset();
            frm_dfKetThucDaoTao.reset();
            frm_dfBatDauDangKy.reset();
            frm_dfHetHanDangKy.reset();
            frm_txtDiaDiemDaoTao.reset();
            frm_txtSoLuongHocVien.reset();
            frm_txtDoiTuongDaoTao.reset();
            frm_txtThoiLuongDaoTao.reset();
            frm_txtLyDoDaoTao.reset();
            frm_txtNoiDungDaoTao.reset();
            frm_txtGHiChi.reset();
            frm_cbPhuTrachDaoTao.reset();
            frm_cbTrangThai.reset();
        }

        var CheckInputGiaoVienGiangDay = function () {
            if (gv_txtMaGiaoVien.getValue().trim() == '') {
                Ext.Msg.alert('Thông báo', 'Bạn chưa nhập mã giáo viên');
                return false;
            }
            if (gv_txtHoten.getValue().trim() == '') {
                Ext.Msg.alert('Thông báo', 'Bạn chưa nhập họ tên giáo viên');
                return false;
            }
        }
        var CheckInputCacKhoanChiPhi = function () {
            if (txtTenKhoanChiPhi.getValue().trim() == '') {
                Ext.Msg.alert('Thông báo', 'Bạn chưa nhập tên khoản chi phí !');
                return false;
            }
            if (txtSoTienChiPhi.getValue().trim() == '') {
                Ext.Msg.alert('Thông báo', 'Bạn chưa nhập số tiền !');
                return false;
            }
        }
        var RenderDaThamGia = function (value, p, record) {
            if (value == "1") {
                return "<span style='color:blue;'>Có</span>";
            }
            return "<span style='color:red;'>Không</span>";
        }

        var CheckInputMaKhoaHoc = function () {
            if (txtNewPrimaryKey.getValue().trim() == '') {
                Ext.Msg.alert('Thông báo', 'Bạn chưa nhập mã khóa học');
                return false;
            }
            return true;
        }

        var ReloadStoreDetail = function () {
            var tab = TabPanel1.getActiveTab();
            if (tab != null) {
                var tabTitle = tab.title;
                switch (tabTitle) {
                    case "Giáo viên đào tạo":
                        grp_GiaoVienDaoTaoStore.reload();
                        btnThemGiaoVienDaoTao.enable();
                        Button18.enable();
                        break;
                    case "Các khoản chi phí":
                        grp_CacKhoanChiPhiStore.reload();
                        Button6.disable(); btnSuaChiPhi.disable();
                        break;
                    case "Nhân viên tham gia đào tạo":
                        grp_nhanVienThamGiaDaoTaoStore.reload();
                        Button11.disable();
                        break;
                }
            }
        }

        var CheckCurrentRecordID = function () {
            if (hdfRecordID.getValue().trim() == '') {
                Ext.Msg.alert('Cảnh báo', 'Bạn chưa chọn khóa học nào !');
                return false;
            }
            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ext:ResourceManager runat="server" ID="RM" />
            <ext:Hidden runat="server" ID="hdfTrangThai" />
            <ext:Store ID="Store1" runat="server" AutoSave="true" ShowWarningOnFailure="false"
                OnBeforeStoreChanged="HandleChanges" SkipIdForNewRecords="false" RefreshAfterSaving="None"
                GroupField="TrangThai">
                <Proxy>
                    <ext:HttpProxy Method="GET" Url="KeHoachDaoTao.ashx" />
                </Proxy>
                <AutoLoadParams>
                    <ext:Parameter Name="start" Value="={0}" />
                    <ext:Parameter Name="limit" Value="={50}" />
                </AutoLoadParams>
                <BaseParams>
                    <ext:Parameter Name="SearchKey" Value="#{txtSearch}.getValue()" Mode="Raw" />
                    <ext:Parameter Name="TrangThai" Value="#{hdfTrangThai}.getValue()" Mode="Raw" />
                </BaseParams>
                <Reader>
                    <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="MaKeHoach">
                        <Fields>
                            <ext:RecordField Name="MaKeHoach" />
                            <ext:RecordField Name="TenkeHoach" />
                            <ext:RecordField Name="TuNgay" />
                            <ext:RecordField Name="DenNgay" />
                            <ext:RecordField Name="TenChungChi" />
                            <ext:RecordField Name="KinhPhiDuKien" />
                            <ext:RecordField Name="KinhPhiThucTe" />
                            <ext:RecordField Name="KinhPhiCongTyHoTro" />
                            <ext:RecordField Name="KinhPhiNhanVienDong" />
                            <ext:RecordField Name="NgayBatDauDangKy" />
                            <ext:RecordField Name="NgayKetThucDangKy" />
                            <ext:RecordField Name="MucDichKhoaHoc" />
                            <ext:RecordField Name="NoiDungDaoTao" />
                            <ext:RecordField Name="DiaDiemDaoTao" />
                            <ext:RecordField Name="ThoiGianDaoTao" />
                            <ext:RecordField Name="TrangThai" />
                            <ext:RecordField Name="DoiTuongDaoTao" />
                            <ext:RecordField Name="SoLuongHocVien" />
                            <ext:RecordField Name="LyDoDaoTao" />
                            <ext:RecordField Name="DonViPhuTrachDaoTao" />
                            <ext:RecordField Name="GhiChu" />
                        </Fields>
                    </ext:JsonReader>
                </Reader>
            </ext:Store>
            <ext:Hidden runat="server" ID="hdfRecordID" />
            <ext:Window runat="server" Resizable="false" Hidden="true" AutoHeight="true" Layout="FormLayout"
                Width="680" Modal="true" Constrain="true" ID="wdAddWindow" Title="Thêm mới kế hoạch đào tạo"
                Icon="Add">
                <Items>
                    <ext:Hidden runat="server" ID="hdfDaoTaoCommand" />
                    <ext:Hidden runat="server" ID="hdfCurrentStatus" />
                    <ext:TabPanel runat="server" ID="tpl" Border="false" AnchorHorizontal="100%">
                        <Items>
                            <ext:Panel runat="server" Padding="6" Height="400" Layout="FormLayout" LabelWidth="110"
                                Title="Thông tin khóa học" ID="tpnThongTinKhoaHoc">
                                <Items>
                                    <ext:TextField runat="server" ID="frm_txtMaKhoaDaoTao" AllowBlank="false" FieldLabel="Mã khóa đào tạo<span style='color:red'>*</span>"
                                        CtCls="requiredData" AnchorHorizontal="40%" MaxLength="50" />
                                    <ext:TriggerField ID="frm_txtTenKhoaDaoTao" AllowBlank="false" EmptyText="Nhập mới khóa đào tạo hoặc chọn khóa đào tạo có sẵn"
                                        FieldLabel="Tên khóa đào tạo<span style='color:red'>*</span>" AnchorHorizontal="100%"
                                        runat="server" MaxLength="50" CtCls="requiredData">
                                        <Triggers>
                                            <ext:FieldTrigger Icon="SimpleEllipsis" />
                                        </Triggers>
                                        <Listeners>
                                            <TriggerClick Handler="#{wdChonKhoaHoc}.show();" />
                                        </Listeners>
                                    </ext:TriggerField>
                                    <ext:ComboBox ID="frm_cbChungChi" DisplayField="TEN" ValueField="MA" MinChars="1" PageSize="15"
                                        Editable="true" runat="server" FieldLabel="Chứng chỉ<span style='color:red'></span>"
                                        AnchorHorizontal="100%">
                                        <Store>
                                            <ext:Store runat="server" AutoLoad="false" ID="frm_cbChungChiStore">
                                                <Proxy>
                                                    <ext:HttpProxy Method="POST" Url="../HoSoNhanSu/SearchDanhMucHandler.ashx" />
                                                </Proxy>
                                                <BaseParams>
                                                    <ext:Parameter Name="table" Value="DM_CHUNGCHI" Mode="Value" />
                                                    <ext:Parameter Name="ma" Value="MA_CHUNGCHI" Mode="Value" />
                                                    <ext:Parameter Name="ten" Value="TEN_CHUNGCHI" Mode="Value" />
                                                </BaseParams>
                                                <Reader>
                                                    <ext:JsonReader Root="plants" TotalProperty="total" IDProperty="MA">
                                                        <Fields>
                                                            <ext:RecordField Name="MA" />
                                                            <ext:RecordField Name="TEN" />
                                                        </Fields>
                                                    </ext:JsonReader>
                                                </Reader>
                                            </ext:Store>
                                        </Store>
                                        <Listeners>
                                            <Select Handler="this.triggers[0].show();" />
                                            <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                            <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                        </Listeners>
                                        <Triggers>
                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                        </Triggers>
                                    </ext:ComboBox>
                                    <ext:Container runat="server" Height="140" Layout="ColumnLayout">
                                        <Items>
                                            <ext:Container runat="server" Height="130" ColumnWidth="0.55">
                                                <Items>
                                                    <ext:FieldSet AutoHeight="true" Title="Kinh phí" runat="server" ID="fs" Width="350">
                                                        <Items>
                                                            <ext:TextField runat="server" MaskRe="/[0-9\.]/" FieldLabel="Kinh phí dự kiến" ID="frm_txtKinhPhiDuKien"
                                                                AnchorHorizontal="100%" MaxLength="18" />
                                                            <ext:TextField runat="server" MaskRe="/[0-9\.]/" FieldLabel="Kinh phí thực tế" ID="frm_txtKinhPhiThucTe"
                                                                AnchorHorizontal="100%" MaxLength="18" />
                                                            <ext:Container runat="server" Height="27" Layout="ColumnLayout">
                                                                <Items>
                                                                    <ext:Container runat="server" Height="23" ColumnWidth="0.85">
                                                                        <Items>
                                                                            <ext:TextField runat="server" MaskRe="/[0-9\.]/" EmptyText="Số tiền hỗ trợ cho 1 nhân viên"
                                                                                FieldLabel="Công ty hỗ trợ" Width="270" ID="frm_txtCongTyHoTro" MaxLength="18" />
                                                                        </Items>
                                                                    </ext:Container>
                                                                    <ext:Container runat="server" Height="23" ColumnWidth="0.15">
                                                                        <Items>
                                                                            <ext:Label ID="Label2" runat="server" Text="VNĐ/1 NV" AnchorHorizontal="100%" />
                                                                        </Items>
                                                                    </ext:Container>
                                                                </Items>
                                                            </ext:Container>
                                                            <ext:Container ID="Container9" runat="server" Height="27" Layout="ColumnLayout">
                                                                <Items>
                                                                    <ext:Container ID="Container10" runat="server" Height="23" ColumnWidth="0.85">
                                                                        <Items>
                                                                            <ext:TextField runat="server" MaskRe="/[0-9\.]/" EmptyText="Số tiền nhân viên phải đóng thêm"
                                                                                FieldLabel="NV đóng góp" Width="270" MaxLength="18" ID="frm_txtNhanVienDongGop" />
                                                                        </Items>
                                                                    </ext:Container>
                                                                    <ext:Container ID="Container11" runat="server" Height="23" ColumnWidth="0.15">
                                                                        <Items>
                                                                            <ext:Label ID="Label3" runat="server" Text="VNĐ" AnchorHorizontal="100%" />
                                                                        </Items>
                                                                    </ext:Container>
                                                                </Items>
                                                            </ext:Container>
                                                        </Items>
                                                    </ext:FieldSet>
                                                </Items>
                                            </ext:Container>
                                            <ext:FieldSet AutoHeight="true" Title="Thời gian" runat="server" ID="FieldSet1" ColumnWidth="0.45"
                                                LabelWidth="110">
                                                <Items>
                                                    <ext:DateField runat="server" ID="frm_dfBatDauDangKy" Vtype="daterange" Editable="true"
                                                        MaskRe="/[0-9\/]/" CtCls="requiredData" FieldLabel="Bắt đầu đăng ký<span style='color:red'>*</span>"
                                                        AnchorHorizontal="100%">
                                                        <Triggers>
                                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                        </Triggers>
                                                        <Listeners>
                                                            <Select Handler="this.triggers[0].show();" />
                                                            <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                                                        </Listeners>
                                                    </ext:DateField>
                                                    <ext:DateField runat="server" ID="frm_dfHetHanDangKy" Vtype="daterange" Editable="true"
                                                        MaskRe="/[0-9\/]/" CtCls="requiredData" FieldLabel="Hết hạn đăng ký<span style='color:red'>*</span>"
                                                        AnchorHorizontal="100%">
                                                        <Triggers>
                                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                        </Triggers>
                                                        <Listeners>
                                                            <Select Handler="this.triggers[0].show();" />
                                                            <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                                                        </Listeners>
                                                    </ext:DateField>
                                                    <ext:DateField runat="server" ID="frm_dfBatDauDaoTao" Vtype="daterange" Editable="true"
                                                        MaskRe="/[0-9\/]/" CtCls="requiredData" FieldLabel="Bắt đầu đào tạo<span style='color:red'>*</span>"
                                                        AnchorHorizontal="100%">
                                                        <Triggers>
                                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                        </Triggers>
                                                        <Listeners>
                                                            <Select Handler="this.triggers[0].show();" />
                                                            <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                                                        </Listeners>
                                                    </ext:DateField>
                                                    <ext:DateField runat="server" ID="frm_dfKetThucDaoTao" Vtype="daterange" Editable="true"
                                                        MaskRe="/[0-9\/]/" CtCls="requiredData" FieldLabel="Kết thúc đào tạo<span style='color:red'>*</span>"
                                                        AnchorHorizontal="100%">
                                                        <Triggers>
                                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                        </Triggers>
                                                        <Listeners>
                                                            <Select Handler="this.triggers[0].show();" />
                                                            <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                                                        </Listeners>
                                                    </ext:DateField>
                                                </Items>
                                            </ext:FieldSet>
                                        </Items>
                                    </ext:Container>
                                    <ext:Container runat="server" Height="30" Layout="ColumnLayout">
                                        <Items>
                                            <ext:Container runat="server" Height="30" ColumnWidth="0.55">
                                                <Items>
                                                    <ext:TextField ID="frm_txtDiaDiemDaoTao" runat="server" FieldLabel="Địa điểm đào tạo"
                                                        Width="350" MaxLength="500" />
                                                </Items>
                                            </ext:Container>
                                            <ext:NumberField ID="frm_txtSoLuongHocVien" AllowNegative="false" runat="server"
                                                FieldLabel="Số lượng học viên" ColumnWidth="0.45" />
                                        </Items>
                                    </ext:Container>
                                    <ext:Container ID="Container4" runat="server" Height="30" Layout="ColumnLayout">
                                        <Items>
                                            <ext:Container ID="Container5" runat="server" Height="30" ColumnWidth="0.55">
                                                <Items>
                                                    <ext:TextField ID="frm_txtDoiTuongDaoTao" runat="server" FieldLabel="Đối tượng đào tạo"
                                                        Width="350" MaxLength="50" />
                                                </Items>
                                            </ext:Container>
                                            <ext:Container runat="server" Height="30" ColumnWidth="0.45">
                                                <Items>
                                                    <ext:Container ID="Container12" runat="server" Height="27" Layout="ColumnLayout">
                                                        <Items>
                                                            <ext:Container ID="Container13" runat="server" Height="23" ColumnWidth="0.88">
                                                                <Items>
                                                                    <ext:TextField ID="frm_txtThoiLuongDaoTao" runat="server" Width="250" FieldLabel="Thời lượng đào tạo"
                                                                        MaxLength="50" />
                                                                </Items>
                                                            </ext:Container>
                                                            <ext:Container ID="Container14" runat="server" Height="23" ColumnWidth="0.12">
                                                                <Items>
                                                                    <ext:Label runat="server" Text="tháng" />
                                                                </Items>
                                                            </ext:Container>
                                                        </Items>
                                                    </ext:Container>
                                                </Items>
                                            </ext:Container>
                                        </Items>
                                    </ext:Container>
                                    <ext:ComboBox ID="frm_txtLyDoDaoTao" DisplayField="TEN_LYDO_DAOTAO" ValueField="TEN_LYDO_DAOTAO"
                                        runat="server" FieldLabel="Lý do đào tạo" AnchorHorizontal="100%">
                                        <Store>
                                            <ext:Store ID="stTrinhDo" runat="server" AutoLoad="false">
                                                <Proxy>
                                                    <ext:HttpProxy Method="POST" Url="../Base/ComboSearchHandler.ashx" />
                                                </Proxy>
                                                <BaseParams>
                                                    <ext:Parameter Name="Table" Value="dbo.DM_LYDO_DAOTAO" Mode="Value" />
                                                    <ext:Parameter Name="ValueField" Value="MA_LYDO_DAOTAO" Mode="Value" />
                                                    <ext:Parameter Name="DisplayField" Value="TEN_LYDO_DAOTAO" Mode="Value" />
                                                </BaseParams>
                                                <Reader>
                                                    <ext:JsonReader Root="plants" TotalProperty="total">
                                                        <Fields>
                                                            <ext:RecordField Name="MA_LYDO_DAOTAO" />
                                                            <ext:RecordField Name="TEN_LYDO_DAOTAO" />
                                                        </Fields>
                                                    </ext:JsonReader>
                                                </Reader>
                                            </ext:Store>
                                        </Store>
                                        <Listeners>
                                            <Select Handler="this.triggers[0].show();" />
                                            <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                            <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                        </Listeners>
                                        <Triggers>
                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                        </Triggers>
                                    </ext:ComboBox>
                                    <ext:TextField ID="frm_txtNoiDungDaoTao" runat="server" FieldLabel="Nội dung đào tạo"
                                        AnchorHorizontal="100%" MaxLength="500" />
                                    <ext:TextField ID="frm_txtGHiChi" runat="server" FieldLabel="Ghi chú" AnchorHorizontal="100%"
                                        MaxLength="500" />
                                    <ext:Container ID="Container6" runat="server" Height="30" Layout="ColumnLayout">
                                        <Items>
                                            <ext:Container ID="Container7" runat="server" Height="30" ColumnWidth="0.55">
                                                <Items>
                                                    <ext:ComboBox ID="frm_cbPhuTrachDaoTao" DisplayField="Ten" ValueField="Ma" Editable="false"
                                                        runat="server" FieldLabel="Phụ trách đào tạo" Width="350">
                                                        <Triggers>
                                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                            <%--<ext:FieldTrigger Icon="SimpleAdd" Qtip="Đơn vị phụ trách đào tạo" />--%>
                                                        </Triggers>
                                                        <Store>
                                                            <ext:Store runat="server" AutoLoad="false" ID="frm_cbPhuTrachDaoTaoStore" OnRefreshData="frm_cbPhuTrachDaoTaoStore_OnRefreshData">
                                                                <Reader>
                                                                    <ext:JsonReader IDProperty="Ma">
                                                                        <Fields>
                                                                            <ext:RecordField Name="Ma" />
                                                                            <ext:RecordField Name="Ten" />
                                                                        </Fields>
                                                                    </ext:JsonReader>
                                                                </Reader>
                                                            </ext:Store>
                                                        </Store>
                                                        <Listeners>
                                                            <Select Handler="this.triggers[0].show();" />
                                                            <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                            <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                        </Listeners>
                                                    </ext:ComboBox>
                                                </Items>
                                            </ext:Container>
                                            <ext:ComboBox ID="frm_cbTrangThai" Editable="false" SelectedIndex="0" runat="server"
                                                FieldLabel="Trạng thái" ColumnWidth="0.45">
                                                <Triggers>
                                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                </Triggers>
                                                <Listeners>
                                                    <Select Handler="this.triggers[0].show();" />
                                                    <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                                                </Listeners>
                                                <Items>
                                                    <ext:ListItem Text="1. Không được duyệt" Value="1. Không được duyệt" />
                                                    <ext:ListItem Text="2. Chờ duyệt" Value="2. Chờ duyệt" />
                                                    <ext:ListItem Text="3. Đã duyệt" Value="3. Đã duyệt" />
                                                    <ext:ListItem Text="4. Chưa triển khai" Value="4. Chưa triển khai" />
                                                    <ext:ListItem Text="5. Đang triển khai" Value="5. Đang triển khai" />
                                                    <ext:ListItem Text="6. Đã hoàn thành" Value="6. Đã hoàn thành" />
                                                </Items>
                                            </ext:ComboBox>
                                        </Items>
                                    </ext:Container>
                                </Items>
                            </ext:Panel>
                            <%--<ext:Panel runat="server" Height="400" Title="Giáo viên đào tạo" ID="Panel1">
                        </ext:Panel>
                        <ext:Panel runat="server" Height="400" Title="Các khoản chi phí" ID="Panel2">
                        </ext:Panel>
                        <ext:Panel runat="server" Height="400" Title="Nhân viên tham gia đào tạo" ID="Panel3">
                        </ext:Panel>--%>
                        </Items>
                    </ext:TabPanel>
                </Items>
                <Listeners>
                    <BeforeShow Handler="if(#{frm_cbChungChi}.store.getCount()==0)
                                    {
                                        #{frm_cbChungChiStore}.reload();
                                    }
                                    if(#{frm_cbPhuTrachDaoTao}.store.getCount()==0)
                                    {
                                        #{frm_cbPhuTrachDaoTaoStore}.reload();
                                    }
                                    if(hdfDaoTaoCommand.getValue()=='Edit')
                                    {
                                        btnCapNhat.hide();Button1.hide();Button12.show();
                                    }
                                    " />
                    <Hide Handler="ResetValue();if(hdfDaoTaoCommand.getValue()=='Edit'){Ext.net.DirectMethods.ResetWindow();};hdfDaoTaoCommand.reset();
                               btnCapNhat.show();Button1.show();Button12.hide();frm_txtMaKhoaDaoTao.enable();" />
                </Listeners>
                <Buttons>
                    <ext:Button runat="server" ID="btnCapNhat" Text="Cập nhật" Icon="Disk">
                        <Listeners>
                            <Click Handler="return CheckInputDaoTaoinformation();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnCapNhat_Click">
                                <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                <ExtraParams>
                                    <ext:Parameter Name="Close" Value="False">
                                    </ext:Parameter>
                                </ExtraParams>
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button ID="Button1" runat="server" Text="Cập nhật & Đóng lại" Icon="Disk">
                        <Listeners>
                            <Click Handler="return CheckInputDaoTaoinformation();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnCapNhat_Click">
                                <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                <ExtraParams>
                                    <ext:Parameter Name="Close" Value="True">
                                    </ext:Parameter>
                                </ExtraParams>
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button ID="Button12" runat="server" Hidden="true" Text="Cập nhật" Icon="Disk">
                        <Listeners>
                            <Click Handler="return CheckInputDaoTaoinformation();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnCapNhat_Click">
                                <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                <ExtraParams>
                                    <ext:Parameter Name="Close" Value="True">
                                    </ext:Parameter>
                                    <ext:Parameter Name="Command" Value="Edit" />
                                </ExtraParams>
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button ID="Button5" runat="server" Text="Đóng lại" Icon="Decline">
                        <Listeners>
                            <Click Handler="#{wdAddWindow}.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:Window>
            <ext:Window runat="server" Resizable="false" Hidden="true" AutoHeight="true" Layout="FormLayout"
                LabelWidth="110" Width="400" Modal="true" Constrain="true" ID="wdCacKhoanChiPhi"
                Title="Các khoản chi phí" Padding="6" Icon="Money">
                <Items>
                    <ext:TextField ID="txtTenKhoanChiPhi" runat="server" AllowBlank="false" AnchorHorizontal="100%"
                        CtCls="requiredData" FieldLabel="Tên khoản chi phí<span style='color:red'>*</span>" />
                    <ext:TextField ID="txtNguonCHi" runat="server" AnchorHorizontal="100%" FieldLabel="Nguồn chi" />
                    <ext:TextField runat="server" ID="txtSoTienChiPhi" AllowBlank="false" FieldLabel="Số tiền<span style='color:red'>*</span>"
                        MaskRe="/[0-9\.]/" MaxLength="15" CtCls="requiredData" AnchorHorizontal="100%">
                    </ext:TextField>
                </Items>
                <Buttons>
                    <ext:Button runat="server" ID="btnCapNhatChiPhi" Text="Cập nhật" Icon="Disk">
                        <Listeners>
                            <Click Handler="return CheckInputCacKhoanChiPhi();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnCapNhatChiPhi_Click">
                                <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                <ExtraParams>
                                    <ext:Parameter Name="Close" Value="False" />
                                </ExtraParams>
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button ID="Button7" runat="server" Text="Cập nhật & Đóng lại" Icon="Disk">
                        <Listeners>
                            <Click Handler="return CheckInputCacKhoanChiPhi();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnCapNhatChiPhi_Click">
                                <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                <ExtraParams>
                                    <ext:Parameter Name="Close" Value="True" />
                                </ExtraParams>
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button ID="Button9" runat="server" Text="Cập nhật" Hidden="true" Icon="Disk">
                        <DirectEvents>
                            <Click OnEvent="btnCapNhatChiPhi_Click">
                                <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                <ExtraParams>
                                    <ext:Parameter Name="Close" Value="True" />
                                    <ext:Parameter Name="Edit" Value="True" />
                                </ExtraParams>
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button ID="Button8" runat="server" Text="Đóng lại" Icon="Decline">
                        <Listeners>
                            <Click Handler="#{wdCacKhoanChiPhi}.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
                <Listeners>
                    <Hide Handler="#{btnCapNhatChiPhi}.show();#{Button7}.show();#{Button9}.hide();
                               txtTenKhoanChiPhi.reset();txtNguonCHi.reset();txtSoTienChiPhi.reset();" />
                </Listeners>
            </ext:Window>
            <ext:Window runat="server" Resizable="false" Hidden="true" AutoHeight="true" Layout="FormLayout"
                Width="400" Modal="true" Constrain="true" ID="wdNhanVienThamGiaDaoTao" Title="Nhân viên tham gia đào tạo"
                Padding="6" Icon="User">
                <Items>
                </Items>
                <Buttons>
                    <ext:Button runat="server" ID="Button13" Text="Cập nhật" Icon="Disk">
                        <DirectEvents>
                            <Click OnEvent="btnCapNhatChiPhi_Click">
                                <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                <ExtraParams>
                                    <ext:Parameter Name="Close" Value="False" />
                                </ExtraParams>
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button ID="Button14" runat="server" Text="Cập nhật & Đóng lại" Icon="Disk">
                        <DirectEvents>
                            <Click OnEvent="btnCapNhatChiPhi_Click">
                                <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                <ExtraParams>
                                    <ext:Parameter Name="Close" Value="True" />
                                </ExtraParams>
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button ID="Button15" runat="server" Text="Cập nhật" Hidden="true" Icon="Disk">
                        <DirectEvents>
                            <Click OnEvent="btnCapNhatChiPhi_Click">
                                <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                <ExtraParams>
                                    <ext:Parameter Name="Close" Value="True" />
                                    <ext:Parameter Name="Edit" Value="True" />
                                </ExtraParams>
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button ID="Button16" runat="server" Text="Đóng lại" Icon="Decline">
                        <Listeners>
                            <Click Handler="#{wdCacKhoanChiPhi}.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
                <Listeners>
                    <Hide Handler="#{btnCapNhatChiPhi}.show();#{Button7}.show();#{Button9}.hide();" />
                </Listeners>
            </ext:Window>
            <ext:Window runat="server" Resizable="false" Hidden="true" AutoHeight="true" Layout="FormLayout"
                Width="400" Modal="true" Constrain="true" ID="wdChonKhoaHoc" Title="Chọn khóa học"
                Icon="Add">
                <Items>
                    <ext:Hidden runat="server" ID="hdfMaKhoaHoc" />
                    <ext:GridPanel Border="false" ID="grp_DanhSachKhoaHoc" Header="false" runat="server"
                        StripeRows="true" Title="Danh sách khóa học" AnchorHorizontal="100%" Height="290"
                        AutoExpandColumn="TenKhoaDaoTao">
                        <%--<TopBar>
                        <ext:Toolbar runat="server" ID="tbgrp_DanhSachKhoaHoc">
                            <Items>
                                <ext:Button Text="Thêm mới" Icon="Add" runat="server">
                                </ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </TopBar>--%>
                        <Store>
                            <ext:Store ID="grp_DanhSachKhoaHocStore" runat="server" OnRefreshData="grp_DanhSachKhoaHocStore_OnRefreshData">
                                <Reader>
                                    <ext:JsonReader IDProperty="PR_KEY">
                                        <Fields>
                                            <ext:RecordField Name="PR_KEY" />
                                            <ext:RecordField Name="TenKhoaDaoTao" />
                                        </Fields>
                                    </ext:JsonReader>
                                </Reader>
                            </ext:Store>
                        </Store>
                        <ColumnModel ID="ColumnModel2" runat="server">
                            <Columns>
                                <ext:RowNumbererColumn Header="STT" />
                                <ext:Column ColumnID="TenKhoaDaoTao" Header="Tên khóa học" Width="160" DataIndex="TenKhoaDaoTao" />
                            </Columns>
                        </ColumnModel>
                        <SelectionModel>
                            <ext:RowSelectionModel ID="RowSelectionModel1" runat="server">
                                <Listeners>
                                    <RowSelect Handler="hdfMaKhoaHoc.setValue(RowSelectionModel1.getSelected().id);" />
                                </Listeners>
                            </ext:RowSelectionModel>
                        </SelectionModel>
                        <LoadMask ShowMask="true" />
                        <DirectEvents>
                            <DblClick OnEvent="btnChonKhoaHocOK_Click">
                            </DblClick>
                        </DirectEvents>
                    </ext:GridPanel>
                </Items>
                <Listeners>
                    <BeforeShow Handler="#{grp_DanhSachKhoaHocStore}.reload();" />
                </Listeners>
                <Buttons>
                    <ext:Button runat="server" ID="btnChonKhoaHocOK" Text="Đồng ý" Icon="Accept">
                        <DirectEvents>
                            <Click OnEvent="btnChonKhoaHocOK_Click">
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button runat="server" Text="Đóng lại" Icon="Decline">
                        <Listeners>
                            <Click Handler="#{wdChonKhoaHoc}.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:Window>
            <ext:Window runat="server" ID="wdGiaoVien" Icon="UserSuitBlack" Padding="10" Resizable="false"
                Hidden="true" Title="Giáo viên đào tạo" Modal="true" Width="600" AutoHeight="true">
                <Items>
                    <ext:TextField runat="server" ID="gv_txtMaGiaoVien" AllowBlank="false" BlankText="Mã giáo viên không được để trống"
                        MaxLength="10" MaskRe="/[0-9\/\-|a-z|A-Z]/" FieldLabel="Mã giáo viên<span style='color:red'>*</span>"
                        TabIndex="1" CtCls="requiredData">
                        <DirectEvents>
                            <Blur OnEvent="gv_txtMaGiaoVien_Blur" />
                        </DirectEvents>
                    </ext:TextField>
                    <ext:TextField runat="server" ID="gv_txtHoten" AllowBlank="false" BlankText="Không được để trống họ tên"
                        MaxLength="250" CtCls="requiredData" Width="565" FieldLabel="Họ tên<span style='color:red'>*</span>"
                        TabIndex="2" />
                    <ext:Container runat="server" ID="ctq1" Layout="ColumnLayout" Height="160">
                        <Items>
                            <ext:Container runat="server" ID="c1" ColumnWidth=".5" Layout="FormLayout">
                                <Items>
                                    <ext:DateField runat="server" ID="df_ngaysinh" Editable="false" FieldLabel="Ngày sinh"
                                        AnchorHorizontal="98%" TabIndex="3">
                                    </ext:DateField>
                                    <ext:TextField runat="server" ID="txt_chucvu" FieldLabel="Chức vụ" AnchorHorizontal="98%"
                                        MaxLength="250" TabIndex="5">
                                    </ext:TextField>
                                    <ext:TextField runat="server" ID="txt_hocvan" FieldLabel="Học vấn" AnchorHorizontal="98%"
                                        MaxLength="250" TabIndex="7">
                                    </ext:TextField>
                                    <ext:TextField runat="server" ID="txt_email" FieldLabel="Email" AnchorHorizontal="98%"
                                        MaxLength="250" TabIndex="9">
                                    </ext:TextField>
                                    <ext:TextField runat="server" ID="txt_dtcq" FieldLabel="Điện thoại CQ" AnchorHorizontal="98%"
                                        MaxLength="250" TabIndex="11">
                                    </ext:TextField>
                                    <ext:Checkbox runat="server" ID="chk_nvcongty" BoxLabel="Là nhân viên công ty" TabIndex="13"
                                        MaxLength="250" AnchorHorizontal="98%">
                                    </ext:Checkbox>
                                </Items>
                            </ext:Container>
                            <ext:Container runat="server" ID="Container8" ColumnWidth=".5" Layout="FormLayout">
                                <Items>
                                    <ext:ComboBox runat="server" Editable="false" ID="cbx_gioitinh" SelectedIndex="0"
                                        FieldLabel="Giới tính" AnchorHorizontal="100%" TabIndex="4">
                                        <Items>
                                            <ext:ListItem Text="Nam" Value="True" />
                                            <ext:ListItem Text="Nữ" Value="False" />
                                        </Items>
                                    </ext:ComboBox>
                                    <ext:TextField runat="server" ID="txt_donvicongtac" FieldLabel="Đơn vị công tác"
                                        MaxLength="250" AnchorHorizontal="100%" TabIndex="6">
                                    </ext:TextField>
                                    <ext:TextField runat="server" ID="txt_diachi" FieldLabel="Địa chỉ liên hệ" AnchorHorizontal="100%"
                                        MaxLength="250" TabIndex="8">
                                    </ext:TextField>
                                    <ext:TextField runat="server" ID="txt_didong" FieldLabel="Di động" AnchorHorizontal="100%"
                                        MaxLength="250" TabIndex="10">
                                    </ext:TextField>
                                    <ext:TextField runat="server" ID="txt_nhanxet" FieldLabel="Nhận xét" AnchorHorizontal="100%"
                                        MaxLength="250" TabIndex="12">
                                    </ext:TextField>
                                </Items>
                            </ext:Container>
                        </Items>
                    </ext:Container>
                    <ext:TextArea runat="server" ID="txt_kinhnghiem" Width="565" Height="100" FieldLabel="Kinh nghiệm"
                        MaxLength="250" EmptyText="Kinh nghiệm giảng dạy!" TabIndex="14">
                    </ext:TextArea>
                </Items>
                <Buttons>
                    <ext:Button ID="Button17" runat="server" Text="Cập nhật" Icon="Disk">
                        <Listeners>
                            <Click Handler="return CheckInputGiaoVienGiangDay();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="Button17_Click">
                                <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                                <ExtraParams>
                                    <ext:Parameter Name="Close" Value="False">
                                    </ext:Parameter>
                                </ExtraParams>
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button ID="btn_EditGiaoVien" runat="server" Hidden="true" Text="Cập nhật" Icon="Disk">
                        <Listeners>
                            <Click Handler="return CheckInputGiaoVienGiangDay();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="Button17_Click">
                                <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                                <ExtraParams>
                                    <ext:Parameter Name="Command" Value="Edit">
                                    </ext:Parameter>
                                </ExtraParams>
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button runat="server" ID="btn_UpdateClose" Text="Cập nhật & Đóng lại" Icon="Disk">
                        <Listeners>
                            <Click Handler="return CheckInputGiaoVienGiangDay();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="Button17_Click">
                                <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                                <ExtraParams>
                                    <ext:Parameter Name="Close" Value="True">
                                    </ext:Parameter>
                                </ExtraParams>
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button ID="Button21" runat="server" Text="Đóng lại" Icon="Decline">
                        <Listeners>
                            <Click Handler="#{wdGiaoVien}.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
                <Listeners>
                    <Hide Handler="#{Button17}.show();#{btn_EditGiaoVien}.hide();#{btn_UpdateClose}.show();
                                gv_txtMaGiaoVien.reset();gv_txtHoten.reset();df_ngaysinh.reset();txt_chucvu.reset();
                                txt_hocvan.reset();txt_email.reset();txt_dtcq.reset();chk_nvcongty.reset();cbx_gioitinh.reset();cbx_gioitinh.reset();
                                txt_donvicongtac.reset();txt_diachi.reset();txt_didong.reset();txt_nhanxet.reset();txt_kinhnghiem.reset();gv_txtMaGiaoVien.enable();
                              " />
                </Listeners>
            </ext:Window>
            <ext:Window runat="server" ID="wdChonTuDanhSachGiaoVien" Width="650" Constrain="true"
                Title="Chọn giáo viên từ danh sách" Icon="UserSuitBlack" Hidden="true" AutoHeight="true"
                Layout="FormLayout" Modal="true" Padding="0" Resizable="false">
                <Items>
                    <ext:Hidden runat="server" ID="hdfIsLoaded" />
                    <ext:GridPanel ID="GridPanel2" Header="false" runat="server" Border="false" StripeRows="true"
                        Title="Array Grid" AnchorHorizontal="100%" Height="300">
                        <Store>
                            <ext:Store ID="StoreDanhSachGiaoVien" AutoLoad="false" runat="server" OnRefreshData="StoreDanhSachGiaoVien_OnRefreshData">
                                <Reader>
                                    <ext:JsonReader IDProperty="MaGV">
                                        <Fields>
                                            <ext:RecordField Name="ChucVu" />
                                            <ext:RecordField Name="MaGV" />
                                            <ext:RecordField Name="DiaChiLienHe" />
                                            <ext:RecordField Name="HoTenGV" />
                                            <ext:RecordField Name="DonViCongTac" />
                                            <ext:RecordField Name="DiDong" />
                                            <ext:RecordField Name="NgaySinh" />
                                        </Fields>
                                    </ext:JsonReader>
                                </Reader>
                            </ext:Store>
                        </Store>
                        <ColumnModel ID="ColumnModel6" runat="server">
                            <Columns>
                                <ext:RowNumbererColumn Header="STT" Locked="true" Width="30" />
                                <ext:Column ColumnID="MaGV" Locked="true" Header="Mã GV" Width="60" DataIndex="MaGV" />
                                <ext:Column ColumnID="HoTenGV" Locked="true" Header="Họ tên" Width="100" DataIndex="HoTenGV" />
                                <ext:DateColumn Format="dd/MM/yyyy" ColumnID="NgaySinh" Header="Ngày sinh" Width="70"
                                    DataIndex="NgaySinh" />
                                <ext:Column ColumnID="DiDong" Header="Di động" Width="100" DataIndex="DiDong" />
                                <ext:Column ColumnID="DonViCongTac" Header="Đơn vị công tác" Width="120" DataIndex="DonViCongTac" />
                                <ext:Column ColumnID="DiaChiLienHe" Header="Địa chỉ liên hệ" Width="120" DataIndex="DiaChiLienHe" />
                            </Columns>
                        </ColumnModel>
                        <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                        <%-- <View>
                        <ext:LockingGridView runat="server" ID="lkv" />
                    </View>--%>
                        <SelectionModel>
                            <ext:CheckboxSelectionModel ID="RowSelectionModel5" runat="server" />
                        </SelectionModel>
                        <LoadMask ShowMask="true" />
                        <BottomBar>
                            <ext:PagingToolbar ID="PagingToolbar2" runat="server" PageSize="20">
                            </ext:PagingToolbar>
                        </BottomBar>
                    </ext:GridPanel>
                </Items>
                <Buttons>
                    <ext:Button runat="server" Text="Đồng ý" Icon="Accept" ID="btnOK">
                        <DirectEvents>
                            <Click OnEvent="btnOK_Click">
                                <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button runat="server" Text="Đóng lại" Icon="Decline" ID="Button4">
                        <Listeners>
                            <Click Handler="#{wdChonTuDanhSachGiaoVien}.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
                <Listeners>
                    <BeforeShow Handler="if(hdfIsLoaded.getValue()==''){
                                         StoreDanhSachGiaoVien.reload();
                                         hdfIsLoaded.setValue('True');
                                    }" />
                </Listeners>
            </ext:Window>
            <ext:Window runat="server" ID="wdInputNewPrimaryKey" Icon="Key" Padding="10" Resizable="false"
                Hidden="true" Title="Nhập mã kế hoạch đào tạo" Layout="FormLayout" Modal="true"
                Width="400" AutoHeight="true">
                <Items>
                    <ext:TextField runat="server" ID="txtNewPrimaryKey" EmptyText="Nhập mã khóa học mới"
                        AnchorHorizontal="100%" AllowBlank="false" BlankText="Bạn bắt buộc phải nhập khóa chính mới"
                        CtCls="requiredData" FieldLabel="Mã khóa học<span style='color:red'>*</span>"
                        MaxLength="50" />
                    <ext:FieldSet AutoHeight="true" runat="server" AnchorHorizontal="100%" Title="Chọn nguồn dữ liệu để copy">
                        <Items>
                            <ext:Checkbox runat="server" BoxLabel="Thông tin khóa học" Disabled="true" Checked="true"
                                ID="Checkbox1">
                            </ext:Checkbox>
                            <ext:Checkbox runat="server" BoxLabel="Giáo viên đào tạo" ID="chkDuplicateGiaoVien" />
                            <ext:Checkbox runat="server" BoxLabel="Các khoản chi phí" ID="chkDuplicateCacKhoanChiPhi" />
                            <ext:Checkbox runat="server" BoxLabel="Nhân viên tham gia đào tạo" ID="chkDuplicateNhanVienThamGiaDaoTao" />
                        </Items>
                    </ext:FieldSet>
                </Items>
                <Buttons>
                    <ext:Button ID="btnOkPrimaryKey" runat="server" Text="Đồng ý" Icon="Accept">
                        <Listeners>
                            <Click Handler="return CheckInputMaKhoaHoc();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnOkPrimaryKey_Click">
                                <EventMask ShowMask="true" Msg="Chờ trong giây lát" />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button runat="server" Text="Đóng lại" Icon="Decline" ID="btnCancelForm">
                        <Listeners>
                            <Click Handler="#{wdInputNewPrimaryKey}.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
                <Listeners>
                    <BeforeShow Handler="#{txtNewPrimaryKey}.reset();
                                     chkDuplicateGiaoVien.reset();
                                     chkDuplicateCacKhoanChiPhi.reset();
                                     chkDuplicateNhanVienThamGiaDaoTao.reset();" />
                </Listeners>
            </ext:Window>
            <ext:Viewport runat="server" ID="vp">
                <Items>
                    <ext:BorderLayout runat="server" ID="br">
                        <Center>
                            <ext:GridPanel ID="GridPanel1" Border="false" runat="server" StoreID="Store1" StripeRows="true"
                                Icon="ApplicationViewColumns" TrackMouseOver="false" AnchorHorizontal="100%">
                                <TopBar>
                                    <ext:Toolbar runat="server" ID="tb">
                                        <Items>
                                            <%--<ext:Button ID="Button4" runat="server" Text="Hồ sơ giấy tờ" Icon="PageRed">
                                        </ext:Button>--%>
                                            <ext:Button ID="btnAddNew" runat="server" Text="Thêm mới" Icon="Add">
                                                <Listeners>
                                                    <Click Handler="#{hdfCurrentStatus}.setValue(''); #{wdAddWindow}.show();" />
                                                </Listeners>
                                            </ext:Button>
                                            <ext:Button ID="btnEdit" runat="server" Disabled="true" Text="Sửa" Icon="Pencil">
                                                <Listeners>
                                                    <Click Handler=" return CheckSelectedRows(GridPanel1);" />
                                                </Listeners>
                                                <DirectEvents>
                                                    <Click OnEvent="btnEdit_Click">
                                                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:Button>
                                            <ext:Button ID="btnDelete" runat="server" Text="Xóa" Disabled="true" Icon="Delete">
                                                <Listeners>
                                                    <Click Handler="if(CheckSelectedRows(GridPanel1)){ RemoveItemOnGrid(GridPanel1,Store1, '1');}" />
                                                </Listeners>
                                            </ext:Button>
                                            <ext:ToolbarSeparator runat="server" />
                                            <ext:Button ID="Button2" runat="server" Text="Quản lý" Icon="ApplicationCascade">
                                                <Menu>
                                                    <ext:Menu runat="server">
                                                        <Items>
                                                            <ext:MenuItem ID="mnuChuyenTT" Text="Chuyển trạng thái">
                                                                <Menu>
                                                                    <ext:Menu runat="server">
                                                                        <Items>
                                                                            <ext:MenuItem ID="MenuItem3" runat="server" Text="1. Không được duyệt">
                                                                                <Listeners>
                                                                                    <Click Handler="return CheckCurrentRecordID();" />
                                                                                </Listeners>
                                                                                <DirectEvents>
                                                                                    <Click OnEvent="ChuyenTrangThai_Click">
                                                                                        <ExtraParams>
                                                                                            <ext:Parameter Name="TrangThai" Value="1. Không được duyệt" />
                                                                                        </ExtraParams>
                                                                                    </Click>
                                                                                </DirectEvents>
                                                                            </ext:MenuItem>
                                                                            <ext:MenuItem ID="mnuChoDuyet" runat="server" Text="2. Chờ duyệt">
                                                                                <Listeners>
                                                                                    <Click Handler="return CheckCurrentRecordID();" />
                                                                                </Listeners>
                                                                                <DirectEvents>
                                                                                    <Click OnEvent="ChuyenTrangThai_Click">
                                                                                        <ExtraParams>
                                                                                            <ext:Parameter Name="TrangThai" Value="2. Chờ duyệt" />
                                                                                        </ExtraParams>
                                                                                    </Click>
                                                                                </DirectEvents>
                                                                            </ext:MenuItem>
                                                                            <ext:MenuItem ID="MenuItem2" runat="server" Text="3. Đã duyệt">
                                                                                <Listeners>
                                                                                    <Click Handler="return CheckCurrentRecordID();" />
                                                                                </Listeners>
                                                                                <DirectEvents>
                                                                                    <Click OnEvent="ChuyenTrangThai_Click">
                                                                                        <ExtraParams>
                                                                                            <ext:Parameter Name="TrangThai" Value="3. Đã duyệt" />
                                                                                        </ExtraParams>
                                                                                    </Click>
                                                                                </DirectEvents>
                                                                            </ext:MenuItem>
                                                                            <ext:MenuItem ID="MenuItem4" runat="server" Text="4. Chưa triển khai">
                                                                                <Listeners>
                                                                                    <Click Handler="return CheckCurrentRecordID();" />
                                                                                </Listeners>
                                                                                <DirectEvents>
                                                                                    <Click OnEvent="ChuyenTrangThai_Click">
                                                                                        <ExtraParams>
                                                                                            <ext:Parameter Name="TrangThai" Value="4. Chưa triển khai" />
                                                                                        </ExtraParams>
                                                                                    </Click>
                                                                                </DirectEvents>
                                                                            </ext:MenuItem>
                                                                            <ext:MenuItem ID="MenuItem5" runat="server" Text="5. Đang triển khai">
                                                                                <Listeners>
                                                                                    <Click Handler="return CheckCurrentRecordID();" />
                                                                                </Listeners>
                                                                                <DirectEvents>
                                                                                    <Click OnEvent="ChuyenTrangThai_Click">
                                                                                        <ExtraParams>
                                                                                            <ext:Parameter Name="TrangThai" Value="5. Đang triển khai" />
                                                                                        </ExtraParams>
                                                                                    </Click>
                                                                                </DirectEvents>
                                                                            </ext:MenuItem>
                                                                            <ext:MenuItem ID="MenuItem6" runat="server" Text="6. Đã hoàn thành">
                                                                                <Listeners>
                                                                                    <Click Handler="return CheckCurrentRecordID();" />
                                                                                </Listeners>
                                                                                <DirectEvents>
                                                                                    <Click OnEvent="ChuyenTrangThai_Click">
                                                                                        <ExtraParams>
                                                                                            <ext:Parameter Name="TrangThai" Value="6. Đã hoàn thành" />
                                                                                        </ExtraParams>
                                                                                    </Click>
                                                                                </DirectEvents>
                                                                            </ext:MenuItem>
                                                                        </Items>
                                                                    </ext:Menu>
                                                                </Menu>
                                                            </ext:MenuItem>
                                                            <ext:MenuItem ID="mnuLocTheoTT" Text="Lọc theo trạng thái">
                                                                <Menu>
                                                                    <ext:Menu ID="Menu1" runat="server">
                                                                        <Items>
                                                                            <ext:MenuItem ID="MenuItem9" runat="server" Text="1. Không được duyệt">
                                                                                <Listeners>
                                                                                    <Click Handler="#{hdfTrangThai}.setValue('1. Không được duyệt');#{Store1}.reload();" />
                                                                                </Listeners>
                                                                            </ext:MenuItem>
                                                                            <ext:MenuItem ID="MenuItem7" runat="server" Text="2. Chờ duyệt">
                                                                                <Listeners>
                                                                                    <Click Handler="#{hdfTrangThai}.setValue('2. Chờ duyệt');#{Store1}.reload();" />
                                                                                </Listeners>
                                                                            </ext:MenuItem>
                                                                            <ext:MenuItem ID="MenuItem8" runat="server" Text="3. Đã duyệt">
                                                                                <Listeners>
                                                                                    <Click Handler="#{hdfTrangThai}.setValue('3. Đã duyệt');#{Store1}.reload();" />
                                                                                </Listeners>
                                                                            </ext:MenuItem>
                                                                            <ext:MenuItem ID="MenuItem10" runat="server" Text="4. Chưa triển khai">
                                                                                <Listeners>
                                                                                    <Click Handler="#{hdfTrangThai}.setValue('4. Chưa triển khai');#{Store1}.reload();" />
                                                                                </Listeners>
                                                                            </ext:MenuItem>
                                                                            <ext:MenuItem ID="MenuItem11" runat="server" Text="5. Đang triển khai">
                                                                                <Listeners>
                                                                                    <Click Handler="#{hdfTrangThai}.setValue('5. Đang triển khai');#{Store1}.reload();" />
                                                                                </Listeners>
                                                                            </ext:MenuItem>
                                                                            <ext:MenuItem ID="MenuItem12" runat="server" Text="6. Đã hoàn thành">
                                                                                <Listeners>
                                                                                    <Click Handler="#{hdfTrangThai}.setValue('6. Đã hoàn thành');#{Store1}.reload();" />
                                                                                </Listeners>
                                                                            </ext:MenuItem>
                                                                        </Items>
                                                                    </ext:Menu>
                                                                </Menu>
                                                            </ext:MenuItem>
                                                            <ext:MenuItem ID="mnuHuyLoc" runat="server" Icon="Cancel" Text="Hủy lọc">
                                                                <Listeners>
                                                                    <Click Handler="#{hdfTrangThai}.reset();#{Store1}.reload();" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                        </Items>
                                                    </ext:Menu>
                                                </Menu>
                                            </ext:Button>
                                            <ext:Button ID="btnTienIch" runat="server" Text="Tiện ích" Icon="Build">
                                                <Menu>
                                                    <ext:Menu runat="server">
                                                        <Items>
                                                            <ext:MenuItem runat="server" Disabled="true" ID="mnuNhanDoiDuLieu" Text="Nhân đôi dữ liệu"
                                                                Icon="DiskMultiple">
                                                                <Listeners>
                                                                    <Click Handler="if(CheckSelectedRows(GridPanel1)){#{wdInputNewPrimaryKey}.show();}" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                        </Items>
                                                    </ext:Menu>
                                                </Menu>
                                            </ext:Button>
                                            <ext:ToolbarFill runat="server" ID="tbfill" />
                                            <ext:TriggerField runat="server" Width="200" AllowBlank="false" IDMode="Static" BlankText="Nhập từ khóa tìm kiếm..."
                                                EmptyText="Nhập từ khóa tìm kiếm..." EnableKeyEvents="true" ID="txtSearch">
                                                <Listeners>
                                                    <KeyPress Fn="enterKeyPressHandler" />
                                                </Listeners>
                                                <Triggers>
                                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                </Triggers>
                                                <Listeners>
                                                    <Blur Handler="this.triggers[0].show();" />
                                                    <TriggerClick Handler="#{txtSearch}.reset();
                                                               #{GridPanel1}.getSelectionModel().clearSelections();
                                                               #{PagingToolbar1}.pageIndex=0;
                                                               #{PagingToolbar1}.doLoad();
                                                               this.triggers[0].hide();" />
                                                </Listeners>
                                            </ext:TriggerField>
                                            <ext:Button Text="Tìm kiếm" Icon="Zoom" runat="server" ID="btnSearch">
                                                <Listeners>
                                                    <Click Handler="#{Store1}.reload();" />
                                                </Listeners>
                                            </ext:Button>
                                        </Items>
                                    </ext:Toolbar>
                                </TopBar>
                                <ColumnModel ID="ColumnModel1" runat="server">
                                    <Columns>
                                        <ext:RowNumbererColumn Locked="true" Header="STT" />
                                        <ext:Column ColumnID="MaKeHoach" Locked="true" Header="Mã" Width="50" Sortable="true"
                                            DataIndex="MaKeHoach">
                                        </ext:Column>
                                        <ext:Column ColumnID="TenkeHoach" Header="Tên khóa đào tạo" DataIndex="TenkeHoach"
                                            Locked="true" Width="300" />
                                        <ext:DateColumn Format="dd/MM/yyyy" ColumnID="TuNgay" Header="Từ ngày" DataIndex="TuNgay"
                                            Width="70" />
                                        <ext:DateColumn DataIndex="DenNgay" Width="70" Header="Đến ngày" Format="dd/MM/yyyy" />
                                        <ext:Column ColumnID="TenChungChi" Header="Chứng chỉ" DataIndex="TenChungChi" Width="250" />
                                        <%-- <ext:Column ColumnID="KinhPhiDuKien" Header="Kinh phí dự kiến" DataIndex="KinhPhiDuKien"
                                        Width="100" />
                                    <ext:Column ColumnID="KinhPhiThucTe" Header="Kinh phí thực tế" DataIndex="KinhPhiThucTe"
                                        Width="100" />
                                    <ext:Column ColumnID="KinhPhiCongTyHoTro" Header="Kinh phí công ty hỗ trợ" DataIndex="KinhPhiCongTyHoTro"
                                        Width="130">
                                    </ext:Column>
                                    <ext:Column ColumnID="KinhPhiNhanVienDong" Header="Kinh phí nhân viên đóng" DataIndex="KinhPhiNhanVienDong"
                                        Width="130">
                                    </ext:Column>--%>
                                        <%--<ext:Column ColumnID="NgayBatDauDangKy" Header="Bắt đầu đăng ký" DataIndex="NgayBatDauDangKy"
                                        Width="100">
                                    </ext:Column>
                                    <ext:Column ColumnID="NgayKetThucDangKy" Header="Kết thúc đăng ký" DataIndex="NgayKetThucDangKy"
                                        Width="100">
                                    </ext:Column>
                                    <ext:Column ColumnID="MucDichKhoaHoc" Header="Mục đích khóa học" DataIndex="MucDichKhoaHoc"
                                        Width="100">
                                    </ext:Column>
                                    <ext:Column ColumnID="NoiDungDaoTao" Header="Nội dung đào tạo" DataIndex="NoiDungDaoTao"
                                        Width="100">
                                    </ext:Column>
                                    <ext:Column ColumnID="DiaDiemDaoTao" Header="Địa điểm đào tạo" DataIndex="DiaDiemDaoTao"
                                        Width="100">
                                    </ext:Column>
                                    <ext:Column ColumnID="ThoiGianDaoTao" Header="Thời gian đào tạo" DataIndex="ThoiGianDaoTao"
                                        Width="100" />--%>
                                        <ext:Column ColumnID="TrangThai" Header="Trạng thái" DataIndex="TrangThai" Width="70">
                                        </ext:Column>
                                        <%--<ext:Column ColumnID="DoiTuongDaoTao" Header="Đối tượng đào tạo" DataIndex="DoiTuongDaoTao"
                                        Width="100">
                                    </ext:Column>
                                    <ext:Column ColumnID="SoLuongHocVien" Header="Số lượng học viên" DataIndex="SoLuongHocVien"
                                        Width="100">
                                    </ext:Column>
                                    <ext:Column ColumnID="LyDoDaoTao" Header="Lý do đào tạo" DataIndex="LyDoDaoTao" Width="150">
                                    </ext:Column>--%>
                                        <ext:Column ColumnID="DonViPhuTrachDaoTao" Header="Đơn vị đào tạo" DataIndex="DonViPhuTrachDaoTao"
                                            Width="150">
                                        </ext:Column>
                                        <%--<ext:Column ColumnID="GhiChu" Header="Ghi chú" DataIndex="GhiChu" Width="60">
                                    </ext:Column>--%>
                                    </Columns>
                                </ColumnModel>
                                <View>
                                    <ext:GroupingView ID="GroupingView1" runat="server" ForceFit="true" MarkDirty="false"
                                        ShowGroupName="false" EnableNoGroups="true" HideGroupedColumn="true" />
                                    <%-- <ext:LockingGridView ID="LockingGridView1" runat="server" />--%>
                                </View>
                                <SelectionModel>
                                    <ext:RowSelectionModel runat="server" ID="checkboxSelection">
                                        <Listeners>
                                            <RowSelect Handler="#{hdfRecordID}.setValue(#{checkboxSelection}.getSelected().id);
                                                            ReloadStoreDetail();" />
                                            <RowDeselect Handler="" />
                                        </Listeners>
                                    </ext:RowSelectionModel>
                                </SelectionModel>
                                <Listeners>
                                    <RowDblClick Handler="return CheckSelectedRows(GridPanel1);" />
                                </Listeners>
                                <BottomBar>
                                    <ext:PagingToolbar ID="PagingToolbar1" EmptyMsg="Hiện không có dữ liệu" NextText="Trang sau"
                                        PageSize="50" PrevText="Trang trước" LastText="Trang cuối cùng" FirstText="Trang đầu tiên"
                                        DisplayMsg="Dòng {0} đến dòng {1} / {2} dòng" runat="server">
                                        <Items>
                                            <ext:Label ID="Label1" runat="server" Text="Số bản ghi trên 1 trang:" />
                                            <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                            <ext:ComboBox ID="ComboBoxPaging" runat="server" Width="80" SelectedIndex="0">
                                                <Items>
                                                    <ext:ListItem Text="50" />
                                                    <ext:ListItem Text="70" />
                                                    <ext:ListItem Text="100" />
                                                    <ext:ListItem Text="200" />
                                                    <ext:ListItem Text="500" />
                                                    <ext:ListItem Text="1000" />
                                                </Items>
                                                <Listeners>
                                                    <Select Handler="#{PagingToolbar1}.pageSize = parseInt(this.getValue()); #{PagingToolbar1}.doLoad();" />
                                                </Listeners>
                                            </ext:ComboBox>
                                        </Items>
                                    </ext:PagingToolbar>
                                </BottomBar>
                                <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                                <%--<DirectEvents>
                                <DblClick OnEvent="btnEdit_Click">
                                </DblClick>
                            </DirectEvents>--%>
                            </ext:GridPanel>
                        </Center>
                        <South Split="true">
                            <ext:TabPanel ID="TabPanel1" runat="server" AnchorHorizontal="100%" Border="false"
                                Height="220">
                                <Items>
                                    <ext:Panel ID="Tab1" Title="Thông tin khóa học" Padding="6" Cls="panelGeneralInformation"
                                        runat="server" CloseAction="Hide">
                                        <Items>
                                            <ext:Container ID="Container1" Layout="ColumnLayout" runat="server" Height="200">
                                                <Items>
                                                    <ext:Container ID="Contain1" Layout="FormLayout" runat="server" ColumnWidth=".45">
                                                        <Items>
                                                            <ext:TextField FieldLabel="Tên khóa học" EnableKeyEvents="true" AnchorHorizontal="95%"
                                                                runat="server" ID="txtTenKhoaHoc">
                                                                <Listeners>
                                                                    <KeyDown Handler="this.blur();" />
                                                                </Listeners>
                                                            </ext:TextField>
                                                            <ext:TextField FieldLabel="Chứng chỉ" AnchorHorizontal="95%" runat="server" ID="txtChungChi">
                                                                <Listeners>
                                                                    <Focus Handler="this.blur();" />
                                                                </Listeners>
                                                            </ext:TextField>
                                                            <ext:TextField FieldLabel="Lý do đào tạo" EnableKeyEvents="true" runat="server" AnchorHorizontal="95%"
                                                                ID="txtLyDoDaoTao">
                                                                <Listeners>
                                                                    <Focus Handler="this.blur();" />
                                                                </Listeners>
                                                            </ext:TextField>
                                                            <ext:TextField FieldLabel="Địa điểm đào tạo" runat="server" AnchorHorizontal="95%"
                                                                ID="txtDiaDiemDaoTao">
                                                                <Listeners>
                                                                    <Focus Handler="this.blur();" />
                                                                </Listeners>
                                                            </ext:TextField>
                                                            <ext:TextField FieldLabel="Thời gian đào tạo" runat="server" AnchorHorizontal="95%"
                                                                ID="txtThoiGianDaoTao">
                                                                <Listeners>
                                                                    <Focus Handler="this.blur();" />
                                                                </Listeners>
                                                            </ext:TextField>
                                                        </Items>
                                                    </ext:Container>
                                                    <ext:Container ID="Container2" Layout="FormLayout" runat="server" ColumnWidth=".3">
                                                        <Items>
                                                            <ext:TextField FieldLabel="Kinh phí dự kiến" runat="server" AnchorHorizontal="95%"
                                                                ID="txtKinhPhiDuKien">
                                                                <Listeners>
                                                                    <Focus Handler="this.blur();" />
                                                                </Listeners>
                                                            </ext:TextField>
                                                            <ext:TextField FieldLabel="Kinh phí thực tế" runat="server" AnchorHorizontal="95%"
                                                                ID="txtKinhPhiThucTe">
                                                                <Listeners>
                                                                    <Focus Handler="this.blur();" />
                                                                </Listeners>
                                                            </ext:TextField>
                                                            <ext:TextField AnchorHorizontal="95%" FieldLabel="Công ty hỗ trợ" EmptyText="Công ty hỗ trợ"
                                                                runat="server" ID="txtCongTyHoTro">
                                                                <Listeners>
                                                                    <Focus Handler="this.blur();" />
                                                                </Listeners>
                                                            </ext:TextField>
                                                            <ext:TextField FieldLabel="NV đóng góp" EmptyText="Nhân viên đóng góp" AnchorHorizontal="95%"
                                                                runat="server" ID="txtNVDongGop">
                                                                <Listeners>
                                                                    <Focus Handler="this.blur();" />
                                                                </Listeners>
                                                            </ext:TextField>
                                                            <ext:TextField FieldLabel="Nội dung đào tạo" runat="server" AnchorHorizontal="95%"
                                                                ID="txtNoiDungDaoTao">
                                                                <Listeners>
                                                                    <Focus Handler="this.blur();" />
                                                                </Listeners>
                                                            </ext:TextField>
                                                        </Items>
                                                    </ext:Container>
                                                    <ext:Container ID="Container3" Layout="FormLayout" runat="server" LabelWidth="120"
                                                        ColumnWidth=".25">
                                                        <Items>
                                                            <ext:TextField FieldLabel="Từ ngày" AnchorHorizontal="95%" runat="server" ID="txtTuNgay">
                                                                <Listeners>
                                                                    <Focus Handler="this.blur();" />
                                                                </Listeners>
                                                            </ext:TextField>
                                                            <ext:TextField FieldLabel="Đến ngày" runat="server" AnchorHorizontal="95%" ID="txtDenNgay">
                                                                <Listeners>
                                                                    <Focus Handler="this.blur();" />
                                                                </Listeners>
                                                            </ext:TextField>
                                                            <ext:TextField FieldLabel="Số lượng học viên" AnchorHorizontal="95%" runat="server"
                                                                ID="txtSoLuongHocVien">
                                                                <Listeners>
                                                                    <Focus Handler="this.blur();" />
                                                                </Listeners>
                                                            </ext:TextField>
                                                            <ext:TextField FieldLabel="Đối tượng đào tạo" runat="server" AnchorHorizontal="95%"
                                                                ID="txtDoiTuongDaoTao">
                                                                <Listeners>
                                                                    <Focus Handler="this.blur();" />
                                                                </Listeners>
                                                            </ext:TextField>
                                                        </Items>
                                                    </ext:Container>
                                                </Items>
                                            </ext:Container>
                                        </Items>
                                    </ext:Panel>
                                    <ext:Panel ID="Tab2" Title="Giáo viên đào tạo" Layout="BorderLayout" runat="server"
                                        CloseAction="Hide">
                                        <Items>
                                            <ext:Hidden ID="hdfCurrentMaDT" runat="server" />
                                            <ext:GridPanel ID="grp_GiaoVienDaoTao" runat="server" Border="false" StripeRows="true"
                                                AnchorHorizontal="100%" Region="Center">
                                                <TopBar>
                                                    <ext:Toolbar runat="server" ID="Toolbar2">
                                                        <Items>
                                                            <ext:Button ID="btnThemGiaoVienDaoTao" Disabled="true" runat="server" Icon="Add"
                                                                Text="Thêm">
                                                                <Menu>
                                                                    <ext:Menu runat="server" ID="s">
                                                                        <Items>
                                                                            <ext:MenuItem Text="Chọn từ danh sách giáo viên">
                                                                                <Listeners>
                                                                                    <Click Handler="wdChonTuDanhSachGiaoVien.show();" />
                                                                                </Listeners>
                                                                            </ext:MenuItem>
                                                                            <ext:MenuItem Text="Nhập mới">
                                                                                <Listeners>
                                                                                    <Click Handler="wdGiaoVien.show();" />
                                                                                </Listeners>
                                                                            </ext:MenuItem>
                                                                        </Items>
                                                                    </ext:Menu>
                                                                </Menu>
                                                            </ext:Button>
                                                            <ext:Button ID="Button18" Disabled="true" runat="server" Icon="Delete" Text="Xóa">
                                                                <Listeners>
                                                                    <Click Handler="RemoveItemOnGrid(grp_GiaoVienDaoTao, grp_GiaoVienDaoTaoStore, '2');" />
                                                                </Listeners>
                                                            </ext:Button>
                                                            <ext:Button runat="server" Disabled="true" ID="btnSuaGiaoVien" Icon="Pencil" Text="Sửa">
                                                                <Listeners>
                                                                    <Click Handler="return CheckSelectedRecord(#{grp_GiaoVienDaoTao},#{grp_GiaoVienDaoTaoStore});#{btn_UpdateClose}.hide();#{Button17}.hide();#{btn_EditGiaoVien}.show();" />
                                                                </Listeners>
                                                                <DirectEvents>
                                                                    <Click OnEvent="btnSuaGiaoVien_Click">
                                                                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                                    </Click>
                                                                </DirectEvents>
                                                            </ext:Button>
                                                        </Items>
                                                    </ext:Toolbar>
                                                </TopBar>
                                                <View>
                                                    <ext:LockingGridView ID="LockingGridView2" runat="server" />
                                                </View>
                                                <Store>
                                                    <ext:Store ID="grp_GiaoVienDaoTaoStore" runat="server" AutoSave="true" ShowWarningOnFailure="false"
                                                        OnBeforeStoreChanged="HandleChangesGiaoVien" SkipIdForNewRecords="false" RefreshAfterSaving="None"
                                                        OnRefreshData="grp_GiaoVienDaoTaoStore_OnRefreshData">
                                                        <Reader>
                                                            <ext:JsonReader IDProperty="MaGV">
                                                                <Fields>
                                                                    <ext:RecordField Name="MaGV" />
                                                                    <ext:RecordField Name="HoTenGV" />
                                                                    <ext:RecordField Name="ChucVu" />
                                                                    <ext:RecordField Name="DonViCongTac" />
                                                                    <ext:RecordField Name="HocVan" />
                                                                    <ext:RecordField Name="DiaChiLienHe" />
                                                                    <ext:RecordField Name="Email" />
                                                                    <ext:RecordField Name="DiDong" />
                                                                    <ext:RecordField Name="DTCoQuan" />
                                                                    <ext:RecordField Name="KinhNghiemGiangDay" />
                                                                    <ext:RecordField Name="NhanXet" />
                                                                    <ext:RecordField Name="LaNhanvienCty" />
                                                                    <ext:RecordField Name="GioiTinh" Type="String" />
                                                                    <ext:RecordField Name="NgaySinh" />
                                                                </Fields>
                                                            </ext:JsonReader>
                                                        </Reader>
                                                    </ext:Store>
                                                </Store>
                                                <ColumnModel ID="ColumnModel5" runat="server">
                                                    <Columns>
                                                        <ext:RowNumbererColumn Header="STT" Locked="true" Width="30" />
                                                        <ext:Column Header="Mã giáo viên" Width="75" Locked="true" DataIndex="MaGV">
                                                        </ext:Column>
                                                        <ext:Column Header="Họ tên" Width="140" Locked="true" DataIndex="HoTenGV">
                                                        </ext:Column>
                                                        <ext:Column Header="Giới tính" Width="60" DataIndex="GioiTinh">
                                                            <Renderer Fn="GetGenderTrueFalse" />
                                                        </ext:Column>
                                                        <ext:DateColumn Format="dd/MM/yyyy" Header="Ngày sinh" Width="90" DataIndex="NgaySinh">
                                                        </ext:DateColumn>
                                                        <ext:Column Header="Di động" Width="90" DataIndex="DiDong">
                                                        </ext:Column>
                                                        <%--<ext:Column Header="Chức vụ" Width="100" DataIndex="ChucVu">
                                                    </ext:Column>--%>
                                                        <ext:Column Header="Đơn vị công tác" Width="150" DataIndex="DonViCongTac">
                                                        </ext:Column>
                                                        <ext:Column Header="Trình độ" Width="100" DataIndex="HocVan">
                                                        </ext:Column>
                                                        <ext:Column Header="Địa chỉ liên hệ" Width="150" DataIndex="DiaChiLienHe">
                                                        </ext:Column>
                                                        <ext:Column Header="Email" Width="100" DataIndex="Email">
                                                        </ext:Column>
                                                        <%--<ext:Column Header="Điện thoại CQ" Width="120" DataIndex="DTCoQuan">
                                                    </ext:Column>--%>
                                                        <ext:Column Header="Kinh nghiệm giảng dạy" Width="150" DataIndex="KinhNghiemGiangDay">
                                                        </ext:Column>
                                                        <ext:Column Header="Nhận xét" Width="120" DataIndex="NhanXet">
                                                        </ext:Column>
                                                        <ext:Column Header="Là nhân viên công ty" Width="120" DataIndex="LaNhanvienCty">
                                                            <Renderer Fn="GetBooleanIcon" />
                                                        </ext:Column>
                                                    </Columns>
                                                </ColumnModel>
                                                <SelectionModel>
                                                    <ext:RowSelectionModel ID="RowSelectionModel4" runat="server" SingleSelect="true">
                                                        <Listeners>
                                                            <RowSelect Handler="Button18.enable();" />
                                                            <RowDeselect Handler="Button18.disable();" />
                                                        </Listeners>
                                                    </ext:RowSelectionModel>
                                                </SelectionModel>
                                                <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                                                <%--<DirectEvents>
                                                <DblClick OnEvent="btnSuaGiaoVien_Click">
                                                </DblClick>
                                            </DirectEvents>--%>
                                            </ext:GridPanel>
                                        </Items>
                                        <Listeners>
                                            <Activate Handler="if(hdfCurrentMaDT.getValue()!=hdfRecordID.getValue()){
                                                              grp_GiaoVienDaoTaoStore.reload();
                                                              hdfCurrentMaDT.setValue(hdfRecordID.getValue());
                                                          }" />
                                            <Close Handler="#{ShowTab2}.setDisabled(false);" />
                                        </Listeners>
                                    </ext:Panel>
                                    <ext:Panel ID="Tab3" Title="Các khoản chi phí" Layout="BorderLayout" runat="server"
                                        CloseAction="Hide">
                                        <Items>
                                            <ext:Hidden runat="server" ID="hdfChiPhi" />
                                            <ext:Hidden runat="server" ID="hdfMaDaoTaoChiPhi" />
                                            <ext:GridPanel ID="grp_CacKhoanChiPhi" runat="server" Border="false" StripeRows="true"
                                                AnchorHorizontal="100%" Region="Center" AutoExpandColumn="TenChiPhi">
                                                <TopBar>
                                                    <ext:Toolbar runat="server" ID="tbgrp_CacKhoanChiPhi">
                                                        <Items>
                                                            <ext:Button ID="Button3" Disabled="true" runat="server" Icon="Add" Text="Thêm">
                                                                <Listeners>
                                                                    <Click Handler="wdCacKhoanChiPhi.show();" />
                                                                </Listeners>
                                                            </ext:Button>
                                                            <ext:Button ID="Button6" Disabled="true" runat="server" Icon="Delete" Text="Xóa">
                                                                <Listeners>
                                                                    <Click Handler="RemoveItemOnGrid(grp_CacKhoanChiPhi, grp_CacKhoanChiPhiStore, '3');" />
                                                                </Listeners>
                                                            </ext:Button>
                                                            <ext:Button runat="server" Disabled="true" ID="btnSuaChiPhi" Icon="Pencil" Text="Sửa">
                                                                <Listeners>
                                                                    <Click Handler="#{btnCapNhatChiPhi}.hide();#{Button7}.hide();#{Button9}.show();return CheckSelectedRecord(#{grp_CacKhoanChiPhi},#{grp_CacKhoanChiPhiStore});" />
                                                                </Listeners>
                                                                <DirectEvents>
                                                                    <Click OnEvent="btnSuaChiPhi_Click">
                                                                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                                    </Click>
                                                                </DirectEvents>
                                                            </ext:Button>
                                                        </Items>
                                                    </ext:Toolbar>
                                                </TopBar>
                                                <Store>
                                                    <ext:Store ID="grp_CacKhoanChiPhiStore" runat="server" AutoSave="true" ShowWarningOnFailure="false"
                                                        OnBeforeStoreChanged="HandleChangesChiPhi" SkipIdForNewRecords="false" RefreshAfterSaving="None"
                                                        OnRefreshData="grp_CacKhoanChiPhiStore_OnRefreshData">
                                                        <Reader>
                                                            <ext:JsonReader IDProperty="ID">
                                                                <Fields>
                                                                    <ext:RecordField Name="ID" />
                                                                    <ext:RecordField Name="FR_KEY" />
                                                                    <ext:RecordField Name="TenChiPhi" />
                                                                    <ext:RecordField Name="SoTien" />
                                                                    <ext:RecordField Name="NguonChi" />
                                                                </Fields>
                                                            </ext:JsonReader>
                                                        </Reader>
                                                    </ext:Store>
                                                </Store>
                                                <ColumnModel ID="ColumnModel3" runat="server">
                                                    <Columns>
                                                        <ext:RowNumbererColumn Header="STT" Width="30" />
                                                        <ext:Column Header="Tên khoản chi phí" Width="75" DataIndex="TenChiPhi">
                                                        </ext:Column>
                                                        <ext:Column Header="Nguồn chi" Width="270" DataIndex="NguonChi">
                                                        </ext:Column>
                                                        <ext:Column Header="Số tiền" Width="150" DataIndex="SoTien">
                                                            <Renderer Fn="RenderVND" />
                                                        </ext:Column>
                                                    </Columns>
                                                </ColumnModel>
                                                <SelectionModel>
                                                    <ext:RowSelectionModel ID="RowSelectionModel2" runat="server">
                                                        <Listeners>
                                                            <RowSelect Handler="#{hdfChiPhi}.setValue(#{RowSelectionModel2}.getSelected().id);" />
                                                        </Listeners>
                                                    </ext:RowSelectionModel>
                                                </SelectionModel>
                                                <%--<DirectEvents>
                                                <DblClick OnEvent="btnSuaChiPhi_Click">
                                                </DblClick>
                                            </DirectEvents>--%>
                                                <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                                            </ext:GridPanel>
                                        </Items>
                                        <Listeners>
                                            <Activate Handler="if(hdfMaDaoTaoChiPhi.getValue()!= hdfRecordID.getValue()){
                                                              #{grp_CacKhoanChiPhiStore}.reload();
                                                              hdfMaDaoTaoChiPhi.setValue(hdfRecordID.getValue());
                                                           }" />
                                        </Listeners>
                                    </ext:Panel>
                                    <ext:Panel ID="Tab4" Title="Nhân viên tham gia đào tạo" Layout="BorderLayout" runat="server"
                                        CloseAction="Hide">
                                        <Items>
                                            <ext:Hidden runat="server" ID="hdfCurrentMaDaoTao" />
                                            <ext:GridPanel ID="grp_nhanVienThamGiaDaoTao" runat="server" Border="false" StripeRows="true"
                                                AnchorHorizontal="100%" Region="Center">
                                                <TopBar>
                                                    <ext:Toolbar runat="server" ID="Toolbar1">
                                                        <Items>
                                                            <ext:Button ID="Button10" Disabled="true" runat="server" Icon="Add" Text="Thêm">
                                                                <Listeners>
                                                                    <Click Handler="ucChooseEmployee1_wdChooseUser.show();" />
                                                                </Listeners>
                                                            </ext:Button>
                                                            <ext:Button ID="Button11" Disabled="true" runat="server" Icon="Delete" Text="Xóa">
                                                                <Listeners>
                                                                    <Click Handler="RemoveItemOnGrid(grp_nhanVienThamGiaDaoTao, grp_nhanVienThamGiaDaoTaoStore, '4');" />
                                                                </Listeners>
                                                            </ext:Button>
                                                        </Items>
                                                    </ext:Toolbar>
                                                </TopBar>
                                                <View>
                                                    <ext:LockingGridView ID="LockingGridView1" runat="server" />
                                                </View>
                                                <Store>
                                                    <ext:Store ID="grp_nhanVienThamGiaDaoTaoStore" runat="server" AutoSave="true" ShowWarningOnFailure="false"
                                                        OnBeforeStoreChanged="HandleChangesDaoTao" SkipIdForNewRecords="false" RefreshAfterSaving="None"
                                                        OnRefreshData="grp_nhanVienThamGiaDaoTaoStore_OnRefreshData">
                                                        <Reader>
                                                            <ext:JsonReader IDProperty="ID">
                                                                <Fields>
                                                                    <ext:RecordField Name="ID" />
                                                                    <ext:RecordField Name="MaCB" />
                                                                    <ext:RecordField Name="TenCB" />
                                                                    <ext:RecordField Name="PhongBan" />
                                                                    <ext:RecordField Name="DiaDiemLamViec" />
                                                                    <ext:RecordField Name="ViTriCongViec" />
                                                                    <ext:RecordField Name="DonViCongTac" />
                                                                    <ext:RecordField Name="DaThamGia" />
                                                                    <ext:RecordField Name="Diem" />
                                                                    <ext:RecordField Name="KetQua" />
                                                                    <ext:RecordField Name="NhanXetCuaGiaoVien" />
                                                                    <ext:RecordField Name="SoTienNhanVienDong" />
                                                                    <ext:RecordField Name="SoTienCongTyDong" />
                                                                    <ext:RecordField Name="GhiChu" />
                                                                    <ext:RecordField Name="DiemDanh" />
                                                                </Fields>
                                                            </ext:JsonReader>
                                                        </Reader>
                                                    </ext:Store>
                                                </Store>
                                                <ColumnModel ID="ColumnModel4" runat="server">
                                                    <Columns>
                                                        <ext:RowNumbererColumn Header="STT" Locked="true" Width="30" />
                                                        <ext:Column Header="Mã cán bộ" Width="75" Locked="true" DataIndex="MaCB">
                                                        </ext:Column>
                                                        <ext:Column Header="Họ tên" Width="130" Locked="true" DataIndex="TenCB">
                                                        </ext:Column>
                                                        <ext:Column Header="Phòng ban" Width="150" DataIndex="PhongBan">
                                                        </ext:Column>
                                                        <ext:Column Header="Địa điểm làm viêc" Width="150" DataIndex="DiaDiemLamViec">
                                                        </ext:Column>
                                                        <%--<ext:Column Header="Vị trí công việc" Width="150" DataIndex="ViTriCongViec">
                                                    </ext:Column>--%>
                                                        <ext:Column Header="Đã tham gia" Width="90" DataIndex="DaThamGia">
                                                            <Renderer Fn="RenderDaThamGia" />
                                                            <Editor>
                                                                <ext:Checkbox runat="server" ID="chkDaThamGia" />
                                                            </Editor>
                                                        </ext:Column>
                                                        <ext:Column Header="Điểm danh" Width="60" Align="Right" DataIndex="DiemDanh">
                                                            <Editor>
                                                                <ext:NumberField runat="server" AllowNegative="false" ID="txtDiemDanh" />
                                                            </Editor>
                                                        </ext:Column>
                                                        <ext:Column Header="Điểm" Width="60" Align="Right" DataIndex="Diem">
                                                            <Editor>
                                                                <ext:NumberField runat="server" AllowNegative="false" ID="txtdiem" />
                                                            </Editor>
                                                        </ext:Column>
                                                        <ext:Column Header="Kết quả" Width="100" DataIndex="KetQua">
                                                            <Editor>
                                                                <ext:TextField runat="server" ID="txtKQ" />
                                                            </Editor>
                                                        </ext:Column>
                                                        <ext:Column Header="Giáo viên nhận xét" Width="200" DataIndex="NhanXetCuaGiaoVien">
                                                            <Editor>
                                                                <ext:TextField runat="server" ID="txtGiaoVienNhanXet" />
                                                            </Editor>
                                                        </ext:Column>
                                                        <ext:Column Header="Nhân viên phải đóng" Width="120" DataIndex="SoTienNhanVienDong">
                                                            <Renderer Fn="RenderVND0" />
                                                            <Editor>
                                                                <ext:NumberField runat="server" ID="nvphaidong" />
                                                            </Editor>
                                                        </ext:Column>
                                                        <ext:Column Header="Công ty hỗ trợ" Width="90" DataIndex="SoTienCongTyDong">
                                                            <Renderer Fn="RenderVND0" />
                                                            <Editor>
                                                                <ext:NumberField runat="server" ID="ctyHoTro" />
                                                            </Editor>
                                                        </ext:Column>
                                                        <ext:Column Header="Ghi Chu" Width="200" DataIndex="GhiChu">
                                                            <Editor>
                                                                <ext:TextField runat="server" ID="txtGhiChu" />
                                                            </Editor>
                                                        </ext:Column>
                                                    </Columns>
                                                </ColumnModel>
                                                <SelectionModel>
                                                    <ext:RowSelectionModel ID="RowSelectionModel3" runat="server">
                                                        <Listeners>
                                                            <RowSelect Handler="" />
                                                        </Listeners>
                                                    </ext:RowSelectionModel>
                                                </SelectionModel>
                                                <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                                            </ext:GridPanel>
                                        </Items>
                                        <Listeners>
                                            <Activate Handler="if(#{hdfCurrentMaDaoTao}.getValue()!=#{hdfRecordID}.getValue()){
                                                               #{grp_nhanVienThamGiaDaoTaoStore}.reload();
                                                               hdfCurrentMaDaoTao.setValue(hdfRecordID.getValue());
                                                           }" />
                                        </Listeners>
                                    </ext:Panel>
                                </Items>
                            </ext:TabPanel>
                        </South>
                    </ext:BorderLayout>
                </Items>
            </ext:Viewport>
            <uc1:ucChooseEmployee ID="ucChooseEmployee1" runat="server" />
        </div>
    </form>
</body>
</html>
