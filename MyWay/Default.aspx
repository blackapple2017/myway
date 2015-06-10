<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register Src="Modules/Base/AjaxSearch/AjaxSearch.ascx" TagName="AjaxSearch" TagPrefix="uc1" %> 
<%@ Register Src="Modules/System/SystemConfiguration.ascx" TagName="SystemConfiguration"
    TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        <asp:Literal Text="" ID="ltrApplicationName" runat="server" />
    </title>
    <style type="text/css">
        div#unlicensed
        {
            display: none !important;
            width: 10px !important;
        }
        .x-layout-collapsed-west
        {
            background: url(Resource/images/Menu_Chuc_Nang.png) no-repeat center;
        }
    </style>
    <link rel="shortcut icon" href="/favicon.ico" type="image/ico" />
    <script src="Resource/js/Extcommon.js" type="text/javascript"></script>
    <script src="Resource/js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="Resource/js/jquery.ui.core.min.js" type="text/javascript"></script>
    <script src="Resource/js/jquery.ui.widget.min.js" type="text/javascript"></script>
    <script src="Resource/js/jquery.ui.mouse.min.js" type="text/javascript"></script>
    <script src="Resource/js/jquery.ui.sortable.min.js" type="text/javascript"></script>
    <link href="Resource/css/DefaultStyle.css" rel="stylesheet" type="text/css" />
    <link href="Resource/css/IconStyle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function SetTreeNodeID(NodeID) {
            document.getElementById("hdfTreeNodeID").value = NodeID;
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
        var getValues = function (tree) {
            var msg = [],
                    selNodes = tree.getChecked();

            Ext.each(selNodes, function (node) {
                //msg.push(node.id);
            });

            return msg.join(",");
        };
        //Thiết lập checked cho tree
        var SetNodeChecked = function (tree, textfield) {
            //  tree.getNodeById("4").getUI().checkbox.checked = true;
            //  alert("hehe");
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
        var LastChoice = new Array();
        var getText = function (tree) {
            var CurrentChoice = new Array();
            var msg = [],
                    selNodes = tree.getChecked();
            var i = 0;
            Ext.each(selNodes, function (node) {
                CurrentChoice[i] = node.id;
                i = i + 1;
            });

            var CurrentNodeID = GetNodeID(CurrentChoice);
            Ext.each(selNodes, function (node) {
                node.getUI().checkbox.checked = false;
                if (CurrentNodeID == node.id) {
                    node.getUI().checkbox.checked = true;
                    msg.push(node.text);
                    document.getElementById("hdfParentID").value = node.id;
                }
            });
            return msg.join("");
        };

        var GetNodeID = function (CurrentChoice) {
            var rs = CurrentChoice[0];
            for (var i = 0; i < CurrentChoice.length; i++) {
                if (IsInLastChoice(CurrentChoice[i]) == false) {
                    rs = CurrentChoice[i];
                    break;
                }
            }
            for (var i = 0; i < CurrentChoice.length; i++) {
                LastChoice[i] = CurrentChoice[i];
            }
            return rs;
        };

        var IsInLastChoice = function (nodeID) {
            for (var j = 0; j < LastChoice.length; j++) {
                if (nodeID == LastChoice[j]) {
                    return true;
                }
            }
            return false;
        };

        function heartBeat() {
            $.get("KeepAlive.ashx?", function (data) { });
        }

        $(function () {
            setInterval("heartBeat()", 1000 * 270); // 4" gửi request một lần
        });

        //        var ConfirmToExit = function () {
        //            Ext.MessageBox.buttonText.yes = " Có ";
        //            Ext.MessageBox.buttonText.no = " Không ";
        //            Ext.Msg.confirm('Xác nhận', 'Bạn có chắc chắn muốn thoát không ?', function (btn) {
        //                if (btn == 'yes') {
        //                    return true;
        //                }
        //                else
        //                    return false;
        //            });
        //        }

        var checkChangePassword = function() {
            if (txtOldPassword.getValue() == '') {
                var content = "<asp:Literal runat='server' Text='<%$ Resources:Language, warning_not_fill_full_content%>' />";
                alert(content);
                txtOldPassword.focus();
                return false;
            }
            if (txtNewPassword.getValue() == '') {
                var content = "<asp:Literal runat='server' Text='<%$ Resources:Language, warning_not_fill_full_content%>' />";
                alert(content);
                txtNewPassword.focus();
                return false;
            }
            if (TextField1.getValue() == '') {
                var content = "<asp:Literal runat='server' Text='<%$ Resources:Language, warning_not_fill_full_content%>' />";
                alert(content);
                TextField1.focus();
                return false;
            }
            if (txtNewPassword.getValue() != TextField1.getValue()) {
                var cont = "<asp:Literal runat='server' Text='<%$ Resources:Language, warning_new_password_not_match%>' />";
                Ext.Msg.alert(Title, cont);
                return false;
            }
            return true;
        };

        function addDesk() {
            var Title = '<asp:Literal runat="server" Text="<%$ Resources:Language, desks%>" />';
            addHomePage(pnTabPanel, 'Homepage', 'Modules/Home/Default.aspx', Title)
        }

        ;

        function addAccessDiaryTab() {
            var title = '<asp:Literal runat="server" Text="<%$ Resources:Language, access_diary%>" />';
            addTab(pnTabPanel, 'dm_file_btnSystem_NhatKyTruyCap', 'Modules/System/NhatKyTruyCap.aspx', title);
        }

        ;

        function addUserManagerTab() {
            var title = '<asp:Literal runat="server" Text="<%$ Resources:Language, user_manager%>" />';
            addTab(pnTabPanel, 'dm_file_btnSystem_UsersList', 'Modules/Users/Default.aspx', title);
        }

        ;

        function addAuthorizationCategoryTab() {
            var title = '<asp:Literal runat="server" Text="<%$ Resources:Language, authorization_category%>" />';
            addTab(pnTabPanel, 'dm_file_btnSystem_PermissionList', 'Modules/Role/Default.aspx', title);
        }

        ;

       

        var KiemTraPhanQuyen = function() {
            if (txtControlText.getValue().trim() == '') {
                alert('Bạn chưa nhập Tên định danh');
                txtControlText.focus();
                return false;
            }
            if (txtDescription.getValue().trim() == '') {
                alert('Bạn chưa nhập Tên chức năng');
                txtDescription.focus();
                return false;
            }
            if (cbxChucNangCha.getValue() == '') {
                alert('Bạn chưa chọn chức năng cha');
                cbxChucNangCha.focus();
                return false;
            }
            return true;
        };

        var resetWdFunction = function() {
            txtControlText.reset();
            txtDescription.reset();
            //cbxChucNangCha.reset();
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager ID="ResourceManager1" runat="server">
            <Listeners>
                <DocumentReady Handler="addDesk()" />
            </Listeners> 
        </ext:ResourceManager> 
        <!--Hidden field -->
        <ext:Hidden runat="server" ID="hdfTreeNodeID" />
        <!--Lưu menu TreeNodeID -->
        <!--menu context-->
        <ext:Menu ID="Menu4" runat="server">
            <Items>
                <ext:MenuItem ID="mnuAddMenu" Visible="false" runat="server" Icon="Add" Text="<%$ Resources:Language, add_submenu%>">
                    <DirectEvents>
                        <Click OnEvent="mnuAddMenu_Click">
                            <EventMask ShowMask="true" Msg="<%$ Resources:Language, loading%>" />
                            <ExtraParams>
                                <ext:Parameter Name="Note" Value="AddChildMenu" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:MenuItem>
                <ext:MenuItem ID="mnuAddTheSameMenu" Visible="false" runat="server" Icon="Add" Text="<%$ Resources:Language, add_same_level_menu%>">
                    <DirectEvents>
                        <Click OnEvent="mnuAddMenu_Click">
                            <EventMask ShowMask="true" Msg="<%$ Resources:Language, loading%>" />
                            <ExtraParams>
                                <ext:Parameter Name="Note" Value="AddMenu" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:MenuItem>
                <ext:MenuItem ID="MenuItem9" Visible="false" runat="server" Icon="Pencil" Text="<%$ Resources:Language, edit%>">
                    <DirectEvents>
                        <Click OnEvent="mnuAddMenu_Click">
                            <EventMask ShowMask="true" Msg="<%$ Resources:Language, loading%>" />
                            <ExtraParams>
                                <ext:Parameter Name="Note" Value="UpdateMenu" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:MenuItem>
                <ext:MenuItem ID="MnuDeleteMenu" Visible="false" runat="server" Icon="Delete" Text="<%$ Resources:Language, delete%>">
                    <DirectEvents>
                        <Click OnEvent="MnuDeleteMenu_Click">
                            <Confirmation Title="<%$ Resources:Language, thong_bao%>" Message="<%$ Resources:Language, confirm_delete%>"
                                ConfirmRequest="true" />
                        </Click>
                    </DirectEvents>
                </ext:MenuItem>
                <ext:MenuSeparator />
                <ext:MenuItem ID="mnuOrder" Visible="false" runat="server" Icon="SortAscending" Text="<%$ Resources:Language, sorting%>">
                    <DirectEvents>
                        <Click OnEvent="mnuOrder_Click">
                            <EventMask ShowMask="true" Msg="<%$ Resources:Language, LoadingMask%>" />
                        </Click>
                    </DirectEvents>
                </ext:MenuItem>
                <ext:MenuItem ID="MenuItem1" Visible="false" runat="server" Icon="Key" Text="<%$ Resources:Language, xacdinh_phanquyen_chucnang%>">
                    <Listeners>
                        <Click Handler="wdFunction.show();" />
                    </Listeners>
                </ext:MenuItem>
            </Items>
        </ext:Menu>
        <!--Window copyright-->
        <ext:Window ID="wdAbout" Constrain="true" runat="server" Icon="Computer" Width="350" Modal="true"
            Height="200" Title="<%$ Resources:Language, about_software%>" Hidden="true">
            <Items>
                <ext:Image runat="server" ImageUrl="Resource/images/thongtinphanmem.jpg" />
            </Items>
        </ext:Window>
        <ext:Window runat="server" AutoHeight="true" Title="<%$ Resources:Language, decentralized_function%>"
            Width="465" Modal="true" ID="wdFunction" Padding="6" Hidden="true" Icon="Key">
            <Content>
                <ext:FieldSet AutoHeight="true" runat="server" Title="<%$ Resources:Language, determine_function%>">
                    <Items>
                        <ext:TextField ID="txtControlText" runat="server" Width="300" FieldLabel="<%$ Resources:Language, name_identifiers%>"
                            AllowBlank="false" />
                        <ext:TextField ID="txtDescription" runat="server" Width="300" FieldLabel="<%$ Resources:Language, function_name%>"
                            AllowBlank="false" />
                        <ext:ComboBox runat="server" ID="cbxChucNangCha" FieldLabel="Chức năng cha" DisplayField="Description"
                            ValueField="ID" Width="300" TabIndex="6" Editable="false">
                            <Store>
                                <ext:Store runat="server" ID="cbxChucNangChaStore" AutoLoad="False" OnRefreshData="cbxChucNangChaStore_OnRefreshData">
                                    <Reader>
                                        <ext:JsonReader IDProperty="ID">
                                            <Fields>
                                                <ext:RecordField Name="ID" />
                                                <ext:RecordField Name="Description" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                            <Listeners>
                                <Expand Handler="cbxChucNangChaStore.reload();" />
                            </Listeners>
                        </ext:ComboBox>
                    </Items>
                </ext:FieldSet>
                <ext:FieldSet runat="server" Title="<%$ Resources:Language, decentralized%>" CheckboxToggle="true"
                    AutoHeight="true" Collapsed="true">
                    <Items>
                        <ext:Panel Height="60" Border="false" runat="server" ID="pnl">
                            <Content>
                                <uc1:AjaxSearch ID="AjaxSearchUser" DisplayField="UserName" TableName="users" PageSize="7"
                                    FieldLabel="<%$ Resources:Language, user%>" Width="310" ValueField="ID" SearchField="DisplayName"
                                    runat="server" />
                                <ext:DropDownField ID="DropDownField1" FieldLabel="<%$ Resources:Language, select_authorization%>"
                                    Width="400" runat="server" Editable="false" TriggerIcon="SimpleArrowDown">
                                    <Component>
                                        <ext:TreePanel ID="TreePanel1" runat="server" Title="<%$ Resources:Language, choose_authorization_category%>"
                                            Icon="Accept" Height="250" Shadow="None" UseArrows="true" AutoScroll="true" Animate="true"
                                            EnableDD="true" ContainerScroll="true" RootVisible="false">
                                            <Buttons>
                                                <ext:Button ID="Button4" runat="server" Text="<%$ Resources:Language, close%>">
                                                    <Listeners>
                                                        <Click Handler="#{DropDownField1}.collapse();" />
                                                    </Listeners>
                                                </ext:Button>
                                            </Buttons>
                                            <Listeners>
                                                <CheckChange Handler="this.dropDownField.setValue(getRoleTextAndValue(this), false);" />
                                            </Listeners>
                                        </ext:TreePanel>
                                    </Component>
                                    <Listeners>
                                        <Expand Handler="this.component.getRootNode().expand(true);SetNodeChecked(#{TreePanel1});"
                                            Single="true" Delay="10" />
                                    </Listeners>
                                </ext:DropDownField>
                            </Content>
                        </ext:Panel>
                    </Items>
                </ext:FieldSet>
            </Content>
            <Buttons>
                <ext:Button runat="server" Text="<%$ Resources:Language, update%>" Icon="Disk" ID="btnAddFunction">
                    <Listeners>
                        <Click Handler="return KiemTraPhanQuyen();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnAddFunction_Click">
                            <EventMask ShowMask="true" Msg="<%$ Resources:Language, updating%>" />
                            <ExtraParams>
                                <ext:Parameter Name="Continue" Value="Yes" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" Text="<%$ Resources:Language, update_close%>" Icon="Disk"
                    ID="Button6">
                    <Listeners>
                        <Click Handler="return KiemTraPhanQuyen();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnAddFunction_Click">
                            <EventMask ShowMask="true" Msg="<%$ Resources:Language, updating%>" />
                            <ExtraParams>
                                <ext:Parameter Name="Continue" Value="No" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" Text="<%$ Resources:Language, cancel%>" Icon="Decline"
                    ID="Button2">
                    <Listeners>
                        <Click Handler="wdFunction.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <BeforeShow Handler="document.getElementById('hdfRoleID').value='';" />
                <Hide Handler="ResetTreeID();ClearFormValue();" />
                <Close Handler="ResetTreeID();ClearFormValue();" />
            </Listeners>
        </ext:Window>
        <!--Window for order tree panel-->
        <ext:Window ID="wdSortAscending" runat="server" Icon="SortAscending" Width="300"
            Modal="false" Height="350" Title="<%$ Resources:Language, sort_list_function%>"
            Hidden="true">
            <TopBar>
                <ext:Toolbar runat="server" ID="ctl2454">
                    <Items>
                        <ext:Button Text="<%$ Resources:Language, save%>" runat="server" Icon="Disk" ID="btnSaveOrderedMenu">
                            <DirectEvents>
                                <Click OnEvent="btnSaveOrderedMenu_Click">
                                    <EventMask ShowMask="true" Msg="<%$ Resources:Language, saving%>" />
                                    <ExtraParams>
                                        <ext:Parameter Name="order" Value="$('#sortable').sortable('toArray').toString()"
                                            Mode="Raw">
                                        </ext:Parameter>
                                    </ExtraParams>
                                </Click>
                            </DirectEvents>
                        </ext:Button>
                        <ext:Button runat="server" Text="<%$ Resources:Language, cancel%>" Icon="Decline"
                            ID="ctl2456">
                            <Listeners>
                                <Click Handler="wdSortAscending.hide();" />
                            </Listeners>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </TopBar>
            <Content>
                <div style="background: #DFE8F6;">
                    <ext:Label runat="server" ID="lblOutput" />
                </div>
            </Content>
        </ext:Window>
        <!--window for change password-->
        <ext:Window ID="wdChangePassword" Border="false" runat="server" Width="400" AutoHeight="true"
            Resizable="false" Modal="true" Icon="Lock" Title="<%$ Resources:Language, change_password%>"
            Hidden="true" Padding="6" LabelWidth="130" Layout="Form">
            <Items>
                <ext:TextField ID="txtOldPassword" AllowBlank="false" runat="server" FieldLabel="<%$ Resources:Language, old_password%>"
                    InputType="Password" AnchorHorizontal="100%">
                </ext:TextField>
                <ext:TextField ID="txtNewPassword" AllowBlank="false" runat="server" FieldLabel="<%$ Resources:Language, new_password%>"
                    InputType="Password" AnchorHorizontal="100%">
                </ext:TextField>
                <ext:TextField ID="TextField1" AllowBlank="false" runat="server" Vtype="password"
                    FieldLabel="<%$ Resources:Language, confirm_password%>" InputType="Password"
                    MsgTarget="Side" AnchorHorizontal="100%">
                </ext:TextField>
            </Items>
            <Buttons>
                <ext:Button runat="server" Icon="Disk" Text="<%$ Resources:Language, update%>" ID="btnUpdatePassword">
                    <%--  <Listeners>
                        <Click Handler="Ext.Msg.alert('Thông báo','Phiên bản demo không cho phép bạn đổi mật khẩu !')" />
                    </Listeners>--%>
                    <Listeners>
                        <Click Handler="return checkChangePassword();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnUpdatePassword_Click" />
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" Icon="Decline" Text="<%$ Resources:Language, cancel%>"
                    ID="btnClose">
                    <Listeners>
                        <Click Handler="wdChangePassword.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <!--window for add module-->
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
        <ext:Window ID="wdAddModule" runat="server" Border="false" Padding="0" Icon="Pencil"
            Width="560" Modal="true" Maximizable="false" Resizable="false" AutoHeight="true"
            Title="" Hidden="true">
            <Items>
                <ext:Panel runat="server" Frame="true" Padding="6" Border="false" Layout="FormLayout">
                    <Items>
                        <ext:Hidden ID="hdfMenuCommand" runat="server" />
                        <ext:DropDownField ID="ddfParentMenu" FieldLabel="Menu cấp cha" Width="400" runat="server"
                            Editable="false" TriggerIcon="SimpleArrowDown">
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
                        <ext:TextField ID="txtMenuName" runat="server" FieldLabel="<%$ Resources:Language, menu_name%>"
                            Width="400" />
                        <ext:TextField ID="txtTabName" runat="server" Width="400" FieldLabel="<%$ Resources:Language, tab_name%>"
                            AllowBlank="false" MsgTarget="Side" />
                        <ext:ComboBox ID="cbModule" runat="server" Editable="false" Width="400" TypeAhead="true"
                            Mode="Local" FieldLabel="<%$ Resources:Language, choose_module%>" ForceSelection="true"
                            TriggerAction="All" SelectOnFocus="true" EmptyText="<%$ Resources:Language, choose_module%>">
                            <Listeners>
                                <Select Handler="#{cbFile}.clearValue(); #{ModuleFileStore}.reload();" />
                            </Listeners>
                        </ext:ComboBox>
                        <ext:ComboBox ID="cbFile" StoreID="ModuleFileStore" Editable="false" runat="server"
                            TypeAhead="true" Width="400" Mode="Local" FieldLabel="<%$ Resources:Language, choose_file%>"
                            ForceSelection="true" TriggerAction="All" DisplayField="Path" ValueField="Path"
                            EmptyText="<%$ Resources:Language, choose_file%> aspx...">
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
                            AnchorHorizontal="100%" />
                        <ext:Hidden ID="hdfOldMenuRole" runat="server" />
                        <ext:Hidden runat="server" ID="hdfRoleID" />
                        <ext:TextField ID="txtIcon" FieldLabel="<%$ Resources:Language, choose_icon%>" runat="server" />
                        <ext:Checkbox runat="server" FieldLabel="<%$ Resources:Language, choose_is_panel%>"
                            ID="chkIsMenuPanel" />
                    </Items>
                    <Buttons>
                        <ext:Button runat="server" Text="<%$ Resources:Language, update%>" Icon="Disk" ID="btnUpdateMenu">
                            <DirectEvents>
                                <Click OnEvent="btnUpdateMenu_Click">
                                    <EventMask ShowMask="true" Msg="<%$ Resources:Language, updating%>" />
                                    <ExtraParams>
                                        <ext:Parameter Name="MenuCommand" Mode="Raw" Value="#{hdfMenuCommand}.value" />
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
        <!--view port-->
        <ext:Viewport ID="Viewport1" runat="server" Layout="Fit">
            <Items>
                <ext:BorderLayout ID="BorderLayout1" runat="server">
                    <North Split="false" Collapsible="true">
                        <ext:Panel runat="server" Height="27" Border="false" Title="false" Header="false">
                            <Items>
                                <ext:Toolbar ID="Toolbar1" runat="server" EnableOverflow="true">
                                    <Items>
                                        <ext:ToolbarSeparator runat="server" ID="ToolbarSeparator1" />
                                        <ext:Button runat="server" Visible="false" ID="btnSystem" Disabled="false" Text="<%$ Resources:Language, system%>"
                                            Cls="btnSystem" Icon="Computer">
                                            <Menu>
                                                <ext:Menu runat="server" ID="btnSystem_Menu">
                                                    <Items>
                                                        <ext:MenuItem runat="server" ID="btnSystem_PermissionList" Visible="false" Icon="Key"
                                                            Text="<%$ Resources:Language, authorization_category%>">
                                                            <%--<Listeners>
                                                                <Click Handler="Ext.Msg.alert('Thông báo','Phiên bản demo không cho phép sử dụng tính năng này')" />
                                                            </Listeners>--%>
                                                            <Listeners>
                                                                <Click Handler="addAuthorizationCategoryTab()" />
                                                            </Listeners>
                                                        </ext:MenuItem> 
                                                        <ext:MenuItem runat="server" ID="btnSystem_UsersList" Visible="false" Icon="User"
                                                            Text="<%$ Resources:Language, user_manager%>">
                                                            <%-- <Listeners>
                                                                <Click Handler="Ext.Msg.alert('Thông báo','Phiên bản demo không cho phép sử dụng tính năng này')" />
                                                            </Listeners>--%>
                                                            <Listeners>
                                                                <Click Handler="addUserManagerTab()" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem runat="server" ID="mnuSystemConfig" Visible="false" Icon="Cog" Text="<%$ Resources:Language, system_configuration_information%>">
                                                            <Listeners>
                                                                <Click Handler="SystemConfiguration1_wdWindow.show();" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem runat="server" ID="MenuItem7" Visible="false" Icon="Clock" Text="<%$ Resources:Language, access_diary%>">
                                                            <Listeners>
                                                                <Click Handler="addAccessDiaryTab()" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                    </Items>
                                                </ext:Menu>
                                            </Menu>
                                        </ext:Button>
                                        <ext:Button ID="Button1" runat="server" Text="<%$ Resources:Language, help%>" Icon="Help">
                                            <Menu>
                                                <ext:Menu ID="Menu2" runat="server">
                                                    <Items>
                                                        <%--<ext:MenuItem ID="mnuHowToUse" runat="server" Text="<%$ Resources:Language, manual%>"
                                                            Icon="Book">
                                                            <Listeners>
                                                                <Click Handler="window.open('HelpBook/Default.aspx','_blank')" />
                                                            </Listeners>
                                                        </ext:MenuItem>--%>
                                                        <ext:MenuItem ID="mnuSoftwareInformation" runat="server" Text="<%$ Resources:Language, software_information%>"
                                                            Icon="Information">
                                                            <Listeners>
                                                                <Click Handler="wdAbout.show();" />
                                                            </Listeners>
                                                        </ext:MenuItem> 
                                                        <ext:MenuItem ID="mnuChangeTheme" runat="server" Text="<%$ Resources:Language, change_interface%>"
                                                            Icon="Theme">
                                                            <Menu>
                                                                <ext:Menu ID="Menu3" runat="server">
                                                                    <Items>
                                                                        <ext:MenuItem ID="MenuItem6" runat="server" Text="<%$ Resources:Language, blue_default%>">
                                                                            <Listeners>
                                                                                <Click Handler="Ext.net.ResourceMgr.setTheme('/extjs/resources/css/xtheme-default-embedded-css/ext.axd');" />
                                                                            </Listeners>
                                                                        </ext:MenuItem>
                                                                        <ext:MenuItem ID="MenuItem12" runat="server" Text="<%$ Resources:Language, gray%>">
                                                                            <Listeners>
                                                                                <Click Handler="Ext.net.ResourceMgr.setTheme('/extjs/resources/css/xtheme-gray-embedded-css/ext.axd');" />
                                                                            </Listeners>
                                                                        </ext:MenuItem>
                                                                        <ext:MenuItem ID="MenuItem13" runat="server" Text="Slate">
                                                                            <Listeners>
                                                                                <Click Handler="Ext.net.ResourceMgr.setTheme('/extjs/resources/css/xtheme-slate-embedded-css/ext.axd');" />
                                                                            </Listeners>
                                                                        </ext:MenuItem>
                                                                        <ext:MenuItem ID="MenuItem14" runat="server" Text="Accessibility ">
                                                                            <Listeners>
                                                                                <Click Handler="Ext.net.ResourceMgr.setTheme('/extjs/resources/css/xtheme-access-embedded-css/ext.axd');" />
                                                                            </Listeners>
                                                                        </ext:MenuItem>
                                                                    </Items>
                                                                </ext:Menu>
                                                            </Menu>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem ID="MenuItem5" runat="server" Text="<%$ Resources:Language, register_product%>"
                                                            Icon="Star" />
                                                    </Items>
                                                </ext:Menu>
                                            </Menu>
                                        </ext:Button>
                                        <ext:ToolbarFill />
                                        <ext:Button ID="btnDisplayName" runat="server" Text="Administrator" Icon="User">
                                            <Menu>
                                                <ext:Menu ID="Menu1" runat="server">
                                                    <Items>
                                                        <ext:MenuItem ID="MenuItem2" runat="server" Text="<%$ Resources:Language, change_password%>"
                                                            Icon="Key">
                                                            <Listeners>
                                                                <Click Handler="wdChangePassword.show();" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem ID="MenuItem3" runat="server" Text="<%$ Resources:Language, user_information%>"
                                                            Icon="Information" />
                                                    </Items>
                                                </ext:Menu>
                                            </Menu>
                                        </ext:Button>
                                        <ext:ToolbarSeparator />
                                        <ext:Button ID="BtnLogout" runat="server" Text="<%$ Resources:Language, close%>"
                                            Icon="DoorIn">
                                            <%--<Listeners>
                                                <Click Handler="return ConfirmToExit();" />
                                            </Listeners>--%>
                                            <DirectEvents>
                                                <Click OnEvent="BtnLogout_Click">
                                                    <Confirmation ConfirmRequest="true" Title="<%$ Resources:Language, warning%>" Message="<%$ Resources:Language, confirm_close%>" />
                                                    <EventMask ShowMask="true" Msg="<%$ Resources:Language, closing%>" />
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </Items>
                        </ext:Panel>
                    </North>
                    <Center MarginsSummary="5 5 0 5">
                        <ext:TabPanel ID="pnTabPanel" EnableTabScroll="true" runat="server">
                            <Plugins>
                                <ext:TabCloseMenu CloseOtherTabsText="<%$ Resources:Language, close_other_tab%>"
                                    CloseAllTabsText="<%$ Resources:Language, close_all_tab%>" CloseTabText="<%$ Resources:Language, close_tab%>">
                                </ext:TabCloseMenu>
                                <ext:TabScrollerMenu runat="server" />
                            </Plugins>
                        </ext:TabPanel>
                    </Center>
                    <South Split="false" Collapsible="false" CMargins-Top="5">
                        <ext:Panel ID="Panel2" runat="server" Border="false" Title="false" Header="false"
                            BodyStyle="padding:0;">
                            <TopBar>
                                <ext:Toolbar ID="tbfooter" runat="server">
                                    <Items>
                                        <ext:ToolbarFill>
                                        </ext:ToolbarFill>
                                        <ext:Label ID="lblEmailTo" runat="server" Html="Website: <a href='http://www.dthsoft.com.vn' target='_blank'><b>www.dthsoft.com.vn</b></a>">
                                        </ext:Label>
                    <%--                    <ext:ToolbarSeparator>
                                        </ext:ToolbarSeparator>
                                        <ext:Label runat="server" Html="Phiên bản phần mềm 1.0">
                                        </ext:Label>
                                        <ext:ToolbarSpacer runat="server" Width="10" />--%>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                        </ext:Panel>
                    </South>
                </ext:BorderLayout>
            </Items>
        </ext:Viewport>
        <uc3:SystemConfiguration ID="SystemConfiguration1" runat="server" />
    </div>
    </form>
</body>
</html>
