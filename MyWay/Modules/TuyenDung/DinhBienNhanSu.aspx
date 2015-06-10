<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DinhBienNhanSu.aspx.cs" Inherits="Modules_TuyenDung_DinhBienNhanSu" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="../../Resource/js/jquery-1.4.2.min.js"></script>
    <script src="Resource/DinhBienNhanSu.js" type="text/javascript"></script>
    <link href="Resource/DinhBienNhanSu.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        div#divSql
        {
            display: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager runat="server" ID="RM">
            <Listeners>
                <DocumentReady Handler="cbChonNam.setValue(new Date().year);" />
            </Listeners>
        </ext:ResourceManager>
        <div id="divSql">
        </div>
        <ext:Hidden runat="server" ID="hdfMaPhong" />
        <ext:Hidden runat="server" ID="hdfMaDonVi" /> 
        <ext:Window ID="wdChonPhong" Modal="true" Layout="FormLayout" Width="500" Padding="6"
            Constrain="false" Title="Thêm kế hoạch nhân sự" Hidden="true" Icon="Tick" runat="server"
            AutoHeight="true">
            <Items>
                <ext:Checkbox runat="server" FieldLabel="Chọn đơn vị" ID="chkAllDepartments" Checked="true"
                    BoxLabel="Tất cả đơn vị">
                    <Listeners>
                        <Check Handler="if(chkAllDepartments.checked==true){
                                            cbDonViList.disable();
                                       }else
                                       {
                                           cbDonViList.enable();
                                       }" />
                    </Listeners>
                </ext:Checkbox>
                <ext:MultiCombo Editable="false" DisplayField="TEN_DONVI" ValueField="MA_DONVI" runat="server"
                    ID="cbDonViList" LabelWidth="60" Width="369" Disabled="True">
                    <Store>
                        <ext:Store ID="cbStoreDonViList" OnRefreshData="cbDonViList_OnRefreshData" AutoLoad="False"
                            runat="server">
                            <Reader>
                                <ext:JsonReader IDProperty="MA_DONVI">
                                    <Fields>
                                        <ext:RecordField Name="MA_DONVI" />
                                        <ext:RecordField Name="TEN_DONVI" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <Listeners>
                        <%--<Change Handler="cbStoreCongViecList.reload();"></Change>--%>
                    </Listeners>
                </ext:MultiCombo>
                <ext:Checkbox runat="server" FieldLabel="Chọn công việc" ID="chkAllWorks" Checked="true"
                    BoxLabel="Tất cả đơn vị">
                    <Listeners>
                        <Check Handler="if(chkAllWorks.checked==true){
                                            cbCongViecList.disable();
                                       }else
                                       {
                                           cbCongViecList.enable();
                                       }" />
                    </Listeners>
                </ext:Checkbox>
              
                <ext:MultiCombo  DisplayField="TEN" ValueField="MA" runat="server"
                    ID="cbCongViecList" LabelWidth="60" Width="369"  Disabled="True">
                    <Store>
                        <ext:Store ID="cbStoreCongViecList" OnRefreshData="cbCongViecList_OnRefreshData"
                            AutoLoad="False" runat="server">
                           <%-- <Proxy>
                                <ext:HttpProxy Method="POST" Url="DinhBienNhanSuHandler.ashx" />
                            </Proxy>
                            <AutoLoadParams>
                                <ext:Parameter Name="Type" Value="GetWorkList" />
                                <ext:Parameter Name="Start" Value="={0}" />
                                <ext:Parameter Name="Limit" Value="={10}" />
                            </AutoLoadParams>--%>
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
                    </Listeners>
                </ext:MultiCombo>
                <ext:DateField runat="server" ID="dfDatetime" Editable="false" Width="150" FieldLabel="Chọn ngày"
                    Note="Số lượng nhân sự được tính toán đến thời điểm mà bạn chọn">
                </ext:DateField>
                <ext:Checkbox runat="server" FieldLabel="Gồm NV thử việc" ID="chAllStaffType" Checked="true">
                </ext:Checkbox>
            </Items>
            <Listeners>
                <Hide Handler="cbDonViList.reset();cbCongViecList.reset();dfDatetime.reset();chkAllWorks.reset();chkAllDepartments.reset();" />
            </Listeners>
            <Buttons>
                <ext:Button runat="server" Icon="Accept" Text="Đồng ý" ID="btnOK">
                    <Listeners>
                        <Click Handler="return ValidateFormwdChonPhong();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnSum_Click">
                            <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnCancel" Icon="Decline" Text="Thoát">
                    <Listeners>
                        <Click Handler="wdChonPhong.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>

        <ext:Window ID="wdThemViTriCongViec" Modal="true" Layout="FormLayout" Width="480"
            Padding="6" Constrain="false" Title="Thêm vị trí công việc" Hidden="true" Icon="Group"
            runat="server" AutoHeight="true">
            <Items>
                <ext:TextField FieldLabel="Mã công việc <span class='requireLable'>*</span>" runat="server" Width="250" CtCls="requiredData" ID="MaCongViec">
                </ext:TextField>
                <ext:TextField FieldLabel="Tên công việc <span class='requireLable'>*</span>" runat="server" CtCls="requiredData" AnchorHorizontal="100%"
                    ID="TenCongViec">
                </ext:TextField>
                <%--<span class='requireLable'>*</span>--%>
                <ext:ComboBox ID="cbDonVi" DisplayField="TEN_DONVI" EmptyText="Chọn đơn vị" ValueField="MA_DONVI"
                    runat="server" FieldLabel="Chọn đơn vị" AnchorHorizontal="100%">
                    <Store>
                        <ext:Store runat="server" OnRefreshData="cbStoreDonVi_OnRefreshData" AutoLoad="False"
                            ID="cbStoreDonVi">
                            <Reader>
                                <ext:JsonReader IDProperty="MA_DONVI">
                                    <Fields>
                                        <ext:RecordField Name="MA_DONVI" />
                                        <ext:RecordField Name="TEN_DONVI" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                </ext:ComboBox>
                <%--OnRefreshData="cbStoreChucVuList_OnRefreshData"  --%>
                <ext:ComboBox ID="cbChucVuList" DisplayField="TEN" EmptyText="Chọn đơn vị" ValueField="MA"
                    runat="server" FieldLabel="Chọn chức vụ <span class='requireLable'>*</span>" AnchorHorizontal="100%">
                    <Store>
                        <ext:Store runat="server" AutoLoad="False" ID="Store2">
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
                </ext:ComboBox>
                
                 <ext:Container ID="Container4" runat="server" Layout="Column" Height="50" >
                    <Items>
                        <ext:Container ID="Container5" runat="server" LabelAlign="Top" ColumnWidth="0.5" Layout="Form">
                            <Items>
                                <ext:NumberField ID="txtDinhBien" runat="server" CtCls="requiredData" MinValue="0" AnchorHorizontal="100%" FieldLabel="Định biên " />
                            </Items>
                        </ext:Container>
                        <ext:Container ID="Container6" runat="server" LabelAlign="Top" ColumnWidth="0.5" Layout="Form"  Split="True" >
                            <Items>
                                <ext:DateField ID="dateTinhDenNgay" runat="server" Editable="False"  AnchorHorizontal="100%"   FieldLabel="Tính đến ngày" />
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Container>
                

                <ext:Container runat="server" Layout="Column" Height="200">
                    <Items>
                        <ext:Container ID="Container1" runat="server" LabelAlign="Top" ColumnWidth="0.5" Layout="Form">
                            <Items>
                                <ext:NumberField ID="thang1" runat="server" FieldLabel="Tháng 1" />
                                <ext:NumberField ID="thang4" runat="server" FieldLabel="Tháng 4" />
                                <ext:NumberField ID="thang7" runat="server" FieldLabel="Tháng 7" />
                                <ext:NumberField ID="thang10" runat="server" FieldLabel="Tháng 10" />
                                
                            </Items>
                        </ext:Container>
                        <ext:Container ID="Container2" runat="server" LabelAlign="Top" ColumnWidth="0.5" Layout="Form">
                            <Items>
                               
                                <ext:NumberField ID="thang2" runat="server" FieldLabel="Tháng 2" />
                                <ext:NumberField ID="thang5" runat="server" FieldLabel="Tháng 6" />
                                <ext:NumberField ID="thang8" runat="server" FieldLabel="Tháng 9" />
                                <ext:NumberField ID="thang11" runat="server" FieldLabel="Tháng 11" />
                                
                            </Items>
                        </ext:Container>
                        <ext:Container ID="Container3" runat="server" LabelAlign="Top" Layout="Form">
                            <Items>
                                <ext:NumberField ID="thang3" runat="server" FieldLabel="Tháng 3" />
                                <ext:NumberField ID="thang6" runat="server" FieldLabel="Tháng 6" />
                                <ext:NumberField ID="thang9" runat="server" FieldLabel="Tháng 9" />
                                <ext:NumberField ID="thang12" runat="server" FieldLabel="Tháng 12" />
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Container>
            </Items>
            <Listeners>
                <BeforeShow Handler="if(cbStoreDonVi.getCount()==0){cbStoreDonVi.reload();} 
                                     " />
                <Hide Handler="ResetForm();" />
            </Listeners>
            <Buttons>
                <ext:Button runat="server" Icon="Accept" Text="Đồng ý" ID="btnThemViTriCongViec">
                    <Listeners>
                        <Click Handler="return ValidateForm();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnThemViTriCongViec_Click">
                            <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="Button6" Icon="Decline" Text="Thoát">
                    <Listeners>
                        <Click Handler="wdThemViTriCongViec.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>

        <ext:Viewport runat="server" ID="vp">
            <Items>
                <ext:BorderLayout runat="server" ID="br">
                    <Center>
                        <ext:GridPanel Border="false" ID="GridPanel1" ClicksToEdit="1" runat="server" StripeRows="False">
                            <TopBar>
                                <ext:Toolbar runat="server">
                                    <Items>
                                        <ext:Button runat="server" Icon="ApplicationOsx" Text="Chức năng">
                                            <Menu>
                                                <ext:Menu runat="server">
                                                    <Items>
                                                        <ext:MenuItem ID="btnSum" Text="Thêm kế hoạch nhân sự" Icon="Group">
                                                            <Listeners>
                                                                <Click Handler="wdChonPhong.show();" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem Text="Thêm vị trí công việc" Icon="Tick">
                                                            <Listeners>
                                                                <Click Handler="wdThemViTriCongViec.show();" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                    </Items>
                                                </ext:Menu>
                                            </Menu>
                                        </ext:Button>
                                        <ext:ComboBox runat="server" ID="cbChonNam" FieldLabel="Chọn năm" DisplayField="Year"
                                            ValueField="Year" AnchorHorizontal="100%" TabIndex="6" LabelWidth="60" Width="150"
                                            Editable="false" AllowBlank="false">
                                            <Triggers>
                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                            </Triggers>
                                            <Store>
                                                <ext:Store runat="server" ID="cbChonNamStore" OnRefreshData="cbChonNamStore_OnRefreshData">
                                                    <Reader>
                                                        <ext:JsonReader IDProperty="Year">
                                                            <Fields>
                                                                <ext:RecordField Name="Year" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                            <ToolTips>
                                                <ext:ToolTip ID="ToolTip1" runat="server" Title="Chọn năm" />
                                            </ToolTips>
                                            <Listeners>
                                                <Select Handler="hdfMaDonVi.reset();hdfMaPhong.reset();PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad();Store1.reload();this.triggers[0].show();$('#cbChonNam').addClass('combo-selected');" />
                                                <%-- <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />--%>
                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); } Store1.reload(); $('#cbChonNam').removeClass('combo-selected');" />
                                            </Listeners>
                                        </ext:ComboBox>
                                        <ext:ToolbarSeparator runat="server" ID="tbs" />
                                        <ext:Button ID="Button2" runat="server" Text="Xuất ra Excel" Icon="PageExcel">
                                            <Listeners>
                                                <Click Handler="GridPanel1.submitData(false);" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:Button runat="server" Text="Nhập từ Excel" Icon="PageExcel">
                                        </ext:Button>
                                        <%--<ext:Button ID="btnSaveData" runat="server" Text="Lưu" Icon="Disk">
                                            <DirectEvents>
                                                <Click OnEvent="btnSaveData_Click">
                                                    <EventMask ShowMask="true" Msg="Đang lưu dữ liệu..." />
                                                    <ExtraParams>
                                                        <ext:Parameter Name="html" Mode="Raw" Value="document.getElementById('divSql').innerHTML">
                                                        </ext:Parameter>
                                                    </ExtraParams>
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>--%>
                                        <ext:ToolbarSeparator runat="server" ID="ToolbarSeparator1" />
                                        <ext:Button runat="server" Text="Báo cáo" Icon="Printer">
                                        </ext:Button>
                                        <ext:ToolbarFill runat="server">
                                        </ext:ToolbarFill>
                                        <ext:TextField runat="server" ID="txtSearchKey" Width="220" EmptyText="Nhập tên công việc hoặc chức vụ..."
                                            EnableKeyEvents="true">
                                            <Listeners>
                                                <KeyPress Fn="enterKeyPressHandler" />
                                            </Listeners>
                                        </ext:TextField>
                                        <ext:Button runat="server" ID="btnSearch" Text="Tìm kiếm" Icon="Zoom">
                                            <Listeners>
                                                <Click Handler="hdfMaDonVi.reset();hdfMaPhong.reset();PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad();Store1.reload();" />
                                            </Listeners>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <Store>
                                <ext:Store ID="Store1" GroupField="TenDonVi" OnSubmitData="Store1_Submit" runat="server">
                                    <Proxy>
                                        <ext:HttpProxy Method="GET" Url="DinhBienNhanSuHandler.ashx" />
                                    </Proxy>
                                    <BaseParams>
                                        <ext:Parameter Name="Year" Value="cbChonNam.getValue()" Mode="Raw">
                                        </ext:Parameter>
                                        <ext:Parameter Name="SearchKey" Value="txtSearchKey.getValue()" Mode="Raw">
                                        </ext:Parameter>
                                        <ext:Parameter Name="MaPhong" Value="hdfMaPhong.getValue()" Mode="Raw">
                                        </ext:Parameter>
                                    </BaseParams>
                                    <AutoLoadParams>
                                        <ext:Parameter Name="start" Value="={0}" />
                                        <ext:Parameter Name="limit" Value="={25}" />
                                    </AutoLoadParams>
                                    <Reader>
                                        <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="ID">
                                            <Fields>
                                                <ext:RecordField Name="ID" />
                                                <ext:RecordField Name="MaDonVi" />
                                                <ext:RecordField Name="TenDonVi" />
                                                <ext:RecordField Name="MaChucVu" />
                                                <ext:RecordField Name="MaCongViec" />
                                                <ext:RecordField Name="TenChucVu" />
                                                <ext:RecordField Name="TenCongViec" />
                                                <ext:RecordField Name="Thang1" />
                                                <ext:RecordField Name="Thang2" />
                                                <ext:RecordField Name="Thang3" />
                                                <ext:RecordField Name="Thang4" />
                                                <ext:RecordField Name="Thang5" />
                                                <ext:RecordField Name="Thang6" />
                                                <ext:RecordField Name="Thang7" />
                                                <ext:RecordField Name="Thang8" />
                                                <ext:RecordField Name="Thang9" />
                                                <ext:RecordField Name="Thang10" />
                                                <ext:RecordField Name="Thang11" />
                                                <ext:RecordField Name="Thang12" />
                                                <ext:RecordField Name="SoLuongTuyenMoi" />
                                                <ext:RecordField Name="SoLuongDinhBien" />
                                                <ext:RecordField Name="TinhDenNgay" />
                                                <ext:RecordField Name="SoLuongNhanSu" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                            <Listeners>
                                <AfterEdit Fn="SaveData" />
                            </Listeners>
                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
                                    <ext:GroupingSummaryColumn ColumnID="TenDonVi" Width="150" Header="Phòng ban" Sortable="true"
                                        DataIndex="TenDonVi" Hideable="false">
                                    </ext:GroupingSummaryColumn>
                                    <ext:RowNumbererColumn Header="STT" />
                                    <ext:Column ColumnID="TEN_CONGVIEC" Header="Công việc" Width="160" DataIndex="TenCongViec" />
                                    <ext:Column ColumnID="TEN_CHUCVU" Header="Chức vụ" Width="160" DataIndex="TenChucVu" />
                                    <ext:Column Header="Hiện có" Width="70" Align="Center"  DataIndex="SoLuongNhanSu">
                                        <Renderer Fn="GetHienCo" />
                                    </ext:Column>
                                    <ext:DateColumn Header="Tính đến ngày" Width="90" Format="dd/MM/yyyy" DataIndex="TinhDenNgay">
                                        <Renderer Fn="AlignRight" />
                                    </ext:DateColumn>
                                    <ext:Column Header="Định biên" Width="70" DataIndex="SoLuongDinhBien">
                                        <Renderer Fn="AlignRight" />
                                        
                                        <Editor>
                                            <ext:NumberField runat="server" ID="nbfDinhBien" MinValue="0" MinText="Giá trị phải lớn hơn hoặc bằng không">
                                            </ext:NumberField>
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column Header="Tuyển mới" Width="70" DataIndex="SoLuongTuyenMoi">
                                        <Renderer Fn="AlignRight" />
                                        <Editor>
                                            <ext:NumberField runat="server" ID="NumberField1">
                                            </ext:NumberField>
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column Header="Tháng 1" Width="55" DataIndex="Thang1">
                                        <Renderer Fn="AlignRight" />
                                        <Editor>
                                            <ext:NumberField runat="server" ID="NumberField2">
                                            </ext:NumberField>
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column Header="Tháng 2" Width="55" DataIndex="Thang2">
                                        <Renderer Fn="AlignRight" />
                                        <Editor>
                                            <ext:NumberField runat="server" ID="NumberField3">
                                            </ext:NumberField>
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column Header="Tháng 3" Width="55" DataIndex="Thang3">
                                        <Renderer Fn="AlignRight" />
                                        <Editor>
                                            <ext:NumberField runat="server" ID="NumberField4">
                                            </ext:NumberField>
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column Header="Tháng 4" Width="55" DataIndex="Thang4">
                                        <Renderer Fn="AlignRight" />
                                        <Editor>
                                            <ext:NumberField runat="server" ID="NumberField5">
                                            </ext:NumberField>
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column Header="Tháng 5" Width="55" DataIndex="Thang5">
                                        <Renderer Fn="AlignRight" />
                                        <Editor>
                                            <ext:NumberField runat="server" ID="NumberField6">
                                            </ext:NumberField>
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column Header="Tháng 6" Width="55" DataIndex="Thang6">
                                        <Renderer Fn="AlignRight" />
                                        <Editor>
                                            <ext:NumberField runat="server" ID="NumberField7">
                                            </ext:NumberField>
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column Header="Tháng 7" Width="55" DataIndex="Thang7">
                                        <Renderer Fn="AlignRight" />
                                        <Editor>
                                            <ext:NumberField runat="server" ID="NumberField8">
                                            </ext:NumberField>
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column Header="Tháng 8" Width="55" DataIndex="Thang8">
                                        <Renderer Fn="AlignRight" />
                                        <Editor>
                                            <ext:NumberField runat="server" ID="NumberField9">
                                            </ext:NumberField>
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column Header="Tháng 9" Width="55" DataIndex="Thang9">
                                        <Renderer Fn="AlignRight" />
                                        <Editor>
                                            <ext:NumberField runat="server" ID="NumberField10">
                                            </ext:NumberField>
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column Header="Tháng 10" Width="55" DataIndex="Thang10">
                                        <Renderer Fn="AlignRight" />
                                        <Editor>
                                            <ext:NumberField runat="server" ID="NumberField11">
                                            </ext:NumberField>
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column Header="Tháng 11" Width="55" DataIndex="Thang11">
                                        <Renderer Fn="AlignRight" />
                                        <Editor>
                                            <ext:NumberField runat="server" ID="NumberField12">
                                            </ext:NumberField>
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column Header="Tháng 12" Width="55" DataIndex="Thang12">
                                        <Renderer Fn="AlignRight" />
                                        <Editor>
                                            <ext:NumberField runat="server" ID="NumberField13">
                                            </ext:NumberField>
                                        </Editor>
                                    </ext:Column>
                                </Columns>
                            </ColumnModel>
                            <View>
                                <ext:GroupingView ID="GroupingView1" runat="server" ForceFit="true" MarkDirty="false"
                                    ShowGroupName="false" EnableNoGroups="true" HideGroupedColumn="true" />
                            </View>
                            <SelectionModel>
                                <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" />
                            </SelectionModel>
                            <LoadMask ShowMask="true" Msg="Chờ trong giây lát..." />
                            <BottomBar>
                                <ext:PagingToolbar ID="PagingToolbar1" IDMode="Static" EmptyMsg="Hiện không có dữ liệu"
                                    NextText="Trang sau" PrevText="Trang trước" LastText="Trang cuối cùng" FirstText="Trang đầu tiên"
                                    DisplayMsg="Dòng {0} đến dòng {1} / {2} dòng" runat="server">
                                    <Items>
                                        <ext:Label ID="Label1" runat="server" Text="Số bản ghi trên 1 trang:" />
                                        <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                        <ext:ComboBox ID="ComboBoxPaging" runat="server" Width="80">
                                            <Items>
                                                <ext:ListItem Text="5" />
                                                <ext:ListItem Text="10" />
                                                <ext:ListItem Text="15" />
                                                <ext:ListItem Text="20" />
                                                <ext:ListItem Text="25" />
                                                <ext:ListItem Text="30" />
                                            </Items>
                                            <Listeners>
                                                <Select Handler="#{PagingToolbar1}.pageSize = parseInt(this.getValue()); #{PagingToolbar1}.doLoad();" />
                                            </Listeners>
                                        </ext:ComboBox>
                                    </Items>
                                </ext:PagingToolbar>
                            </BottomBar>
                        </ext:GridPanel>
                    </Center>
                </ext:BorderLayout>
            </Items>
        </ext:Viewport>
    </div>
    </form>
</body>
</html>
