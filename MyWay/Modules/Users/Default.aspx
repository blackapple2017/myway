<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Modules_Users_Users" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register Src="../ChooseEmployee/ucChooseEmployee.ascx" TagName="ucChooseEmployee"
    TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../Resource/js/RenderJS.js" type="text/javascript"></script>
    <style type="text/css">
        .west-panel2 .x-layout-collapsed-west
        {
            background: url(../../Resource/images/Loc_Theo_Quyen.png) no-repeat center;
        }
    </style>
    <script type="text/javascript">
        var enterKeyPressHandler = function (f, e) {
            if (e.getKey() == e.ENTER) {
                Store1.reload();
            }
        }
        var RemoveItemOnGrid = function (grid, Store) {
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
                        Ext.net.DirectMethods.DeleteUser(r.data.ID);
                        Store.commitChanges();
                    }
                }
            });
        }

        var GetListUserID = function (grid, store) {
            var s = grid.getSelectionModel().getSelections();
            var str = '';
            for (var i = 0, r; r = s[i]; i++) {
                str += r.data.ID + ',';
            }
            hdfListUserID.setValue(str);
        }

        //reset tree role về trạng thái chưa được chọn
        var ResetNodeChecked = function (tree) {
            if (hdfAllNodeID.getValue().length != 0) {
                var str = hdfAllNodeID.getValue().split(',');
                for (var i = 0; i < str.length; i++) {
                    if (str[i].length != 0) {
                        tree.getNodeById(str[i]).getUI().checkbox.checked = false;
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

        var checkChangePassword = function () {
            if (txtNewPassword.getValue() == '' || TextField1.getValue() == '') {
                Ext.Msg.alert("Cảnh báo", "Bạn chưa nhập đầy đủ thông tin");
                return false;
            }
            if (txtNewPassword.getValue() != TextField1.getValue()) {
                Ext.Msg.alert("Cảnh báo", "Mật khẩu mới không khớp nhau");
                return false;
            }
            return true;
        }
        //Bắt lỗi nhập liệu
        var checkNullValue = function () {
            if (txtFirstName.getValue() == '') {
                //    Ext.Msg.alert("Cảnh báo", "Bạn chưa nhập Họ đệm");
                alert("Bạn chưa nhập họ đệm");
                txtFirstName.focus();
                return false;
            }
            if (txtLastName.getValue() == '') {
                //   Ext.Msg.alert("Cảnh báo", "Bạn chưa nhập Tên");
                alert("Bạn chưa nhập Tên");
                txtLastName.focus();
                return false;
            }
            if (txtDisplayName.getValue() == '') {
                //      Ext.Msg.alert("Cảnh báo", "Bạn chưa nhập Tên hiển thị");
                alert("Bạn chưa nhập Tên hiển thị");
                txtDisplayName.focus();
                return false;
            }
            if (txtUserName.getValue() == '') {
                //      Ext.Msg.alert("Cảnh báo", "Bạn chưa nhập Tài khoản");
                alert("Bạn chưa nhập Tài khoản");
                txtUserName.focus();
                return false;
            }
            if (hdfUserCommand.getValue() != 'Update') {
                if (txtPassword.getValue() == '') {
                    alert("Bạn chưa nhập Mật khẩu");
                    txtPassword.focus();
                    return false;
                }
                if (txtConfirmPassword.getValue() == '') {
                    alert("Bạn chưa Xác nhận mật khẩu");
                    txtConfirmPassword.focus();
                    return false;
                }
            }
            if (txtPassword.getValue() != txtConfirmPassword.getValue()) {
                //      Ext.Msg.alert("Cảnh báo", "Xác nhận mật khẩu không đúng");
                alert("Xác nhận mật khẩu không đúng");
                txtConfirmPassword.focus();
                return false;
            }
            if (cbx_bophan.getValue() == '') {
                alert("Bạn chưa chọn bộ phận");
                return false;
            }
            return true;
        }

        var getSelectedIndexRow = function () {
            var record = GridPanel1.getSelectionModel().getSelected();
            var index = GridPanel1.store.indexOf(record);
            if (index == -1)
                return 0;
            return index;
        }

        var addRecord = function (ID, Gender, LastName, IsLock, Phone, UserName, FirstName, CreatedOn, DisplayName, Address, Birthday, Email) {
            var rowindex = getSelectedIndexRow();
            GridPanel1.insertRecord(rowindex, {
                ID: ID,
                Gender: Gender,
                LastName: LastName,
                IsLock: IsLock,
                Phone: Phone,
                UserName: UserName,
                FirstName: FirstName,
                CreatedOn: CreatedOn,
                DisplayName: DisplayName,
                Address: Address,
                Birthday: Birthday,
                Email: Email
            });
            GridPanel1.getView().refresh();
            GridPanel1.getSelectionModel().selectRow(rowindex);
            Store1.commitChanges();
        }

        addUpdatedRecord = function (ID, Gender, LastName, IsLock, Phone, UserName, FirstName, CreatedOn, DisplayName, Address, Birthday, Email) {
            var rowindex = getSelectedIndexRow();
            //xóa bản ghi cũ 
            var s = GridPanel1.getSelectionModel().getSelections();
            for (var i = 0, r; r = s[i]; i++) {
                Store1.remove(r);
                Store1.commitChanges();
            }

            //Thêm bản ghi đã update
            GridPanel1.insertRecord(rowindex, {
                ID: ID,
                Gender: Gender,
                LastName: LastName,
                IsLock: IsLock,
                Phone: Phone,
                UserName: UserName,
                FirstName: FirstName,
                CreatedOn: CreatedOn,
                DisplayName: DisplayName,
                Address: Address,
                Birthday: Birthday,
                Email: Email
            });
            GridPanel1.getView().refresh();
            GridPanel1.getSelectionModel().selectRow(rowindex);
            Store1.commitChanges();
        }

        var resetForm = function () {
            txtFirstName.reset(); txtLastName.reset(); txtDisplayName.reset(); txtUserName.reset(); txtPassword.reset();
            txtEmail.reset(); txtPhone.reset(); txtAddress.reset(); dfBirthday.reset(); RadioGroup1.reset();
            Ext.net.DirectMethods.ResetWindowTitle(); txtConfirmPassword.reset(); cbx_bophan.reset();
            btnAddUser.show(); btnAddUserAndClose.show(); btnUpdateUser.hide(); hdfUserCommand.reset();
            txtPassword.enable(); txtConfirmPassword.enable(); hdfSelectedDepartmentID.reset();
        }

        var RenderDate = function (value, p, record) {
            try {
                if (value == null) return "";
                if (value.toString().indexOf('1900') != -1)
                    return "";
                value = value.replace(" ", "T");
                var temp = value.split("T");
                var date = temp[0].split("-");
                var dateStr = date[2] + "/" + date[1] + "/" + date[0];
                if (dateStr != "") {
                    return dateStr;
                }
            } catch (e) {

            }
        }
    </script>
    <style type="text/css">
        .x-layout-split
        {
            border: 1px solid #8DB2E3 !important;
            border-bottom: none !important;
            border-top: none !important;
        }
        #grpUserAcc
        {
            border-top: 1px solid #8DB2E3 !important;
            border-bottom: 1px solid #8DB2E3 !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <ext:Hidden runat="server" ID="hdfNodeID" />
        <ext:Hidden runat="server" ID="hdfMaDonViOfCurrentUser" />
        <ext:Hidden runat="server" ID="hdfRecordID" />
        <ext:Hidden runat="server" ID="hdfListUserID" />
        <input type="hidden" id="hdfCheckLoaded" />
        <ext:Window Modal="true" Icon="UserAdd" Hidden="true" Padding="6" Layout="FormLayout"
            Width="450" LabelWidth="120" AutoHeight="true" Resizable="false" Title="Thêm mới người dùng"
            runat="server" Constrain="true" ID="wdAddUser">
            <Items>
                <ext:Hidden runat="server" ID="hdfUserCommand" />
                <ext:FieldSet runat="server" AnchorHorizontal="100%" Title="Thông tin tài khoản"
                    AutoHeight="true" ID="fsThongTInTaiKhoan">
                    <Items>
                        <ext:TextField runat="server" AllowBlank="false" EmptyText="Ví dụ: Nguyễn Văn" ID="txtFirstName"
                            FieldLabel="Họ đệm<span style='color:red;'>*</span>" CtCls="requiredData" AnchorHorizontal="100%"
                            MaxLength="50">
                        </ext:TextField>
                        <ext:TextField runat="server" AllowBlank="false" ID="txtLastName" EmptyText="Ví dụ: Tiến"
                            FieldLabel="Tên<span style='color:red;'>*</span>" CtCls="requiredData" AnchorHorizontal="100%"
                            MaxLength="50">
                            <Listeners>
                                <Blur Handler="txtDisplayName.setValue(txtFirstName.getValue()+' '+txtLastName.getValue());" />
                            </Listeners>
                        </ext:TextField>
                        <ext:TextField runat="server" AllowBlank="false" ID="txtDisplayName" FieldLabel="Tên hiển thị<span style='color:red;'>*</span>"
                            CtCls="requiredData" AnchorHorizontal="100%" MaxLength="50">
                        </ext:TextField>
                        <ext:TextField runat="server" ID="txtUserName" AllowBlank="false" FieldLabel="Tài khoản<span style='color:red;'>*</span>"
                            CtCls="requiredData" AnchorHorizontal="100%" MaxLength="50" />
                        <ext:TextField runat="server" InputType="Password" ID="txtPassword" AllowBlank="false"
                            FieldLabel="Mật khẩu<span style='color:red;'>*</span>" CtCls="requiredData" AnchorHorizontal="100%"
                            MaxLength="500" />
                        <ext:TextField runat="server" InputType="Password" ID="txtConfirmPassword" AllowBlank="false"
                            FieldLabel="Nhập lại mật khẩu<span style='color:red;'>*</span>" CtCls="requiredData"
                            AnchorHorizontal="100%" MaxLength="500" />
                    </Items>
                </ext:FieldSet>
                <ext:FieldSet runat="server" AnchorHorizontal="100%" Title="Thông tin cá nhân" ID="fsThongTinCaNhan">
                    <Items>
                        <ext:Hidden runat="server" ID="hdfSelectedDepartmentID" />
                        <ext:ComboBox runat="server" ID="cbx_bophan" FieldLabel="Bộ phận<span style='color:red;'>*</span>"
                            CtCls="requiredData" DisplayField="TEN" ValueField="MA" LoadingText="Đang tải dữ liệu..."
                            ItemSelector="div.list-item" AnchorHorizontal="100%" TabIndex="33" Editable="false"
                            AllowBlank="false">
                            <Triggers>
                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                            </Triggers>
                            <Template ID="Template37" runat="server">
                                <Html>
                                    <tpl for=".">
						                                              <div class="list-item"> 
							                                             {TEN}
						                                              </div>
					                                               </tpl>
                                </Html>
                            </Template>
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
                                <Expand Handler="if(cbx_bophan.store.getCount()==0) cbx_bophan_Store.reload();" />
                                <Select Handler="this.triggers[0].show();hdfSelectedDepartmentID.setValue(cbx_bophan.getValue());" />
                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); hdfSelectedDepartmentID.reset();}" />
                            </Listeners>
                        </ext:ComboBox>
                        <ext:FormPanel ID="FormPanel1" runat="server" ButtonAlign="Right" Layout="FormLayout"
                            Border="false">
                            <Items>
                                <ext:TextField runat="server" ID="txtEmail" AllowBlank="true" FieldLabel="Email"
                                    AnchorHorizontal="100%" Regex="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$">
                                    <Listeners>
                                        <Blur Handler="if (!#{FormPanel1}.getForm().isValid()) {
	                                                        Ext.Msg.show({icon: Ext.MessageBox.ERROR, title: 'Thông báo', msg: 'Email không hợp lệ', buttons:Ext.Msg.OK});
                                                            return false;
                                                        }" />
                                    </Listeners>
                                </ext:TextField>
                            </Items>
                        </ext:FormPanel>
                        <ext:TextField runat="server" ID="txtAddress" FieldLabel="Địa chỉ" AnchorHorizontal="100%"
                            MaxLength="500" />
                        <ext:Container runat="server" Height="27" AnchorHorizontal="100%" Layout="ColumnLayout">
                            <Items>
                                <ext:Container runat="server" Height="27" Layout="FormLayout" ColumnWidth="0.5">
                                    <Items>
                                        <ext:TextField runat="server" MaskRe="/[0-9\.]/" ID="txtPhone" FieldLabel="Điện thoại"
                                            AnchorHorizontal="98%" MaxLength="50" />
                                    </Items>
                                </ext:Container>
                                <ext:DateField runat="server" ColumnWidth="0.5" ID="dfBirthday" FieldLabel="Ngày sinh"
                                    AllowBlank="false" AnchorHorizontal="100%" Editable="false" />
                            </Items>
                        </ext:Container>
                        <ext:RadioGroup ID="RadioGroup1" runat="server" FieldLabel="Giới tính">
                            <Items>
                                <ext:Radio BoxLabel="Nam" runat="server" Checked="true" ID="rdNam">
                                </ext:Radio>
                                <ext:Radio BoxLabel="Nữ" runat="server" ID="rdNu">
                                </ext:Radio>
                            </Items>
                        </ext:RadioGroup>
                    </Items>
                </ext:FieldSet>
                <ext:Checkbox runat="server" ID="chkSendMail" BoxLabel="Gửi mail thông báo tới người dùng" />
            </Items>
            <Buttons>
                <ext:Button runat="server" Text="Cập nhật" Icon="Disk" ID="btnAddUser">
                    <Listeners>
                        <Click Handler="return checkNullValue();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnAddUser_Click">
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="False">
                                </ext:Parameter>
                            </ExtraParams>
                            <EventMask ShowMask="true" Msg="Đợi trong giây lát" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" Text="Cập nhật & Đóng lại" Icon="Disk" ID="btnAddUserAndClose">
                    <Listeners>
                        <Click Handler="return checkNullValue();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnAddUser_Click">
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="True">
                                </ext:Parameter>
                            </ExtraParams>
                            <EventMask ShowMask="true" Msg="Đợi trong giây lát" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" Text="Cập nhật" Hidden="true" Icon="Disk" ID="btnUpdateUser">
                    <Listeners>
                        <Click Handler="return checkNullValue();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnAddUser_Click">
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="True">
                                </ext:Parameter>
                                <ext:Parameter Name="Command" Value="Update">
                                </ext:Parameter>
                            </ExtraParams>
                            <EventMask ShowMask="true" Msg="Đợi trong giây lát" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" Text="Đóng lại" Icon="Decline" ID="btnClose2">
                    <Listeners>
                        <Click Handler="wdAddUser.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <BeforeShow Handler="if(hdfUserCommand.getValue()=='Update'){
                                           btnAddUser.hide();btnAddUserAndClose.hide();btnUpdateUser.show();
                                           txtPassword.disable();txtConfirmPassword.disable();
                                     }" />
                <Hide Handler="resetForm();" />
            </Listeners>
        </ext:Window>
        <ext:Window ID="wdChangePassword" Padding="6" Border="false" runat="server" Width="400"
            AutoHeight="true" Resizable="false" Modal="true" Layout="FormLayout" Icon="Lock"
            Title="Đổi mật khẩu" Hidden="true" LabelWidth="130">
            <Items>
                <ext:TextField ID="txtNewPassword" AllowBlank="false" runat="server" FieldLabel="Mật khẩu mới"
                    InputType="Password" AnchorHorizontal="95%">
                </ext:TextField>
                <ext:TextField ID="TextField1" AllowBlank="false" runat="server" Vtype="password"
                    FieldLabel="Nhập lại mật khẩu" InputType="Password" MsgTarget="Side" AnchorHorizontal="95%">
                    <CustomConfig>
                        <ext:ConfigItem Name="initialPassField" Value="#{txtNewPassword}" Mode="Value" />
                    </CustomConfig>
                </ext:TextField>
            </Items>
            <Listeners>
                <Hide Handler="txtNewPassword.reset();TextField1.reset();" />
            </Listeners>
            <Buttons>
                <ext:Button runat="server" Icon="Disk" Text="Cập nhật" ID="btnUpdatePassword">
                    <Listeners>
                        <Click Handler="return checkChangePassword();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnUpdatePassword_Click" />
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" Icon="Decline" Text="Hủy" ID="btnClose">
                    <Listeners>
                        <Click Handler="wdChangePassword.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Window runat="server" Hidden="true" AutoHeight="true" Layout="FormLayout" Width="300"
            Padding="0" Resizable="false" Icon="Key" Modal="true" ID="wdAssignRole" Title="Gán quyền cho người dùng">
            <Items>
                <ext:Hidden runat="server" ID="hdfRoleID" />
                <ext:Hidden runat="server" ID="hdfAllNodeID" />
                <ext:Hidden runat="server" ID="hdfSelectedNodeID" />
                <ext:TreePanel ID="treeRole" runat="server" Width="300" Height="250" Border="false"
                    RootVisible="false" AutoScroll="true">
                    <Root>
                    </Root>
                </ext:TreePanel>
            </Items>
            <Buttons>
                <ext:Button runat="server" Text="Đồng ý" ID="btnAddRole" Icon="Accept">
                    <Listeners>
                        <Click Handler="GetSelectedNodeID(#{treeRole});" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnAddRole_Click">
                            <EventMask ShowMask="true" Msg="Đợi trong giây lát..." />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdAssignRole}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <BeforeShow Handler="try{ResetNodeChecked(#{treeRole});}catch(e){} try{SetNodeChecked(#{treeRole});}catch(e){}" />
            </Listeners>
        </ext:Window>
        <ext:Window Modal="true" Resizable="false" Hidden="true" runat="server" ID="wdTaoTaiKhoanNhanVien"
            Constrain="true" Title="Tài khoản của nhân viên" Layout="FormLayout" Icon="User"
            Width="500" Padding="0" AutoHeight="true">
            <Items>
                <ext:TabPanel runat="server" Border="false" AnchorHorizontal="100%">
                    <Items>
                        <ext:Panel runat="server" Title="Thông tin tài khoản" AutoHeight="true" Border="false"
                            AnchorHorizontal="100%" Layout="FormLayout">
                            <Items>
                                <ext:Container runat="server" ID="ctn3" Layout="FormLayout" AnchorHorizontal="100%"
                                    LabelWidth="6">
                                    <Items>
                                        <ext:DisplayField runat="server" ID="dpf7" Text="Chọn định dạng tài khoản đăng nhập của cán bộ:" />
                                        <ext:RadioGroup ID="rdLoaiTenDN" runat="server" LabelAlign="Top" ColumnsNumber="2"
                                            GroupName="aa" ItemCls="x-check-group-alt">
                                            <Items>
                                                <ext:Radio ID="rdSuDungTenTuSinh" runat="server" BoxLabel="Sử dụng tài khoản đăng nhập tự sinh"
                                                    Checked="true">
                                                    <Listeners>
                                                        <Check Handler="#{StoreAcc}.reload();" />
                                                    </Listeners>
                                                </ext:Radio>
                                                <ext:Radio ID="rdSuDungEmail" runat="server" BoxLabel="Sử dụng địa chỉ email">
                                                    <Listeners>
                                                        <Check Handler="#{StoreAcc}.reload();" />
                                                    </Listeners>
                                                </ext:Radio>
                                            </Items>
                                        </ext:RadioGroup>
                                    </Items>
                                </ext:Container>
                                <ext:Container runat="server" ID="Container1" Layout="FormLayout" AnchorHorizontal="100%"
                                    LabelWidth="6">
                                    <Items>
                                        <ext:Checkbox ID="Checkbox1" runat="server" BoxLabel="Gửi mail thông báo tới người dùng"
                                            Checked="true">
                                            <Listeners>
                                                <%--<Check Handler="if(Checkbox1.checked==true)
                                                    {
                                                        txtGmail.enable();
                                                        txtPasswordGmail.enable();
                                                    }
                                                    else
                                                    {
                                                        txtGmail.disable();
                                                        txtPasswordGmail.disable();
                                                    }" />--%>
                                            </Listeners>
                                        </ext:Checkbox>
                                    </Items>
                                </ext:Container>
                                <ext:GridPanel runat="server" ID="grpUserAcc" ClicksToEdit="1" Border="false" AutoExpandColumn="FullName"
                                    AutoExpandMin="80" AutoScroll="true" AnchorHorizontal="100%" Height="280" Title="Danh sách cán bộ được tạo tài khoản đăng nhập">
                                    <TopBar>
                                        <ext:Toolbar runat="server" ID="tb5">
                                            <Items>
                                                <ext:Button runat="server" ID="btnChonNhanVien" Text="Chọn cán bộ" Icon="UserAdd">
                                                    <Listeners>
                                                        <Click Handler="ucChooseEmployee1_wdChooseUser.show();" />
                                                    </Listeners>
                                                </ext:Button>
                                            </Items>
                                        </ext:Toolbar>
                                    </TopBar>
                                    <SelectionModel>
                                        <ext:RowSelectionModel runat="server" ID="CheckboxSelectionModel1" />
                                    </SelectionModel>
                                    <Store>
                                        <ext:Store ID="StoreAcc" runat="server" AutoSave="true" AutoLoad="true" OnRefreshData="StoreAcc_OnRefreshData">
                                            <Reader>
                                                <ext:JsonReader IDProperty="UserID">
                                                    <Fields>
                                                        <ext:RecordField Name="UserID" />
                                                        <ext:RecordField Name="FullName" />
                                                        <ext:RecordField Name="UserName" />
                                                        <ext:RecordField Name="Password" />
                                                        <ext:RecordField Name="Email" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                    <ColumnModel ID="ColumnModel3" runat="server">
                                        <Columns>
                                            <ext:RowNumbererColumn Width="30" Header="STT" />
                                            <ext:Column Header="Họ tên" ColumnID="FullName" DataIndex="FullName">
                                            </ext:Column>
                                            <ext:Column Header="Tài khoản" ColumnID="TaiKhoan" DataIndex="UserName">
                                            </ext:Column>
                                            <ext:Column Header="Mật khẩu" ColumnID="MatKhau" DataIndex="Password">
                                                <Editor>
                                                    <ext:TextField runat="server" ID="txtEmployeePassword" />
                                                </Editor>
                                            </ext:Column>
                                            <ext:Column Header="Địa chỉ mail" ColumnID="Email" DataIndex="Email">
                                            </ext:Column>
                                        </Columns>
                                    </ColumnModel>
                                </ext:GridPanel>
                                <ext:Hidden runat="server" ID="hdfIdList" />
                                <ext:Hidden runat="server" ID="hdfJsonData" />
                            </Items>
                        </ext:Panel>
                        <ext:Panel runat="server" Border="false" Height="320" AnchorHorizontal="100%" Title="Thiết lập quyền">
                            <Items>
                                <ext:GridPanel ID="grp_roleList" Border="false" runat="server" StripeRows="true"
                                    Title="Danh sách quyền" AnchorHorizontal="100%" Height="290" AutoExpandColumn="RoleName">
                                    <Store>
                                        <ext:Store ID="grp_roleListStore" AutoLoad="false" runat="server" OnRefreshData="grp_roleListStore_OnRefreshData">
                                            <Reader>
                                                <ext:JsonReader IDProperty="ID">
                                                    <Fields>
                                                        <ext:RecordField Name="RoleName" />
                                                        <ext:RecordField Name="ID" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                    <ColumnModel ID="ColumnModel2" runat="server">
                                        <Columns>
                                            <ext:RowNumbererColumn Header="STT" Width="30" />
                                            <ext:Column ColumnID="RoleName" Header="Tên quyền" Width="160" DataIndex="RoleName" />
                                        </Columns>
                                    </ColumnModel>
                                    <SelectionModel>
                                        <ext:CheckboxSelectionModel ID="CheckboxSelectionModelRoleList" runat="server" />
                                    </SelectionModel>
                                    <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                                </ext:GridPanel>
                            </Items>
                            <Listeners>
                                <Activate Handler="if(document.getElementById('hdfCheckLoaded').value ==''){#{grp_roleListStore}.reload();document.getElementById('hdfCheckLoaded').value = 'True';}" />
                            </Listeners>
                        </ext:Panel>
                    </Items>
                </ext:TabPanel>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnTaoTaiKhoan" Text="Tạo tài khoản" Icon="Accept">
                    <%--<Listeners>
                        <Click Handler="grpUserAcc.submitData(false);" />
                    </Listeners>--%>
                    <DirectEvents>
                        <Click OnEvent="btnTaoTaiKhoan_Click">
                            <EventMask ShowMask="true" Msg="Đang tạo tài khoản. Vui lòng chờ..." />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="Button5" runat="server" Text="Hủy và đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdTaoTaiKhoanNhanVien}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="#{StoreAcc}.removeAll();" />
            </Listeners>
        </ext:Window>
        <ext:Menu ID="RowContextMenu" runat="server">
            <Items>
                <ext:MenuItem ID="MenuItem2" runat="server" Icon="Key" Text="Gán quyền">
                    <DirectEvents>
                        <Click OnEvent="btnShowWindowRole_Click">
                            <EventMask ShowMask="true" Msg="Chờ trong giây lát" />
                        </Click>
                    </DirectEvents>
                </ext:MenuItem>
                <ext:MenuItem ID="mnuAddNew" runat="server" Icon="Add" Text="Thêm mới">
                    <Listeners>
                        <Click Handler="wdAddUser.show();" />
                    </Listeners>
                </ext:MenuItem>
                <ext:MenuItem ID="MenuItem4" runat="server" Icon="Delete" Text="Xóa">
                    <Listeners>
                        <Click Handler="RemoveItemOnGrid(GridPanel1,Store1)" />
                    </Listeners>
                </ext:MenuItem>
                <ext:MenuItem ID="mnuEditUser" runat="server" Icon="Pencil" Text="Sửa">
                    <DirectEvents>
                        <Click OnEvent="btnEditUser_Click">
                            <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                        </Click>
                    </DirectEvents>
                </ext:MenuItem>
                <ext:MenuSeparator runat="server" />
                <ext:MenuItem runat="server" ID="mnuQuanLy" Text="Quản lý" Icon="ApplicationCascade">
                    <Menu>
                        <ext:Menu ID="Menu2" runat="server">
                            <Items>
                                <ext:MenuItem runat="server" Icon="Reload" ID="MenuItem3" Text="Reset mật khẩu">
                                    <DirectEvents>
                                        <Click OnEvent="mnuResetPassword_Click">
                                            <EventMask ShowMask="true" Msg="Chờ trong giây lát" />
                                            <Confirmation ConfirmRequest="true" Title="Cảnh báo" Message="Đây là chức năng để thay đổi mật khẩu tự động. Được áp dụng đối với những trường hợp người dùng quên mật khẩu. Mật khẩu mới sẽ được gửi tự động vào Email của người dùng !" />
                                        </Click>
                                    </DirectEvents>
                                    <ToolTips>
                                        <ext:ToolTip ID="ToolTip2" runat="server" Title="Đổi mật khẩu tự động" Html="Chọn một hoặc nhiều người dùng để đổi mật khẩu! Giữ Ctrl để chọn từng người dùng và giữ shift để chọn một khoảng người dùng">
                                        </ext:ToolTip>
                                    </ToolTips>
                                </ext:MenuItem>
                                <ext:MenuItem ID="MenuItem5" Icon="Key" runat="server" Text="Đổi mật khẩu">
                                    <Listeners>
                                        <Click Handler="if(#{hdfRecordID}.getValue()==''){
                                                                                    Ext.Msg.alert('Cảnh báo','Bạn chưa chọn tài khoản nào');
                                                                                }else
                                                                                {
                                                                                    wdChangePassword.show();
                                                                                }" />
                                    </Listeners>
                                </ext:MenuItem>
                                <ext:MenuItem ID="MenuItem6" runat="server" Icon="Lock" Text="Khóa tài khoản">
                                    <DirectEvents>
                                        <Click OnEvent="mnuLockUser_Click">
                                            <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                        </Click>
                                    </DirectEvents>
                                    <ToolTips>
                                        <ext:ToolTip ID="ToolTip3" runat="server" Title="Hướng dẫn" Html="Bạn có thể chọn một hoặc nhiều tài khoản để tiến hành khóa tài khoản">
                                        </ext:ToolTip>
                                    </ToolTips>
                                </ext:MenuItem>
                                <ext:MenuItem ID="MenuItem7" runat="server" Icon="Lock" Text="Mở tài khoản">
                                    <DirectEvents>
                                        <Click OnEvent="mnuUnlockUser_Click">
                                            <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                        </Click>
                                    </DirectEvents>
                                </ext:MenuItem>
                                <ext:MenuItem ID="MenuItem8" runat="server" Icon="UserAdd" Text="Tạo tài khoản cho nhân viên">
                                    <Listeners>
                                        <Click Handler="ucChooseEmployee1_wdChooseUser.show();" />
                                    </Listeners>
                                </ext:MenuItem>
                            </Items>
                        </ext:Menu>
                    </Menu>
                </ext:MenuItem>
            </Items>
        </ext:Menu>
        <ext:Viewport runat="server" ID="vp">
            <Items>
                <ext:BorderLayout runat="server" ID="brLayout">
                    <Center>
                        <ext:GridPanel ID="GridPanel1" Border="false" runat="server" StripeRows="true" AnchorHorizontal="100%">
                            <TopBar>
                                <ext:Toolbar runat="server" ID="tbgridpanel">
                                    <Items>
                                        <ext:Button runat="server" ID="btnShowWindowRole" Disabled="true" Text="Gán quyền"
                                            Icon="Key">
                                            <DirectEvents>
                                                <Click OnEvent="btnShowWindowRole_Click">
                                                    <EventMask ShowMask="true" Msg="Chờ trong giây lát" />
                                                </Click>
                                            </DirectEvents>
                                            <ToolTips>
                                                <ext:ToolTip ID="ToolTip1Role" runat="server" Title="Hướng dẫn" Html="Chọn một hoặc nhiều người dùng để gán quyền ! Giữ Ctrl để chọn từng người dùng và giữ shift để chọn một khoảng người dùng">
                                                </ext:ToolTip>
                                            </ToolTips>
                                        </ext:Button>
                                        <ext:Button runat="server" ID="btnThemMoi" EnableViewState="false" Text="Thêm mới"
                                            Icon="Add">
                                            <Listeners>
                                                <Click Handler="wdAddUser.show();" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:Button ID="btnEditUser" runat="server" Disabled="true" Text="Sửa" Icon="Pencil">
                                            <DirectEvents>
                                                <Click OnEvent="btnEditUser_Click">
                                                    <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:Button runat="server" ID="btnDeleteUser" Text="Xóa" Disabled="true" Icon="Delete">
                                            <Listeners>
                                                <Click Handler="RemoveItemOnGrid(GridPanel1,Store1)" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:Button runat="server" ID="mnuTienIch" Text="Quản lý" Icon="ApplicationCascade">
                                            <Menu>
                                                <ext:Menu ID="Menu1" runat="server">
                                                    <Items>
                                                        <ext:MenuItem runat="server" Disabled="true" Icon="Reload" ID="mnuResetPassword"
                                                            Text="Reset mật khẩu">
                                                            <Listeners>
                                                                <Click Handler="if(#{hdfRecordID}.getValue()==''){
                                                                                    Ext.Msg.alert('Cảnh báo','Bạn chưa chọn tài khoản nào');
                                                                                    return false;
                                                                                }" />
                                                            </Listeners>
                                                            <DirectEvents>
                                                                <Click OnEvent="mnuResetPassword_Click" Before="GetListUserID(#{GridPanel1}, #{Store1})">
                                                                    <EventMask ShowMask="true" Msg="Chờ trong giây lát" />
                                                                    <Confirmation ConfirmRequest="true" Title="Cảnh báo" Message="Đây là chức năng để thay đổi mật khẩu tự động. Được áp dụng đối với những trường hợp người dùng quên mật khẩu. Mật khẩu mới sẽ được gửi tự động vào Email của người dùng !" />
                                                                </Click>
                                                            </DirectEvents>
                                                            <ToolTips>
                                                                <ext:ToolTip ID="ToolTipResetPass" runat="server" Title="Đổi mật khẩu tự động" Html="Chọn một hoặc nhiều người dùng để đổi mật khẩu! Giữ Ctrl để chọn từng người dùng và giữ shift để chọn một khoảng người dùng">
                                                                </ext:ToolTip>
                                                            </ToolTips>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem ID="mnuShowChangePasswordWindow" Disabled="true" Icon="Key" runat="server"
                                                            Text="Đổi mật khẩu">
                                                            <Listeners>
                                                                <Click Handler="if(#{hdfRecordID}.getValue()==''){
                                                                                    Ext.Msg.alert('Cảnh báo','Bạn chưa chọn tài khoản nào');
                                                                                }else
                                                                                {
                                                                                    wdChangePassword.show();
                                                                                }" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem ID="mnuLockUser" runat="server" Disabled="true" Icon="Lock" Text="Khóa tài khoản">
                                                            <Listeners>
                                                                <Click Handler="if(#{hdfRecordID}.getValue()==''){
                                                                                    Ext.Msg.alert('Cảnh báo','Bạn chưa chọn tài khoản nào');
                                                                                    return false;
                                                                                }" />
                                                            </Listeners>
                                                            <DirectEvents>
                                                                <Click OnEvent="mnuLockUser_Click">
                                                                    <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                                </Click>
                                                            </DirectEvents>
                                                            <ToolTips>
                                                                <ext:ToolTip ID="ToolTip1" runat="server" Title="Hướng dẫn" Html="Bạn có thể chọn một hoặc nhiều tài khoản để tiến hành khóa tài khoản">
                                                                </ext:ToolTip>
                                                            </ToolTips>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem ID="mnuUnlockUser" Disabled="true" runat="server" Icon="Lock" Text="Mở tài khoản">
                                                            <Listeners>
                                                                <Click Handler="if(#{hdfRecordID}.getValue()==''){
                                                                                    Ext.Msg.alert('Cảnh báo','Bạn chưa chọn tài khoản nào');
                                                                                    return false;
                                                                                }" />
                                                            </Listeners>
                                                            <DirectEvents>
                                                                <Click OnEvent="mnuUnlockUser_Click">
                                                                    <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                                </Click>
                                                            </DirectEvents>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem ID="MenuItem1" runat="server" Icon="UserAdd" Text="Tạo tài khoản cho nhân viên">
                                                            <Listeners>
                                                                <Click Handler="#{wdTaoTaiKhoanNhanVien}.show();" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                    </Items>
                                                </ext:Menu>
                                            </Menu>
                                        </ext:Button>
                                        <ext:ToolbarSeparator runat="server" />
                                        <ext:Button runat="server" ID="btnHelp" Text="Trợ giúp" Icon="Help">
                                        </ext:Button>
                                        <ext:ToolbarFill runat="server" />
                                        <ext:TextField runat="server" ID="txtSearchKey" EnableKeyEvents="true" Width="220"
                                            EmptyText="Nhập tên tài khoản hoặc tên hiển thị...">
                                            <Listeners>
                                                <KeyPress Fn="enterKeyPressHandler" />
                                            </Listeners>
                                        </ext:TextField>
                                        <ext:Button runat="server" Text="Tìm kiếm" Icon="Zoom" ID="btnSearch">
                                            <Listeners>
                                                <Click Handler="Store1.reload();" />
                                            </Listeners>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <Store>
                                <ext:Store ID="Store1" runat="server">
                                    <Proxy>
                                        <ext:HttpProxy Method="GET" Url="Handler.ashx" />
                                    </Proxy>
                                    <AutoLoadParams>
                                        <ext:Parameter Name="start" Value="={0}" />
                                        <ext:Parameter Name="limit" Value="={30}" />
                                    </AutoLoadParams>
                                    <BaseParams>
                                        <ext:Parameter Name="SearchKey" Value="#{txtSearchKey}.getValue()" Mode="Raw">
                                        </ext:Parameter>
                                        <ext:Parameter Name="MaDonVi" Value="#{hdfMaDonViOfCurrentUser}.getValue()" Mode="Raw">
                                        </ext:Parameter>
                                        <ext:Parameter Name="RoleID" Value="#{hdfNodeID}.getValue()" Mode="Raw">
                                        </ext:Parameter>
                                    </BaseParams>
                                    <Reader>
                                        <ext:JsonReader Root="Data" IDProperty="ID" TotalProperty="TotalRecords">
                                            <Fields>
                                                <ext:RecordField Name="ID" />
                                                <ext:RecordField Name="Gender" />
                                                <ext:RecordField Name="LastName" />
                                                <ext:RecordField Name="IsLock" />
                                                <ext:RecordField Name="Phone" />
                                                <ext:RecordField Name="UserName" />
                                                <ext:RecordField Name="FirstName" />
                                                <ext:RecordField Name="CreatedOn" />
                                                <ext:RecordField Name="DisplayName" />
                                                <ext:RecordField Name="Address" />
                                                <ext:RecordField Name="Birthday" />
                                                <ext:RecordField Name="Email" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn Header="STT" Locked="true" Width="30" />
                                    <ext:Column ColumnID="DisplayName" Locked="true" Header="Mã tài khoản" Width="90"
                                        DataIndex="ID" />
                                    <ext:Column Header="Tài khoản" Locked="true" Width="160" DataIndex="UserName" />
                                    <ext:Column ColumnID="DisplayName" Locked="true" Header="Tên hiển thị" Width="160"
                                        DataIndex="DisplayName" />
                                    <ext:Column Header="Giới tính" Width="75" DataIndex="Gender">
                                        <Renderer Fn="GetGenderBoolean" />
                                    </ext:Column>
                                    <ext:Column Header="Điện thọai" Width="100" DataIndex="Phone" />
                                    <ext:Column Header="Email" Width="175" DataIndex="Email" />
                                    <ext:Column Header="Địa chỉ" Width="275" DataIndex="Address" />
                                    <ext:DateColumn Format="dd/MM/yyyy" Header="Ngày tạo" Width="75" DataIndex="CreatedOn" />
                                    <ext:Column Header="Ngày sinh" Width="75" DataIndex="Birthday">
                                        <Renderer Fn="RenderDate" />
                                    </ext:Column>
                                    <ext:Column Header="Bị tạm khóa" Width="75" Align="Center" DataIndex="IsLock">
                                        <Renderer Fn="GetBooleanIcon" />
                                    </ext:Column>
                                </Columns>
                            </ColumnModel>
                            <View>
                                <ext:LockingGridView runat="server" ID="lkv">
                                </ext:LockingGridView>
                            </View>
                            <Listeners>
                                <RowContextMenu Handler="e.preventDefault(); #{RowContextMenu}.dataRecord = this.store.getAt(rowIndex);#{RowContextMenu}.showAt(e.getXY());#{GridPanel1}.getSelectionModel().selectRow(rowIndex);" />
                            </Listeners>
                            <SelectionModel>
                                <ext:RowSelectionModel ID="RowSelectionModel1" runat="server">
                                    <Listeners>
                                        <RowSelect Handler="#{hdfRecordID}.setValue(#{RowSelectionModel1}.getSelected().id);
                                                            btnEditUser.enable();btnDeleteUser.enable();btnShowWindowRole.enable();
                                                            mnuResetPassword.enable();mnuShowChangePasswordWindow.enable();mnuLockUser.enable();
                                                            mnuUnlockUser.enable();
                                                            " />
                                    </Listeners>
                                </ext:RowSelectionModel>
                            </SelectionModel>
                            <LoadMask ShowMask="true" />
                            <DirectEvents>
                                <DblClick OnEvent="btnEditUser_Click">
                                    <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                </DblClick>
                            </DirectEvents>
                            <BottomBar>
                                <ext:PagingToolbar ID="PagingToolbar1" EmptyMsg="Hiện không có dữ liệu" NextText="Trang sau"
                                    PrevText="Trang trước" LastText="Trang cuối cùng" FirstText="Trang đầu tiên"
                                    DisplayMsg="Dòng {0} đến dòng {1} / {2} dòng" runat="server">
                                    <Items>
                                        <ext:Label ID="Label1" runat="server" Text="Số bản ghi trên 1 trang:" />
                                        <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                        <ext:ComboBox ID="ComboBoxPaging" SelectedIndex="4" runat="server" Width="80">
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
                    <West Split="true" Collapsible="true">
                        <ext:Panel runat="server" Width="220" CtCls="west-panel2" Title="Lọc theo quyền"
                            Collapsible="true" Collapsed="false" Border="false" Layout="BorderLayout">
                            <Items>
                                <ext:TreePanel ID="TreePanel1" runat="server" Region="Center" Header="false" Border="false"
                                    RootVisible="false" AutoScroll="true">
                                    <TopBar>
                                        <ext:Toolbar runat="server" ID="tbTree">
                                            <Items>
                                                <ext:Button ID="Button1" runat="server" Text="Mở rộng">
                                                    <Listeners>
                                                        <Click Handler="#{TreePanel1}.expandAll();" />
                                                    </Listeners>
                                                </ext:Button>
                                                <ext:Button ID="Button2" runat="server" Text="Thu nhỏ">
                                                    <Listeners>
                                                        <Click Handler="#{TreePanel1}.collapseAll();" />
                                                    </Listeners>
                                                </ext:Button>
                                            </Items>
                                        </ext:Toolbar>
                                    </TopBar>
                                    <Root>
                                    </Root>
                                </ext:TreePanel>
                            </Items>
                        </ext:Panel>
                    </West>
                </ext:BorderLayout>
            </Items>
        </ext:Viewport>
    </div>
    <uc2:ucChooseEmployee ID="ucChooseEmployee1" runat="server" />
    </form>
</body>
</html>
