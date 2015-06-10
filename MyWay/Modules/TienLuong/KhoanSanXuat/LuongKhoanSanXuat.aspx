<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LuongKhoanSanXuat.aspx.cs"
    Inherits="Modules_TienLuong_KhoanSanXuat_LuongKhoanSanXuat" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../../Resource/js/RenderJS.js" type="text/javascript"></script>
    <style type="text/css">
        .hsl_template1
        {
            line-height: 18px;
            border-bottom: 1px solid #DDE7FC;
            text-align: center;
        }
        
        .ml_template1
        {
            line-height: 18px;
            text-align: center;
        }
        
        .hsl_template
        {
            line-height: 25px;
            border-bottom: 1px solid #DDE7FC;
            white-space: nowrap;
        }
        .hsl_tembottom
        {
            border-bottom: 1px solid #C1C1C1;
        }
        .ml_template
        {
            line-height: 25px;
            border-bottom: 1px solid #C1C1C1;
            white-space: nowrap;
        }
        #tb .x-form-item
        {
            margin-bottom: 0 !important;
        }
    </style>
    <script type="text/javascript">
        var enterKeyPressHandler = function (f, e) {
            if (e.getKey() == e.ENTER) {
                GridPanel1.getSelectionModel().clearSelections();
                PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad();
            }
        }
        var RenderHoTen = function (value, p, record) {
            if (value == null)
                arr = new Array(0);
            else
                var arr = value.split('##');
            if (arr.length > 1) {
                var rs = "<div class='hsl_template'>";
                rs += arr[0];
                rs += "</div><div class='ml_template'>";
                rs += arr[1];
                rs += "</div>";
            }
            else
                rs = '';
            return rs;
        }
        var RenderNgay = function (value, p, record) {
            if (value == null)
                arr = new Array(0);
            else
                var arr = value.split('##');
            if (arr.length > 1) {
                var rs = '<div style="width:185px">';
                rs += '<div style="width:100%;">';
                rs += '<div style="width:50%; float:left" class="hsl_template1">ĐK: ' + arr[0] + '</div>';
                rs += '<div style="width:50%; float:left" class="hsl_template1">GL: ' + arr[1] + '</div>';
                rs += '</div>';
                rs += '<div style="width:100%;">';
                rs += '<div style="width:50%; float:left" class="hsl_template1">SPC: ' + arr[2] + '</div>';
                rs += '<div style="width:50%; float:left" class="hsl_template1">SPP: ' + arr[3] + '</div>';
                rs += '</div>';
                rs += '<div style="text-align:center" class="hsl_tembottom">' + arr[4] + '</div>';
                rs += '</div>';
            }
            else
                rs = '';
            return rs;
        }
        var ResetWindows = function () {
            hdfCanBo.reset(); cbCanBo.reset(); txtSoGioDangKy.reset(); txtSanPhamChinh.reset();
            cbxNgay.reset(); txtSoGioLamViec.reset(); txtSanPhamPhu.reset(); txtLuongSanPham.reset();
            txtLuongCongNhat.reset(); txtLuongHoTro.reset(); txtLuongKhac.reset(); txtSoGioCaTo.reset();
        }
        var CheckInputLuongKhoan = function () {
            if (!cbCanBo.getValue()) {
                alert('Bạn chưa chọn cán bộ');
                cbCanBo.focus();
                return false;
            }
            if (!hdfNgay.getValue()) {
                alert('Bạn chưa chọn ngày');
                cbxNgay.focus();
                return false;
            }
            //            if (!txtSoGioDangKy.getValue()) {
            //                alert('Bạn chưa nhập số giờ đăng ký');
            //                txtSoGioDangKy.focus();
            //                return false;
            //            }
            //            if (!txtSoGioLamViec.getValue()) {
            //                alert('Bạn chưa nhập số giờ làm việc');
            //                txtSoGioLamViec.focus();
            //                return false;
            //            }
            //            if (!txtSanPhamChinh.getValue()) {
            //                alert('Bạn chưa nhập số lượng sản phẩm chính');
            //                txtSanPhamChinh.focus();
            //                return false;
            //            }
            //            if (!txtSanPhamPhu.getValue()) {
            //                alert('Bạn chưa nhập số lượng sản phẩm phụ');
            //                txtSanPhamPhu.focus();
            //                return false;
            //            }
            //            if (!txtLuongSanPham.getValue()) {
            //                alert('Bạn chưa nhập lương sản phẩm');
            //                txtLuongSanPham.focus();
            //                return false;
            //            }
            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager runat="server" ID="RM" />
        <ext:Hidden runat="server" ID="hdfMax" />
        <ext:Hidden runat="server" ID="hdfUserID" />
        <ext:Hidden runat="server" ID="hdfMenuID" />
        <ext:Hidden runat="server" ID="hdfMaDonVi" />
        <ext:Hidden runat="server" ID="hdfLuongCoBan" />
        <ext:Hidden runat="server" ID="hdfIsSelected" />
        <ext:Window Modal="true" Hidden="true" runat="server" Layout="BorderLayout" ID="wdBangCongThucLuongKhoan"
            Title="Bảng công thức tính lương khoán" Maximized="true" Icon="Date">
            <Items>
                <ext:TabPanel ID="pnBangCongThucLuongKhoan" Region="Center" AnchorVertical="100%"
                    Border="false" runat="server">
                </ext:TabPanel>
            </Items>
            <Listeners>
                <BeforeShow Handler="#{pnBangCongThucLuongKhoan}.remove(0);addHomePage(#{pnBangCongThucLuongKhoan},'Homepage','BangCongThucLuongKhoan.aspx', 'Bảng công thức tính lương khoán')" />
            </Listeners>
            <Buttons>
                <ext:Button ID="Button3" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdxemchedotheothang}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Window runat="server" ID="wdAddDepartment" Title="Thêm nhân viên theo bộ phận"
            Hidden="true" Icon="Add" Modal="true" Constrain="true" Width="450" Layout="FormLayout"
            Padding="6" AutoHeight="true">
            <Items>
                <ext:MultiCombo runat="server" ID="mcbxBoPhan" FieldLabel="Bộ phận" Editable="false"
                    AnchorHorizontal="100%" SelectionMode="All" DisplayField="TEN" ValueField="MA">
                    <Store>
                        <ext:Store runat="server" ID="cbx_bophan_Store" AutoLoad="false" OnRefreshData="cbx_bophan_Store_OnRefreshData">
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
                        <Expand Handler="if (cbx_bophan_Store.getCount() == 0) cbx_bophan_Store.reload();" />
                    </Listeners>
                </ext:MultiCombo>
                <ext:Container runat="server" ID="ctn1111" Layout="FitLayout" AnchorHorizontal="100%">
                    <Items>
                        <ext:DisplayField runat="server" ID="dpf" Text="Tất cả nhân viên trong các đơn vị được chọn sẽ được thêm vào bảng lương khoán" />
                    </Items>
                </ext:Container>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnAccept" Text="Đồng ý" Icon="Accept">
                    <Listeners>
                        <Click Handler="if (!mcbxBoPhan.getValue()) {alert('Bạn chưa chọn bộ phận áp dụng'); return false;}" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="ThemNhanVienTheoBoPhan_CLick">
                            <EventMask ShowMask="true" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="Button4" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="wdAddDepartment.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="mcbxBoPhan.reset();" />
            </Listeners>
        </ext:Window>
        <ext:Window Modal="true" Hidden="true" runat="server" Layout="FormLayout" ID="wdLuongKhoanSanXuat"
            Title="Thay đổi thông tin lương sản phẩm" Icon="Money" Constrain="true" Width="500"
            Padding="6" AutoHeight="true">
            <Items>
                <ext:FieldSet runat="server" ID="fs1" Title="Lương khoán sản xuất" Layout="FormLayout"
                    AnchorHorizontal="100%">
                    <Items>
                        <ext:Hidden runat="server" ID="hdfQDLuong" />
                        <ext:Hidden runat="server" ID="hdfMaBoPhan" />
                        <ext:Container runat="server" ID="ctn1" Layout="ColumnLayout" AnchorHorizontal="100%"
                            Height="105">
                            <Items>
                                <ext:Container runat="server" ID="ctn2" Layout="FormLayout" ColumnWidth="0.5">
                                    <Items>
                                        <ext:Hidden runat="server" ID="hdfCanBo" />
                                        <ext:ComboBox AnchorHorizontal="98%" ValueField="MACB" DisplayField="HOTEN" runat="server"
                                            FieldLabel="Mã cán bộ<span style='color:red;'>*</span>" PageSize="10" HideTrigger="true"
                                            ItemSelector="div.search-item" MinChars="1" EmptyText="nhập tên để tìm kiếm"
                                            ID="cbCanBo" LoadingText="Đang tải dữ liệu...">
                                            <Store>
                                                <ext:Store ID="Store3" runat="server" AutoLoad="false">
                                                    <Proxy>
                                                        <ext:HttpProxy Method="POST" Url="../../HoSoNhanSu/QuyetDinhLuong/SearchUserHandler.ashx" />
                                                    </Proxy>
                                                    <Reader>
                                                        <ext:JsonReader Root="plants" TotalProperty="total">
                                                            <Fields>
                                                                <ext:RecordField Name="HOTEN" />
                                                                <ext:RecordField Name="MACB" />
                                                                <ext:RecordField Name="NGAYSINH" />
                                                                <ext:RecordField Name="PHONGBAN" />
                                                                <ext:RecordField Name="PRKEY" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                            <Template ID="Template3" runat="server">
                                                <Html>
                                                    <tpl for=".">
						                      <div class="search-item">
							                     <h3>{HOTEN}</h3>
                                                 {MACB} <br />
                                                 <tpl if="NGAYSINH &gt; ''">{NGAYSINH:date("d/m/Y")}</tpl><br />
							                     {PHONGBAN}
						                      </div>
					                       </tpl>
                                                </Html>
                                            </Template>
                                            <Listeners>
                                                <Select Handler="hdfCanBo.setValue(cbCanBo.getValue());" />
                                            </Listeners>
                                            <DirectEvents>
                                                <Select OnEvent="cbCanBo_Selected" />
                                            </DirectEvents>
                                        </ext:ComboBox>
                                        <ext:TextField runat="server" ID="txtSoGioDangKy" TabIndex="1" FieldLabel="Giờ đăng ký"
                                            AnchorHorizontal="98%" MaskRe="/[0-9.,]/">
                                        </ext:TextField>
                                        <ext:TextField runat="server" ID="txtSoGioCaTo" TabIndex="3" FieldLabel="Giờ cả tổ"
                                            MaskRe="/[0-9.,]/" AnchorHorizontal="98%" />
                                        <ext:TextField runat="server" ID="txtSanPhamChinh" TabIndex="3" FieldLabel="Sản phẩm chính"
                                            AnchorHorizontal="98%">
                                            <DirectEvents>
                                                <Blur OnEvent="ThayDoi">
                                                </Blur>
                                            </DirectEvents>
                                        </ext:TextField>
                                    </Items>
                                </ext:Container>
                                <ext:Container runat="server" ID="ctn3" Layout="FormLayout" ColumnWidth="0.5">
                                    <Items>
                                        <ext:Hidden runat="server" ID="hdfNgay" />
                                        <ext:ComboBox runat="server" ID="cbxNgay" FieldLabel="Ngày<span style='color:red;'>*</span>"
                                            DisplayField="TEN" ValueField="MA" AnchorHorizontal="100%" Editable="false">
                                            <Triggers>
                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                            </Triggers>
                                            <Store>
                                                <ext:Store runat="server" ID="cbxNgayStore" AutoLoad="false" OnRefreshData="cbxNgayStore_OnRefreshData">
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
                                                <Expand Handler="if(cbxNgay.store.getCount()==0) cbxNgay.store.reload();" />
                                                <Select Handler="this.triggers[0].show(); hdfNgay.setValue(cbxNgay.getValue())" />
                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                            </Listeners>
                                        </ext:ComboBox>
                                        <ext:TextField runat="server" ID="txtSoGioLamViec" TabIndex="2" FieldLabel="Giờ làm việc"
                                            AnchorHorizontal="100%" MaskRe="/[0-9.,]/">
                                        </ext:TextField>
                                        <ext:Container runat="server" ID="ctnasds" Height="27" />
                                        <ext:TextField runat="server" ID="txtSanPhamPhu" TabIndex="4" FieldLabel="Sản phẩm phụ"
                                            AnchorHorizontal="100%" Text="0">
                                        </ext:TextField>
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:Container>
                        <ext:TextField runat="server" ID="txtLuongSanPham" FieldLabel="Lương sản phẩm" TabIndex="5"
                            AnchorHorizontal="100%">
                        </ext:TextField>
                    </Items>
                </ext:FieldSet>
                <ext:FieldSet runat="server" ID="fs2" Layout="FormLayout" AnchorHorizontal="100%"
                    Title="Lương khác">
                    <Items>
                        <ext:Container runat="server" ID="ctn333" Layout="ColumnLayout" AnchorHorizontal="100%"
                            Height="55">
                            <Items>
                                <ext:Container runat="server" ID="ctn334" Layout="FormLayout" ColumnWidth="0.5">
                                    <Items>
                                        <ext:TextField runat="server" ID="txtLuongCongNhat" FieldLabel="Lương công nhật"
                                            MaskRe="/[0-9]/" AnchorHorizontal="98%" MaxLength="18">
                                        </ext:TextField>
                                        <ext:CompositeField runat="server" ID="cpf" FieldLabel="Lương hỗ trợ" AnchorHorizontal="98%">
                                            <Items>
                                                <ext:TextField runat="server" ID="txtLuongHoTro" MaskRe="/[0-9]/" Width="90" MaxLength="8">
                                                </ext:TextField>
                                                <ext:DisplayField runat="server" Text="%" />
                                            </Items>
                                        </ext:CompositeField>
                                    </Items>
                                </ext:Container>
                                <ext:Container runat="server" ID="ctn335" Layout="FormLayout" ColumnWidth="0.5">
                                    <Items>
                                        <ext:TextField runat="server" ID="txtLuongKhac" FieldLabel="Lương khác" MaskRe="/[0-9]/"
                                            AnchorHorizontal="100%" MaxLength="18">
                                        </ext:TextField>
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:FieldSet>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnCapNhat" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckInputLuongKhoan();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnCapNhat_Click">
                            <EventMask ShowMask="true" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnCapNhatEdit" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckInputLuongKhoan();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnCapNhat_Click">
                            <EventMask ShowMask="true" />
                            <ExtraParams>
                                <ext:Parameter Name="Edit" Value="True" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnUpdateAndClose" Text="Cập nhật và đóng lại" Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckInputLuongKhoan();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnCapNhat_Click">
                            <EventMask ShowMask="true" />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="True" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnDong" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="wdLuongKhoanSanXuat.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="ResetWindows();" />
            </Listeners>
        </ext:Window>
        <ext:Window runat="server" ID="wdNhapTuExcel" Width="500" Icon="PageExcel" Title="Đọc từ file excel"
            Height="160" Padding="10" Modal="true" Constrain="true" Hidden="true" Layout="FormLayout">
            <Items>
                <ext:FormPanel ID="BasicForm" runat="server" Border="false" MonitorValid="true" Layout="FormLayout"
                    AutoHeight="true">
                    <Items>
                        <ext:FileUploadField ID="FileUploadField1" runat="server" Text="" FieldLabel="Chọn file Excel<span style='color:red;'>*</span>"
                            CtCls="requiredData" Icon="PageExcel" AnchorHorizontal="100%" AllowBlank="false">
                            <Listeners>
                                <FileSelected Handler="if(#{FileUploadField1}.getValue().lastIndexOf('.xls')!=-1 || #{FileUploadField1}.getValue().lastIndexOf('.xlsx')!=-1){
                                    #{cbSheetNameStore}.reload();#{cbSheetName}.enable();
                                    }" />
                            </Listeners>
                        </ext:FileUploadField>
                        <ext:ComboBox ID="cbSheetName" Disabled="true" FieldLabel="Chọn sheet<span style='color:red;'>*</span>"
                            CtCls="requiredData" SelectedIndex="0" Editable="false" AnchorHorizontal="100%"
                            runat="server" DisplayField="SheetName" ValueField="SheetName" SelectOnFocus="true"
                            AllowBlank="false">
                            <Store>
                                <ext:Store ID="cbSheetNameStore" runat="server" OnRefreshData="cbSheetNameStore_OnRefreshData"
                                    AutoLoad="false" EnableViewState="false">
                                    <DirectEventConfig>
                                        <EventMask ShowMask="false" />
                                    </DirectEventConfig>
                                    <Reader>
                                        <ext:JsonReader IDProperty="SheetName">
                                            <Fields>
                                                <ext:RecordField Name="SheetName" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                        </ext:ComboBox>
                    </Items>
                    <Listeners>
                        <ClientValidation Handler="#{btnImport}.setDisabled(!valid);" />
                    </Listeners>
                </ext:FormPanel>
            </Items>
            <Buttons>
                <ext:Button ID="btnTaiTepMau" runat="server" Text="Tải file mẫu" Icon="Attach">
                    <DirectEvents>
                        <Click OnEvent="DownloadBangChamCongMau" IsUpload="true" />
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnImport" runat="server" Text="Nhập dữ liệu" Hidden="false" Icon="Accept">
                    <DirectEvents>
                        <Click OnEvent="ImportDataFromExcel">
                            <EventMask ShowMask="true" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="Button2" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="wdNhapTuExcel.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="#{FileUploadField1}.reset(); #{cbSheetName}.reset();" />
            </Listeners>
        </ext:Window>
        <ext:Store ID="Store1" AutoLoad="true" runat="server">
            <Proxy>
                <ext:HttpProxy Method="GET" Url="LuongKhoanSanXuatHandler.ashx" />
            </Proxy>
            <AutoLoadParams>
                <ext:Parameter Name="start" Value="={0}" />
                <ext:Parameter Name="limit" Value="={30}" />
            </AutoLoadParams>
            <BaseParams>
                <ext:Parameter Name="month" Value="cbxMonth.getValue()" Mode="Raw" />
                <ext:Parameter Name="year" Value="spnYear.getValue()" Mode="Raw" />
                <ext:Parameter Name="MaDonVi" Value="hdfMaDonVi.getValue()" Mode="Raw" />
                <ext:Parameter Name="searchKey" Value="txtSearchKey.getValue()" Mode="Raw" />
                <ext:Parameter Name="UserID" Value="hdfUserID.getValue()" Mode="Raw" />
                <ext:Parameter Name="MenuID" Value="hdfMenuID.getValue()" Mode="Raw" />
            </BaseParams>
            <Reader>
                <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="MA_CB">
                    <Fields>
                        <ext:RecordField Name="MA_CB" />
                        <ext:RecordField Name="HO_TEN" />
                        <ext:RecordField Name="TEN_CHUCVU" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        <ext:Viewport runat="server">
            <Items>
                <ext:BorderLayout runat="server" ID="br">
                    <Center>
                        <ext:GridPanel ID="GridPanel1" runat="server" StripeRows="true" TrackMouseOver="true"
                            Title="Bảng lương sản phẩm" Icon="BookOpenMark" Width="1000" Height="400" Border="false"
                            StoreID="Store1" Header="false">
                            <TopBar>
                                <ext:Toolbar runat="server" ID="tb">
                                    <Items>
                                        <ext:Button runat="server" ID="btnAddAll" Text="Thêm mới" Icon="Add">
                                            <Menu>
                                                <ext:Menu runat="server">
                                                    <Items>
                                                        <ext:MenuItem runat="server" ID="mnuAddOne" Text="Thêm mới nhân viên" Icon="UserAdd">
                                                            <Listeners>
                                                                <Click Handler="btnCapNhat.show();btnCapNhatEdit.hide();btnUpdateAndClose.show();
                                                                    cbCanBo.enable(); cbxNgay.enable();" />
                                                            </Listeners>
                                                            <DirectEvents>
                                                                <Click OnEvent="mnuAddOne_Click" />
                                                            </DirectEvents>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem runat="server" ID="mnuAddDepartment" Text="Thêm nhân viên theo bộ phận"
                                                            Icon="UserAdd">
                                                            <Listeners>
                                                                <Click Handler="wdAddDepartment.show();" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                    </Items>
                                                </ext:Menu>
                                            </Menu>
                                        </ext:Button>
                                        <ext:Button runat="server" ID="btnSua" Text="Sửa" Icon="Pencil" Disabled="true">
                                            <Listeners>
                                                <Click Handler="if (#{hdfIsSelected}.getValue() != 'true') 
                                                    { alert('Bạn chưa ô nào để sửa!'); return false; } 
                                                    cbCanBo.disable();cbxNgay.disable();" />
                                            </Listeners>
                                            <DirectEvents>
                                                <Click OnEvent="btnSua_Click" Before="btnCapNhat.hide();btnCapNhatEdit.show();btnUpdateAndClose.hide();">
                                                    <EventMask ShowMask="true" />
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:Button runat="server" ID="btnDeleteEmployee" Text="Xóa" Icon="Delete" Disabled="true">
                                            <Menu>
                                                <ext:Menu runat="server">
                                                    <Items>
                                                        <ext:MenuItem runat="server" ID="mnuXoaTheoNgay" Text="Xóa theo ngày" Icon="Delete">
                                                            <Listeners>
                                                                <Click Handler="if (hdfIsSelected.getValue() != 'true') {alert('Bạn chưa chọn ô nào'); return false;}" />
                                                            </Listeners>
                                                            <DirectEvents>
                                                                <Click OnEvent="mnuXoaLuongKhoan_Click">
                                                                    <EventMask ShowMask="true" />
                                                                    <Confirmation ConfirmRequest="true" Message="Bạn có chắc chắn muốn xóa không?" />
                                                                    <ExtraParams>
                                                                        <ext:Parameter Name="Delete" Value="day" />
                                                                    </ExtraParams>
                                                                </Click>
                                                            </DirectEvents>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem runat="server" ID="mnuXoaNhanVien" Text="Xóa nhân viên" Icon="Delete">
                                                            <Listeners>
                                                                <Click Handler="if (hdfIsSelected.getValue() != 'true') {alert('Bạn chưa chọn ô nào'); return false;}" />
                                                            </Listeners>
                                                            <DirectEvents>
                                                                <Click OnEvent="mnuXoaLuongKhoan_Click">
                                                                    <EventMask ShowMask="true" />
                                                                    <Confirmation ConfirmRequest="true" Message="Bạn có chắc chắn muốn xóa không?" />
                                                                    <ExtraParams>
                                                                        <ext:Parameter Name="Delete" Value="employee" />
                                                                    </ExtraParams>
                                                                </Click>
                                                            </DirectEvents>
                                                        </ext:MenuItem>
                                                    </Items>
                                                </ext:Menu>
                                            </Menu>
                                        </ext:Button>
                                        <ext:Button runat="server" ID="btnImportFromExcel" Text="Nhập từ excel" Icon="PageExcel">
                                            <Listeners>
                                                <Click Handler="wdNhapTuExcel.show();" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:ToolbarSeparator runat="server" />
                                        <ext:Container runat="server" ID="ctn111" Layout="FormLayout" LabelWidth="65">
                                            <Items>
                                                <ext:ComboBox runat="server" ID="cbxMonth" Width="70" Editable="false" FieldLabel="Chọn tháng">
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
                                                    <Listeners>
                                                        <Select Handler="PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad();" />
                                                    </Listeners>
                                                </ext:ComboBox>
                                            </Items>
                                        </ext:Container>
                                        <ext:ToolbarSpacer runat="server" Width="5" />
                                        <ext:Container runat="server" ID="Container1" Layout="FormLayout" LabelWidth="60">
                                            <Items>
                                                <ext:SpinnerField runat="server" ID="spnYear" FieldLabel="Chọn năm" Width="55">
                                                    <Listeners>
                                                        <Spin Handler="PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad();" />
                                                    </Listeners>
                                                </ext:SpinnerField>
                                            </Items>
                                        </ext:Container>
                                        <ext:ToolbarSeparator ID="ToolbarSeparator1" runat="server" Width="10" />
                                        <ext:Button ID="Button1" runat="server" Icon="Help">
                                            <ToolTips>
                                                <ext:ToolTip ID="ToolTip1" runat="server" Title="Mô tả" Html="<table width='200' border='1' cellpadding='0' cellspacing='0'><tr><td><div align='center'>Giờ đăng ký</div></td><td><div align='center'>Giờ làm việc</div></td></tr><tr><td><div align='center'>Sản phẩm chính (Loại 20.25 kg)</div></td><td><div align='center'>Sản phẩm phụ (Loại 5 kg)</div></td></tr><tr><td colspan='2'><div align='center'>Lương sản phẩm</div></td></tr></table>" />
                                            </ToolTips>
                                        </ext:Button>
                                        <ext:ToolbarFill ID="ToolbarFill1" runat="server" />
                                        <ext:TriggerField runat="server" Width="200" EnableKeyEvents="true" EmptyText="Nhập tên hoặc tên nhân viên"
                                            ID="txtSearchKey">
                                            <Triggers>
                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                            </Triggers>
                                            <Listeners>
                                                <KeyPress Fn="enterKeyPressHandler" />
                                                <KeyUp Handler="if (txtSearchKey.getValue() != '') this.triggers[0].show();" />
                                                <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad(); }" />
                                            </Listeners>
                                        </ext:TriggerField>
                                        <ext:Button Text="Tìm kiếm" Icon="Zoom" runat="server" ID="btnSearch">
                                            <Listeners>
                                                <Click Handler="PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad();" />
                                            </Listeners>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <ColumnModel runat="server" ID="ColumnModel1">
                                <Columns>
                                    <ext:RowNumbererColumn Width="35" Header="STT" Locked="true" />
                                    <ext:Column ColumnID="MA_CB" Width="70" Header="Mã cán bộ" DataIndex="MA_CB" Locked="true">
                                    </ext:Column>
                                    <ext:Column ColumnID="HO_TEN" Width="120" Header="Họ tên" DataIndex="HO_TEN" Locked="true">
                                        <Renderer Fn="RenderHoTen" />
                                    </ext:Column>
                                    <ext:Column ColumnID="TEN_CHUCVU" Width="120" Header="Chức vụ" DataIndex="TEN_CHUCVU"
                                        Locked="true">
                                        <Renderer Fn="RenderHoTen" />
                                    </ext:Column>
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:CellSelectionModel runat="server" ID="CellSelectionModel1">
                                    <Listeners>
                                        <CellSelect Handler="#{hdfIsSelected}.setValue('true'); try{btnSua.enable();}catch(e){} try{btnDeleteEmployee.enable();}catch(e){}" />
                                    </Listeners>
                                    <%--<DirectEvents>
                                        <CellSelect OnEvent="Cell_Click" />
                                    </DirectEvents>--%>
                                </ext:CellSelectionModel>
                            </SelectionModel>
                            <View>
                                <ext:LockingGridView runat="server" ID="lkv">
                                </ext:LockingGridView>
                            </View>
                            <BottomBar>
                                <ext:PagingToolbar ID="PagingToolbar1" EmptyMsg="Hiện không có dữ liệu" NextText="Trang sau"
                                    PageSize="30" PrevText="Trang trước" LastText="Trang cuối cùng" FirstText="Trang đầu tiên"
                                    DisplayMsg="Dòng {0} đến dòng {1} / {2} dòng" runat="server">
                                    <Items>
                                        <ext:Label ID="Label1" runat="server" Text="Số bản ghi trên 1 trang:" />
                                        <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                        <ext:ComboBox ID="ComboBoxPaging" runat="server" Width="80">
                                            <Items>
                                                <ext:ListItem Text="20" />
                                                <ext:ListItem Text="30" />
                                                <ext:ListItem Text="40" />
                                                <ext:ListItem Text="50" />
                                            </Items>
                                            <SelectedItem Value="30" />
                                            <Listeners>
                                                <Select Handler="#{PagingToolbar1}.pageSize = parseInt(this.getValue()); #{PagingToolbar1}.doLoad();" />
                                            </Listeners>
                                        </ext:ComboBox>
                                    </Items>
                                </ext:PagingToolbar>
                            </BottomBar>
                            <LoadMask ShowMask="true" Msg="Đang tải dữ liệu. Vui lòng chờ..." />
                            <Listeners>
                                <CellContextMenu Handler="
                                    e.preventDefault(); #{CellContextMenu}.showAt(e.getXY());"></CellContextMenu>
                            </Listeners>
                            <%--<DirectEvents>
                                <CellDblClick OnEvent="btnSua_Click" Before="btnCapNhat.hide();btnCapNhatEdit.show();btnUpdateAndClose.hide();cbCanBo.disable();cbxNgay.disable();">
                                    <EventMask ShowMask="true" />
                                </CellDblClick>
                            </DirectEvents>--%>
                        </ext:GridPanel>
                    </Center>
                </ext:BorderLayout>
            </Items>
        </ext:Viewport>
    </div>
    </form>
</body>
</html>
