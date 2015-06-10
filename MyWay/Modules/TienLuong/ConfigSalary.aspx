<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConfigSalary.aspx.cs" Inherits="Modules_TienLuong_ConfigSalary" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript">
        var afterEdit = function (e) {
            if (e.record.data.ID == null) {
                //SalaryBoardConfigX.Insert(e.record.data.MenuID, e.field, e.originalValue, e.value, e.record.data);
            }
            else {
                SalaryBoardConfigX.AfterEdit(e.record.data.ID, e.record.data.MenuID, e.field, e.originalValue, e.value, e.record.data);
            }
        };
        var SetNodeChecked = function (tree) {
            if (hdfRoleID.getValue().length != 0) {
                var str = hdfRoleID.getValue().split(',');
                for (var i = 0; i < str.length; i++) {
                    if (str[i].length != 0) {
                        tree.getNodeById(str[i]).getUI().checkbox.checked = true;
                    }
                }
            }
        }
        //Lấy các role được chọn
        var GetSelectedNodeID = function (tree) {
            if (hdfAllNodeID.getValue().length != 0) {
                hdfSelectedNodeID.reset();
                var str = hdfAllNodeID.getValue().split(',');
                for (var i = 0; i < str.length; i++) {
                    if (str[i].length != 0) {
                        if (tree.getNodeById(str[i]).getUI().checkbox.checked == true) {
                            hdfSelectedNodeID.setValue(hdfSelectedNodeID.getValue() + "," + str[i]);
                        }
                    }
                }
            }
        }
        //Check các role node theo user
        var SetNodeChecked = function (tree) {
            if (hdfRoleID.getValue().length != 0) {
                var str = hdfRoleID.getValue().split(',');
                for (var i = 0; i < str.length; i++) {
                    if (str[i].length != 0) {
                        tree.getNodeById(str[i]).getUI().checkbox.checked = true;
                    }
                }
            }
        }
        var getRoleTextAndValue = function (tree) {
            var msg = [],
                    selNodes = tree.getChecked();
            document.getElementById("hdfRoleID").value = "";
            Ext.each(selNodes, function (node) {
                msg.push(node.text);
                document.getElementById("hdfRoleID").value += node.id + ",";
            });

            return msg.join(",");
        };
        var CheckSelectedRow = function (grid) {
            var s = grid.getSelectionModel().getSelections();
            var count = 0;
            for (var i = 0, r; r = s[i]; i++) {
                count++;
            }
            if (count == 0) {
                alert('Bạn chưa chọn bản ghi nào!');
                return false;
            }
            return true;
        }
        var Render = function (value, p, record) {
            if (value == 'RenderVND')
                return "Kiểu tiền tệ";
            if (value == 'RenderNumber')
                return "Kiểu số";
            else return value;
        }
        var RenderComboboxDataSource = function (value, p, record) {
            var r = stDataSourceFunction.getById(value);
            if (Ext.isEmpty(r)) {
                return value;
            }
            return r.data.TEN;
        }
        var RenderAlign = function (value, p, record) {
            if (value == "Left") {
                return "Trái";
            }
            else if (value == "Right")
                return "Phải";
            else if (value == "Center")
                return "Giữa";
            return value;
        }

        function ResetTreeID() {
            document.getElementById("hdfTreeNodeID").value = "";
        }
        function ClearFormValue() {
            document.getElementById("txtMenuName").value = "";
            document.getElementById("txtTabName").value = "";
            document.getElementById("hdfMenuCommand").value = "";
            document.getElementById("hdfParentID").value = "";
            document.getElementById("hdfOldMenuRole").value = "";
            document.getElementById("txtIcon").value = "";
            document.getElementById("ddfParentMenu").value = "";
        }
        var checkInputWdAddRecord = function () {
            if (cbbColumnID.getValue() == '') {
                alert("Bạn chưa chọn ký hiệu");
                return false;
            }
            if (nfThuTu.getValue() == '') {
                alert("Bạn chưa chọn thứ tự tính toán");
                return false;
            }
            if (nfOrderDisplay.getValue() == '') {
                alert("Bạn chưa chọn thứ tự hiển thị");
                return false;
            }
            if (txtDienGiai.getValue() == '') {
                alert("Bạn chưa nhập tên diễn giải");
                return false;
            }
            return true;
        }
        var resetWdAddRecord = function () {
            cbbColumnID.reset();
            txtDienGiai.reset();
            nfThuTu.reset();
            nfOrderDisplay.reset();
            txtCongThuc.reset();
            cbbDataSource.reset();
            cbbDataSource.triggers[0].hide();
            hdfDataSource.reset();
            cbbRenderJS.reset();
            cbbAlign.reset();
            nfWidth.reset();
            nfDefaultValue.reset();
            txtDKTinhLuong.reset();
            ckDisplayOnGridView.setValue(false);
            ckIsInUsed.setValue(false);
            ckAllowEditOnGrid.setValue(false);
            ckAllowSum.setValue(false);
            ckDisplayOnReport.setValue(false);
        }
    </script>
    <script src="../../Resource/js/RenderJS.js" type="text/javascript"></script>
    <title></title>
    <style type="text/css">
        div#grpSalaryConfig .x-grid3-cell-inner, .x-grid3-hd-inner {
            white-space: nowrap !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ext:ResourceManager runat="server" ID="RM" />
            <ext:Hidden runat="server" ID="hdfTreeNodeID" />
            <ext:Store runat="server" ID="ModuleFileStore" AutoLoad="false" OnRefreshData="ModuleFileRefresh">
                <DirectEventConfig>
                    <EventMask ShowMask="false" />
                </DirectEventConfig>
                <Reader>
                    <ext:JsonReader IDProperty="Path">
                        <Fields>
                            <ext:RecordField Name="Path" Type="String" />
                        </Fields>
                    </ext:JsonReader>
                </Reader>
                <Listeners>
                    <Load Handler="#{cbFile}.setValue(#{cbFile}.store.getAt(0).get('Path'));" />
                </Listeners>
            </ext:Store>
            <ext:Window ID="wdAddModule" runat="server" Border="false" Padding="0" Icon="Add"
                Width="550" Modal="true" Maximizable="false" Resizable="false" AutoHeight="true"
                Title="Thêm mới một bảng lương" Hidden="true">
                <Items>
                    <ext:Panel ID="Panel1" runat="server" Frame="true" Padding="6" Border="false" Layout="FormLayout">
                        <Items>
                            <ext:Hidden ID="hdfMenuCommand" runat="server" />
                            <ext:DropDownField ID="ddfParentMenu" FieldLabel="Menu cấp cha" Width="400" runat="server"
                                Editable="false" TriggerIcon="SimpleArrowDown" Hidden="true">
                                <Component>
                                    <ext:TreePanel ID="MenuTreePanel" runat="server" Title="<%$ Resources:Language, choose_parent_category%>"
                                        Icon="Accept" Height="300" Shadow="None" UseArrows="true" AutoScroll="true" Animate="true"
                                        EnableDD="true" ContainerScroll="true" RootVisible="false">
                                        <Listeners>
                                            <CheckChange Handler="this.dropDownField.setValue(getText(this),getValues(this), false);" />
                                        </Listeners>
                                    </ext:TreePanel>
                                </Component>
                                <Listeners>
                                    <Expand Handler="this.component.getRootNode().expand(true);" Single="true" Delay="10" />
                                </Listeners>
                            </ext:DropDownField>
                            <ext:Hidden runat="server" ID="hdfParentID" />
                            <ext:TextField ID="txtMenuName" runat="server" FieldLabel="Tên bảng lương"
                                Width="400" />
                            <ext:TextField ID="txtTabName" runat="server" Width="400" FieldLabel="<%$ Resources:Language, tab_name%>"
                                AllowBlank="false" MsgTarget="Side" Hidden="true" />
                            <ext:ComboBox ID="cbModule" runat="server" Editable="false" Width="400" TypeAhead="true"
                                Mode="Local" FieldLabel="<%$ Resources:Language, choose_module%>" ForceSelection="true"
                                TriggerAction="All" SelectOnFocus="true" EmptyText="<%$ Resources:Language, choose_module%>"
                                Hidden="true">
                                <Listeners>
                                    <Select Handler="#{cbFile}.clearValue(); #{ModuleFileStore}.reload();" />
                                </Listeners>
                            </ext:ComboBox>
                            <ext:ComboBox ID="cbFile" StoreID="ModuleFileStore" Editable="false" runat="server"
                                TypeAhead="true" Width="400" Mode="Local" FieldLabel="<%$ Resources:Language, choose_file%>"
                                ForceSelection="true" TriggerAction="All" DisplayField="Path" ValueField="Path"
                                EmptyText="<%$ Resources:Language, choose_file%> aspx..." Hidden="true">
                                <Triggers>
                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                </Triggers>
                                <Listeners>
                                    <Select Handler="this.triggers[0].show();" />
                                    <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                    <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                </Listeners>
                            </ext:ComboBox>
                            <ext:DropDownField ID="ddfRole" FieldLabel="<%$ Resources:Language, choose_authorization%>"
                                Width="400" runat="server" Editable="false" TriggerIcon="SimpleArrowDown">
                                <Component>
                                    <ext:TreePanel ID="TreePanelRole" runat="server" Title="<%$ Resources:Language, choose_authorization_category%>"
                                        Icon="Accept" Height="250" Shadow="None" UseArrows="true" AutoScroll="true" Animate="true"
                                        EnableDD="true" ContainerScroll="true" RootVisible="false">
                                        <Buttons>
                                            <ext:Button ID="Button5" runat="server" Text="<%$ Resources:Language, close%>">
                                                <Listeners>
                                                    <Click Handler="#{ddfRole}.collapse();" />
                                                </Listeners>
                                            </ext:Button>
                                        </Buttons>
                                        <Listeners>
                                            <CheckChange Handler="this.dropDownField.setValue(getRoleTextAndValue(this), false);" />
                                        </Listeners>
                                    </ext:TreePanel>
                                </Component>
                                <Listeners>
                                    <Expand Handler="this.component.getRootNode().expand(true);SetNodeChecked(#{TreePanelRole});"
                                        Single="true" Delay="10" />
                                </Listeners>
                            </ext:DropDownField>
                            <ext:TextField runat="server" ID="txtMenuLink" FieldLabel="<%$ Resources:Language, link%>"
                                AnchorHorizontal="100%" Hidden="true" />
                            <ext:Hidden ID="hdfOldMenuRole" runat="server" />
                            <ext:Hidden runat="server" ID="hdfRoleID" />
                            <ext:TextField ID="txtIcon" FieldLabel="<%$ Resources:Language, choose_icon%>" runat="server"
                                Hidden="true" />
                            <ext:Checkbox runat="server" FieldLabel="<%$ Resources:Language, choose_is_panel%>"
                                ID="chkIsMenuPanel" Hidden="true" />
                        </Items>
                        <Buttons>
                            <ext:Button runat="server" Text="<%$ Resources:Language, update%>" Icon="Disk" ID="btnUpdateMenu">
                                <DirectEvents>
                                    <Click OnEvent="btnUpdateMenu_Click">
                                        <EventMask ShowMask="true" Msg="<%$ Resources:Language, updating%>" />
                                        <ExtraParams>
                                            <ext:Parameter Name="MenuCommand" Value="insert" />
                                        </ExtraParams>
                                    </Click>
                                </DirectEvents>
                            </ext:Button>
                            <ext:Button ID="Button3" runat="server" Text="<%$ Resources:Language, close%>" Icon="Decline">
                                <Listeners>
                                    <Click Handler="wdAddModule.hide();" />
                                </Listeners>
                            </ext:Button>
                        </Buttons>
                    </ext:Panel>
                </Items>
                <Listeners>
                    <Hide Handler="ResetTreeID();ClearFormValue();" />
                    <Close Handler="ResetTreeID();ClearFormValue();" />
                </Listeners>
            </ext:Window>
            <ext:Store runat="server" ID="stDataSourceFunction">
                <Proxy>
                    <ext:HttpProxy Method="POST" Url="Handler/HandlerDataSourceFunction.ashx" />
                </Proxy>
                <Reader>
                    <ext:JsonReader IDProperty="MA" Root="plants" TotalProperty="total">
                        <Fields>
                            <ext:RecordField Name="MA" />
                            <ext:RecordField Name="TEN" />
                        </Fields>
                    </ext:JsonReader>
                </Reader>
            </ext:Store>
            <ext:Window ID="wdAddRecord" runat="server" Border="false" Padding="6" Icon="Add"
                Width="500" Modal="true" Maximizable="false" Resizable="false" AutoHeight="true" Layout="FormLayout"
                Title="Thêm một cột mới trong bảng lương" Hidden="true">
                <Items>
                    <ext:Container runat="server" Layout="ColumnLayout" ID="tcv" Height="30">
                        <Items>
                            <ext:Container runat="server" Layout="FormLayout" ColumnWidth="0.4" ID="ctv11">
                                <Items>
                                    <ext:ComboBox runat="server" ID="cbbColumnID" FieldLabel="Ký hiệu<span style='color:red'>*</span>" CtCls="requiredData" AnchorHorizontal="98%" ValueField="ColumnID" DisplayField="ColumnID">
                                        <Store>
                                            <ext:Store runat="server" ID="stColumnID" OnRefreshData="stColumnID_RefreshData">
                                                <Reader>
                                                    <ext:JsonReader>
                                                        <Fields>
                                                            <ext:RecordField Name="ColumnID" />
                                                        </Fields>
                                                    </ext:JsonReader>
                                                </Reader>
                                            </ext:Store>
                                        </Store>
                                        <Listeners>
                                            <Expand Handler="stColumnID.reload();" />
                                        </Listeners>
                                    </ext:ComboBox>
                                </Items>
                            </ext:Container>
                            <ext:Container runat="server" Layout="FormLayout" ColumnWidth="0.3" ID="ctv12" LabelWidth="85">
                                <Items>
                                    <ext:TextField runat="server" ID="nfThuTu" FieldLabel="TT Tính toán<span style='color:red'>*</span>" CtCls="requiredData"
                                        MaxLength="5" AllowNegative="false" AllowDecimals="false" AnchorHorizontal="98%" MaskRe="/[0-9]/" EmptyText="Thứ tự" />
                                </Items>
                            </ext:Container>
                            <ext:Container runat="server" Layout="FormLayout" ColumnWidth="0.3" ID="Container1" LabelWidth="85">
                                <Items>
                                    <ext:TextField runat="server" ID="nfOrderDisplay" FieldLabel="TT Hiển thị<span style='color:red'>*</span>" CtCls="requiredData"
                                        MaxLength="5" AllowNegative="false" AllowDecimals="false" AnchorHorizontal="100%" MaskRe="/[0-9]/" EmptyText="Thứ tự" />
                                </Items>
                            </ext:Container>
                        </Items>
                    </ext:Container>
                    <ext:TextField runat="server" ID="txtDienGiai" FieldLabel="Tên diễn giải<span style='color:red'>*</span>" CtCls="requiredData" AnchorHorizontal="100%" />
                    <ext:TextField runat="server" ID="txtCongThuc" FieldLabel="Công thức" MaxLength="500" AnchorHorizontal="100%" />
                    <ext:Hidden runat="server" ID="hdfDataSource" />
                    <ext:ComboBox runat="server" ID="cbbDataSource" FieldLabel="Nguồn dữ liệu" ItemSelector="div.list-item"
                        StoreID="stDataSourceFunction" ValueField="MA" DisplayField="TEN" AnchorHorizontal="100%">
                        <Triggers>
                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                        </Triggers>
                        <Template ID="Template38" runat="server">
                            <Html>
                                <tpl for=".">
						            <div class="list-item"> 
							            {TEN}
						            </div>
					            </tpl>
                            </Html>
                        </Template>
                        <Listeners>
                            <Expand Handler="stDataSourceFunction.reload();" />
                            <Select Handler="this.triggers[0].show();hdfDataSource.setValue(this.getValue());" />
                            <TriggerClick Handler="this.triggers[0].hide(); this.clearValue(); hdfDataSource.reset();" />
                        </Listeners>
                    </ext:ComboBox>
                    <ext:Container runat="server" Layout="ColumnLayout" Height="30">
                        <Items>
                            <ext:Container runat="server" Layout="FormLayout" ColumnWidth="0.5">
                                <Items>
                                    <ext:ComboBox runat="server" ID="cbbRenderJS" FieldLabel="Định dạng" AnchorHorizontal="98%">
                                        <Items>
                                            <ext:ListItem Value="RenderVND" Text="Kiểu tiền tệ" />
                                            <ext:ListItem Value="RenderNumber" Text="Kiểu số" />
                                        </Items>
                                    </ext:ComboBox>
                                </Items>
                            </ext:Container>
                            <ext:Container runat="server" Layout="FormLayout" ColumnWidth="0.5">
                                <Items>
                                    <ext:ComboBox Editable="false" runat="server" ID="cbbAlign" FieldLabel="Căn lề" AnchorHorizontal="100%">
                                        <Items>
                                            <ext:ListItem Text="Trái" Value="Left" />
                                            <ext:ListItem Text="Phải" Value="Right" />
                                            <ext:ListItem Text="Giữa" Value="Center" />
                                        </Items>
                                    </ext:ComboBox>
                                </Items>
                            </ext:Container>
                        </Items>
                    </ext:Container>
                    <ext:Container runat="server" Layout="ColumnLayout" Height="30">
                        <Items>
                            <ext:Container runat="server" Layout="FormLayout" ColumnWidth="0.5">
                                <Items>
                                    <ext:NumberField runat="server" ID="nfWidth" FieldLabel="Độ rộng cột" AllowNegative="false" AllowDecimals="false" AnchorHorizontal="98%" />
                                </Items>
                            </ext:Container>
                            <ext:Container runat="server" Layout="FormLayout" ColumnWidth="0.5">
                                <Items>
                                    <ext:NumberField runat="server" ID="nfDefaultValue" FieldLabel="Giá trị mặc định" AnchorHorizontal="100%" />
                                </Items>
                            </ext:Container>
                        </Items>
                    </ext:Container>
                    <ext:TextField runat="server" ID="txtDKTinhLuong" FieldLabel="Điều kiện" MaxLength="4000" AnchorHorizontal="100%" EmptyText="Điều kiện tính lương" />
                    <ext:Checkbox runat="server" ID="ckDisplayOnGridView" BoxLabel="Hiển thị trên bảng lương" />
                    <ext:Checkbox runat="server" ID="ckAllowEditOnGrid" BoxLabel="Cho phép chỉnh sửa trên bảng lương" />
                    <ext:Checkbox runat="server" ID="ckAllowSum" BoxLabel="Tính tổng đầu cột" />
                    <ext:Checkbox runat="server" ID="ckDisplayOnReport" BoxLabel="Hiển thị trên báo cáo" />
                    <ext:Checkbox runat="server" ID="ckIsInUsed" BoxLabel="Đang sử dụng" />
                </Items>
                <Buttons>
                    <ext:Button runat="server" ID="btnAddColumn" Text="Cập nhật" Icon="Disk">
                        <Listeners>
                            <Click Handler="return checkInputWdAddRecord();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnAddColumn_Click" />
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button runat="server" ID="btnAddAndCloseColumn" Text="Cập nhật & đóng lại" Icon="Disk">
                        <Listeners>
                            <Click Handler="return checkInputWdAddRecord();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnAddColumn_Click">
                                <ExtraParams>
                                    <ext:Parameter Name="close" Value="true" />
                                </ExtraParams>
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button runat="server" ID="btnCloseWd" Text="Đóng lại" Icon="Decline">
                        <Listeners>
                            <Click Handler="wdAddRecord.hide(); resetWdAddRecord();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:Window>

            <ext:Viewport runat="server" ID="vp">
                <Items>
                    <ext:BorderLayout runat="server" ID="br">
                        <Center>
                            <ext:GridPanel runat="server" ID="grpSalaryConfig" Border="false">
                                <TopBar>
                                    <ext:Toolbar runat="server">
                                        <Items>
                                            <ext:Hidden ID="hdfSalaryTable" runat="server" />
                                            <ext:Button runat="server" Text="Tạo mới một bảng lương" Icon="Add" ID="btnAddMenuSalary">
                                                <Listeners>
                                                    <Click Handler="wdAddModule.show();" />
                                                </Listeners>
                                            </ext:Button>
                                            <ext:Button runat="server" ID="btnAddAndDeleteRecord" Text="Thêm, xóa cột trong bảng lương" Icon="BookAdd" Width="185">
                                                <Menu>
                                                    <ext:Menu runat="server" AnchorHorizontal="100%" ID="menuAddAndDeleteRecord" Width="185">
                                                        <Items>
                                                            <ext:MenuItem runat="server" ID="btnAddRecord" Text="Thêm" Icon="Add">
                                                                <Listeners>
                                                                    <Click Handler="if(hdfSalaryTable.getValue() != '') {wdAddRecord.show();} else {alert('Bạn chưa chọn bảng lương nào!');}" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                            <ext:MenuItem runat="server" ID="btnDeleteRecord" Text="Xóa" Icon="Delete" Disabled="true">
                                                                <Listeners>
                                                                    <Click Handler="return CheckSelectedRow(grpSalaryConfig);" />
                                                                </Listeners>
                                                                <DirectEvents>
                                                                    <Click OnEvent="btnDeleteRecord_Click">
                                                                        <EventMask ShowMask="true" />
                                                                        <Confirmation Title="Xác nhận" Message="Bạn có chắc chắn muốn xóa cột khỏi bảng lương!"
                                                                            ConfirmRequest="true" />
                                                                    </Click>
                                                                </DirectEvents>
                                                            </ext:MenuItem>
                                                        </Items>
                                                    </ext:Menu>
                                                </Menu>
                                            </ext:Button>
                                            <ext:ComboBox runat="server" EmptyText="Chọn bảng lương" Width="250" Editable="false"
                                                ID="cbChooseSalaryTable" ValueField="MenuID" DisplayField="MenuName">
                                                <Store>
                                                    <ext:Store runat="server" ID="stChooseSalaryTable" AutoLoad="false" OnRefreshData="stChooseSalaryTable_OnRefreshData">
                                                        <Reader>
                                                            <ext:JsonReader IDProperty="MenuID">
                                                                <Fields>
                                                                    <ext:RecordField Name="MenuID" />
                                                                    <ext:RecordField Name="MenuName" />
                                                                </Fields>
                                                            </ext:JsonReader>
                                                        </Reader>
                                                    </ext:Store>
                                                </Store>
                                                <Listeners>
                                                    <Expand Handler="{stChooseSalaryTable.reload();}" />
                                                    <Select Handler="hdfSalaryTable.setValue(cbChooseSalaryTable.getValue()); grpSalaryConfig.reload();" />
                                                </Listeners>
                                            </ext:ComboBox>
                                        </Items>
                                    </ext:Toolbar>
                                </TopBar>
                                <Store>
                                    <ext:Store runat="server" ID="stSalaryConfig" AutoLoad="false" OnRefreshData="stSalaryConfig_OnRefreshData">
                                        <Reader>
                                            <ext:JsonReader IDProperty="ID">
                                                <Fields>
                                                    <ext:RecordField Name="ID" />
                                                    <ext:RecordField Name="MenuID" />
                                                    <ext:RecordField Name="RenderJS" />
                                                    <ext:RecordField Name="Order" />
                                                    <ext:RecordField Name="OrderDisplay" />
                                                    <ext:RecordField Name="Width" />
                                                    <ext:RecordField Name="ColumnName" />
                                                    <ext:RecordField Name="ColumnDescription" />
                                                    <ext:RecordField Name="Formula" />
                                                    <ext:RecordField Name="AllowSum" />
                                                    <ext:RecordField Name="Align" />
                                                    <ext:RecordField Name="DataSourceFunction" />
                                                    <ext:RecordField Name="DisplayOnGrid" />
                                                    <ext:RecordField Name="WhereClause" />
                                                    <ext:RecordField Name="IsInUsed" />
                                                    <ext:RecordField Name="AllowEditOnGrid" />
                                                    <ext:RecordField Name="DefaultValue" />
                                                    <ext:RecordField Name="DisplayOnReport" />
                                                </Fields>
                                            </ext:JsonReader>
                                        </Reader>
                                    </ext:Store>
                                </Store>
                                <Listeners>
                                    <AfterEdit Fn="afterEdit" />
                                </Listeners>
                                <ColumnModel>
                                    <Columns>
                                        <ext:RowNumbererColumn Header="STT" Align="Center" Width="35" Locked="true" />
                                        <ext:Column DataIndex="ColumnName" Width="50" Header="Ký hiệu" Locked="true">
                                            <Editor>
                                                <%--<ext:ComboBox runat="server" ID="cbColumnName" DisplayField="Value" ValueField="ID"
                                                Editable="false">
                                                <Store>
                                                    <ext:Store runat="server" ID="stColumnName" AutoLoad="false" OnRefreshData="stColumnName_OnRefreshData" >
                                                        <Reader>
                                                            <ext:JsonReader IDProperty="ID">
                                                                <Fields>
                                                                    <ext:RecordField Name="ID" />
                                                                    <ext:RecordField Name="Value" />
                                                                </Fields>
                                                            </ext:JsonReader>
                                                        </Reader>
                                                    </ext:Store>
                                                </Store>
                                            </ext:ComboBox>--%>
                                                <%-- <ext:TextField runat="server" ID="txtColumnName" />--%>
                                            </Editor>
                                        </ext:Column>
                                        <ext:Column DataIndex="ColumnDescription" Width="250" Header="Tên diễn giải" Locked="true">
                                            <Editor>
                                                <ext:TextField runat="server" ID="txtDescription" />
                                            </Editor>
                                        </ext:Column>
                                        <ext:Column DataIndex="Order" Width="80" Align="Right" Header="Thứ tự tính toán">
                                            <Editor>
                                                <ext:TextField runat="server" ID="txtOrder" />
                                            </Editor>
                                        </ext:Column>
                                        <ext:Column DataIndex="OrderDisplay" Width="80" Align="Right" Header="Thứ tự hiển thị">
                                            <Editor>
                                                <ext:TextField runat="server" ID="TextField1" />
                                            </Editor>
                                        </ext:Column>
                                        <ext:Column DataIndex="Formula" Width="250" Header="Công thức">
                                            <Editor>
                                                <ext:TextField runat="server" ID="txtFormula" />
                                            </Editor>
                                        </ext:Column>
                                        <ext:Column DataIndex="Width" Width="65" Header="Độ rộng" Align="Right">
                                            <Editor>
                                                <ext:NumberField runat="server" ID="txtWidth">
                                                </ext:NumberField>
                                            </Editor>
                                            <Renderer Fn="RenderAlign" />
                                        </ext:Column>
                                        <ext:Column DataIndex="RenderJS" Width="120" Header="Định dạng">
                                            <Editor>
                                                <ext:ComboBox runat="server" ID="cbRenderJS">
                                                    <Store>
                                                        <ext:Store runat="server" ID="Store5" AutoLoad="false">
                                                            <Reader>
                                                                <ext:JsonReader IDProperty="ID">
                                                                    <Fields>
                                                                        <ext:RecordField Name="ID" />
                                                                        <ext:RecordField Name="Value" />
                                                                    </Fields>
                                                                </ext:JsonReader>
                                                            </Reader>
                                                        </ext:Store>
                                                    </Store>
                                                    <Items>
                                                        <ext:ListItem Value="RenderVND" Text="Kiểu tiền tệ" />
                                                        <ext:ListItem Value="RenderNumber" Text="Kiểu số" />
                                                    </Items>
                                                </ext:ComboBox>
                                            </Editor>
                                            <Renderer Fn="Render" />
                                        </ext:Column>
                                        <ext:Column DataIndex="AllowSum" Width="80" Header="Tính tổng">
                                            <Editor>
                                                <ext:ComboBox runat="server" ID="cbAllowSum">
                                                    <Store>
                                                        <ext:Store runat="server" ID="Store1" AutoLoad="false">
                                                            <Reader>
                                                                <ext:JsonReader IDProperty="ID">
                                                                    <Fields>
                                                                        <ext:RecordField Name="ID" />
                                                                        <ext:RecordField Name="Value" />
                                                                    </Fields>
                                                                </ext:JsonReader>
                                                            </Reader>
                                                        </ext:Store>
                                                    </Store>
                                                    <Items>
                                                        <ext:ListItem Value="True" Text="True" />
                                                        <ext:ListItem Value="False" Text="False" />
                                                    </Items>
                                                </ext:ComboBox>
                                            </Editor>
                                            <Renderer Fn="GetBooleanIcon" />
                                        </ext:Column>
                                        <ext:Column DataIndex="Align" Width="60" Header="Căn lề">
                                            <Editor>
                                                <ext:ComboBox Editable="false" runat="server" ID="txtAlign">
                                                    <Items>
                                                        <ext:ListItem Text="Trái" Value="Left" />
                                                        <ext:ListItem Text="Phải" Value="Right" />
                                                        <ext:ListItem Text="Giữa" Value="Center" />
                                                    </Items>
                                                </ext:ComboBox>
                                            </Editor>
                                            <Renderer Fn="RenderAlign" />
                                        </ext:Column>
                                        <ext:Column DataIndex="DataSourceFunction" Width="250" Header="Nguồn dữ liệu">
                                            <Renderer Fn="RenderComboboxDataSource" />
                                            <Editor>
                                                <ext:ComboBox runat="server" ListWidth="300" ID="txtDataSourceTable" StoreID="stDataSourceFunction" ValueField="MA" DisplayField="TEN">
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" />
                                                    </Triggers>
                                                    <Listeners>
                                                        <Select Handler="this.triggers[0].show();" />
                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                    </Listeners>
                                                </ext:ComboBox>
                                            </Editor>
                                        </ext:Column>
                                        <ext:Column DataIndex="WhereClause" Width="80" Header="Điều kiện tính lương">
                                            <Editor>
                                                <ext:TextField runat="server" ID="txtWhereClause" />
                                            </Editor>
                                        </ext:Column>
                                        <ext:Column DataIndex="DefaultValue" Width="100" Header="Giá trị mặc định">
                                            <Editor>
                                                <ext:TextField runat="server" ID="txtDefaultValue" />
                                            </Editor>
                                        </ext:Column>
                                        <ext:Column DataIndex="DisplayOnGrid" Width="80" Header="Hiển thị trên bảng lương">
                                            <Editor>
                                                <ext:ComboBox runat="server" ID="cbDisplayOnGrid">
                                                    <Store>
                                                        <ext:Store runat="server" ID="Store3" AutoLoad="false">
                                                            <Reader>
                                                                <ext:JsonReader IDProperty="ID">
                                                                    <Fields>
                                                                        <ext:RecordField Name="ID" />
                                                                        <ext:RecordField Name="Value" />
                                                                    </Fields>
                                                                </ext:JsonReader>
                                                            </Reader>
                                                        </ext:Store>
                                                    </Store>
                                                    <Items>
                                                        <ext:ListItem Value="True" Text="True" />
                                                        <ext:ListItem Value="False" Text="False" />
                                                    </Items>
                                                </ext:ComboBox>
                                            </Editor>
                                            <Renderer Fn="GetBooleanIcon" />
                                        </ext:Column>
                                        <ext:Column DataIndex="IsInUsed" Width="80" Header="Đang sử dụng">
                                            <Editor>
                                                <ext:ComboBox runat="server" ID="cbIsInUsed">
                                                    <Store>
                                                        <ext:Store runat="server" ID="Store4" AutoLoad="false">
                                                            <Reader>
                                                                <ext:JsonReader IDProperty="ID">
                                                                    <Fields>
                                                                        <ext:RecordField Name="ID" />
                                                                        <ext:RecordField Name="Value" />
                                                                    </Fields>
                                                                </ext:JsonReader>
                                                            </Reader>
                                                        </ext:Store>
                                                    </Store>
                                                    <Items>
                                                        <ext:ListItem Value="True" Text="True" />
                                                        <ext:ListItem Value="False" Text="False" />
                                                    </Items>
                                                </ext:ComboBox>
                                            </Editor>
                                            <Renderer Fn="GetBooleanIcon" />
                                        </ext:Column>
                                        <ext:Column DataIndex="AllowEditOnGrid" Width="90" Header="Cho phép sửa trên grid">
                                            <Editor>
                                                <ext:ComboBox runat="server" ID="cbAllowEditOnGrid">
                                                    <Store>
                                                        <ext:Store runat="server" ID="Store2" AutoLoad="false">
                                                            <Reader>
                                                                <ext:JsonReader IDProperty="ID">
                                                                    <Fields>
                                                                        <ext:RecordField Name="ID" />
                                                                        <ext:RecordField Name="Value" />
                                                                    </Fields>
                                                                </ext:JsonReader>
                                                            </Reader>
                                                        </ext:Store>
                                                    </Store>
                                                    <Items>
                                                        <ext:ListItem Value="True" Text="True" />
                                                        <ext:ListItem Value="False" Text="False" />
                                                    </Items>
                                                </ext:ComboBox>
                                            </Editor>
                                            <Renderer Fn="GetBooleanIcon" />
                                        </ext:Column>
                                        <ext:Column DataIndex="DisplayOnReport" Width="80" Header="Hiển thị trên báo cáo">
                                            <Editor>
                                                <ext:ComboBox runat="server" ID="cbDisplayOnReport">
                                                    <Store>
                                                        <ext:Store runat="server" ID="Store6" AutoLoad="false">
                                                            <Reader>
                                                                <ext:JsonReader IDProperty="ID">
                                                                    <Fields>
                                                                        <ext:RecordField Name="ID" />
                                                                        <ext:RecordField Name="Value" />
                                                                    </Fields>
                                                                </ext:JsonReader>
                                                            </Reader>
                                                        </ext:Store>
                                                    </Store>
                                                    <Items>
                                                        <ext:ListItem Value="True" Text="True" />
                                                        <ext:ListItem Value="False" Text="False" />
                                                    </Items>
                                                </ext:ComboBox>
                                            </Editor>
                                            <Renderer Fn="GetBooleanIcon" />
                                        </ext:Column>
                                    </Columns>
                                </ColumnModel>
                                <View>
                                    <ext:LockingGridView runat="server" ID="LockingGridView1" LockText="Cố định cột này lại"
                                        UnlockText="Hủy cố định cột" />
                                </View>
                                <LoadMask ShowMask="true" />
                                <SelectionModel>
                                    <ext:RowSelectionModel ID="RowSelectionModel1" runat="server">
                                        <Listeners>
                                        </Listeners>
                                    </ext:RowSelectionModel>
                                </SelectionModel>
                                <BottomBar>
                                    <ext:PagingToolbar ID="StaticPagingToolbar" IDMode="Static" EmptyMsg="Hiện không có dữ liệu"
                                        NextText="Trang sau" PageSize="100" PrevText="Trang trước" LastText="Trang cuối cùng"
                                        FirstText="Trang đầu tiên" DisplayMsg="Dòng {0} đến dòng {1} / {2} dòng" runat="server">
                                        <Items>
                                            <ext:Label ID="Label1" runat="server" Text="Số bản ghi trên 1 trang:" />
                                            <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                            <ext:ComboBox ID="ComboBoxPaging" SelectedIndex="1" Editable="false" runat="server"
                                                Width="80">
                                                <Items>
                                                    <ext:ListItem Text="50" />
                                                    <ext:ListItem Text="100" />
                                                    <ext:ListItem Text="200" />
                                                    <ext:ListItem Text="300" />
                                                    <ext:ListItem Text="400" />
                                                    <ext:ListItem Text="500" />
                                                </Items>
                                                <Listeners>
                                                    <Select Handler="#{StaticPagingToolbar}.pageSize = parseInt(this.getValue()); #{StaticPagingToolbar}.doLoad();" />
                                                </Listeners>
                                            </ext:ComboBox>
                                        </Items>
                                        <Listeners>
                                            <Change Handler="RowSelectionModel1.clearSelections();" />
                                        </Listeners>
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
