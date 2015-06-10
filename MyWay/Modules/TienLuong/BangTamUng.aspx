<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BangTamUng.aspx.cs" Inherits="Modules_TienLuong_BangTamUng" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register Src="~/Modules/Base/SingleGridPanel/SingleGridPanel.ascx" TagPrefix="uc1"
    TagName="SingleGridPanel" %>
<%@ Register Src="../ChooseEmployee/ucChooseEmployee.ascx" TagName="ucChooseEmployee"
    TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .search-item
        {
            font: normal 11px tahoma, arial, helvetica, sans-serif;
            padding: 3px 10px 3px 10px;
            border: 1px solid #fff;
            border-bottom: 1px solid #eeeeee;
            white-space: normal;
            color: #555;
        }
        
        .search-item h3
        {
            display: block;
            font: inherit;
            font-weight: bold;
            color: #222;
        }
        
        .search-item h3 span
        {
            float: right;
            font-weight: normal;
            margin: 0 0 5px 5px;
            width: 100px;
            display: block;
            clear: none;
        }
        
        p
        {
            width: 650px;
        }
        
        .ext-ie .x-form-text
        {
            position: static !important;
        }
    </style>
    <script src="Resource/BangTamUng.js" type="text/javascript"></script>
    <script src="../../Resource/js/RenderJS.js" type="text/javascript"></script>
    <script type="text/javascript">
        var resetFormHistory = function () {

            txaDescription.reset();
            dfPaidDate.reset();
            cbPaymentType.reset();
            nbfChietKhau.reset();
            nbfPaid.reset();
        }
        var CheckInputStoreHistory = function () { 
            if (dfPaidDate.getValue() == '') {
                alert('Bạn chưa nhập ngày thanh toán');
                dfPaidDate.focus();
                return false;
            }
            if (cbPaymentType.getValue() == '') {
                alert('Bạn chưa nhập hình thức thanh toán....');
                cbPaymentType.focus();
                return false;
            }
            if (nbfPaid.getValue() == '') {
                alert('Bạn chưa nhập thanh toán....');
                nbfPaid.focus();
                return false;
            } 
            return true; 
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:Hidden runat="server" ID="hdfPRKEYHOSO" />
        <ext:Hidden runat="server" ID="hdfRecordID" />
        <ext:Hidden runat="server" ID="hdfMaDonVi" />
        <ext:Hidden runat="server" ID="hdfSelectedEmployee" />
        <ext:Hidden runat="server" ID="hdfBangTamUngHistoryID" />
        <%-- <ext:Hidden runat="server" ID="hdfCurrentRecordID" />--%>
        <uc2:ucChooseEmployee ID="ucChooseEmployee1" runat="server" />
        <ext:Menu runat="server" ID="RowContextMenu">
            <Items>
                <ext:MenuItem ID="Button1" runat="server" Text="Thêm nhân viên tạm ứng" Icon="UserAdd">
                    <Menu>
                        <ext:Menu runat="server" ID="mnuUserAdd">
                            <Items>
                                <ext:MenuItem ID="MenuItem1" runat="server" Text="Thêm một nhân viên" Icon="UserAdd">
                                    <Listeners>
                                        <Click Handler="wdAddWindow.show();btnCapNhatThem.show();btnCapNhatThemVaDongLai.show();btnCapNhatSua.hide();" />
                                    </Listeners>
                                </ext:MenuItem>
                                <ext:MenuItem ID="mnuMultiple" runat="server" Text="Thêm nhiều nhân viên" Icon="GroupAdd">
                                    <Listeners>
                                        <Click Handler="#{wdCapNhatTamUngHangLoat}.show();" />
                                    </Listeners>
                                </ext:MenuItem>
                            </Items>
                        </ext:Menu>
                    </Menu>
                </ext:MenuItem>
                <ext:MenuItem ID="Button2" runat="server" Text="Sửa" Icon="Pencil">
                    <DirectEvents>
                        <Click OnEvent="btnSuaClick">
                            <EventMask ShowMask="true" />
                        </Click>
                    </DirectEvents>
                </ext:MenuItem>
                <ext:MenuItem ID="btnDeleteTamUng" runat="server" Text="Xóa" Icon="Delete">
                    <DirectEvents>
                        <Click OnEvent="btnDeleteTamUng_Click">
                            <Confirmation Title="Cảnh báo" Message="Bạn có chắc chắn muốn xóa không ? " ConfirmRequest="true" />
                            <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                        </Click>
                    </DirectEvents>
                </ext:MenuItem>
            </Items>
        </ext:Menu>
        <%--Thêm mới một nhân viên tạm ứng--%>
        <ext:Window runat="server" Resizable="false" Hidden="true" AutoHeight="true" Layout="FormLayout"
            Width="450" Modal="true" Padding="10" Constrain="true" ID="wdAddWindow" Title="Tạm ứng"
            Icon="Money" LabelWidth="125">
            <Items>
                <ext:ComboBox runat="server" TypeAhead="false" EmptyText="Nhập từ khóa để tìm kiếm"
                    CtCls="requiredData" DisplayField="HO_TEN" ValueField="PR_KEY" LoadingText="Đang tìm kiếm..."
                    AnchorHorizontal="100%" PageSize="10" HideTrigger="true" ItemSelector="div.search-item"
                    MinChars="1" Note="Bạn phải chọn 1 cán bộ" ID="cbonhanvien" FieldLabel="Chọn cán bộ<span style='color:red;'>*</span>"
                    Width="300">
                    <Store>
                        <ext:Store ID="StoreChonNhanVien" runat="server" AutoLoad="true">
                            <Proxy>
                                <ext:HttpProxy Method="POST" Url="Handler/ChonNhanVien.ashx" />
                            </Proxy>
                            <AutoLoadParams>
                                <ext:Parameter Name="Start" Value="={0}" />
                                <ext:Parameter Name="Limit" Value="={10}" />
                            </AutoLoadParams>
                            <BaseParams>
                                <ext:Parameter Name="MaDonVi" Value="#{hdfMaDonVi}.getValue()" Mode="Raw" />
                            </BaseParams>
                            <Reader>
                                <ext:JsonReader Root="plants" TotalProperty="total">
                                    <Fields>
                                        <ext:RecordField Name="HO_TEN" />
                                        <ext:RecordField Name="PR_KEY" />
                                        <ext:RecordField Name="MA_CB" />
                                        <ext:RecordField Name="TEN_PHONG" />
                                        <ext:RecordField Name="NGAY_SINH" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <Template ID="Template3" runat="server">
                        <Html>
                            <tpl for=".">
						                                  <div class="search-item">
							                                 <h3>{HO_TEN}</h3>
							                                 {TEN_PHONG}</BR>
                                                            Ngày sinh: {NGAY_SINH:date("d/m/Y")}
						                                  </div>
					                                   </tpl>
                        </Html>
                    </Template>
                    <Listeners>
                        <Select Handler="#{hdfPRKEYHOSO}.setValue(cbonhanvien.getValue());" />
                    </Listeners>
                    <DirectEvents>
                        <Select OnEvent="CheckDaThoiViec">
                        </Select>
                    </DirectEvents>
                </ext:ComboBox>
                <ext:DateField runat="server" ID="dfNgayTamUng" FieldLabel="Ngày tạm ứng<span style='color:red;'>*</span>"
                    CtCls="requiredData" AnchorHorizontal="100%" Editable="false">
                </ext:DateField>
                <%--  <ext:DateField runat="server" ID="dfThoiHanTamUng" FieldLabel="Thời hạn thanh toán<span style='color:red;'>*</span>"
                    CtCls="requiredData" Hidden="true" AnchorHorizontal="100%" Editable="false" Vtype="daterange">
                </ext:DateField>--%>
                <ext:TextField runat="server" ID="txtSoTien" FieldLabel="Số tiền<span style='color:red;'>*</span>"
                    CtCls="requiredData" MaxLength="11" MaxLengthText="11" AnchorHorizontal="100%"
                    MaskRe="/[0-9]/">
                </ext:TextField>
                <ext:TextField runat="server" ID="txtSoTienDaTra" FieldLabel="Số tiền đã trả" MaxLength="11"
                    Hidden="true" MaxLengthText="11" AnchorHorizontal="100%" MaskRe="/[0-9]/">
                </ext:TextField>
                <ext:TextArea runat="server" ID="txtLyDoTamUng" FieldLabel="Lý do tạm ứng" AnchorHorizontal="100%">
                </ext:TextArea>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnCapNhatThem" Text="Cập nhật" Icon="Disk" Hidden="true">
                    <Listeners>
                        <Click Handler="return checkInput();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnCapNhatThem_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu..." />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="False">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnCapNhatSua" Hidden="true" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return checkInput();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnCapNhatSua_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu..." />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnCapNhatThemVaDongLai" runat="server" Text="Cập nhật & Đóng lại"
                    Icon="Disk" Hidden="true">
                    <Listeners>
                        <Click Handler="return checkInput();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnCapNhatThem_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu..." />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="True">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnDongLai" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdAddWindow}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="resetForm();#{cbonhanvien}.enable();" />
            </Listeners>
        </ext:Window>
        <ext:Button runat="server" Text="Thêm nhân viên tạm ứng" ID="btnUserAdd" Icon="UserAdd">
            <Menu>
                <ext:Menu runat="server" ID="Menu1">
                    <Items>
                        <ext:MenuItem ID="MenuItem2" runat="server" Text="Thêm một nhân viên" Icon="UserAdd">
                            <Listeners>
                                <Click Handler="wdAddWindow.show();btnCapNhatThem.show();btnCapNhatThemVaDongLai.show();btnCapNhatSua.hide();" />
                            </Listeners>
                        </ext:MenuItem>
                        <ext:MenuItem ID="MenuItem3" runat="server" Text="Thêm nhiều nhân viên" Icon="GroupAdd">
                            <Listeners>
                                <Click Handler="wdCapNhatTamUngHangLoat.show();" />
                            </Listeners>
                        </ext:MenuItem>
                    </Items>
                </ext:Menu>
            </Menu>
        </ext:Button>
        <%--Thêm nhân viên tạm ứng hàng loạt--%>
        <ext:Window runat="server" ID="wdCapNhatTamUngHangLoat" Layout="FormLayout" Constrain="true"
            AutoHeight="true" Modal="true" Title="Cập nhật tạm ứng cho nhân viên" Width="700"
            Icon="GroupAdd" Hidden="true" Resizable="false">
            <TopBar>
                <ext:Toolbar runat="server" ID="tb1">
                    <Items>
                        <ext:Button runat="server" ID="btnChonCanBo" Text="Thêm cán bộ" Icon="UserAdd">
                            <Listeners>
                                <Click Handler="ucChooseEmployee1_wdChooseUser.show();" />
                            </Listeners>
                        </ext:Button>
                        <ext:Button runat="server" ID="btnXoaCanBo" Text="Xóa" Icon="Delete">
                            <Listeners>
                                <Click Handler="deleteEmployee(#{grpListEmployee});" />
                            </Listeners>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </TopBar>
            <Items>
                <ext:GridPanel ID="grpListEmployee" runat="server" StripeRows="true" Border="false"
                    AnchorHorizontal="100%" Height="300" Title="Danh sách cán bộ">
                    <Store>
                        <ext:Store ID="grpListEmployeeStore" AutoSave="false" AutoLoad="false" runat="server"
                            OnBeforeStoreChanged="HandleChanges" ShowWarningOnFailure="false" SkipIdForNewRecords="false"
                            RefreshAfterSaving="None">
                            <Reader>
                                <ext:ArrayReader>
                                    <Fields>
                                        <ext:RecordField Name="PrkeyHoSo" />
                                        <ext:RecordField Name="MA_CB" />
                                        <ext:RecordField Name="HO_TEN" />
                                        <ext:RecordField Name="TEN_DONVI" />
                                        <ext:RecordField Name="NgayTamUng" Type="Date" />
                                        <ext:RecordField Name="NgayThanhToan" Type="Date" />
                                        <ext:RecordField Name="LyDoTamUng" />
                                        <ext:RecordField Name="SoTien" Type="Float" />
                                        <ext:RecordField Name="SoTienDaTra" Type="Float" />
                                    </Fields>
                                </ext:ArrayReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel1" runat="server">
                        <Columns>
                            <ext:RowNumbererColumn Header="STT" Locked="true" Width="35" />
                            <ext:Column ColumnID="PrkeyHoSo" Header="" Locked="true" Hidden="true" DataIndex="PrkeyHoSo" />
                            <ext:Column ColumnID="MA_CB" Header="Mã cán bộ" Locked="true" Width="70" DataIndex="MA_CB" />
                            <ext:Column ColumnID="HO_TEN" Header="Họ tên" Width="150" Locked="true" DataIndex="HO_TEN" />
                            <ext:Column ColumnID="TEN_DONVI" Header="Bộ phận" Width="200" DataIndex="TEN_DONVI" />
                            <ext:DateColumn ColumnID="NgayTamUng" Header="Ngày tạm ứng" Width="90" DataIndex="NgayTamUng"
                                Format="dd/MM/yyyy">
                                <Editor>
                                    <ext:DateField Editable="true" ID="date_edit_ngaytamung" Vtype="daterange" runat="server"
                                        AnchorHorizontal="98%" MaskRe="/[0-9\/]/" Format="dd/MM/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/"
                                        RegexText="Định dạng ngày không đúng">
                                        <Triggers>
                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                        </Triggers>
                                        <Listeners>
                                            <Select Handler="this.triggers[0].show();" />
                                            <TriggerClick Handler="if (index == 0) { this.reset(); #{date_thanhtoan}.setMinValue(); this.triggers[0].hide(); }" />
                                        </Listeners>
                                    </ext:DateField>
                                </Editor>
                            </ext:DateColumn>
                            <ext:DateColumn ColumnID="NgayThanhToan" Header="Hạn thanh toán" Width="100" Format="dd/MM/yyyy"
                                DataIndex="NgayThanhToan">
                                <Editor>
                                    <ext:DateField Editable="true" ID="date_edit_thanhtoan" Vtype="daterange" runat="server"
                                        AnchorHorizontal="98%" TabIndex="34" MaskRe="/[0-9\/]/" Format="dd/MM/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/"
                                        RegexText="Định dạng ngày không đúng">
                                        <Triggers>
                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                        </Triggers>
                                        <Listeners>
                                            <Select Handler="this.triggers[0].show();" />
                                            <TriggerClick Handler="if (index == 0) { this.reset(); #{date_ngaytamung}.setMinValue(); this.triggers[0].hide(); }" />
                                        </Listeners>
                                    </ext:DateField>
                                </Editor>
                            </ext:DateColumn>
                            <ext:Column ColumnID="SoTien" Header="Số tiền" Width="100" DataIndex="SoTien">
                                <Editor>
                                    <ext:TextField runat="server" ID="txtEditSoTien" Text="0" MaskRe="[0-9|.,]" />
                                </Editor>
                            </ext:Column>
                            <ext:Column ColumnID="SoTienDaTra" Header="Đã trả" Width="100" DataIndex="SoTienDaTra">
                                <Editor>
                                    <ext:TextField runat="server" ID="txtEditDaTra" Text="0" MaskRe="[0-9|.,]" />
                                </Editor>
                            </ext:Column>
                            <ext:Column ColumnID="LyDoTamUng" Header="Lý do tạm ứng" Width="150" DataIndex="LyDoTamUng">
                                <Editor>
                                    <ext:TextField runat="server" ID="txtEditLyDo" />
                                </Editor>
                            </ext:Column>
                        </Columns>
                    </ColumnModel>
                    <View>
                        <ext:LockingGridView runat="server" ID="lkv" />
                    </View>
                    <SelectionModel>
                        <ext:RowSelectionModel runat="server" ID="SelectionModel1" SingleSelect="true">
                            <Listeners>
                                <RowSelect Handler="#{fpTamUng}.getForm().loadRecord(record);#{fpTamUng}.record = record;" />
                            </Listeners>
                        </ext:RowSelectionModel>
                    </SelectionModel>
                    <LoadMask ShowMask="true" />
                </ext:GridPanel>
                <ext:FormPanel runat="server" ID="fpTamUng" Frame="true" AnchorHorizontal="100%"
                    Title="Thông tin tạm ứng" Icon="Information" Layout="FormLayout" Border="false">
                    <Items>
                        <ext:Container runat="server" ID="ctn001" Layout="ColumnLayout" AnchorHorizontal="100%"
                            Height="27">
                            <Items>
                                <ext:Container runat="server" ID="ctn002" Layout="FormLayout" ColumnWidth="0.35">
                                    <Items>
                                        <ext:TextField runat="server" ID="txtName" AnchorHorizontal="98%" FieldLabel="Tên cán bộ"
                                            Disabled="false" DataIndex="HO_TEN">
                                            <Listeners>
                                                <Focus Handler="this.blur();" />
                                            </Listeners>
                                        </ext:TextField>
                                    </Items>
                                </ext:Container>
                                <ext:Container runat="server" ID="ctn003" Layout="FormLayout" ColumnWidth="0.65">
                                    <Items>
                                        <ext:TextField runat="server" ID="txtDepartment" AnchorHorizontal="100%" FieldLabel="Bộ phận"
                                            Disabled="false" DataIndex="TEN_DONVI">
                                            <Listeners>
                                                <Focus Handler="this.blur();" />
                                            </Listeners>
                                        </ext:TextField>
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:Container>
                        <ext:Container runat="server" ID="ctn004" Layout="ColumnLayout" AnchorHorizontal="100%"
                            Height="53">
                            <Items>
                                <ext:Container runat="server" ID="ctn005" Layout="FormLayout" ColumnWidth="0.5">
                                    <Items>
                                        <ext:DateField Editable="true" ID="dfNgayTamUngHL" Vtype="daterange" runat="server"
                                            CtCls="requiredData" FieldLabel="Ngày tạm ứng<span style='color:red;'>*</span>"
                                            AnchorHorizontal="98%" MaskRe="/[0-9\/]/" Format="dd/MM/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/"
                                            RegexText="Định dạng ngày không đúng" DataIndex="NgayTamUng">
                                            <Triggers>
                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                <ext:FieldTrigger Icon="SimpleTick" HideTrigger="false" Qtip="Click để áp dụng cho tất cả cán bộ" />
                                            </Triggers>
                                            <Listeners>
                                                <Select Handler="this.triggers[0].show();" />
                                                <TriggerClick Handler="if (index == 0) { this.reset(); #{dfNgayThanhToanHL}.setMinValue(); this.triggers[0].hide(); }
                                                    if (index == 1) { setRecord('NgayTamUng', dfNgayTamUngHL.getRawValue()); }" />
                                            </Listeners>
                                        </ext:DateField>
                                        <ext:TriggerField runat="server" ID="txtSoTienHL" MaxLength="18" AnchorHorizontal="98%"
                                            CtCls="requiredData" FieldLabel="Số tiền<span style='color:red;'>*</span>" MaskRe="[0-9.,]"
                                            DataIndex="SoTien">
                                            <Triggers>
                                                <ext:FieldTrigger Icon="SimpleTick" HideTrigger="false" Qtip="Click để áp dụng cho tất cả cán bộ" />
                                            </Triggers>
                                            <Listeners>
                                                <TriggerClick Handler="if (index == 0) { setRecord('SoTien', txtSoTienHL.getValue()); }" />
                                            </Listeners>
                                        </ext:TriggerField>
                                    </Items>
                                </ext:Container>
                                <ext:Container runat="server" ID="ctn006" Layout="FormLayout" ColumnWidth="0.5" LabelWidth="110">
                                    <Items>
                                        <ext:DateField Editable="true" ID="dfNgayThanhToanHL" Vtype="daterange" runat="server"
                                            CtCls="requiredData" FieldLabel="Hạn thanh toán<span style='color:red;'>*</span>"
                                            AnchorHorizontal="100%" TabIndex="34" MaskRe="/[0-9\/]/" Format="dd/MM/yyyy"
                                            Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/" RegexText="Định dạng ngày không đúng"
                                            DataIndex="NgayThanhToan">
                                            <Triggers>
                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                <ext:FieldTrigger Icon="SimpleTick" HideTrigger="false" Qtip="Click để áp dụng cho tất cả cán bộ" />
                                            </Triggers>
                                            <Listeners>
                                                <Select Handler="this.triggers[0].show();" />
                                                <TriggerClick Handler="if (index == 0) { this.reset(); #{dfNgayTamUngHL}.setMaxValue(); this.triggers[0].hide(); }
                                                    if (index == 1) { setRecord('NgayThanhToan', dfNgayThanhToanHL.getRawValue()); }" />
                                            </Listeners>
                                        </ext:DateField>
                                        <ext:TriggerField runat="server" ID="txtDaTra" MaxLength="18" AnchorHorizontal="100%"
                                            Hidden="true" FieldLabel="Số tiền thanh toán" MaskRe="[0-9.,]" DataIndex="SoTienDaTra">
                                            <Triggers>
                                                <ext:FieldTrigger Icon="SimpleTick" HideTrigger="false" Qtip="Click để áp dụng cho tất cả cán bộ" />
                                            </Triggers>
                                            <Listeners>
                                                <TriggerClick Handler="if (index == 0) { setRecord('SoTienDaTra', txtDaTra.getValue()); }" />
                                            </Listeners>
                                        </ext:TriggerField>
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:Container>
                        <ext:TriggerField runat="server" ID="txtLyDoHL" Height="40" FieldLabel="Lý do tạm ứng"
                            MaxLength="5000" DataIndex="LyDoTamUng" AnchorHorizontal="100%">
                            <Triggers>
                                <ext:FieldTrigger Icon="SimpleTick" HideTrigger="false" Qtip="Click để áp dụng cho tất cả cán bộ" />
                            </Triggers>
                            <Listeners>
                                <TriggerClick Handler="if (index == 0) { setRecord('LyDoTamUng', txtLyDoHL.getValue()); }" />
                            </Listeners>
                        </ext:TriggerField>
                    </Items>
                    <Buttons>
                        <ext:Button runat="server" ID="btnCapNhatTU" Text="Áp dụng" Icon="Disk">
                            <Listeners>
                                <Click Handler="updateRecord(#{grpListEmployee});" />
                            </Listeners>
                        </ext:Button>
                        <ext:Button runat="server" ID="btnCapNhatTUAll" Text="Áp dụng cho tất cả cán bộ"
                            Icon="DiskMultiple">
                            <Listeners>
                                <Click Handler="updateAllRecord(#{grpListEmployee});" />
                            </Listeners>
                        </ext:Button>
                    </Buttons>
                </ext:FormPanel>
            </Items>
            <Buttons>
                <ext:Button runat="server" Text="Cập nhật" Icon="Disk" ID="btnCapNhatHL">
                    <Listeners>
                        <Click Handler="#{grpListEmployee}.save();" />
                    </Listeners>
                </ext:Button>
                <ext:Button runat="server" Text="Đóng lại" Icon="Decline" ID="btnDongLaiHL">
                    <Listeners>
                        <Click Handler="wdCapNhatTamUngHangLoat.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="grpListEmployeeStore.removeAll();fpTamUng.getForm().reset();" />
            </Listeners>
        </ext:Window>
        <ext:Panel runat="server" EnableViewState="false" Height="220" Border="false" Title="Lịch sử thanh toán"
            Layout="BorderLayout" ID="pnlPaymentHistory">
            <TopBar>
                <ext:Toolbar runat="server" ID="Toolbar2">
                    <Items>
                        <ext:Button runat="server" Disabled="true" Text="Thêm lịch sử thanh toán" Icon="Add"
                            ID="btnAddPayment">
                            <Listeners>
                                <Click Handler="alert(grpBangTamUng_RowSelectionModel1.getSelected().id);" />
                                <%--<Click Handler="if(#{grpLiabilitiesOfCustomer}.grpLiabilitiesOfCustomer_RowSelectionModel1.getCount()<1){alert('Chưa có bản ghi nào được chọn');return false;}" />--%>
                            </Listeners>
                        </ext:Button>
                        <ext:Button ID="btnEditPayment" Disabled="true" runat="server" Text="Sửa" Icon="Pencil">
                        </ext:Button>
                        <ext:Button runat="server" ID="btnDeletePayment" Disabled="true" Text="Xóa" Icon="Delete">
                            <Listeners>
                                <Click Handler="if(#{grpPaymentHistory}.getSelectionModel().getCount() == 0){alert('Chưa có bản ghi nào được chọn');return false;}" />
                            </Listeners>
                            <DirectEvents>
                                <Click OnEvent="btnDeletePayment_Click">
                                    <EventMask ShowMask="true" />
                                    <Confirmation Title="Cảnh báo" Message="Bạn có chắc chắn muốn xóa không ?" ConfirmRequest="true" />
                                </Click>
                            </DirectEvents>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </TopBar>
            <Items>
                <ext:GridPanel ID="grpPaymentHistory" Border="false" runat="server" StripeRows="true"
                    Header="false" Region="Center" Width="600" Height="290" AutoExpandColumn="DESCRIPTION">
                    <Store>
                        <ext:Store ID="storePaymentHistory" runat="server" OnRefreshData="storePaymentHistory_OnRefreshData">
                            <Reader>
                                <ext:JsonReader IDProperty="ID">
                                    <Fields>
                                        <ext:RecordField Name="ID" />
                                        <ext:RecordField Name="NgayTra" />
                                        <ext:RecordField Name="Description" />
                                        <ext:RecordField Name="FB" />
                                        <ext:RecordField Name="LoaiThanhToan" />
                                        <ext:RecordField Name="SoTienThanhToan" />
                                        <ext:RecordField Name="CreatedDate" />
                                        <ext:RecordField Name="DisplayName" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel2" runat="server">
                        <Columns>
                            <ext:RowNumbererColumn Header="STT" Width="35" />
                            <%--   <ext:Column Header="ID" Width="40" DataIndex="ID">
                            </ext:Column>--%>
                            <ext:DateColumn ColumnID="NgayTra" Format="dd/MM/yyyy" Header="Ngày tháng" Width="90"
                                DataIndex="NgayTra" />
                            <ext:Column Header="Số tiền" Width="85" DataIndex="SoTienThanhToan">
                                <Renderer Fn="RenderVND" />
                            </ext:Column>
                            <ext:Column Header="Chiết khấu" Width="85" Hidden="true" DataIndex="FB">
                                <Renderer Fn="RenderVND" />
                            </ext:Column>
                            <ext:Column Header="Hình thức thanh toán" Width="125" DataIndex="LoaiThanhToan">
                            </ext:Column>
                            <ext:Column Header="Ghi chú" ColumnID="DESCRIPTION" Width="125" DataIndex="Description">
                            </ext:Column>
                            <ext:DateColumn Format="dd/MM/yyyy" Header="Ngày tạo" Width="85" DataIndex="CreatedDate">
                            </ext:DateColumn>
                            <ext:Column Header="Người tạo" Width="125" DataIndex="DisplayName">
                            </ext:Column>
                        </Columns>
                    </ColumnModel>
                    <SelectionModel>
                        <ext:RowSelectionModel ID="rsm" runat="server">
                            <Listeners>
                                <RowSelect Handler="try{#{btnDeletePayment}.enable();#{btnEditPayment}.enable();}catch(e){};#{hdfBangTamUngHistoryID}.setValue(#{rsm}.getSelected().data.ID);" />
                                <RowDeselect Handler="hdfBangTamUngHistoryID.reset();" />
                            </Listeners>
                        </ext:RowSelectionModel>
                    </SelectionModel>
                    <LoadMask ShowMask="true" />
                </ext:GridPanel>
            </Items>
        </ext:Panel>
        <uc1:SingleGridPanel ID="grpBangTamUng" TableOrViewName="v_BangTamUng" Render="SoTien=RenderVND,SoTienThanhToan=RenderVND,RemainMoney=RenderVND"
            ColumnWidth="MA_CB=80, TEN_DONVI=216,NgayTamUng=85,LyDoTamUng=170,SoTienDaTra=90"
            OrderBy="NgayTamUng" IDProperty="PR_KEY" ColumnHeader="PR_KEY,Mã cán bộ,Họ tên,Bộ phận,Ngày tạm ứng, Lý do tạm ứng,Số tiền,Đã thanh toán,Còn phải thu,abc"
            ColumnName="PR_KEY,MA_CB,HO_TEN,TEN_DONVI,NgayTamUng,LyDoTamUng,SoTien,SoTienThanhToan,RemainMoney,TrangThai"
            TableForDeleting="TienLuong.BangTamUng" runat="server" EmptyTextSearch="Tìm kiếm theo mã, tên cán bộ"
            AutoExpandColumn="HO_TEN" GroupField="TrangThai" HideGrouped="true" SearchField="MA_CB,HO_TEN" />
        <ext:Window runat="server" ID="wdPaymentHistory" Hidden="true" Title="Cập nhật lịch sử thanh toán"
            Modal="true" Constrain="true" AutoHeight="true" LabelWidth="110" Layout="FormLayout"
            Width="500" Padding="6">
            <Items>
                <ext:Container ID="Container1" Layout="ColumnLayout" runat="server" Height="30" AnchorHorizontal="100%">
                    <Items>
                        <ext:Container ID="Container2" runat="server" Height="30" LabelWidth="110" ColumnWidth="0.5"
                            Layout="FormLayout">
                            <Items>
                                <ext:DateField runat="server" ID="dfPaidDate" CtCls="requiredData" FieldLabel="Ngày thanh toán<span style='color:red;'>*</span>"
                                    AnchorHorizontal="98%" Editable="false" />
                            </Items>
                        </ext:Container>
                        <ext:ComboBox runat="server" CtCls="requiredData" Editable="false" ID="cbPaymentType"
                            LabelWidth="110" FieldLabel="H/T thanh toán<span style='color:red;'>*</span>"
                            ColumnWidth="0.5">
                            <Items>
                                <ext:ListItem Text="Chuyển khoản" Value="Chuyển khoản" />
                                <ext:ListItem Text="Tiền mặt" Value="Tiền mặt" />
                            </Items>
                        </ext:ComboBox>
                    </Items>
                </ext:Container>
                <ext:Container ID="Container3" Layout="ColumnLayout" LabelWidth="110" runat="server"
                    Height="30" AnchorHorizontal="100%">
                    <Items>
                        <ext:Container ID="Container4" runat="server" LabelWidth="110" Height="30" ColumnWidth="0.5"
                            Layout="FormLayout">
                            <Items>
                                <ext:NumberField ID="nbfPaid" CtCls="requiredData" AllowNegative="false" runat="server"
                                    MaxLength="9" AnchorHorizontal="98%" FieldLabel="Đã thanh toán<span style='color:red;'>*</span>" />
                            </Items>
                        </ext:Container>
                        <ext:NumberField runat="server" ID="nbfChietKhau" AllowNegative="false" ColumnWidth="0.5"
                            LabelWidth="110" FieldLabel="Chiết khấu (FB)" Hidden="true" />
                    </Items>
                </ext:Container>
                <ext:Hidden runat="server" ID="hdfPaymentHistory" />
                <ext:TextArea runat="server" ID="txaDescription" FieldLabel="Chi chú" LabelWidth="110"
                    AnchorHorizontal="100%" />
            </Items>
            <Listeners>
                <Hide Handler="resetFormHistory();" />
            </Listeners>
            <Buttons>
                <ext:Button runat="server" Text="Cập nhật" ID="btnUpdateHistory" Hidden="true" Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckInputStoreHistory();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnUpdateHistory_Click">
                            <ExtraParams>
                                <ext:Parameter Name="Command" Value="UpdateHistory" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" Text="Cập nhật" ID="btnAddHistory" Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckInputStoreHistory();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnUpdateHistory_Click">
                            <ExtraParams>
                                <ext:Parameter Name="Command" Value="AddHistory" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" Text="Cập nhật & Đóng lại" ID="btnAddAndCloseHistory"
                    Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckInputStoreHistory();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnUpdateHistory_Click">
                            <ExtraParams>
                                <ext:Parameter Name="CloseHistory" Value="True" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" Text="Đóng lại" ID="Button432" Icon="Decline">
                    <Listeners>
                        <Click Handler="wdPaymentHistory.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
    </div>
    </form>
</body>
</html>
