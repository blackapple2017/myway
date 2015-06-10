<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BangCheDoBaoHiem.ascx.cs"
    Inherits="Modules_BaoHiem_QuyDinhChung_BangCheDoBaoHiem" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<style type="text/css">
    .x-layout-collapsed-west
    {
        background: url(../../../Resource/images/NhomCheDoBaoHiem.png) no-repeat center !important;
    }
    div#BangCheDoBaoHiem1_Panel1-xsplit
    {
        border-left: 1px solid #98C0F4 !important;
        border-right: 1px solid #98C0F4 !important;
    }
</style>
<script type="text/javascript">
    var enterKeyPressHandler1 = function (f, e) {
        if (e.getKey() == e.ENTER) {
            BangCheDoBaoHiem1_PagingToolbar1.pageIndex = 0;
            BangCheDoBaoHiem1_PagingToolbar1.doLoad();
        }
        if (this.getValue() != '') {
            this.triggers[0].show();
        }
    }
    var CheckSelectedRecord = function (grid, Store) {

        var s = grid.getSelectionModel().getSelections();
        var count = 0;
        for (var i = 0, r; r = s[i]; i++) {
            count++;
        }
        if (count > 1) {
            alert('Bạn chỉ được chọn một dòng');
            return false;
        }
        return true;
    }
    var RemoveItemOnGrid2 = function (grid, Store, DirectMethods) {
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
                    DirectMethods.DeleteRecord(r.data.IDCheDoBaoHiem);
                    BangCheDoBaoHiem1_btnEdit.disable();
                    BangCheDoBaoHiem1_btnDelete.disable();
                }
            }
        });
    }
    var RemoveItemOnGrid_nhomcha = function (grid, Store, DirectMethods) {
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
                    DirectMethods.DeleteRecord(r.data.IDCheDoBaoHiem);

                    BangCheDoBaoHiem1_btnSuaNhomCDBH.disable();
                    BangCheDoBaoHiem1_btnXoaNhomCDBH.disable();
                }
            }
        });
    }
    var getSelectedIndexRow = function () {
        var record = GridPanel1.getSelectionModel().getSelected();
        var index = GridPanel1.store.indexOf(record);
        if (index == -1)
            return 0;
        return index;
    }

    var CheckInput2 = function () {
        if (BangCheDoBaoHiem1_txtcha_machedobh.getValue() == '') {
            alert("Bạn chưa nhập mã chế độ bảo hiểm");
            BangCheDoBaoHiem1_txtcha_machedobh.focus();
            return false;
        }
        if (BangCheDoBaoHiem1_txtcha_tenchedobh.getValue() == '') {
            alert("Bạn chưa nhập tên chế độ bảo hiểm");
            BangCheDoBaoHiem1_txtcha_tenchedobh.focus();
            return false;
        }

        return true;
    }

    var CheckInput1 = function () {
        if (BangCheDoBaoHiem1_cboCheDoBH.getValue() == '') {
            alert("Bạn chưa chọn nhóm chế độ bảo hiểm");
            BangCheDoBaoHiem1_cboCheDoBH.focus();
            return false;
        }
        if (BangCheDoBaoHiem1_txtMaCheDoBaohiem.getValue() == '') {
            alert("Bạn chưa nhập mã chế độ bảo hiểm");
            BangCheDoBaoHiem1_txtMaCheDoBaohiem.focus();
            return false;
        }
        if (BangCheDoBaoHiem1_txtTenCheDoBaoHiem.getValue() == '') {
            alert("Bạn chưa nhập tên chế độ bảo hiểm");
            BangCheDoBaoHiem1_txtTenCheDoBaoHiem.focus();
            return false;
        }
        return true;
    }
    var btnEditClick = function () {
        if (BangCheDoBaoHiem1_hdfNhomCha.getValue() == '') {
            alert('Bạn chưa chọn nhóm chế độ bảo hiểm nào!');
            return false;
        }
        else {
            var str = BangCheDoBaoHiem1_hdfNhomCha.getValue().split(',');
            if (str.length > 2) {
                alert('Bạn chỉ được chọn một nhóm chế độ bảo hiểm');
                return false;
            }
        }

        return true;
    }
    var resetWindowHide = function () {
        BangCheDoBaoHiem1_cboCheDoBH.reset(); BangCheDoBaoHiem1_txtMaCheDoBaohiem.reset(); BangCheDoBaoHiem1_txtTenCheDoBaoHiem.reset();
    }
    var NhanDoiDuLieu = function () {
        Ext.Msg.confirm('Xác nhận', 'Bạn có chắc chắn muốn nhân đôi dữ liệu?', function (btn) {
            if (btn == "yes") {
                try {
                    Ext.net.DirectMethods.NhanDoiDuLieuTuTang();
                } catch (e) {

                }
            }
        });
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
<div>
    <ext:Hidden runat="server" ID="hdfMaDonVi">
    </ext:Hidden>
    <ext:Hidden runat="server" ID="hdfIdCheDoBH">
    </ext:Hidden>
    <ext:Hidden runat="server" ID="hdfRecordID" />
    <ext:Window ID="wdInputNewPrimaryKey" Modal="true" Layout="FormLayout" Width="400"
        Padding="6" Constrain="false" Title="Nhập khóa chính mới" Hidden="true" Icon="Add"
        runat="server" AutoHeight="true">
        <Items>
            <ext:TextField FieldLabel="Nhập mã" runat="server" ID="txtmaloaihdcoppy" AnchorHorizontal="100%">
            </ext:TextField>
        </Items>
        <Listeners>
            <Hide Handler="txtmaloaihdcoppy.reset();" />
        </Listeners>
        <Buttons>
            <ext:Button runat="server" Icon="Accept" Text="Đồng ý" ID="btnOK">
                <Listeners>
                    <Click Handler="if(txtmaloaihdcoppy.getValue().trim()==''){alert('Bạn chưa nhập mã');txtmaloaihdcoppy.focus();return false;}" />
                </Listeners>
                <DirectEvents>
                    <Click OnEvent="btnOK_Click">
                    </Click>
                </DirectEvents>
            </ext:Button>
            <ext:Button runat="server" ID="btnCancel" Icon="Decline" Text="Thoát">
                <Listeners>
                    <Click Handler="wdInputNewPrimaryKey.hide();" />
                </Listeners>
            </ext:Button>
        </Buttons>
    </ext:Window>
    <ext:Menu ID="RowContextMenu" runat="server">
        <Items>
            <ext:MenuItem ID="mnuAddNew" runat="server" Icon="Add" Text="Thêm mới">
                <Listeners>
                    <Click Handler="#{wdAddWindow}.show();#{txtMaCheDoBaohiem}.enable();" />
                </Listeners>
            </ext:MenuItem>
            <ext:MenuItem ID="MenuItem4" runat="server" Icon="Delete" Text="<%$ Resources:Language, delete%>">
                <Listeners>
                    <Click Handler="RemoveItemOnGrid2(#{GridPanel1},#{Store1},#{DirectMethods})" />
                </Listeners>
            </ext:MenuItem>
            <ext:MenuItem ID="mnuEdit" runat="server" Icon="Pencil" Text="<%$ Resources:CommonMessage, Edit%>">
                <Listeners>
                    <Click Handler="return CheckSelectedRecord(#{GridPanel1},#{Store1});#{btnCapNhat}.hide();#{btnSua}.show();#{Button2}.hide();#{txtMaCheDoBaohiem}.disable();" />
                </Listeners>
                <DirectEvents>
                    <Click OnEvent="btnEdit_Click">
                        <EventMask ShowMask="true" Msg="<%$ Resources:CommonMessage, Waiting%>" />
                    </Click>
                </DirectEvents>
            </ext:MenuItem>
            <ext:MenuSeparator runat="server" ID="mnuDuplicate" />
            <%-- <ext:MenuItem ID="mnuDuplicateData" runat="server" Icon="DiskMultiple" Text="<%$ Resources:HOSO, Double_data%>">
                <Listeners>
                    <Click Handler="wdInputNewPrimaryKey.show();" />
                </Listeners>
            </ext:MenuItem>--%>
        </Items>
    </ext:Menu>
    <%-- West--%>
    <ext:Hidden runat="server" ID="hdfNhomCha">
    </ext:Hidden>
    <ext:Window runat="server" Resizable="false" Hidden="true" AutoHeight="true" Layout="FormLayout"
        Width="500" Modal="true" Padding="6" Constrain="true" ID="wdNhomCheDoBH" Title="Thêm mới chế độ bảo hiểm"
        Icon="Add">
        <Items>
            <ext:TextField runat="server" ID="txtcha_machedobh" FieldLabel="Mã chế độ BH<span style='color:red'>*</span>"
                CtCls="requiredData" AnchorHorizontal="100%" EmptyText="Mã chế độ bảo hiểm">
            </ext:TextField>
            <ext:TextField runat="server" ID="txtcha_tenchedobh" FieldLabel="Tên chế độ BH<span style='color:red'>*</span>"
                CtCls="requiredData" AnchorHorizontal="100%" EmptyText="Tên chế độ bảo hiểm">
            </ext:TextField>
        </Items>
        <Buttons>
            <ext:Button runat="server" ID="Button1" Text="<%$ Resources:Language, update%>" Icon="Disk">
                <Listeners>
                    <Click Handler="return CheckInput2();" />
                </Listeners>
                <DirectEvents>
                    <Click OnEvent="btnCapNhat_Click_Cha">
                        <EventMask ShowMask="true" Msg="Đang lưu dữ liệu..." />
                        <ExtraParams>
                            <ext:Parameter Name="Close" Value="False">
                            </ext:Parameter>
                        </ExtraParams>
                    </Click>
                </DirectEvents>
            </ext:Button>
            <ext:Button runat="server" ID="Button3" Hidden="true" Text="<%$ Resources:Language, update%>" Icon="Disk">
                <Listeners>
                    <Click Handler="return CheckInput2();" />
                </Listeners>
                <DirectEvents>
                    <Click OnEvent="btnCapNhat_Click_Cha">
                        <EventMask ShowMask="true" Msg="Đang lưu dữ liệu..." />
                        <ExtraParams>
                            <ext:Parameter Name="Command" Value="Edit">
                            </ext:Parameter>
                        </ExtraParams>
                    </Click>
                </DirectEvents>
            </ext:Button>
            <ext:Button ID="Button4" runat="server" Text="<%$ Resources:Language, update_close%>" Icon="Disk">
                <Listeners>
                    <Click Handler="return CheckInput2();" />
                </Listeners>
                <DirectEvents>
                    <Click OnEvent="btnCapNhat_Click_Cha">
                        <EventMask ShowMask="true" Msg="Đang lưu dữ liệu..." />
                        <ExtraParams>
                            <ext:Parameter Name="Close" Value="True">
                            </ext:Parameter>
                        </ExtraParams>
                    </Click>
                </DirectEvents>
            </ext:Button>
            <ext:Button ID="Button6" runat="server" Text="<%$ Resources:CommonMessage, Close%>" Icon="Decline">
                <Listeners>
                    <Click Handler="#{wdNhomCheDoBH}.hide();" />
                </Listeners>
            </ext:Button>
        </Buttons>
        <Listeners>
            <BeforeShow Handler="#{Store_cboCheDoBH}.reload();" />
            <Hide Handler="#{wdNhomCheDoBH}.hide();#{txtcha_machedobh}.reset();#{txtcha_tenchedobh}.reset();#{btnEdit}.disable();#{btnDelete}.disable();" />
        </Listeners>
    </ext:Window>
    <%--  hết west--%>
    <ext:Window runat="server" Resizable="false" Hidden="true" AutoHeight="true" Layout="FormLayout"
        Width="500" Modal="true" Padding="6" Constrain="true" ID="wdAddWindow" Title="Thêm mới chế độ bảo hiểm"
        Icon="Add" LabelWidth="110">
        <Items>
            <ext:Hidden runat="server" ID="hdfIdcha_edit">
            </ext:Hidden>
            <ext:Hidden runat="server" ID="hdfCommand" />
            <ext:ComboBox runat="server" ID="cboCheDoBH" FieldLabel="Nhóm chế độ<span style='color:red'>*</span>"
                CtCls="requiredData" AnchorHorizontal="100%" ValueField="IDCheDoBaoHiem" DisplayField="TenCheDoBaoHiem"
                Editable="false">
                <Store>
                    <ext:Store runat="server" ID="Store_cboCheDoBH" OnRefreshData="Store_cboCheDoBH_OnRefreshData"
                        AutoLoad="false">
                        <Reader>
                            <ext:JsonReader IDProperty="IDCheDoBaoHiem">
                                <Fields>
                                    <ext:RecordField Name="IDCheDoBaoHiem">
                                    </ext:RecordField>
                                    <ext:RecordField Name="TenCheDoBaoHiem">
                                    </ext:RecordField>
                                </Fields>
                            </ext:JsonReader>
                        </Reader>
                    </ext:Store>
                </Store>
            </ext:ComboBox>
            <ext:TextField runat="server" ID="txtMaCheDoBaohiem" FieldLabel="Mã chế độ BH<span style='color:red'>*</span>"
                CtCls="requiredData" AnchorHorizontal="100%" EmptyText="Mã chế độ bảo hiểm">
            </ext:TextField>
            <ext:TextField runat="server" ID="txtTenCheDoBaoHiem" FieldLabel="Tên chế độ BH<span style='color:red'>*</span>"
                CtCls="requiredData" AnchorHorizontal="100%" EmptyText="Tên chế độ bảo hiểm">
            </ext:TextField>
        </Items>
        <Buttons>
            <ext:Button runat="server" ID="btnCapNhat" Text="<%$ Resources:Language, update%>" Icon="Disk">
                <Listeners>
                    <Click Handler="return CheckInput1();" />
                </Listeners>
                <DirectEvents>
                    <Click OnEvent="btnCapNhat_Click">
                        <EventMask ShowMask="true" Msg="Đang lưu dữ liệu..." />
                        <ExtraParams>
                            <ext:Parameter Name="Close" Value="False">
                            </ext:Parameter>
                        </ExtraParams>
                    </Click>
                </DirectEvents>
            </ext:Button>
            <ext:Button runat="server" ID="btnSua" Hidden="true" Text="<%$ Resources:Language, update%>" Icon="Disk">
                <Listeners>
                    <Click Handler=" return CheckInput1();" />
                </Listeners>
                <DirectEvents>
                    <Click OnEvent="btnCapNhat_Click">
                        <EventMask ShowMask="true" Msg="Đang lưu dữ liệu..." />
                        <ExtraParams>
                            <ext:Parameter Name="Command" Value="Edit">
                            </ext:Parameter>
                        </ExtraParams>
                    </Click>
                </DirectEvents>
            </ext:Button>
            <ext:Button ID="Button2" runat="server" Text="<%$ Resources:Language, update_close%>" Icon="Disk">
                <Listeners>
                    <Click Handler="return CheckInput1();" />
                </Listeners>
                <DirectEvents>
                    <Click OnEvent="btnCapNhat_Click">
                        <EventMask ShowMask="true" Msg="Đang lưu dữ liệu..." />
                        <ExtraParams>
                            <ext:Parameter Name="Close" Value="True">
                            </ext:Parameter>
                        </ExtraParams>
                    </Click>
                </DirectEvents>
            </ext:Button>
            <ext:Button ID="Button5" runat="server" Text="<%$ Resources:CommonMessage, Close%>" Icon="Decline">
                <Listeners>
                    <Click Handler="#{wdAddWindow}.hide();resetWindowHide();" />
                </Listeners>
            </ext:Button>
        </Buttons>
        <Listeners>
            <BeforeShow Handler="#{Store_cboCheDoBH}.reload();" />
            <Hide Handler="#{btnCapNhat}.show(); #{btnSua}.hide();
                               #{Button2}.show();#{DirectMethods}.ResetWindowTitle();resetWindowHide();" />
        </Listeners>
    </ext:Window>
    <ext:Store ID="Store1" AutoLoad="true" runat="server" GroupField="sapxep">
        <Proxy>
            <ext:HttpProxy Method="GET" Url="HandlerBHCHEDOBAOHIEM.ashx" />
        </Proxy>
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="={0}" />
            <ext:Parameter Name="limit" Value="={30}" />
        </AutoLoadParams>
        <BaseParams>
            <ext:Parameter Name="SearchKey" Value="#{txtSearch}.getValue()" Mode="Raw" />
            <ext:Parameter Name="MaDonVi" Value="#{hdfMaDonVi}.getValue()" Mode="Raw" />
            <ext:Parameter Name="IdCheDoBH" Value="#{hdfNhomCha}.getValue()" Mode="Raw" />
        </BaseParams>
        <Reader>
            <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="IDCheDoBaoHiem">
                <Fields>
                    <ext:RecordField Name="IDCheDoBaoHiem" />
                    <ext:RecordField Name="ParentID" />
                    <ext:RecordField Name="MaCheDoBaohiem" />
                    <ext:RecordField Name="TenCheDoBaoHiem" />
                    <ext:RecordField Name="sapxep" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
    <ext:BorderLayout runat="server" ID="brlayout">
        <West Collapsible="true" Split="true">
            <ext:Panel ID="Panel1" runat="server" Collapsed="false" Width="300" Border="false"
                Layout="BorderLayout" Title="Tên nhóm chế độ bảo hiểm">
                <Items>
                    <ext:GridPanel ID="grp_nhombhdcd" Border="false" runat="server" AutoExpandColumn="TenCheDoBaoHiem"
                        StripeRows="true" TrackMouseOver="false" Region="Center" Height="450">
                        <TopBar>
                            <ext:Toolbar ID="Toolbar1" runat="server">
                                <Items>
                                    <ext:Button ID="btnThemNhomCDBH" runat="server" Text="Thêm mới" Icon="Add">
                                        <Listeners>
                                            <Click Handler="#{wdNhomCheDoBH}.show();#{Button1}.show();#{Button4}.show();#{Button3}.hide();#{txtcha_machedobh}.enable();" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:Button ID="btnSuaNhomCDBH" runat="server" Text="<%$ Resources:CommonMessage, Edit%>" Icon="Pencil" Disabled="true">
                                        <Listeners>
                                            <Click Handler="return CheckSelectedRecord(#{grp_nhombhdcd},#{Store_CheDoBaoHiem});#{Button1}.hide();#{Button4}.hide();#{Button3}.show();#{txtcha_machedobh}.disable();" />
                                        </Listeners>
                                        <DirectEvents>
                                            <Click OnEvent="btnEditCha_Click">
                                                <EventMask ShowMask="true" Msg="<%$ Resources:CommonMessage, Waiting%>" />
                                                <ExtraParams>
                                                    <ext:Parameter Name="EditNhomCha" Value="True" />
                                                </ExtraParams>
                                            </Click>
                                        </DirectEvents>
                                    </ext:Button>
                                    <ext:Button ID="btnXoaNhomCDBH" runat="server" Text="<%$ Resources:Language, delete%>" Icon="Delete" Disabled="true">
                                        <Listeners>
                                            <Click Handler="RemoveItemOnGrid_nhomcha(#{grp_nhombhdcd}, #{Store_CheDoBaoHiem},#{DirectMethods});" />
                                        </Listeners>
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                        <Store>
                            <ext:Store ID="Store_CheDoBaoHiem" AutoLoad="true" runat="server" OnRefreshData="Store_CheDoBaoHiem_Refresh">
                                <Reader>
                                    <ext:JsonReader IDProperty="IDCheDoBaoHiem">
                                        <Fields>
                                            <ext:RecordField Name="IDCheDoBaoHiem" />
                                            <ext:RecordField Name="ParentID" />
                                            <ext:RecordField Name="MaCheDoBaohiem" />
                                            <ext:RecordField Name="TenCheDoBaoHiem" />
                                            <ext:RecordField Name="sapxep" />
                                        </Fields>
                                    </ext:JsonReader>
                                </Reader>
                            </ext:Store>
                        </Store>
                        <ColumnModel ID="ColumnModel2" runat="server">
                            <Columns>
                                <ext:Column ColumnID="MaCheDoBaohiem" Header="Mã chế độ bảo hiểm" DataIndex="MaCheDoBaohiem"
                                    Width="80" />
                                <ext:Column ColumnID="TenCheDoBaoHiem" Header="Tên chế độ bảo hiểm" DataIndex="TenCheDoBaoHiem" />
                            </Columns>
                        </ColumnModel>
                        <SelectionModel>
                            <ext:RowSelectionModel runat="server" ID="RowSelectionModel1">
                                <Listeners>
                                    <RowSelect Handler="#{hdfNhomCha}.setValue(#{RowSelectionModel1}.getSelected().id);#{btnSuaNhomCDBH}.enable();#{btnXoaNhomCDBH}.enable();#{GridPanel1}.reload();#{btnEdit}.disable();#{btnDelete}.disable();" />
                                    <RowDeselect Handler="#{hdfNhomCha}.reset();#{btnSuaNhomCDBH}.disable();#{btnXoaNhomCDBH}.disable();#{GridPanel1}.reload();#{btnEdit}.disable();#{btnDelete}.disable();" />
                                </Listeners>
                            </ext:RowSelectionModel>
                        </SelectionModel>
                        <DirectEvents>
                            <RowDblClick OnEvent="btnEditCha_Click">
                            </RowDblClick>
                        </DirectEvents>
                        <Listeners>
                            <Click Handler="#{Button1}.hide();#{Button4}.hide();#{Button3}.show();#{txtcha_machedobh}.disable();" />
                        </Listeners>
                    </ext:GridPanel>
                </Items>
            </ext:Panel>
        </West>
        <Center>
            <ext:GridPanel ID="GridPanel1" Border="false" runat="server" StoreID="Store1" StripeRows="true"
                    TrackMouseOver="false" AnchorHorizontal="100%" Title="Chế độ bảo hiểm">
                <TopBar>
                    <ext:Toolbar runat="server" ID="tb">
                        <Items>
                            <ext:Button ID="btnAddNew" runat="server" Text="Thêm mới" Icon="Add">
                                <Listeners>
                                    <Click Handler="#{wdAddWindow}.show();#{txtMaCheDoBaohiem}.enable();" />
                                </Listeners>
                            </ext:Button>
                            <ext:Button ID="btnEdit" runat="server" Disabled="true" Text="<%$ Resources:CommonMessage, Edit%>" Icon="Pencil">
                                <Listeners>
                                    <Click Handler="return CheckSelectedRecord(#{GridPanel1},#{Store1});#{btnCapNhat}.hide();#{btnSua}.show();#{Button2}.hide();#{txtMaCheDoBaohiem}.disable();" />
                                </Listeners>
                                <DirectEvents>
                                    <Click OnEvent="btnEdit_Click">
                                        <EventMask ShowMask="true" Msg="<%$ Resources:CommonMessage, Waiting%>" />
                                    </Click>
                                </DirectEvents>
                            </ext:Button>
                            <ext:Button ID="btnDelete" runat="server" Text="<%$ Resources:Language, delete%>" Disabled="true" Icon="Delete">
                                <Listeners>
                                    <Click Handler="RemoveItemOnGrid2(#{GridPanel1},#{Store1},#{DirectMethods})" />
                                </Listeners>
                            </ext:Button>
                            <ext:ToolbarSeparator ID="ToolbarSeparator1" runat="server" />
                            <%-- <ext:Button ID="Button1" runat="server" Text="Tiện ích" Icon="Build">
                                <Menu>
                                    <ext:Menu ID="Menu4" runat="server">
                                        <Items>
                                            <ext:MenuItem runat="server" Disabled="true" ID="mnuNhanDoiDuLieu" Text="<%$ Resources:HOSO, Double_data%>"
                                                Icon="DiskMultiple">
                                                <Listeners>
                                                    <Click Handler="NhanDoiDuLieu();" />
                                                </Listeners>
                                            </ext:MenuItem>
                                        </Items>
                                    </ext:Menu>
                                </Menu>
                            </ext:Button>--%>
                            <ext:ToolbarFill runat="server" ID="tbfill" />
                            <ext:TriggerField runat="server" Width="200" EnableKeyEvents="true" EmptyText="Nhập từ khóa tìm kiếm"
                                EmptyTex="Nhập từ khóa tìm kiếm" ID="txtSearch">
                                <Triggers>
                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                </Triggers>
                                <Listeners>
                                    <KeyPress Fn="enterKeyPressHandler1" />
                                    <TriggerClick Handler="this.clear(); this.triggers[0].hide(); #{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad();" />
                                </Listeners>
                            </ext:TriggerField>
                            <ext:Button Text="<%$ Resources:Language, search%>" Icon="Zoom" runat="server" ID="btnSearch">
                                <Listeners>
                                    <Click Handler="#{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad();" />
                                </Listeners>
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </TopBar>
                <ColumnModel ID="ColumnModel1" runat="server">
                    <Columns>
                        <ext:RowNumbererColumn Locked="true" Header="STT" Width="30" Align="Center" />
                        <ext:Column ColumnID="sapxep" Header="sắp xếp" DataIndex="sapxep" Width="80" />
                        <ext:Column ColumnID="MaCheDoBaohiem" Header="Mã chế độ bảo hiểm" DataIndex="MaCheDoBaohiem"
                            Width="40" />
                        <ext:Column ColumnID="TenCheDoBaoHiem" Header="Tên chế độ bảo hiểm" DataIndex="TenCheDoBaoHiem" />
                    </Columns>
                </ColumnModel>
                <View>
                    <ext:GroupingView ID="GroupingView1" runat="server" ForceFit="true" MarkDirty="false"
                        ShowGroupName="false" EnableNoGroups="true" HideGroupedColumn="true" />
                </View>
                <SelectionModel>
                    <ext:RowSelectionModel runat="server" ID="checkboxSelection">
                        <Listeners>
                            <RowSelect Handler="#{hdfRecordID}.setValue(#{checkboxSelection}.getSelected().id);#{btnEdit}.enable();#{btnDelete}.enable();" />
                            <RowDeselect Handler="#{hdfRecordID}.reset();#{btnEdit}.disable();#{btnDelete}.disable();" />
                        </Listeners>
                    </ext:RowSelectionModel>
                </SelectionModel>
                <BottomBar>
                    <ext:PagingToolbar ID="PagingToolbar1" EmptyMsg="<%$ Resources:HOSO, no_data%>" NextText="<%$ Resources:HOSO, next_page%>"
                        PageSize="30" PrevText="<%$ Resources:HOSO, prev_page%>" LastText="<%$ Resources:HOSO, last_page%>" FirstText="<%$ Resources:HOSO, first_page%>"
                        DisplayMsg="<%$ Resources:HOSO, description_record%>" runat="server">
                        <Items>
                            <ext:Label ID="Label1" runat="server" Text="<%$ Resources:HOSO, number_line_per_page%>" />
                            <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                            <ext:ComboBox ID="ComboBoxPaging" runat="server" Width="80">
                                <Items>
                                    <ext:ListItem Text="30" />
                                    <ext:ListItem Text="50" />
                                    <ext:ListItem Text="70" />
                                    <ext:ListItem Text="100" />
                                </Items>
                                <SelectedItem Value="30" />
                                <Listeners>
                                    <Select Handler="#{PagingToolbar1}.pageSize = parseInt(this.getValue()); #{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad();" />
                                </Listeners>
                            </ext:ComboBox>
                        </Items>
                        <Listeners>
                            <Change Handler="#{checkboxSelection}.clearSelections();" />
                        </Listeners>
                    </ext:PagingToolbar>
                </BottomBar>
                <LoadMask ShowMask="true" Msg="<%$ Resources:Language, LoadingMask%>" />
                <Listeners>
                    <RowContextMenu Handler="e.preventDefault(); #{RowContextMenu}.dataRecord = this.store.getAt(rowIndex);#{RowContextMenu}.showAt(e.getXY());#{GridPanel1}.getSelectionModel().selectRow(rowIndex);" />
                    <RowDblClick Handler="#{btnCapNhat}.hide();#{btnSua}.show();#{Button2}.hide();#{txtMaCheDoBaohiem}.disable();" />
                </Listeners>
                <DirectEvents>
                    <RowDblClick OnEvent="btnEdit_Click">
                        <EventMask ShowMask="true" Msg="<%$ Resources:CommonMessage, Waiting%>" />
                    </RowDblClick>
                </DirectEvents>
            </ext:GridPanel>
        </Center>
    </ext:BorderLayout>
</div>
