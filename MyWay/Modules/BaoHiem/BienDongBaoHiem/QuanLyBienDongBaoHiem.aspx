<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QuanLyBienDongBaoHiem.aspx.cs"
    Inherits="Modules_BaoHiem_QuanLyBienDongBaoHiem" %>

<!DOCTYPE html>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
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
        
        .x-layout-collapsed-west
        {
            background: url(../../../Resource/images/LocTheoPhongBan.png) no-repeat center !important;
        }
        
        div#panel1-xcollapsed .x-layout-collapsed-west
        {
            background: url(../../../Resource/images/DanhSachChungTu.png) no-repeat center !important;
        }
        /*.x-tab-strip-top {
            display: none !important;
        }*/
        #pnlTruyThoaithu
        {
            display: normal !important;
        }
        
        #pnReportPanel1 .x-tab-panel-header
        {
            display: none !important;
        }
        
        #pnReportPanel2 .x-tab-panel-header
        {
            display: none !important;
        }
        
        #TabPanel2 .x-tab-panel-header
        {
            display: none !important;
        }
        
        div#panel1-xsplit
        {
            border-left: 1px solid #98C0F4 !important;
            border-right: 1px solid #98C0F4 !important;
        }
    </style>
    <script src="../../../Resource/js/Extcommon.js" type="text/javascript"></script>
    <script type="text/javascript">
        var check_themmoi_chungtu = function () {
            if (cboloaichungtu.getValue() == '') {
                alert('Bạn phải chọn loại chứng từ');
                cboloaichungtu.focus();
                return false;
            }
            if (txttenchungtu.getValue() == '') {
                alert('Bạn chưa nhập tên chứng từ');
                txttenchungtu.focus();
                return false;
            }
            return true;
        }
        var reset_dauphieu = function () {
            cboloaichungtu.reset();
            ThoiGianBaoCao.reset(); txttenchungtu.reset(); NamBaoCao.reset(); txtsochungtu.reset(); txtSoTaiKhoan.reset();
            txtMoTai.reset(); txtTongSoLaoDong.reset(); txtTrongDoNu.reset(); txtTongQuyLuong.reset();
        }
        var CheckThemMoi = function () {
            if (tgfChonBienDong1.getValue() == '') {
                alert('Bạn chưa chọn loại biến động');
                tgfChonBienDong1.focus();
                return false;
            }
            if (dfNgayDangKyVoiCQBH.getValue() == '') {
                alert('Bạn chưa chọn ngày đăng ký với cơ quan bảo hiểm');
                dfNgayDangKyVoiCQBH.focus();
                return false;
            }
            if (dfTuNgay1.getValue() == '') {
                alert('Bạn chưa chọn từ ngày');
                dfTuNgay.focus();
                return false;
            }
            if (dfDenNgay1.getValue() != '' && dfTuNgay1.getValue() > dfDenNgay1.getValue()) {
                alert('Ngày kết thức phải lớn hơn ngày bắt đầu');
                dfDenNgay1.focus();
                return false;
            }
            return true;
        }

        var enterKeyToSearch = function (f, e) {
            if (e.getKey() == e.ENTER) {
                PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad();
                //                grpBienDongBaoHiemStore.reload();
                grpChiTietNhanVienStore.removeAll(); Button1.disable();
            }
            if (this.getValue() != '') {
                this.triggers[0].show();
            }
        }

        var checkdongy = function () {
            if (hdfLoaiBienDong.getValue() == '') {
                alert('Bạn phải chọn loại biến động');
                return false;
            }
            return true;
        }
        var check_baocao = function () {
            if (hdfMadauphieu.getValue() == '') {
                alert('Bạn phải chọn 1 loại chứng từ');
                return false;
            }
            wdShowReport.show();
            return true;
        }
        var ResetControl = function () {
            dfNgayDangKyVoiCQBH.reset();
            txtMaCanBo1.reset(); dfNgaySinh1.reset(); txtLuongDongBH1.reset();
            txtHoTen1.reset(); txtSoSoBHXH1.reset(); txtThoiGianDongBHXH1.reset();
            tgfChonBienDong1.reset(); dfTuNgay1.reset();
            chkBHXH1.reset(); chkBHYT1.reset(); chkBHTN1.reset(); dfDenNgay1.reset(); txtDienGiai1.reset(); txtLuongDongBHXHCu1.reset();
            txtPhuCapCVCu1.reset(); txtPhuCapTNVKCu1.reset(); txtPhuCapTNNCu1.reset();
            txtLuongDongBHXHMoi1.reset(); txtPhuCapCVMoi1.reset(); txtPhuCapTNVKMoi1.reset();
            txtPhuCapTNNMoi1.reset(); Checkbox4.reset(); ComboBox3.reset(); SpinnerField1.reset();
            ComboBox4.reset(); SpinnerField2.reset(); ComboBox5.reset(); SpinnerField3.reset();
            Checkbox5.reset(); NumberField2.reset(); Checkbox6.reset(); NumberField3.reset();
            Checkbox7.reset(); NumberField4.reset();
            btnCapNhat1.hide();
            btnCapNhatSua1.hide();
            dfDenNgay1.setMinValue(null);
            dfTuNgay1.setMaxValue(null);
            try {
                nfTruyThuBHXH.reset();
                nfTruyThuBHYT.reset();
                nfThoaiThuBHXH.reset();
                nfThoaiThuBHYT.reset();
            } catch (e) {

            }

        }
        var ClearControlThongTin = function () {
            txtTTLuongBHCu.reset(); txtTTPhuCapCVCu.reset(); txtTTPCTNNCu.reset();
            txtTTPCTNVKCu.reset(); txtTTSoQD.reset(); dfTTNgayHieuLuc.reset();
            dfTTNgayHieuLuc.setMaxValue(); dfTTNgayHieuLuc.setMinValue();
            txtTTLuongBHMoi.reset(); txtTTPhuCapCVMoi.reset(); txtTTTenQD.reset();
            dfTTNgayHetHieuLuc.reset(); dfTTNgayHetHieuLuc.setMaxValue();
            dfTTNgayHetHieuLuc.setMinValue(); txtTTPCTNNMoi.reset(); txtTTPCTNVKMoi.reset();
        }
        var XoaDongBienDong = function (grid, Store) {
            Ext.Msg.confirm('Xác nhận', 'Bạn có chắc chắn muốn xóa không ?', function (btn) {
                if (btn == "yes") {
                    try {
                        grid.getRowEditor().stopEditing();
                    } catch (e) {

                    }
                    var s = grid.getSelectionModel().getSelections();
                    for (var i = 0, r; r = s[i]; i++) {
                        Store.remove(r);
                        Store.commitChanges();
                        Ext.net.DirectMethods.XoaChiTietBienDong(r.data.IDBienDongBaoHiem);
                        Button5.disable();
                        Button2.disable();
                    }
                }
            });
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
        var RenderSoNgay = function (value, p, record) {

            if (value == null || value == "") {
                return "0" + " ngày";
            }

            return value + " ngày";
        }

        var RemoveItemOnGrid_dauphieu = function (grid, Store) {
            Ext.Msg.confirm('Xác nhận', 'Bạn có chắc chắn muốn xóa không ?', function (btn) {
                if (btn == "yes") {
                    try {
                        grid.getRowEditor().stopEditing();

                    } catch (e) {

                    }
                    var s = grid.getSelectionModel().getSelections();
                    for (var i = 0, r; r = s[i]; i++) {
                        Store.remove(r);
                        Store.commitChanges();
                        Ext.net.DirectMethods.DeleteRecord_dauphieu(r.data.IdDauPhieu);
                        btnXoaTenCT.disable();
                        btnSuaTenCT.disable();
                    }
                }
            });
        }
        var SetTenChungTu = function () {
            if (cboloaichungtu.getValue()) {
                txttenchungtu.setValue(cboloaichungtu.getValue() + ' ' + ThoiGianBaoCao.getText() + '/' + NamBaoCao.getValue());
            }
        }

        var SetTuNgayDenNgay = function (grid, Store) {
            var s = grid.getSelectionModel().getSelections();
            for (var i = 0, r; r = s[i]; i++) {
                //Store.commitChanges();
                if (r.data.IdDauPhieu == hdfMadauphieu.getValue()) {
                    hdfTuNgay.setValue(r.data.TuNgay);
                    hdfDenNgay.setValue(r.data.DenNgay);
                    return;
                }
                //Ext.net.DirectMethods.ThemNhanVienVaoDongBaoHiem(r.data.MaNhanVien, r.data.BHXH, r.data.BHYT, r.data.BHTN, r.data.LuongBaoHiem);
            }
        }
        var ReloadCenterGrid = function (grid, Store) {
            var s = grid.getSelectionModel().getSelections();
            for (var i = 0, r; r = s[i]; i++) {
                if (hdfMadauphieu.getValue() == r.data.IdDauPhieu) {
                    hdfTuNgay.setValue(r.data.TuNgay);
                    hdfDenNgay.setValue(r.data.DenNgay);
                    continue;
                }
            }
            PagingToolbar5.pageIndex = 0; PagingToolbar5.doLoad();
        }
        var enterKeyPressHandler_quanlydongbaohiem = function (f, e) {
            if (e.getKey() == e.ENTER) {
                grpNhanVienBienDongThoiGianDongBaoHiem_Store.reload();
            }
            if (this.getValue() != '') {
                this.triggers[0].show();
            }
        }
        var hideTruyThu = function () {
            nfTruyThuBHXH.hide();
            nfTruyThuBHYT.hide();
            Container2.setHeight(0);
        }
        var showTruyThu = function () {
            nfTruyThuBHXH.show();
            nfTruyThuBHYT.show();
            Container2.setHeight(30);
        }
        var hideThoaiThu = function () {
            nfThoaiThuBHXH.hide();
            nfThoaiThuBHYT.hide();
            Container2.setHeight(0);
        }
        var showThoaiThu = function () {
            nfThoaiThuBHXH.show();
            nfThoaiThuBHYT.show();
            Container2.setHeight(30);
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
    </script>
    <script src="../../../Resource/js/RenderJS.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager runat="server" ID="RM" />
        <ext:Hidden runat="server" ID="hdfMaDonVi" />
        <ext:Hidden runat="server" ID="hdfRecordID">
        </ext:Hidden>
        <ext:Hidden runat="server" ID="hdfMaNhanVien" />
        <ext:Hidden runat="server" ID="hdfIdNhanVien_BaoHiem" />
        <ext:Hidden runat="server" ID="hdfwdShow" />
        <ext:Hidden runat="server" ID="hdfIDLoaiCheDo" />
        <ext:Hidden runat="server" ID="hdfIDQuyDinhBienDong" />
        <ext:Hidden runat="server" ID="hdfMaLoaiBienDong" />
        <ext:Hidden runat="server" ID="hdfLoaiBienDong" />
        <ext:Hidden runat="server" ID="hdfChiTietID" />
        <ext:Hidden runat="server" ID="hdfIsBHXH" />
        <ext:Hidden runat="server" ID="hdfIsBHYT" />
        <ext:Hidden runat="server" ID="hdfIsBHTN" />
        <ext:Hidden runat="server" ID="hdfTuNgay" />
        <ext:Hidden runat="server" ID="hdfDenNgay" />
        <ext:Hidden runat="server" ID="hdfMenuID" />
        <ext:Store ID="grpDanhSachLoaiBienDong_Store" AutoLoad="false" runat="server">
            <Proxy>
                <ext:HttpProxy Method="GET" Url="../QuyDinhChung/HandlerBHQUYDINHBIENDONG.ashx" />
            </Proxy>
            <AutoLoadParams>
                <ext:Parameter Name="start" Value="={0}" />
                <ext:Parameter Name="limit" Value="={15}" />
            </AutoLoadParams>
            <BaseParams>
                <ext:Parameter Name="SearchKey" Value="#{txtSearchKey}.getValue()" Mode="Raw" />
                <ext:Parameter Name="MaDonVi" Value="#{hdfMaDonVi}.getValue()" Mode="Raw" />
            </BaseParams>
            <Reader>
                <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="IDQuyDinhBienDong">
                    <Fields>
                        <ext:RecordField Name="IDQuyDinhBienDong" />
                        <ext:RecordField Name="MaBienDong" />
                        <ext:RecordField Name="TenBienDong" />
                        <ext:RecordField Name="LoaiAnhHuong" />
                        <ext:RecordField Name="TenCheDoBaoHiem" />
                        <ext:RecordField Name="IsBHXH" />
                        <ext:RecordField Name="IsBHYT" />
                        <ext:RecordField Name="IsBHTN" />
                        <ext:RecordField Name="DangSuDung" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        <ext:Store ID="grpChiTietNhanVienStore" AutoLoad="false" runat="server">
            <Proxy>
                <ext:HttpProxy Json="true" Method="GET" Url="HandlerChiTietBienDongBaoHiem.ashx" />
            </Proxy>
            <AutoLoadParams>
                <ext:Parameter Name="start" Value="={0}" />
                <ext:Parameter Name="limit" Value="={5}" />
            </AutoLoadParams>
            <BaseParams>
                <%-- <ext:Parameter Name="MaDonVi" Value="#{hdfMaDonVi}.getValue()" Mode="Raw" />--%>
                <ext:Parameter Name="MaNhanVien" Value="#{hdfMaNhanVien}.getValue()" Mode="Raw" />
                <ext:Parameter Name="SearchKey" Value="#{txtFullName}.getValue()" Mode="Raw" />
                <ext:Parameter Name="TuNgay" Value="#{hdfTuNgay}.getValue()" Mode="Value" />
                <ext:Parameter Name="DenNgay" Value="#{hdfDenNgay}.getValue()" Mode="Value" />
            </BaseParams>
            <Reader>
                <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="IDBienDongBaoHiem">
                    <Fields>
                        <ext:RecordField Name="IDBienDongBaoHiem" />
                        <ext:RecordField Name="IDNhanVien_BaoHiem" />
                        <ext:RecordField Name="MaBienDong" />
                        <ext:RecordField Name="TenBienDong" />
                        <ext:RecordField Name="TuNgay" />
                        <ext:RecordField Name="DenNgay" />
                        <ext:RecordField Name="SoNgayNghi" />
                        <ext:RecordField Name="TienLuongCu" />
                        <ext:RecordField Name="PhuCapCVCu" />
                        <ext:RecordField Name="PhuCapNgheCu" />
                        <ext:RecordField Name="PhuCapTNVKCu" />
                        <ext:RecordField Name="TienLuongMoi" />
                        <ext:RecordField Name="PhuCapCVMoi" />
                        <ext:RecordField Name="PhuCapTNNgheMoi" />
                        <ext:RecordField Name="PhuCapTNVKMoi" />
                        <ext:RecordField Name="KhongTraThe" />
                        <ext:RecordField Name="DaCoSo" />
                        <ext:RecordField Name="DaDuyet" />
                        <ext:RecordField Name="DateCreate" />
                        <ext:RecordField Name="ThangBienDong" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        <ext:Store ID="grpBienDongBaoHiemStore" ShowWarningOnFailure="false" SkipIdForNewRecords="false"
            runat="server" GroupField="TrangThai" AutoLoad="true">
            <Proxy>
                <ext:HttpProxy Json="true" Method="GET" Url="HandlerQuanLyBienDong.ashx" />
            </Proxy>
            <AutoLoadParams>
                <ext:Parameter Name="start" Value="={0}" />
                <ext:Parameter Name="limit" Value="={15}" />
            </AutoLoadParams>
            <BaseParams>
                <ext:Parameter Name="MaDonVi" Value="#{hdfMaDonVi}.getValue()" Mode="Raw" />
                <ext:Parameter Name="SearchKey" Value="#{txtFullName}.getValue()" Mode="Raw" />
            </BaseParams>
            <Reader>
                <ext:JsonReader Root="Data" IDProperty="MaNhanVien" TotalProperty="TotalRecords">
                    <Fields>
                        <ext:RecordField Name="IDNhanVien_BaoHiem" />
                        <ext:RecordField Name="MaNhanVien" />
                        <ext:RecordField Name="HoTen" />
                        <ext:RecordField Name="PhongBan" />
                        <ext:RecordField Name="ThoiGianDongBaoHiem" />
                        <ext:RecordField Name="LuongBaoHiem" />
                        <ext:RecordField Name="PhuCapCV" />
                        <ext:RecordField Name="PhuCapTNN" />
                        <ext:RecordField Name="PhuCapTNVK" />
                        <ext:RecordField Name="PhuCapKhac" />
                        <ext:RecordField Name="DangDongBHXH" />
                        <ext:RecordField Name="DangDongBHYT" />
                        <ext:RecordField Name="DangDongBHTN" />
                        <ext:RecordField Name="TrangThai" />
                        <ext:RecordField Name="DaNghi" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        <ext:Store ID="grpChiTietBaoCaoStore" runat="server" ShowWarningOnFailure="false"
            SkipIdForNewRecords="false" GroupField="TrangThai" AutoLoad="false" GroupDir="ASC">
            <Proxy>
                <ext:HttpProxy Json="true" Method="GET" Url="HandlerDanhSachBienDong.ashx" />
            </Proxy>
            <AutoLoadParams>
                <ext:Parameter Name="start" Value="={0}" />
                <ext:Parameter Name="limit" Value="={15}" />
            </AutoLoadParams>
            <BaseParams>
                <ext:Parameter Name="MaDonVi" Value="#{hdfMaDonVi}.getValue()" Mode="Raw" />
                <ext:Parameter Name="SearchKey" Value="''" Mode="Raw" />
                <ext:Parameter Name="TuNgay" Value="#{hdfTuNgay}.getValue()" Mode="Raw" />
                <ext:Parameter Name="DenNgay" Value="#{hdfDenNgay}.getValue()" Mode="Raw" />
            </BaseParams>
            <Reader>
                <ext:JsonReader Root="Data" TotalProperty="TotalRecords">
                    <Fields>
                        <ext:RecordField Name="IDBienDongBaoHiem" />
                        <ext:RecordField Name="IDQuyDinhBienDong" />
                        <ext:RecordField Name="IDNhanVien_BaoHiem" />
                        <ext:RecordField Name="MaCanBo" />
                        <ext:RecordField Name="HoTen" />
                        <ext:RecordField Name="MaSo" />
                        <ext:RecordField Name="NgaySinh" />
                        <ext:RecordField Name="GioiTinh" />
                        <ext:RecordField Name="TenBienDong" />
                        <ext:RecordField Name="Loai" />
                        <ext:RecordField Name="TuNgay" />
                        <ext:RecordField Name="DenNgay" />
                        <ext:RecordField Name="SoNgay" />
                        <ext:RecordField Name="TienLuongCu" />
                        <ext:RecordField Name="TongPhuCapCu" />
                        <ext:RecordField Name="TienLuongMoi" />
                        <ext:RecordField Name="TongPhuCapMoi" />
                        <ext:RecordField Name="KhongTraThe" />
                        <ext:RecordField Name="DaCoSo" />
                        <ext:RecordField Name="DienGiai" />
                        <ext:RecordField Name="TrangThai" />
                        <ext:RecordField Name="ThangDangKy" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        <ext:Window runat="server" ID="wdChonLoaiBienDong" Modal="true" Layout="FormLayout"
            Width="620" Constrain="false" Title="Danh sách quy định loại biến động" Hidden="true"
            Icon="Add" AutoHeight="true">
            <Items>
                <ext:GridPanel ID="grpNhanVienBienDong" Border="false" runat="server" StoreID="grpDanhSachLoaiBienDong_Store"
                    StripeRows="true" Icon="ApplicationViewColumns" TrackMouseOver="false" AutoExpandColumn="TenBienDong"
                    Height="370" AnchorHorizontal="100%">
                    <TopBar>
                        <ext:Toolbar runat="server" ID="tb">
                            <Items>
                                <ext:ToolbarFill runat="server" ID="tbfill" />
                                <ext:TriggerField runat="server" Width="250" EnableKeyEvents="true" EmptyText="Tìm kiếm theo mã, tên biến động"
                                    ID="txtSearchKey" Hidden="true">
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Listeners>
                                        <KeyPress Fn="enterKeyPressHandler_quanlydongbaohiem" />
                                        <TriggerClick Handler="this.clear(); this.triggers[0].hide(); PagingToolbar2.pageIndex=0; PagingToolbar2.doLoad();" />
                                    </Listeners>
                                </ext:TriggerField>
                                <ext:Button Text="<%$ Resources:Language, search%>" Icon="Zoom" runat="server" ID="btnSearch"
                                    Hidden="true">
                                    <Listeners>
                                        <Click Handler="#{grpNhanVienBienDong_Store}.reload();" />
                                    </Listeners>
                                </ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
                    <ColumnModel ID="ColumnModel2" runat="server">
                        <Columns>
                            <ext:RowNumbererColumn Locked="true" Header="STT" Width="30" />
                            <ext:Column ColumnID="IDQuyDinhBienDong" Header="Mã biến động" DataIndex="MaBienDong"
                                Width="100" />
                            <ext:Column ColumnID="TenBienDong" Header="Tên biến động bảo hiểm" DataIndex="TenBienDong" />
                            <ext:CheckColumn ColumnID="IsBHXH" Header="BHXH" DataIndex="IsBHXH" Align="Center"
                                Width="40" />
                            <ext:CheckColumn ColumnID="IsBHYT" Header="BHYT" DataIndex="IsBHYT" Width="40" />
                            <ext:CheckColumn ColumnID="IsBHTN" Header="BHTN" DataIndex="IsBHTN" Width="40" />
                            <%--<ext:CheckColumn ColumnID="DangSuDung" Header="SD" DataIndex="DangSuDung" Width="40" />--%>
                        </Columns>
                    </ColumnModel>
                    <SelectionModel>
                        <ext:RowSelectionModel runat="server" ID="checkboxSelection" SingleSelect="true">
                            <Listeners>
                                <RowSelect Handler="#{hdfLoaiBienDong}.setValue(#{checkboxSelection}.getSelected().id);" />
                            </Listeners>
                        </ext:RowSelectionModel>
                    </SelectionModel>
                    <BottomBar>
                        <ext:PagingToolbar ID="PagingToolbar2" EmptyMsg="<%$ Resources:HOSO, no_data%>" NextText="<%$ Resources:HOSO, next_page%>"
                            PageSize="15" PrevText="<%$ Resources:HOSO, prev_page%>" LastText="<%$ Resources:HOSO, last_page%>"
                            FirstText="<%$ Resources:HOSO, first_page%>" DisplayMsg="<%$ Resources:HOSO, description_record%>"
                            runat="server">
                            <Items>
                                <ext:Label ID="Label2" runat="server" Text="<%$ Resources:HOSO, number_line_per_page%>" />
                                <ext:ToolbarSpacer ID="ToolbarSpacer2" runat="server" Width="10" />
                                <ext:ComboBox ID="ComboBox1" runat="server" Width="80">
                                    <Items>
                                        <ext:ListItem Text="10" />
                                        <ext:ListItem Text="30" />
                                        <ext:ListItem Text="50" />
                                        <ext:ListItem Text="100" />
                                        <ext:ListItem Text="300" />
                                        <ext:ListItem Text="500" />
                                        <ext:ListItem Text="1000" />
                                        <ext:ListItem Text="3000" />
                                        <ext:ListItem Text="5000" />
                                        <ext:ListItem Text="10000" />
                                        <ext:ListItem Text="30000" />
                                        <ext:ListItem Text="50000" />
                                        <ext:ListItem Text="100000" />
                                    </Items>
                                    <SelectedItem Value="10" />
                                    <Listeners>
                                        <Select Handler="#{PagingToolbar2}.pageSize = parseInt(this.getValue()); #{PagingToolbar2}.doLoad();" />
                                    </Listeners>
                                </ext:ComboBox>
                            </Items>
                        </ext:PagingToolbar>
                    </BottomBar>
                    <LoadMask ShowMask="true" Msg="<%$ Resources:Language, LoadingMask%>" />
                    <Listeners>
                        <RowContextMenu Handler="e.preventDefault(); 
                                #{RowContextMenu}.dataRecord = this.store.getAt(rowIndex);
                                #{RowContextMenu}.showAt(e.getXY());
                                #{GridPanel1}.getSelectionModel().selectRow(rowIndex);" />
                        <RowDblClick Handler="return checkdongy();" />
                    </Listeners>
                    <DirectEvents>
                        <RowDblClick OnEvent="bt_click" After="#{wdChonLoaiBienDong}.hide();">
                        </RowDblClick>
                    </DirectEvents>
                </ext:GridPanel>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btdongy" Icon="Accept" Text="Đồng ý">
                    <Listeners>
                        <Click Handler="return checkdongy();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="bt_click" After="#{wdChonLoaiBienDong}.hide();">
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btdonglai" Icon="Decline" Text="<%$ Resources:CommonMessage, Close%>">
                    <Listeners>
                        <Click Handler="#{wdChonLoaiBienDong}.hide();#{hdfLoaiBienDong}.reset();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Window runat="server" ID="wdThemSuaBienDongNhanVien" Modal="true" Layout="FormLayout"
            Width="660" Constrain="false" Title="Thêm mới biến động cho nhân viên" Icon="Add"
            AutoHeight="true" Hidden="true">
            <TopBar>
                <ext:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <ext:Button runat="server" ID="btnLayThayDoiTuQuyetDinhLuong" Text="Lấy thay đổi từ quyết định lương"
                            Icon="TextSignature" Disabled="true">
                            <Listeners>
                                <Click Handler="wdThayDoiLuongPhuCap.show();" />
                            </Listeners>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </TopBar>
            <Items>
                <ext:TabPanel runat="server" ID="tabPanel1" Border="false">
                    <Items>
                        <ext:Panel ID="pnlThongTinChung1" runat="server" Title="<%$ Resources:HOSO, ThongTinChung%>">
                            <Items>
                                <ext:Hidden runat="server" ID="Hidden1" Text="Insert" />
                                <ext:FieldSet ID="FieldSet1" runat="server" Title="Thông tin cán bộ" Layout="ColumnLayout"
                                    Height="110" Border="true">
                                    <Items>
                                        <ext:Container ID="Container7" runat="server" Height="130" ColumnWidth=".5" Layout="FormLayout">
                                            <Items>
                                                <ext:TextField runat="server" ID="txtMaCanBo1" AnchorHorizontal="99%" AllowBlank="false"
                                                    FieldLabel="<%$ Resources:HOSO, staff_code%>" Disabled="true">
                                                </ext:TextField>
                                                <ext:DateField runat="server" ID="dfNgaySinh1" AnchorHorizontal="99%" Disabled="true"
                                                    FieldLabel="<%$ Resources:HOSO, staff_birthday%>" MaskRe="/[0-9\/]/" Format="d/M/yyyy"
                                                    Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/" RegexText="Định dạng ngày sinh không đúng">
                                                </ext:DateField>
                                                <ext:TextField runat="server" ID="txtLuongDongBH1" AnchorHorizontal="99%" Disabled="true"
                                                    FieldLabel="Lương đóng BH">
                                                </ext:TextField>
                                            </Items>
                                        </ext:Container>
                                        <ext:Container ID="Container8" runat="server" Height="130" ColumnWidth=".5" Layout="FormLayout">
                                            <Items>
                                                <ext:TextField runat="server" ID="txtHoTen1" Disabled="true" AnchorHorizontal="99%"
                                                    FieldLabel="<%$ Resources:HOSO, staff_name%>">
                                                </ext:TextField>
                                                <ext:TextField runat="server" ID="txtSoSoBHXH1" Disabled="true" AnchorHorizontal="99%"
                                                    FieldLabel="Số sổ BHXH">
                                                </ext:TextField>
                                                <ext:TextField runat="server" ID="txtThoiGianDongBHXH1" Disabled="true" AnchorHorizontal="99%"
                                                    FieldLabel="Thời gian đóng">
                                                </ext:TextField>
                                            </Items>
                                        </ext:Container>
                                    </Items>
                                </ext:FieldSet>
                                <ext:FieldSet ID="FieldSet2" runat="server" Title="Thông tin biến động" Layout="FormLayout"
                                    Height="240" Border="true" LabelWidth="105">
                                    <Items>
                                        <ext:Container ID="Container1" runat="server" AnchorHorizontal="99%" Layout="FormLayout"
                                            LabelWidth="105">
                                            <Items>
                                                <ext:TriggerField runat="server" ID="tgfChonBienDong1" AnchorHorizontal="100%" AllowBlank="false"
                                                    FieldLabel="Chọn biến động<span style='color:red'>*</span>" CtCls="requiredData">
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="SimpleMagnify" />
                                                    </Triggers>
                                                    <Listeners>
                                                        <TriggerClick Handler="#{wdChonLoaiBienDong}.show();grpDanhSachLoaiBienDong_Store.reload();" />
                                                    </Listeners>
                                                </ext:TriggerField>
                                            </Items>
                                        </ext:Container>
                                        <ext:Container ID="Container9" runat="server" AnchorHorizontal="100%" Layout="ColumnLayout"
                                            Height="77">
                                            <Items>
                                                <ext:Container ID="Container12" runat="server" ColumnWidth=".5" Layout="FormLayout"
                                                    AnchorHorizontal="98%" LabelWidth="105">
                                                    <Items>
                                                        <ext:Container ID="Container18" runat="server" Layout="HBoxLayout" Heigh="30" AnchorHorizontal="99%">
                                                            <Items>
                                                                <ext:Checkbox runat="server" LabelWidth="100" FieldLabel="Trạng thái đóng" BoxLabel="BHXH"
                                                                    ID="chkBHXH1" Height="25">
                                                                </ext:Checkbox>
                                                                <ext:Checkbox runat="server" LabelWidth="5" FieldLabel=" " LabelSeparator=" " BoxLabel="BHYT"
                                                                    ID="chkBHYT1" Height="25">
                                                                </ext:Checkbox>
                                                                <ext:Checkbox runat="server" LabelWidth="5" FieldLabel=" " LabelSeparator=" " BoxLabel="BHTN"
                                                                    ID="chkBHTN1" Height="25">
                                                                </ext:Checkbox>
                                                            </Items>
                                                        </ext:Container>
                                                        <ext:DateField runat="server" ID="dfTuNgay1" Vtype="daterange" AnchorHorizontal="99%"
                                                            CtCls="requiredData" FieldLabel="Từ ngày<span style='color:red'>*</span>" MaskRe="/[0-9\/]/"
                                                            Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/"
                                                            RegexText="Định dạng ngày sinh không đúng">
                                                        </ext:DateField>
                                                        <ext:Checkbox runat="server" ID="chkKhongTraThe" BoxLabel="Không trả thẻ BHYT">
                                                        </ext:Checkbox>
                                                    </Items>
                                                </ext:Container>
                                                <ext:Container ID="Container17" runat="server" ColumnWidth=".5" Layout="FormLayout"
                                                    AnchorHorizontal="100%">
                                                    <Items>
                                                        <ext:DateField runat="server" ID="dfNgayDangKyVoiCQBH" Vtype="daterange" AnchorHorizontal="99%"
                                                            FieldLabel="Ngày đăng ký<span style='color:red'>*</span>" CtCls="requiredData"
                                                            MaskRe="/[0-9\/]/" Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/"
                                                            RegexText="Định dạng ngày sinh không đúng">
                                                        </ext:DateField>
                                                        <ext:DateField runat="server" ID="dfDenNgay1" Vtype="daterange" AnchorHorizontal="99%"
                                                            FieldLabel="Đến ngày" MaskRe="/[0-9\/]/" Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/"
                                                            RegexText="Định dạng ngày sinh không đúng">
                                                        </ext:DateField>
                                                        <ext:Checkbox runat="server" ID="chkDaCoSo" BoxLabel="Đã có sổ BHXH">
                                                        </ext:Checkbox>
                                                        <%--<ext:Checkbox runat="server" ID="chkTuDongSinhCheDo" BoxLabel="Tự động sinh chế độ" AnchorHorizontal="99%"></ext:Checkbox>--%>
                                                    </Items>
                                                </ext:Container>
                                            </Items>
                                        </ext:Container>
                                        <ext:Container ID="Container2" runat="server" AnchorHorizontal="100%" Layout="ColumnLayout"
                                            Height="0">
                                            <Items>
                                                <ext:Container ID="Container3" runat="server" ColumnWidth=".5" Layout="FormLayout"
                                                    AnchorHorizontal="98%" LabelWidth="105">
                                                    <Items>
                                                        <ext:NumberField runat="server" ID="nfTruyThuBHXH" FieldLabel="Truy thu BHXH" AnchorHorizontal="98%"
                                                            AllowNegative="false" Hidden="true">
                                                        </ext:NumberField>
                                                        <ext:NumberField runat="server" ID="nfThoaiThuBHXH" FieldLabel="Thoái thu BHXH" AnchorHorizontal="99%"
                                                            AllowNegative="false" Hidden="true">
                                                        </ext:NumberField>
                                                    </Items>
                                                </ext:Container>
                                                <ext:Container ID="Container4" runat="server" ColumnWidth=".5" Layout="FormLayout"
                                                    AnchorHorizontal="100%">
                                                    <Items>
                                                        <ext:NumberField runat="server" ID="nfTruyThuBHYT" FieldLabel="Truy thu BHYT" AnchorHorizontal="98%"
                                                            AllowNegative="false" Hidden="true">
                                                        </ext:NumberField>
                                                        <ext:NumberField runat="server" ID="nfThoaiThuBHYT" FieldLabel="Thoái thu BHYT" AnchorHorizontal="99%"
                                                            AllowNegative="false" Hidden="true">
                                                        </ext:NumberField>
                                                    </Items>
                                                </ext:Container>
                                            </Items>
                                        </ext:Container>
                                        <ext:TextArea runat="server" ID="txtDienGiai1" FieldLabel="Diễn giải" AnchorHorizontal="99%"
                                            Height="50">
                                        </ext:TextArea>
                                    </Items>
                                </ext:FieldSet>
                            </Items>
                        </ext:Panel>
                        <ext:Panel ID="pnlThongTinLuong1" runat="server" Title="Thông tin lương">
                            <Items>
                                <ext:FieldSet ID="FieldSet3" runat="server" Title="" Layout="ColumnLayout" Height="358"
                                    Border="true">
                                    <Items>
                                        <ext:Container ID="Container19" runat="server" Height="230" ColumnWidth=".33" Layout="FormLayout"
                                            LabelWidth="150">
                                            <Items>
                                                <ext:DisplayField ID="DisplayField2" runat="server" FieldLabel=" " LabelSeparator=" "
                                                    AnchorHorizontal="99%">
                                                </ext:DisplayField>
                                                <ext:DisplayField ID="DisplayField6" runat="server" FieldLabel="Lương đóng BHXH"
                                                    AnchorHorizontal="99%">
                                                </ext:DisplayField>
                                                <ext:DisplayField ID="DisplayField7" runat="server" FieldLabel="Phụ cấp chức vụ"
                                                    AnchorHorizontal="99%">
                                                </ext:DisplayField>
                                                <ext:DisplayField ID="DisplayField8" runat="server" FieldLabel="Phụ cấp TNVK" AnchorHorizontal="99%">
                                                </ext:DisplayField>
                                                <ext:DisplayField ID="DisplayField9" runat="server" FieldLabel="Phụ cấp TN nghề"
                                                    AnchorHorizontal="99%">
                                                </ext:DisplayField>
                                            </Items>
                                        </ext:Container>
                                        <ext:Container ID="Container20" runat="server" Height="230" ColumnWidth=".33" Layout="FormLayout"
                                            HideLabels="true">
                                            <Items>
                                                <ext:DisplayField ID="DisplayField10" runat="server" Text="Thông tin cũ" AnchorHorizontal="100%">
                                                </ext:DisplayField>
                                                <ext:TextField runat="server" ID="txtLuongDongBHXHCu1" AnchorHorizontal="95%" MaskRe="/[0-9\.]/"
                                                    LabelWidth="3">
                                                    <Listeners>
                                                        <Blur Handler="tl.hide();" />
                                                        <Focus Handler="tl.show();" />
                                                    </Listeners>
                                                </ext:TextField>
                                                <ext:TextField runat="server" ID="txtPhuCapCVCu1" AnchorHorizontal="95%" MaskRe="/[0-9\.]/"
                                                    LabelWidth="3">
                                                    <Listeners>
                                                        <Blur Handler="tl.hide();" />
                                                        <Focus Handler="tl.show();" />
                                                    </Listeners>
                                                </ext:TextField>
                                                <ext:TextField runat="server" ID="txtPhuCapTNVKCu1" AnchorHorizontal="95%" MaskRe="/[0-9\.]/"
                                                    LabelWidth="3">
                                                    <Listeners>
                                                        <Blur Handler="tl.hide();" />
                                                        <Focus Handler="tl.show();" />
                                                    </Listeners>
                                                </ext:TextField>
                                                <ext:TextField runat="server" ID="txtPhuCapTNNCu1" AnchorHorizontal="95%" MaskRe="/[0-9\.]/"
                                                    LabelWidth="3">
                                                    <Listeners>
                                                        <Blur Handler="tl.hide();" />
                                                        <Focus Handler="tl.show();" />
                                                    </Listeners>
                                                </ext:TextField>
                                            </Items>
                                        </ext:Container>
                                        <ext:Container ID="Container21" runat="server" Height="230" ColumnWidth=".33" Layout="FormLayout"
                                            HideLabels="true">
                                            <Items>
                                                <ext:DisplayField ID="DisplayField11" runat="server" Text="Thông tin mới" AnchorHorizontal="100%"
                                                    LabelWidth="3">
                                                </ext:DisplayField>
                                                <ext:TextField runat="server" ID="txtLuongDongBHXHMoi1" AnchorHorizontal="95%" MaskRe="/[0-9\.]/"
                                                    LabelWidth="3">
                                                </ext:TextField>
                                                <ext:TextField runat="server" ID="txtPhuCapCVMoi1" AnchorHorizontal="95%" MaskRe="/[0-9\.]/"
                                                    LabelWidth="3">
                                                </ext:TextField>
                                                <ext:TextField runat="server" ID="txtPhuCapTNVKMoi1" AnchorHorizontal="95%" MaskRe="/[0-9\.]/"
                                                    LabelWidth="3">
                                                </ext:TextField>
                                                <ext:TextField runat="server" ID="txtPhuCapTNNMoi1" AnchorHorizontal="95%" MaskRe="/[0-9\.]/"
                                                    LabelWidth="3">
                                                </ext:TextField>
                                            </Items>
                                        </ext:Container>
                                    </Items>
                                </ext:FieldSet>
                            </Items>
                        </ext:Panel>
                        <ext:Panel ID="pnlTruyThoaiThu1" runat="server" Title="Truy thu/Thoái thu" Disabled="true">
                            <Items>
                                <ext:FieldSet ID="FieldSet4" runat="server" Title="Truy/Thoái thu" Layout="FormLayout"
                                    Height="350" Border="true">
                                    <Items>
                                        <ext:RadioGroup Vertical="true" runat="server" ID="RadioGroup1" FieldLabel="Loại"
                                            Height="20" AnchorHorizontal="70%">
                                            <Items>
                                                <ext:Radio runat="server" ID="Radio1" BoxLabel="Truy thu">
                                                </ext:Radio>
                                                <ext:Radio runat="server" ID="Radio2" BoxLabel="Thoái thu">
                                                </ext:Radio>
                                                <ext:Radio runat="server" ID="Radio3" BoxLabel="Không">
                                                </ext:Radio>
                                            </Items>
                                        </ext:RadioGroup>
                                        <ext:Checkbox runat="server" ID="Checkbox4" FieldLabel="Trạng thái" AnchorHorizontal="99%"
                                            BoxLabel="Đã đăng ký với CQBH" Height="30">
                                        </ext:Checkbox>
                                        <ext:Container ID="Container22" runat="server" Layout="HBoxLayout" Height="30">
                                            <Items>
                                                <ext:ComboBox runat="server" FieldLabel="Tháng đăng ký" LabelWidth="100" Editable="false"
                                                    SelectedIndex="0" ID="ComboBox3" Width="200">
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
                                                <ext:DisplayField ID="DisplayField12" runat="server" FieldLabel="Năm" LabelWidth="40"
                                                    LabelAlign="Right">
                                                </ext:DisplayField>
                                                <ext:SpinnerField ID="SpinnerField1" runat="server" Width="60" MinValue="1900" MaxValue="2100">
                                                </ext:SpinnerField>
                                            </Items>
                                        </ext:Container>
                                        <ext:Container ID="Container23" runat="server" Layout="HBoxLayout" Height="30">
                                            <Items>
                                                <ext:ComboBox runat="server" FieldLabel="Từ tháng" LabelWidth="100" Editable="false"
                                                    SelectedIndex="0" ID="ComboBox4" Width="200">
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
                                                <ext:DisplayField ID="DisplayField13" runat="server" FieldLabel="Năm" LabelAlign="Right"
                                                    LabelWidth="40">
                                                </ext:DisplayField>
                                                <ext:SpinnerField ID="SpinnerField2" runat="server" Width="60" MinValue="1900" MaxValue="2100">
                                                </ext:SpinnerField>
                                            </Items>
                                        </ext:Container>
                                        <ext:Container ID="Container24" runat="server" Layout="HBoxLayout" Height="30">
                                            <Items>
                                                <ext:ComboBox runat="server" FieldLabel="Đến tháng" LabelWidth="100" Editable="false"
                                                    SelectedIndex="0" ID="ComboBox5" Width="200">
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
                                                <ext:DisplayField ID="DisplayField14" runat="server" FieldLabel="Năm" LabelWidth="40"
                                                    LabelAlign="Right">
                                                </ext:DisplayField>
                                                <ext:SpinnerField ID="SpinnerField3" runat="server" Width="60" MinValue="1900" MaxValue="2100">
                                                </ext:SpinnerField>
                                            </Items>
                                        </ext:Container>
                                        <ext:Container ID="Container25" runat="server" AnchorHorizontal="99%" Layout="HBoxLayout"
                                            Height="30">
                                            <Items>
                                                <ext:Checkbox runat="server" ID="Checkbox5" FieldLabel="BHXH">
                                                </ext:Checkbox>
                                                <ext:NumberField LabelWidth="50" runat="server" ID="NumberField2" FieldLabel="<%$ Resources:QuanLyThoiViec, SoTien%>">
                                                </ext:NumberField>
                                            </Items>
                                        </ext:Container>
                                        <ext:Container ID="Container26" runat="server" AnchorHorizontal="99%" Layout="HBoxLayout"
                                            Height="30">
                                            <Items>
                                                <ext:Checkbox runat="server" ID="Checkbox6" FieldLabel="BHYT">
                                                </ext:Checkbox>
                                                <ext:NumberField LabelWidth="50" runat="server" ID="NumberField3" FieldLabel="<%$ Resources:QuanLyThoiViec, SoTien%>">
                                                </ext:NumberField>
                                            </Items>
                                        </ext:Container>
                                        <ext:Container ID="Container27" runat="server" AnchorHorizontal="99%" Layout="HBoxLayout"
                                            Height="30">
                                            <Items>
                                                <ext:Checkbox runat="server" ID="Checkbox7" FieldLabel="BHTN">
                                                </ext:Checkbox>
                                                <ext:NumberField LabelWidth="50" runat="server" ID="NumberField4" FieldLabel="<%$ Resources:QuanLyThoiViec, SoTien%>">
                                                </ext:NumberField>
                                            </Items>
                                        </ext:Container>
                                    </Items>
                                </ext:FieldSet>
                            </Items>
                        </ext:Panel>
                    </Items>
                </ext:TabPanel>
            </Items>
            <Buttons>
                <ext:Button ID="btnCapNhat1" runat="server" Text="<%$ Resources:Language, update%>"
                    Icon="Disk" Hidden="true">
                    <Listeners>
                        <Click Handler="return CheckThemMoi();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="bt_addclick">
                            <EventMask ShowMask="true" />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="True">
                                </ext:Parameter>
                                <ext:Parameter Name="Command" Value="Insert">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" Icon="Disk" Text="<%$ Resources:Language, update%>" ID="btnCapNhatSua1"
                    Hidden="true">
                    <Listeners>
                        <Click Handler="return CheckThemMoi();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnCapNhatSua_Click">
                            <EventMask ShowMask="true" />
                            <ExtraParams>
                                <ext:Parameter Name="Command" Value="Edit">
                                </ext:Parameter>
                                <ext:Parameter Name="Close" Value="True">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="Button13" runat="server" Text="<%$ Resources:CommonMessage, Close%>"
                    Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdThemSuaBienDongNhanVien}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="ResetControl(); #{tabPanel1}.setActiveTab(#{pnlThongTinChung1});btnLayThayDoiTuQuyetDinhLuong.disable();" />
            </Listeners>
            <DirectEvents>
                <Hide OnEvent="ResetWindown">
                </Hide>
            </DirectEvents>
        </ext:Window>
        <ext:Window ID="wdImport" runat="server" Modal="true" Layout="FormLayout" Width="600"
            Padding="6" Constrain="false" Title="Import số sổ BHXH, số thẻ BHYT" Hidden="true"
            Icon="Add" AutoHeight="true">
        </ext:Window>
        <ext:Window Modal="true" Hidden="true" runat="server" Layout="BorderLayout" ID="wdxentheobiendong"
            Title="Xem biến động theo tháng" Maximized="true" Icon="Date">
            <Items>
                <ext:TabPanel ID="pnReportPanel1" Region="Center" AnchorVertical="100%" Border="false"
                    runat="server">
                </ext:TabPanel>
            </Items>
            <Listeners>
                <BeforeShow Handler="#{pnReportPanel1}.remove(0);addHomePage(#{pnReportPanel1},'Homepage','../BienDongBaoHiem/XemTheoBienDong.aspx?prkey='+#{hdfRecordID}.getValue()+'&menuID='+hdfMenuID.getValue(), 'Xem theo biến động')" />
            </Listeners>
            <Buttons>
                <ext:Button ID="Button3" runat="server" Text="<%$ Resources:CommonMessage, Close%>"
                    Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdxentheobiendong}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Store ID="grpDanhSachBaoCaoStore" runat="server" AutoLoad="true">
            <Proxy>
                <ext:HttpProxy Method="GET" Url="HandlerBHDauBaoHiemBienDong.ashx" />
            </Proxy>
            <AutoLoadParams>
                <ext:Parameter Name="start" Value="={0}" />
                <ext:Parameter Name="limit" Value="={30}" />
            </AutoLoadParams>
            <BaseParams>
                <ext:Parameter Name="MaDonVi" Value="#{hdfMaDonVi}.getValue()" Mode="Raw" />
            </BaseParams>
            <Reader>
                <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="IdDauPhieu">
                    <Fields>
                        <ext:RecordField Name="IdDauPhieu" />
                        <ext:RecordField Name="LoaiChungTu" />
                        <ext:RecordField Name="TenChungTu" />
                        <ext:RecordField Name="TuNgay" />
                        <ext:RecordField Name="DenNgay" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        <ext:Window runat="server" Hidden="true" Layout="FormLayout" ID="wdQuanLyDanhSachBienDongEdit"
            Title="Thêm mới chứng từ" Padding="6" Width="560" Modal="true" AutoHeight="true"
            Icon="Add" Constrain="true">
            <Items>
                <ext:Container runat="server" Layout="ColumnLayout" Height="57">
                    <Items>
                        <ext:Container runat="server" ColumnWidth="0.5" Layout="FormLayout">
                            <Items>
                                <ext:ComboBox runat="server" ID="cboloaichungtu" FieldLabel="Loại chứng từ<span style='color:red'>*</span>"
                                    AnchorHorizontal="98%" Editable="false">
                                    <Items>
                                        <ext:ListItem Value="D02-TS" Text="D02-TS" />
                                    </Items>
                                    <Listeners>
                                        <Select Handler="SetTenChungTu();" />
                                    </Listeners>
                                </ext:ComboBox>
                                <ext:ComboBox runat="server" ID="ThoiGianBaoCao" FieldLabel="Tháng/Quý" AnchorHorizontal="98%" Editable="false">
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
                                        <ext:ListItem Text="Quý 1" Value="Quý 1" />
                                        <ext:ListItem Text="Quý 2" Value="Quý 2" />
                                        <ext:ListItem Text="Quý 3" Value="Quý 3" />
                                        <ext:ListItem Text="Quý 4" Value="Quý 4" />
                                    </Items>
                                    <Listeners>
                                        <Select Handler="SetTenChungTu();" />
                                    </Listeners>
                                </ext:ComboBox>
                            </Items>
                        </ext:Container>
                        <ext:Container runat="server" ColumnWidth="0.5" Layout="FormLayout">
                            <Items>
                                <ext:TextField runat="server" ID="txtsochungtu" FieldLabel="Số chứng từ" AnchorHorizontal="100%">
                                </ext:TextField>
                                <ext:SpinnerField runat="server" ID="NamBaoCao" FieldLabel="Năm" AnchorHorizontal="100%"
                                    EnableKeyEvents="true">
                                    <Listeners>
                                        <Spin Handler="SetTenChungTu();" />
                                        <KeyUp Handler="SetTenChungTu();" />
                                    </Listeners>
                                </ext:SpinnerField>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Container>
                <ext:Container runat="server" Layout="FormLayout">
                    <Items>
                        <ext:TextField runat="server" ID="txttenchungtu" FieldLabel="Tên chứng từ<span style='color:red'>*</span>"
                            AnchorHorizontal="100%">
                        </ext:TextField>
                    </Items>
                </ext:Container>
                <ext:Container runat="server" Layout="ColumnLayout" Height="57">
                    <Items>
                        <ext:Container runat="server" ColumnWidth="0.5" Layout="FormLayout">
                            <Items>
                                <ext:TextField runat="server" ID="txtSoTaiKhoan" FieldLabel="Số tài khoản" AnchorHorizontal="98%">
                                </ext:TextField>
                                <ext:TextField runat="server" ID="txtTongSoLaoDong" FieldLabel="Tổng số lao động"
                                    AnchorHorizontal="98%">
                                </ext:TextField>
                            </Items>
                        </ext:Container>
                        <ext:Container runat="server" Layout="FormLayout" ColumnWidth="0.5">
                            <Items>
                                <ext:TextField runat="server" ID="txtMoTai" FieldLabel="Mở tại" AnchorHorizontal="100%">
                                </ext:TextField>
                                <ext:TextField runat="server" ID="txtTrongDoNu" FieldLabel="Trong đó nữ" AnchorHorizontal="100%">
                                </ext:TextField>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Container>
                <ext:Container ID="Container28" runat="server">
                    <Items>
                        <ext:TextField runat="server" ID="txtTongQuyLuong" FieldLabel="Tổng quỹ lương trong tháng/quý"
                            LabelWidth="190" AnchorHorizontal="100%">
                        </ext:TextField>
                    </Items>
                </ext:Container>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btcapnhat" Icon="Disk" Text="<%$ Resources:Language, update%>">
                    <Listeners>
                        <Click Handler=" return check_themmoi_chungtu();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="bt_themmoichungtu">
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btcapnhat_update" Icon="Disk" Text="<%$ Resources:Language, update%>">
                    <DirectEvents>
                        <Click OnEvent="bt_update">
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btcapnhatvadong" Icon="Disk" Text="<%$ Resources:Language, update_close%>">
                    <Listeners>
                        <Click Handler=" return check_themmoi_chungtu();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="bt_themmoichungtu">
                            <ExtraParams>
                                <ext:Parameter Value="True" Name="D">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btthoat" Icon="Decline" Text="<%$ Resources:CommonMessage, Close%>">
                    <Listeners>
                        <Click Handler="#{wdQuanLyDanhSachBienDongEdit}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <DirectEvents>
                <Hide OnEvent="resetwindown_dauphieu">
                </Hide>
            </DirectEvents>
            <Listeners>
                <Hide Handler="reset_dauphieu();#{grpChiTietBaoCaoStore}.reload();" />
            </Listeners>
        </ext:Window>
        <ext:Hidden runat="server" ID="hdfMadauphieu">
        </ext:Hidden>
        <ext:Window Modal="true" Hidden="true" runat="server" Layout="BorderLayout" ID="wdShowReport"
            Title="Báo cáo thông tin nhân viên đóng bảo hiểm xã hội, bảo hiểm y tế" Maximized="true"
            Icon="Printer">
            <Items>
                <ext:TabPanel ID="TabPanel2" Region="Center" AnchorVertical="100%" Border="false"
                    runat="server">
                </ext:TabPanel>
            </Items>
            <Listeners>
               <%-- <BeforeShow Handler="#{TabPanel2}.remove(0);addHomePage(#{TabPanel2},'Homepage','../../Report/BaoCao_Main.aspx?IdBcBaoHiem='+#{hdfMadauphieu}.getValue(), 'Báo cáo danh sách biến động')" />--%>
                 <BeforeShow Handler="#{TabPanel2}.remove(0);addHomePage(#{TabPanel2},'Homepage','../../Report/BaoCao_Main.aspx?IdBcBaoHiem='+#{hdfMadauphieu}.getValue()+'&TuNgay='+#{hdfTuNgay}.getValue()+ '&DenNgay='+#{hdfDenNgay}.getValue(), 'Báo cáo danh sách biến động')" />
            </Listeners>
            <Buttons>
                <ext:Button ID="Button9" runat="server" Text="<%$ Resources:CommonMessage, Close%>"
                    Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdShowReport}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Window Modal="true" Hidden="true" runat="server" Layout="FormLayout" ID="wdQuanLyDanhSachBienDong"
            Title="Quản lý danh sách biến động" Maximized="true">
            <Items>
                <ext:BorderLayout runat="server" ID="brlayout">
                    <West Collapsible="true" Split="true">
                        <ext:Panel ID="panel1" runat="server" Collapsed="false" Width="300" Border="false"
                            Layout="BorderLayout" Title="Danh sách chứng từ">
                            <Items>
                                <ext:GridPanel ID="grpDanhSachBaoCao" Border="false" runat="server" AutoExpandColumn="TenChungTu"
                                    StripeRows="true" TrackMouseOver="false" Region="Center" Height="450" StoreID="grpDanhSachBaoCaoStore">
                                    <TopBar>
                                        <ext:Toolbar runat="server">
                                            <Items>
                                                <ext:Button runat="server" ID="btnThemTenCT" Text="<%$ Resources:CommonMessage, Add%>"
                                                    Icon="Add">
                                                    <Listeners>
                                                        <Click Handler="#{wdQuanLyDanhSachBienDongEdit}.show();#{btcapnhat}.show();#{btcapnhatvadong}.show();#{btcapnhat_update}.hide();" />
                                                    </Listeners>
                                                </ext:Button>
                                                <ext:Button runat="server" ID="btnSuaTenCT" Text="<%$ Resources:CommonMessage, Edit%>"
                                                    Icon="Pencil" Disabled="true">
                                                    <Listeners>
                                                        <Click Handler="#{btcapnhat}.hide();#{btcapnhatvadong}.hide();#{btcapnhat_update}.show();" />
                                                    </Listeners>
                                                    <DirectEvents>
                                                        <Click OnEvent="LoadEdit_DauPhieu">
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:Button>
                                                <ext:Button runat="server" ID="btnXoaTenCT" Text="<%$ Resources:Language, delete%>"
                                                    Icon="Delete" Disabled="true">
                                                    <Listeners>
                                                        <Click Handler="RemoveItemOnGrid_dauphieu(grpDanhSachBaoCao,grpDanhSachBaoCaoStore)" />
                                                    </Listeners>
                                                </ext:Button>
                                            </Items>
                                        </ext:Toolbar>
                                    </TopBar>
                                    <ColumnModel runat="server">
                                        <Columns>
                                            <ext:RowNumbererColumn Header="STT" Width="30" />
                                            <ext:Column ColumnID="TenChungTu" Header="Tên chứng từ" DataIndex="TenChungTu" />
                                        </Columns>
                                    </ColumnModel>
                                    <BottomBar>
                                        <ext:PagingToolbar ID="PagingToolbar4" EmptyMsg="<%$ Resources:HOSO, no_data%>" NextText="<%$ Resources:HOSO, next_page%>"
                                            PageSize="20" PrevText="<%$ Resources:HOSO, prev_page%>" LastText="<%$ Resources:HOSO, last_page%>"
                                            FirstText="<%$ Resources:HOSO, first_page%>" DisplayMsg="{0} đến {1} / {2}" runat="server">
                                        </ext:PagingToolbar>
                                    </BottomBar>
                                    <SelectionModel>
                                        <ext:RowSelectionModel runat="server" ID="RowSelectionModel4" SingleSelect="true">
                                            <Listeners>
                                                <RowSelect Handler="#{hdfMadauphieu}.setValue(#{RowSelectionModel4}.getSelected().id); 
                                                        ReloadCenterGrid(grpDanhSachBaoCao,grpDanhSachBaoCaoStore);
                                                        #{btnSuaTenCT}.enable();#{btnXoaTenCT}.enable(); #{Button4}.enable();" />
                                                <RowDeselect Handler="#{hdfMadauphieu}.reset();
                                                        #{btnSuaTenCT}.disable();#{btnXoaTenCT}.disable(); #{Button4}.disable();" />
                                            </Listeners>
                                        </ext:RowSelectionModel>
                                    </SelectionModel>
                                    <DirectEvents>
                                        <DblClick OnEvent="LoadEdit_DauPhieu">
                                        </DblClick>
                                    </DirectEvents>
                                    <Listeners>
                                        <DblClick Handler="#{btcapnhat}.hide();#{btcapnhatvadong}.hide();#{btcapnhat_update}.show();" />
                                    </Listeners>
                                    <View>
                                        <ext:GridView ID="GridView1" runat="server" ForceFit="false" />
                                    </View>
                                    <LoadMask ShowMask="true" Msg="<%$ Resources:Language, LoadingMask%>" />
                                </ext:GridPanel>
                            </Items>
                        </ext:Panel>
                    </West>
                    <Center>
                        <ext:GridPanel ID="grpChiTietBaoCao" Border="false" runat="server" StoreID="grpChiTietBaoCaoStore"
                            StripeRows="true" TrackMouseOver="false" AnchorHorizontal="100%" Title="Báo cáo danh sách biến động">
                            <TopBar>
                                <ext:Toolbar ID="Toolbar4" runat="server">
                                    <Items>
                                        <ext:Button runat="server" ID="Button4" Text="<%$ Resources:Language, report%>" Icon="Printer">
                                            <Listeners>
                                                <Click Handler="return check_baocao();" />
                                            </Listeners>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <ColumnModel ID="ColumnModel4" runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn Header="STT" Locked="true" Width="30" Align="Left">
                                    </ext:RowNumbererColumn>
                                    <ext:Column ColumnID="colMaNhanVien" Locked="true" Width="65" DataIndex="MaCanBo"
                                        Header="<%$ Resources:HOSO, staff_code%>">
                                    </ext:Column>
                                    <ext:Column ColumnID="colTenCanBo" Locked="true" Width="150" DataIndex="HoTen" Header="<%$ Resources:HOSO, staff_name%>">
                                    </ext:Column>
                                    <ext:Column ColumnID="colMaSo" Width="80" DataIndex="MaSo" Header="Mã số">
                                    </ext:Column>
                                    <ext:DateColumn ColumnID="colNgaySinh" Width="80" DataIndex="NgaySinh" Header="<%$ Resources:HOSO, staff_birthday%>"
                                        Format="dd/MM/yyyy" />
                                    <ext:CheckColumn ColumnID="colGioiTinh" Width="30" DataIndex="GioiTinh" Header="Nữ" />
                                    <ext:DateColumn Format="dd/MM/yyyy" ColumnID="colThangDangKy" Width="80" DataIndex="ThangDangKy"
                                        Header="Ngày đăng ký" />
                                    <ext:DateColumn Format="dd/MM/yyyy" ColumnID="colTuNgay" Width="70" DataIndex="TuNgay"
                                        Header="Từ ngày" />
                                    <ext:DateColumn Format="dd/MM/yyyy" ColumnID="colDenNgay" Width="70" DataIndex="DenNgay"
                                        Header="Đến ngày" />
                                    <ext:Column ColumnID="colTienLuongCu" Width="100" DataIndex="TienLuongCu" Header="Tiền lương cũ"
                                        Align="Right">
                                        <Renderer Fn="RenderVND" />
                                    </ext:Column>
                                    <ext:Column ColumnID="colTongPhuCapCu" Width="107" DataIndex="TongPhuCapCu" Header="Tổng phụ cấp cũ"
                                        Align="Right">
                                        <Renderer Fn="RenderVND" />
                                    </ext:Column>
                                    <ext:Column ColumnID="colTienLuongMoi" Width="100" DataIndex="TienLuongMoi" Header="Tiền lương mới"
                                        Align="Right">
                                        <Renderer Fn="RenderVND" />
                                    </ext:Column>
                                    <ext:Column ColumnID="colTongPhuCapMoi" Width="117" DataIndex="TongPhuCapMoi" Header="Tổng phụ cấp mới"
                                        Align="Right">
                                        <Renderer Fn="RenderVND" />
                                    </ext:Column>
                                    <ext:CheckColumn ColumnID="colKhongTraThe" Width="46" DataIndex="KhongTraThe" Header="Không trả thẻ">
                                    </ext:CheckColumn>
                                    <ext:CheckColumn ColumnID="colDaCoSo" Width="40" DataIndex="DaCoSo" Header="Đã có sổ">
                                    </ext:CheckColumn>
                                    <ext:Column ColumnID="colDienGiai" Width="200" DataIndex="DienGiai" Header="Diễn giải">
                                    </ext:Column>
                                    <ext:Column ColumnID="colTrangThai" Width="100" DataIndex="TrangThai" Header="Trạng thái">
                                    </ext:Column>
                                </Columns>
                            </ColumnModel>
                            <View>
                                <%--<ext:LockingGridView runat="server" ID="LockingGridView1" LockText="Cố định cột này lại"
                                    UnlockText="Hủy cố định cột">
                                </ext:LockingGridView>--%>
                                <ext:GroupingView ID="GroupingView2" runat="server" MarkDirty="false" ShowGroupName="false"
                                    EnableNoGroups="true" HideGroupedColumn="true">
                                </ext:GroupingView>
                            </View>
                            <BottomBar>
                                <ext:PagingToolbar ID="PagingToolbar5" EmptyMsg="<%$ Resources:HOSO, no_data%>" NextText="<%$ Resources:HOSO, next_page%>"
                                    PageSize="15" PrevText="<%$ Resources:HOSO, prev_page%>" LastText="<%$ Resources:HOSO, last_page%>"
                                    FirstText="<%$ Resources:HOSO, first_page%>" DisplayMsg="{0} đến {1} / {2}" runat="server">
                                    <Items>
                                        <ext:Label ID="Label4" runat="server" Text="<%$ Resources:HOSO, number_line_per_page%>" />
                                        <ext:ToolbarSpacer ID="ToolbarSpacer4" runat="server" Width="10" />
                                        <ext:ComboBox ID="ComboBox6" runat="server" Width="80">
                                            <Items>
                                                <ext:ListItem Text="15" />
                                                <ext:ListItem Text="30" />
                                                <ext:ListItem Text="50" />
                                                <ext:ListItem Text="70" />
                                                <ext:ListItem Text="100" />
                                            </Items>
                                            <Listeners>
                                                <Select Handler="#{PagingToolbar5}.pageSize = parseInt(this.getValue()); #{PagingToolbar5}.doLoad();" />
                                            </Listeners>
                                            <SelectedItem Value="15" />
                                        </ext:ComboBox>
                                    </Items>
                                </ext:PagingToolbar>
                            </BottomBar>
                            <LoadMask ShowMask="true" Msg="Đang xử lý..." />
                            <SelectionModel>
                                <ext:RowSelectionModel runat="server" ID="RowSelectionModel3" SingleSelect="true">
                                    <%-- <DirectEvents>
                                                    <RowSelect OnEvent="DotDanhGia_Click" Before="hdfMaDotDanhGia.setValue(checkSelection.getSelected().id);">
                                                        <EventMask ShowMask="true" />
                                                    </RowSelect>
                                                </DirectEvents>--%>
                                </ext:RowSelectionModel>
                            </SelectionModel>
                        </ext:GridPanel>
                    </Center>
                </ext:BorderLayout>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnDongQuanLyDanhSachBienDong" Text="<%$ Resources:CommonMessage, Close%>"
                    Icon="Decline">
                    <Listeners>
                        <Click Handler="wdQuanLyDanhSachBienDong.hide()" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Window ID="wdThayDoiLuongPhuCap" Modal="true" Hidden="true" runat="server" Title="Thông tin lương, phụ cấp"
            Icon="Information" Padding="6" Width="550" AutoHeight="true" Constrain="true"
            Layout="FormLayout">
            <Items>
                <ext:FieldSet runat="server" Title="Lương và phụ cấp đóng BHXH hiện tại" Layout="ColumnLayout"
                    Height="80">
                    <Items>
                        <ext:Container runat="server" ColumnWidth=".5" Layout="FormLayout">
                            <Items>
                                <ext:TextField runat="server" ID="txtTTLuongBHCu" Disabled="true" FieldLabel="Lương BHXH"
                                    AnchorHorizontal="99%">
                                </ext:TextField>
                                <ext:TextField runat="server" ID="txtTTPhuCapCVCu" Disabled="true" FieldLabel="Phụ cấp CV"
                                    AnchorHorizontal="99%">
                                </ext:TextField>
                            </Items>
                        </ext:Container>
                        <ext:Container runat="server" ColumnWidth=".5" Layout="FormLayout">
                            <Items>
                                <ext:TextField runat="server" ID="txtTTPCTNNCu" Disabled="true" FieldLabel="Phụ cấp TNN"
                                    AnchorHorizontal="99%">
                                </ext:TextField>
                                <ext:TextField runat="server" ID="txtTTPCTNVKCu" Disabled="true" FieldLabel="Phụ cấp TNVK"
                                    AnchorHorizontal="99%">
                                </ext:TextField>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:FieldSet>
                <ext:FieldSet ID="Panel4" runat="server" Title="Nhân viên đang hưởng lương và phụ cấp theo Quyết định:"
                    Height="150" Layout="ColumnLayout">
                    <Items>
                        <ext:Container ID="Container30" runat="server" ColumnWidth=".5" Layout="FormLayout">
                            <Items>
                                <ext:TextField runat="server" ID="txtTTSoQD" Disabled="true" FieldLabel="<%$ Resources:QuanLyThoiViec, SoQuyetDinh%>"
                                    AnchorHorizontal="99%">
                                </ext:TextField>
                                <ext:DateField runat="server" ID="dfTTNgayHieuLuc" Disabled="true" FieldLabel="Ngày hiệu lực"
                                    AnchorHorizontal="99%" Height="30" MaskRe="/[0-9\/]/" Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/"
                                    RegexText="Định dạng ngày sinh không đúng">
                                </ext:DateField>
                                <ext:TextField runat="server" ID="txtTTLuongBHMoi" FieldLabel="Lương BHXH" AnchorHorizontal="99%">
                                </ext:TextField>
                                <ext:TextField runat="server" ID="txtTTPhuCapCVMoi" FieldLabel="Phụ cấp CV" AnchorHorizontal="99%">
                                </ext:TextField>
                            </Items>
                        </ext:Container>
                        <ext:Container ID="Container31" runat="server" ColumnWidth=".5" Layout="FormLayout">
                            <Items>
                                <ext:TextField runat="server" ID="txtTTTenQD" FieldLabel="Tên quyết định" Disabled="true"
                                    AnchorHorizontal="99%">
                                </ext:TextField>
                                <ext:DateField runat="server" ID="dfTTNgayHetHieuLuc" FieldLabel="Hết hiệu lực" Disabled="true"
                                    Height="30" AnchorHorizontal="99%" MaskRe="/[0-9\/]/" Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/"
                                    RegexText="Định dạng ngày sinh không đúng">
                                </ext:DateField>
                                <ext:TextField runat="server" ID="txtTTPCTNNMoi" FieldLabel="Phụ cấp TNN" AnchorHorizontal="99%">
                                </ext:TextField>
                                <ext:TextField runat="server" ID="txtTTPCTNVKMoi" FieldLabel="Phụ cấp TNVK" AnchorHorizontal="99%">
                                </ext:TextField>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:FieldSet>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnTTDongY" Text="Đồng ý" Icon="Accept">
                    <Listeners>
                        <Click Handler="Ext.net.DirectMethods.btnTTDongYClick();" />
                    </Listeners>
                </ext:Button>
                <ext:Button runat="server" ID="btnTTDongLai" Text="<%$ Resources:CommonMessage, Close%>"
                    Icon="Decline">
                    <Listeners>
                        <Click Handler="wdThayDoiLuongPhuCap.hide()" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Viewport runat="server" ID="vp">
            <Items>
                <ext:BorderLayout runat="server" ID="br">
                    <Center>
                        <ext:Panel runat="server" AnchorHorizontal="99%" AnchorVertical="99%" Border="false">
                            <Items>
                                <ext:RowLayout ID="RowLayout1" runat="server" Split="false" AnchorHorizontal="99%"
                                    AnchorVertical="99%">
                                    <Rows>
                                        <ext:LayoutRow runat="server" RowHeight="0.65">
                                            <Items>
                                                <ext:Panel ID="Panel2" runat="server" AnchorVertical="100%" Layout="BorderLayout"
                                                    Border="false">
                                                    <Items>
                                                        <ext:GridPanel runat="server" ID="grpBienDongBaoHiem" Border="false" StripeRows="true"
                                                            AutoExpandColumn="colTenCanBo" Region="Center" AutoExpandMin="150" StoreID="grpBienDongBaoHiemStore">
                                                            <TopBar>
                                                                <ext:Toolbar ID="Toolbar2" runat="server">
                                                                    <Items>
                                                                        <ext:Button runat="server" ID="btnXemTheoBienDong" Text="Xem theo tháng" Icon="Date">
                                                                            <Listeners>
                                                                                <Click Handler="#{wdxentheobiendong}.show();" />
                                                                            </Listeners>
                                                                        </ext:Button>
                                                                        <ext:Button runat="server" ID="btnQuanLyDanhSachBienDong" Text="Quản lý danh sách biến động"
                                                                            Icon="Script">
                                                                            <Listeners>
                                                                                <Click Handler="#{wdQuanLyDanhSachBienDong}.show();" />
                                                                            </Listeners>
                                                                        </ext:Button>
                                                                        <ext:ToolbarSpacer>
                                                                        </ext:ToolbarSpacer>
                                                                        <ext:ToolbarFill ID="ToolbarFill1" runat="server" />
                                                                        <ext:TriggerField runat="server" Width="250" EnableKeyEvents="true" ID="txtFullName"
                                                                            EmptyText="Tìm kiếm theo mã, tên nhân viên">
                                                                            <Triggers>
                                                                                <ext:FieldTrigger HideTrigger="true" Icon="Clear" />
                                                                            </Triggers>
                                                                            <Listeners>
                                                                                <KeyPress Fn="enterKeyToSearch" />
                                                                                <TriggerClick Handler="this.clear(); this.triggers[0].hide(); PagingToolbar1.pageIndex = 0;  PagingToolbar1.doLoad();" />
                                                                            </Listeners>
                                                                        </ext:TriggerField>
                                                                        <ext:Button ID="Button8" runat="server" Text="<%$ Resources:Language, search%>" Icon="Zoom">
                                                                            <Listeners>
                                                                                <Click Handler="PagingToolbar1.pageIndex = 0;  PagingToolbar1.doLoad();" />
                                                                            </Listeners>
                                                                        </ext:Button>
                                                                    </Items>
                                                                </ext:Toolbar>
                                                            </TopBar>
                                                            <ColumnModel ID="ColumnModel1" runat="server">
                                                                <Columns>
                                                                    <ext:RowNumbererColumn Header="STT" Width="30" Align="Left">
                                                                    </ext:RowNumbererColumn>
                                                                    <ext:Column ColumnID="colMaNhanVien" Width="100" DataIndex="MaNhanVien" Header="<%$ Resources:HOSO, staff_code%>">
                                                                    </ext:Column>
                                                                    <ext:Column ColumnID="colTenCanBo" Width="150" DataIndex="HoTen" Header="<%$ Resources:HOSO, staff_name%>">
                                                                    </ext:Column>
                                                                    <ext:Column ColumnID="colPhongBan" Width="150" DataIndex="PhongBan" Header="<%$ Resources:HOSO, staff_section%>">
                                                                    </ext:Column>
                                                                    <ext:Column ColumnID="colSoNamDongBHXH" Width="117" DataIndex="ThoiGianDongBaoHiem"
                                                                        Header="Số năm đóng BHXH" Align="Right">
                                                                        <Renderer Fn="RenderSoNam" />
                                                                    </ext:Column>
                                                                    <ext:Column ColumnID="colLuongBaoHiem" Width="107" DataIndex="LuongBaoHiem" Header="Lương bảo hiểm"
                                                                        Align="Right">
                                                                        <Renderer Fn="RenderVND" />
                                                                    </ext:Column>
                                                                    <ext:Column ColumnID="colPhuCapCV" Width="80" DataIndex="PhuCapCV" Header="Phụ cấp<br/>chức vụ"
                                                                        Align="Right">
                                                                        <Renderer Fn="RenderVND" />
                                                                    </ext:Column>
                                                                    <ext:Column ColumnID="colPhuCapTNN" Width="80" DataIndex="PhuCapTNN" Header="Phụ cấp<br/>TN nghề"
                                                                        Align="Right">
                                                                        <Renderer Fn="RenderVND" />
                                                                    </ext:Column>
                                                                    <ext:Column ColumnID="colPhuCapTNVK" Width="80" DataIndex="PhuCapTNVK" Header="Phụ cấp TN vượt khung"
                                                                        Align="Right">
                                                                        <Renderer Fn="RenderVND" />
                                                                    </ext:Column>
                                                                    <ext:Column ColumnID="colPhuCapKhac" Width="80" DataIndex="PhuCapKhac" Header="Phụ cấp khác"
                                                                        Align="Right">
                                                                        <Renderer Fn="RenderVND" />
                                                                    </ext:Column>
                                                                    <ext:CheckColumn ColumnID="colDangDongBHXH" Width="70" DataIndex="DangDongBHXH" Header="Đang đóng BHXH">
                                                                    </ext:CheckColumn>
                                                                    <ext:CheckColumn ColumnID="colDangDongBHYT" Width="70" DataIndex="DangDongBHYT" Header="Đang đóng BHYT">
                                                                    </ext:CheckColumn>
                                                                    <ext:CheckColumn ColumnID="colDangDongBHTN" Width="70" DataIndex="DangDongBHTN" Header="Đang đóng BHTN">
                                                                    </ext:CheckColumn>
                                                                    <ext:Column ColumnID="colTrangThai" Width="100" DataIndex="TrangThai" Header="Trạng thái">
                                                                    </ext:Column>
                                                                    <%--  <ext:CheckColumn ColumnID="colDanghi" Width="50" DataIndex="DaNghi" Header="Đã nghỉ">
                                                                        </ext:CheckColumn>--%>
                                                                </Columns>
                                                            </ColumnModel>
                                                            <View>
                                                                <ext:GroupingView ID="GroupingView1" runat="server" ForceFit="false" MarkDirty="false"
                                                                    ShowGroupName="false" EnableNoGroups="true" HideGroupedColumn="true">
                                                                </ext:GroupingView>
                                                            </View>
                                                            <BottomBar>
                                                                <ext:PagingToolbar ID="PagingToolbar1" EmptyMsg="<%$ Resources:HOSO, no_data%>" NextText="<%$ Resources:HOSO, next_page%>"
                                                                    PageSize="15" PrevText="<%$ Resources:HOSO, prev_page%>" LastText="<%$ Resources:HOSO, last_page%>"
                                                                    FirstText="<%$ Resources:HOSO, first_page%>" DisplayMsg="<%$ Resources:HOSO, description_record%>"
                                                                    runat="server">
                                                                    <Items>
                                                                        <ext:Label ID="Label1" runat="server" Text="<%$ Resources:HOSO, number_line_per_page%>" />
                                                                        <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                                                        <ext:ComboBox ID="ComboBoxPaging" runat="server" Width="80">
                                                                            <Items>
                                                                                <ext:ListItem Text="15" />
                                                                                <ext:ListItem Text="30" />
                                                                                <ext:ListItem Text="50" />
                                                                                <ext:ListItem Text="70" />
                                                                                <ext:ListItem Text="100" />
                                                                            </Items>
                                                                            <SelectedItem Value="15" />
                                                                            <Listeners>
                                                                                <Select Handler="#{PagingToolbar1}.pageSize = parseInt(this.getValue());#{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad();" />
                                                                            </Listeners>
                                                                        </ext:ComboBox>
                                                                    </Items>
                                                                </ext:PagingToolbar>
                                                            </BottomBar>
                                                            <SelectionModel>
                                                                <ext:RowSelectionModel runat="server" ID="RowSelectionModel2" SingleSelect="true">
                                                                    <Listeners>
                                                                        <RowSelect Handler="#{Button1}.enable(); #{Button2}.disable();#{Button5}.disable(); 
                                                                                                #{hdfMaNhanVien}.setValue(#{RowSelectionModel2}.getSelected().id);
                                                                                                RowSelectionModel1.clearSelections();
                                                                                                PagingToolbar3.pageIndex = 0; PagingToolbar3.doLoad();" />
                                                                        <RowDeselect Handler="#{Button1}.disable(); #{Button2}.disable();#{Button5}.disable(); 
                                                                                                #{hdfMaNhanVien}.reset(); #{hdfChiTietID}.reset();
                                                                                                RowSelectionModel1.clearSelections();" />
                                                                    </Listeners>
                                                                </ext:RowSelectionModel>
                                                            </SelectionModel>
                                                            <LoadMask ShowMask="true" />
                                                            <LoadMask ShowMask="true" />
                                                        </ext:GridPanel>
                                                    </Items>
                                                </ext:Panel>
                                            </Items>
                                        </ext:LayoutRow>
                                        <ext:LayoutRow runat="server" RowHeight="0.35">
                                            <Items>
                                                <ext:Panel ID="Panel3" runat="server" AnchorHorizontal="99%" AnchorVertical="99%"
                                                    Title="Các biến động phát sinh" Layout="BorderLayout" Border="false">
                                                    <Items>
                                                        <ext:GridPanel runat="server" ID="grpChiTietNhanVien" StoreID="grpChiTietNhanVienStore"
                                                            Border="false" Region="Center" AnchorHorizontal="99%" AnchorVertical="99%" StripeRows="true"
                                                            TrackMouseOver="False" AutoExpandColumn="colTenBienDong" AutoExpandMin="300"
                                                            AutoScroll="true">
                                                            <TopBar>
                                                                <ext:Toolbar ID="Toolbar3" runat="server">
                                                                    <Items>
                                                                        <ext:Button runat="server" ID="Button1" Icon="Add" Text="<%$ Resources:CommonMessage, Add%>"
                                                                            Disabled="true">
                                                                            <Listeners>
                                                                                <Click Handler="btnCapNhat1.show();Ext.net.DirectMethods.loadThongTinNhanVien(); wdThemSuaBienDongNhanVien.show();hdfwdShow.setValue('wdThem'); " />
                                                                            </Listeners>
                                                                        </ext:Button>
                                                                        <ext:Button runat="server" ID="Button2" Icon="Pencil" Text="<%$ Resources:CommonMessage, Edit%>"
                                                                            Disabled="true">
                                                                            <Listeners>
                                                                                <Click Handler="if (CheckSelectedRows(grpChiTietNhanVien)){if(#{hdfChiTietID}.getValue() != ''){Ext.net.DirectMethods.loadThongTinBienDong(); wdThemSuaBienDongNhanVien.show();btnCapNhatSua1.show();}}" />
                                                                            </Listeners>
                                                                        </ext:Button>
                                                                        <ext:Button runat="server" ID="Button5" Icon="Delete" Text="<%$ Resources:Language, delete%>"
                                                                            Disabled="true">
                                                                            <Listeners>
                                                                                <Click Handler="XoaDongBienDong(grpChiTietNhanVien,grpChiTietNhanVienStore);" />
                                                                            </Listeners>
                                                                        </ext:Button>
                                                                        <ext:ToolbarSpacer>
                                                                        </ext:ToolbarSpacer>
                                                                        <ext:ToolbarSeparator>
                                                                        </ext:ToolbarSeparator>
                                                                        <ext:Button runat="server" ID="Button7" Icon="Script" Text="Mẫu in" Hidden="true">
                                                                        </ext:Button>
                                                                    </Items>
                                                                </ext:Toolbar>
                                                            </TopBar>
                                                            <ColumnModel ID="ColumnModel3" runat="server">
                                                                <Columns>
                                                                    <ext:RowNumbererColumn Header="STT" Width="30" Align="Left" Locked="true">
                                                                    </ext:RowNumbererColumn>
                                                                    <ext:Column ColumnID="colMaBienDong" Width="100" DataIndex="MaBienDong" Header="Mã biến động"
                                                                        Locked="true">
                                                                    </ext:Column>
                                                                    <ext:Column ColumnID="colTenBienDong" Width="300" DataIndex="TenBienDong" Header="Tên biến động"
                                                                        Locked="true">
                                                                    </ext:Column>
                                                                    <ext:DateColumn ColumnID="colTuNgay" Width="100" DataIndex="TuNgay" Header="Từ ngày"
                                                                        Format="dd/MM/yyyy">
                                                                    </ext:DateColumn>
                                                                    <ext:DateColumn ColumnID="colDenNgay" Width="100" DataIndex="DenNgay" Header="Đến ngày"
                                                                        Format="dd/MM/yyyy">
                                                                    </ext:DateColumn>
                                                                    <ext:Column ColumnID="colSoNgayNghi" Width="100" DataIndex="SoNgayNghi" Header="Số ngày nghỉ"
                                                                        Align="Right">
                                                                        <Renderer Fn="RenderSoNgay" />
                                                                    </ext:Column>
                                                                    <ext:Column ColumnID="colTienLuongCu" Width="100" DataIndex="TienLuongCu" Header="Tiền lương cũ">
                                                                        <Renderer Fn="RenderVND" />
                                                                    </ext:Column>
                                                                    <ext:Column ColumnID="colPhuCapCVCu" Width="120" DataIndex="PhuCapCVCu" Header="Phụ cấp chức vụ cũ">
                                                                        <Renderer Fn="RenderVND" />
                                                                    </ext:Column>
                                                                    <ext:Column ColumnID="colPhuCapNgheCu" Width="100" DataIndex="PhuCapNgheCu" Header="Phụ cấp nghề cũ">
                                                                        <Renderer Fn="RenderVND" />
                                                                    </ext:Column>
                                                                    <ext:Column ColumnID="PhuCapTNVKCu" Width="120" DataIndex="PhuCapTNVKCu" Header="Phụ cấp TNVK cũ">
                                                                        <Renderer Fn="RenderVND" />
                                                                    </ext:Column>
                                                                    <ext:Column ColumnID="TienLuongMoi" Width="100" DataIndex="TienLuongMoi" Header="Tiền lương mới">
                                                                        <Renderer Fn="RenderVND" />
                                                                    </ext:Column>
                                                                    <ext:Column ColumnID="PhuCapCVMoi" Width="120" DataIndex="PhuCapCVMoi" Header="Phụ cấp chức vụ mới">
                                                                        <Renderer Fn="RenderVND" />
                                                                    </ext:Column>
                                                                    <ext:Column ColumnID="PhuCapTNNgheMoi" Width="100" DataIndex="PhuCapTNNgheMoi" Header="Phụ cấp nghề mới">
                                                                        <Renderer Fn="RenderVND" />
                                                                    </ext:Column>
                                                                    <ext:Column ColumnID="PhuCapTNVKMoi" Width="100" DataIndex="PhuCapTNVKMoi" Header="Phụ cấp TNVK mới">
                                                                        <Renderer Fn="RenderVND" />
                                                                    </ext:Column>
                                                                    <ext:CheckColumn ColumnID="colKhongTraThe" Width="90" DataIndex="KhongTraThe" Header="Không trả thẻ">
                                                                    </ext:CheckColumn>
                                                                    <ext:CheckColumn ColumnID="colDaCoSo" Width="80" DataIndex="DaCoSo" Header="Đã có sổ">
                                                                    </ext:CheckColumn>
                                                                    <%--  <ext:CheckColumn ColumnID="colDaDuyet" Width="80" DataIndex="DaDuyet" Header="Đã duyệt">
                                                                    </ext:CheckColumn>--%>
                                                                    <ext:DateColumn ColumnID="colNgayTao" Width="100" DataIndex="DateCreate" Header="Ngày tạo"
                                                                        Format="dd/MM/yyyy">
                                                                    </ext:DateColumn>
                                                                </Columns>
                                                            </ColumnModel>
                                                            <BottomBar>
                                                                <ext:PagingToolbar ID="PagingToolbar3" EmptyMsg="<%$ Resources:HOSO, no_data%>" NextText="<%$ Resources:HOSO, next_page%>"
                                                                    PageSize="5" PrevText="<%$ Resources:HOSO, prev_page%>" LastText="<%$ Resources:HOSO, last_page%>"
                                                                    FirstText="<%$ Resources:HOSO, first_page%>" DisplayMsg="<%$ Resources:HOSO, description_record%>"
                                                                    runat="server">
                                                                    <Items>
                                                                        <ext:Label ID="Label3" runat="server" Text="<%$ Resources:HOSO, number_line_per_page%>" />
                                                                        <ext:ToolbarSpacer ID="ToolbarSpacer3" runat="server" Width="10" />
                                                                        <ext:ComboBox ID="ComboBox2" runat="server" Width="80">
                                                                            <Items>
                                                                                <ext:ListItem Text="5" />
                                                                                <ext:ListItem Text="10" />
                                                                                <ext:ListItem Text="15" />
                                                                                <ext:ListItem Text="20" />
                                                                                <ext:ListItem Text="100" />
                                                                            </Items>
                                                                            <SelectedItem Value="5" />
                                                                            <Listeners>
                                                                                <Select Handler="#{PagingToolbar3}.pageSize = parseInt(this.getValue()); #{PagingToolbar3}.doLoad();" />
                                                                            </Listeners>
                                                                        </ext:ComboBox>
                                                                    </Items>
                                                                    <Listeners>
                                                                        <Change Handler="#{RowSelectionModel1}.clearSelections();" />
                                                                    </Listeners>
                                                                </ext:PagingToolbar>
                                                            </BottomBar>
                                                            <View>
                                                                <ext:LockingGridView runat="server" ID="lkv" LockText="Cố định cột này lại" UnlockText="Hủy cố định cột">
                                                                </ext:LockingGridView>
                                                            </View>
                                                            <SelectionModel>
                                                                <ext:RowSelectionModel runat="server" ID="RowSelectionModel1">
                                                                    <Listeners>
                                                                        <RowSelect Handler="#{Button2}.enable();#{Button5}.enable();#{hdfChiTietID}.setValue(#{RowSelectionModel1}.getSelected().id);" />
                                                                        <RowDeselect Handler="#{Button2}.disable();#{Button5}.disable();#{hdfChiTietID}.reset();" />
                                                                    </Listeners>
                                                                </ext:RowSelectionModel>
                                                            </SelectionModel>
                                                            <Listeners>
                                                                <DblClick Handler="if(#{hdfChiTietID}.getValue() != ''){Ext.net.DirectMethods.loadThongTinBienDong(); wdThemSuaBienDongNhanVien.show();btnCapNhatSua1.show();}" />
                                                            </Listeners>
                                                            <LoadMask ShowMask="true" />
                                                        </ext:GridPanel>
                                                    </Items>
                                                </ext:Panel>
                                            </Items>
                                        </ext:LayoutRow>
                                    </Rows>
                                </ext:RowLayout>
                            </Items>
                        </ext:Panel>
                    </Center>
                    <%--  <South>
                    </South>--%>
                </ext:BorderLayout>
            </Items>
        </ext:Viewport>
    </div>
    </form>
</body>
</html>
