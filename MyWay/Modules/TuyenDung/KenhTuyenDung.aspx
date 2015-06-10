<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KenhTuyenDung.aspx.cs" Inherits="Modules_TuyenDung_NguonTuyenDung" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../Resource/js/Extcommon.js" type="text/javascript"></script>
    <script type="text/javascript">
        var checkinput = function () {
            if (txtTenNguon.getValue().trim().length == 0) {
                alert('Bạn chưa chọn kênh tuyển dụng');
                txtTenNguon.setValue('');
                txtTenNguon.focus();
                return false;
            }
            if (txt_LinkNguon.getValue().trim().length == 0) {
                alert('Bạn chưa chọn link kênh tuyển dụng');
                txt_LinkNguon.setValue('');
                txt_LinkNguon.focus();
                return false;
            }
            return true;
        }
        var CheckSelectedRecordPrint = function (grid, Store) {
            if (hdfRecordID.getValue() == '') {
                alert('Bạn chưa chọn bản ghi nào');
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
        var resetForm = function () {
            txtTenNguon.reset();
            txt_LinkNguon.reset();
            txt_GhiChu.reset();
        }
        var SelectedNguonTuyenDung = function () {
            var records = Store1.getRange();
            for (var i = 0; i < records.length; i++) {
                if (records[i].data.ID == cbxChonNguonTuyenDung.getValue()) { 
                    addTab(TabPanel1, '' + records[i].data.ID, '' + records[i].data.LinkUrl, '' + records[i].data.Name);
                    break;
                }
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ext:Hidden runat="server" ID="hdfRecordID" />
            <ext:Hidden runat="server" ID="hdfLink" />
            <ext:Hidden runat="server" ID="hdfIDTab" />
            <ext:Hidden runat="server" ID="hdfName" />
            <ext:Hidden ID="hdfNguonTuyenDung" runat="server"></ext:Hidden>
            <ext:ResourceManager runat="server" ID="RM" />
            <ext:Store ID="Store1" runat="server" AutoLoad="false" ShowWarningOnFailure="false"
                AutoSave="true" OnRefreshData="cbxChonNguonTuyenDung_store_OnRefreshData">
                <Reader>
                    <ext:JsonReader IDProperty="ID">
                        <Fields>
                            <ext:RecordField Name="ID" />
                            <ext:RecordField Name="Name" />
                            <ext:RecordField Name="LinkUrl" />
                            <ext:RecordField Name="Description" />
                        </Fields>
                    </ext:JsonReader>
                </Reader>
            </ext:Store>
            <ext:Viewport runat="server" ID="vp">
                <Items>
                    <ext:BorderLayout runat="server" ID="brlayout">
                        <Center>
                            <ext:TabPanel Border="false" ID="TabPanel1" AnchorVertical="100%" runat="server"
                                Title="gsfgf">
                                <TopBar>
                                    <ext:Toolbar runat="server" ID="tb">
                                        <Items>
                                            <ext:ComboBox ID="cbxChonNguonTuyenDung" runat="server" Editable="false" LabelWidth="150" FieldLabel="Chọn nguồn tuyển dụng" DisplayField="Name"
                                                ValueField="ID" Width="350" StoreID="Store1">  
                                                <Listeners>
                                                    <Focus Handler="#{Store1}.reload();" />
                                                    <Select Handler="
                                                                    #{hdfNguonTuyenDung}.setValue(#{cbxChonNguonTuyenDung}.getValue());
                                                                    SelectedNguonTuyenDung();
                                                                    " />
                                                </Listeners>
                                            </ext:ComboBox>
                                            <ext:ToolbarSpacer Width="20" runat="server"></ext:ToolbarSpacer>
                                            <ext:Button runat="server" ID="btnQuanLyNguon" Text="Quản lý" Icon="ApplicationCascade">
                                                <Listeners>
                                                    <Click Handler="wdManagement.show();" />
                                                </Listeners>
                                            </ext:Button>
                                        </Items>
                                    </ext:Toolbar>
                                </TopBar>
                            </ext:TabPanel>
                        </Center>
                    </ext:BorderLayout>
                </Items>
            </ext:Viewport>
            <ext:Window ID="wdNguonTuyenDung" AutoHeight="true" Width="500" runat="server" Padding="6"
                Layout="FormLayout" Modal="true" Hidden="true" Constrain="true" Icon="Add" Title="Cập nhật nguồn tuyển dụng">
                <Listeners>
                    <Hide Handler="resetForm();" />
                </Listeners>
                <Items>
                    <ext:Container ID="Container18" runat="server" Layout="Column" Height="120">
                        <Items>
                            <ext:Container ID="Container19" runat="server" LabelWidth="80" LabelAlign="left"
                                Layout="Form" ColumnWidth=".5">
                                <Items>
                                    <ext:TextField ID="txtTenNguon" MaxLength="500" runat="server" FieldLabel="Tên nguồn<span style='color:red;'>*</span>"
                                        CtCls="requiredData" AllowBlank="false" AnchorHorizontal="100%" TabIndex="1">
                                    </ext:TextField>
                                    <ext:TextField ID="txt_LinkNguon" MaxLength="500" runat="server" FieldLabel="Link nguồn<span style='color:red;'>*</span>"
                                        CtCls="requiredData" AnchorHorizontal="100%" TabIndex="2" />
                                    <ext:TextArea ID="txt_GhiChu" runat="server" FieldLabel="Ghi chú" AnchorHorizontal="100%"
                                        TabIndex="5" />
                                </Items>
                            </ext:Container>
                        </Items>
                    </ext:Container>
                </Items>
                <Buttons>
                    <ext:Button runat="server" Text="Cập nhật" ID="btnUpdate" Hidden="true" Icon="Disk">
                        <Listeners>
                            <Click Handler="return checkinput();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnUpdate_Click">
                                <ExtraParams>
                                    <ext:Parameter Name="Command" Value="Update" />
                                </ExtraParams>
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button runat="server" Text="Cập nhật" ID="btnAdd" Icon="Disk">
                        <Listeners>
                            <Click Handler="return checkinput();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnUpdate_Click">
                                <ExtraParams>
                                    <ext:Parameter Name="Command" Value="Add" />
                                </ExtraParams>
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button runat="server" Text="Cập nhật & Đóng lại" ID="btnAddAndClose" Icon="Disk">
                        <Listeners>
                            <Click Handler="return checkinput();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnUpdate_Click">
                                <ExtraParams>
                                    <ext:Parameter Name="Close" Value="True" />
                                </ExtraParams>
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button runat="server" Text="Đóng lại" ID="Button1" Icon="Decline">
                        <Listeners>
                            <Click Handler="wdNguonTuyenDung.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:Window>
            <ext:Window ID="wdManagement" AutoHeight="true" Width="600" runat="server" Layout="FormLayout"
                Modal="true" Hidden="true" Constrain="true" Icon="ApplicationCascade" Title="Quản lý nguồn tuyển dụng">
                <Items>
                    <ext:GridPanel ID="gpTuyenDung" Border="false" runat="server" StripeRows="true" AnchorHorizontal="100%"
                        Height="300" AutoExpandColumn="clDescription" StoreID="Store1"> 
                        <TopBar>
                            <ext:Toolbar runat="server" ID="btNguon">
                                <Items>
                                    <ext:Button runat="server" ID="btnAddRecord" Text="Thêm mới" Icon="Add">
                                        <Listeners>
                                            <Click Handler="#{wdNguonTuyenDung}.show();" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:Button ID="btnEdit" runat="server" Text="Sửa" Icon="Pencil" Disabled="true">
                                        <DirectEvents>
                                            <Click OnEvent="Click_Event" Before="return CheckSelectedRecordPrint(gpTuyenDung,Store1);">
                                                <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                            </Click>
                                        </DirectEvents>
                                    </ext:Button>
                                    <ext:Button runat="server" ID="btnDeleteNguon" Text="Xóa" Icon="Delete" Disabled="true">
                                        <DirectEvents>
                                            <Click OnEvent="btnDeleteNguon_Click">
                                                <Confirmation ConfirmRequest="true" Message="Bạn có chắc chắn muốn xóa !" Title="Cảnh báo" />
                                                <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                            </Click>
                                        </DirectEvents>
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                        <ColumnModel ID="ColumnModel1" runat="server">
                            <Columns>
                                <ext:RowNumbererColumn Header="STT" Locked="true" Width="35" />
                                <ext:Column ColumnID="TEN_NGUON" Header="Tên nguồn tuyển dụng" DataIndex="Name" Width="130">
                                </ext:Column>
                                <ext:Column ColumnID="LINK_NGUON" Header="Đường link" DataIndex="LinkUrl" Width="200">
                                </ext:Column>
                                <ext:Column ColumnID="clDescription" Header="Ghi chú" DataIndex="Description">
                                </ext:Column>
                            </Columns>
                        </ColumnModel>
                        <SelectionModel>
                            <ext:RowSelectionModel runat="server" ID="rsm">
                                <Listeners>
                                    <RowSelect Handler="try{#{btnEdit}.enable();#{btnDeleteNguon}.enable();}catch(e){};hdfRecordID.setValue(rsm.getSelected().data.ID);" />
                                </Listeners>
                            </ext:RowSelectionModel>
                        </SelectionModel>
                        <LoadMask ShowMask="true" />
                    </ext:GridPanel>
                </Items>
                <Listeners>
                    <BeforeShow Handler="#{Store1}.reload();" />
                    <Expand Handler="if(Store1.getCount()==0){Store1.reload();}" />
                </Listeners>
            </ext:Window>

        </div>
    </form>
</body>
</html>
