<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DM_VTHH.aspx.cs" Inherits="Modules_DanhMuc_DM_VTHH" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register Src="../Base/GridPanel/GridPanel.ascx" TagName="GridPanel" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="../../Resource/js/RenderJS.js"></script>
    <script type="text/javascript">
        var enterKeyPressHandler = function (f, e) {
            if (e.getKey() == e.ENTER) {
                PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad();
            }
        }

        var resetForm = function () {
            txt_MA_VTHH.reset();
            txt_TEN_VTHH.reset();
            cb_MA_DONVITINH.reset();
            cb_MA_NHOM_VTHH.reset();
            txt_SOTHANG_KHAUHAO.reset();
            txt_NGUYEN_GIA.reset();
            txt_GHI_CHU.reset();
        }
        var validateForm = function () {
            if (txt_MA_VTHH.getValue().trim() == '') {
                alert("Bạn chưa nhập thẻ tài sản");
                return false;
            }
            if (txt_TEN_VTHH.getValue().trim() == '') {
                alert("Bạn chưa nhập tên tài sản");
                return false;
            }
            return true;
        }
        var validateFormGroup = function ()
        {
            if (txt_MA_NHOM_VTHH.getValue().trim() == '') {
                alert("Bạn chưa nhập mã nhóm");
                return false;
            }
            if (txt_TEN_NHOM_VTHH.getValue().trim() == '') {
                alert("Bạn chưa nhập tên nhóm");
                return false;
            }
            return true;
        }

        var refreshTree = function (tree) {
            Ext.net.DirectMethods.RefreshMenu({
                success: function (result) {
                    var nodes = eval(result);
                    if (nodes.length > 0) {
                        tree.initChildren(nodes);
                    }
                    else {
                        tree.getRootNode().removeChildren();
                    }
                }
            });
        }

        var getDataForEditGroup = function ()
        {
            if (hdfNodeID.getValue() == '-1')
            {
                alert("Bạn phải chọn một nhóm tài sản");
                return false;
            }
            var selectednode = treeFortuneGroup.getSelectionModel().getSelectedNode(); 
            txt_TEN_NHOM_VTHH.setValue(selectednode.text);
            txt_MA_NHOM_VTHH.disable();
            txt_MA_NHOM_VTHH.setValue(hdfNodeID.getValue());
            cb_PARENTID.setValue(hdfParentNodeID.getValue());
            btnCreateGroup.hide(); btnUpdateGroup.show();
            wdThemNhomTaiSan.show(); 
        }

    </script>
    <style type="text/css">
        div#pnl-xsplit {
            border-right: 1px solid #98C0F4;
            border-left: 1px solid #98C0F4;
        }
        .westpanel .x-layout-collapsed-west{
            background: url(../../Resource/images/NhomTaiSan.png) no-repeat center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div> 
            <ext:ResourceManager runat="server" ID="RM">
                <Listeners>
                    <DocumentReady Handler="if(cb_MA_DONVITINH.store.getCount()==0){Storecb_MA_DONVITINH.reload();}
                                            if(cb_MA_NHOM_VTHH.store.getCount()==0){Storecb_MA_NHOM_VTHH.reload();}" />
                </Listeners>
            </ext:ResourceManager>
            <%--<ext:Menu runat="server" ID="mnuTreeMenu">
                <Items>
                    <ext:MenuItem ID="MenuItem1" runat="server" Text="Thêm mới" Icon="Add"></ext:MenuItem>
                    <ext:MenuItem ID="MenuItem2" runat="server" Text="Sửa" Icon="Pencil"></ext:MenuItem>
                    <ext:MenuItem runat="server" Text="Xóa" Icon="Delete"></ext:MenuItem>
                </Items>
            </ext:Menu>--%>
            <ext:Hidden runat="server" ID="hdfNodeID" />
            <ext:Hidden runat="server" ID="hdfParentNodeID" />
            <ext:Window runat="server" Hidden="true" Title="Cập nhật nhóm tài sản" Constrain="true" Width="400" Padding="5" Layout="FormLayout"
                ID="wdThemNhomTaiSan" Resizable="false" Modal="true" AutoHeight="true">
                <Items>
                    <ext:TextField runat="server" CtCls="requiredData" FieldLabel="Mã nhóm<span style='color:red;'>*</span>" ID="txt_MA_NHOM_VTHH" />
                    <ext:TextField runat="server" CtCls="requiredData" FieldLabel="Tên nhóm<span style='color:red;'>*</span>" ID="txt_TEN_NHOM_VTHH" AnchorHorizontal="100%" />
                    <ext:Hidden runat="server" ID="txtx_MA_DONVI" />
                    <ext:ComboBox runat="server" EmptyText="Chọn nhóm cấp trên" Editable="false" AnchorHorizontal="100%" ID="cb_PARENTID" DisplayField="TEN_NHOM_VTHH" ValueField="MA_NHOM_VTHH" FieldLabel="Nhóm cấp trên">
                        <Store>
                            <ext:Store runat="server" AutoLoad="false" OnRefreshData="Storecb_MA_NHOM_VTHH_OnRefreshData" ID="Storecb_MA_NHOM_VTHH">
                                <Reader>
                                    <ext:JsonReader>
                                        <Fields>
                                            <ext:RecordField Name="TEN_NHOM_VTHH" />
                                            <ext:RecordField Name="MA_NHOM_VTHH" />
                                        </Fields>
                                    </ext:JsonReader>
                                </Reader>
                            </ext:Store>
                        </Store>
                        <Listeners>
                            <Expand Handler="if(cb_MA_NHOM_VTHH.store.getCount()==0){Storecb_MA_NHOM_VTHH.reload();}" />
                        </Listeners>
                    </ext:ComboBox>
                </Items>
                <Listeners>
                    <Hide Handler="txt_MA_NHOM_VTHH.reset();txt_TEN_NHOM_VTHH.reset();cb_PARENTID.reset();txt_MA_NHOM_VTHH.enable();btnCreateGroup.show();btnUpdateGroup.hide();" />
                </Listeners>
                <Buttons>
                    <ext:Button runat="server" ID="btnCreateGroup" Text="Cập nhật" Icon="Disk">
                        <Listeners>
                            <Click Handler="return validateFormGroup();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnUpdateGroup_Click">
                                <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" /> 
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button runat="server" ID="btnUpdateGroup" Hidden="true" Text="Cập nhật" Icon="Disk">
                        <Listeners>
                            <Click Handler="return validateFormGroup();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnUpdateGroup_Click">
                                <ExtraParams>
                                    <ext:Parameter Name="Command" Value="Update" />
                                </ExtraParams>
                                <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" /> 
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button runat="server" Text="Đóng lại" Icon="Decline">
                        <Listeners>
                            <Click Handler="wdThemNhomTaiSan.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:Window>
            <ext:Window runat="server" Hidden="true" Title="Cập nhật thông tin tài sản" Constrain="true" Width="500" Padding="5" Layout="FormLayout"
                ID="wdCapNhatTaiSan" Resizable="false" Modal="true" AutoHeight="true">
                <Items>
                    <ext:Hidden runat="server" ID="hdf_MA_DONVI" />
                    <ext:TextField runat="server" ID="txt_MA_VTHH" CtCls="requiredData" FieldLabel="Thẻ tài sản<span style='color:red;'>*</span>" />
                    <ext:TextField runat="server" ID="txt_TEN_VTHH" CtCls="requiredData" FieldLabel="Tên tài sản<span style='color:red;'>*</span>" AnchorHorizontal="100%" />
                    <ext:Container ID="Container1" runat="server" AnchorHorizontal="100%" Height="30" Layout="ColumnLayout">
                        <Items>
                            <ext:Container ID="Container2" runat="server" Layout="FormLayout" Height="30" ColumnWidth="0.5">
                                <Items>
                                    <ext:ComboBox ID="cb_MA_DONVITINH" Editable="false" DisplayField="TEN_DVT" ValueField="MA_DVT" runat="server" FieldLabel="Đơn vị tính" AnchorHorizontal="98%">
                                        <Store>
                                            <ext:Store runat="server" OnRefreshData="Storecb_MA_DONVITINH_OnRefreshData" ID="Storecb_MA_DONVITINH" AutoLoad="false">
                                                <Reader>
                                                    <ext:JsonReader>
                                                        <Fields>
                                                            <ext:RecordField Name="MA_DVT" />
                                                            <ext:RecordField Name="TEN_DVT" />
                                                        </Fields>
                                                    </ext:JsonReader>
                                                </Reader>
                                            </ext:Store>
                                        </Store>
                                        <Triggers>
                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                        </Triggers>
                                        <Listeners>
                                            <Expand Handler="if(cb_MA_DONVITINH.store.getCount()==0){Storecb_MA_DONVITINH.reload();}" />
                                            <Select Handler="this.triggers[0].show();" />
                                            <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                            <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                        </Listeners>
                                    </ext:ComboBox>
                                </Items>
                            </ext:Container>
                            <ext:ComboBox ID="cb_MA_NHOM_VTHH" runat="server" StoreID="Storecb_MA_NHOM_VTHH" Editable="false" ValueField="MA_NHOM_VTHH" DisplayField="TEN_NHOM_VTHH" FieldLabel="Nhóm tài sản" ColumnWidth="0.5">
                                <Triggers>
                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                </Triggers>
                                <Listeners>
                                    <Expand Handler="if(cb_MA_NHOM_VTHH.store.getCount()==0){Storecb_MA_NHOM_VTHH.reload();}" />
                                    <Select Handler="this.triggers[0].show();" />
                                    <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                    <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                </Listeners>
                            </ext:ComboBox>
                        </Items>
                    </ext:Container>
                    <ext:Container runat="server" AnchorHorizontal="100%" Height="30" Layout="ColumnLayout">
                        <Items>
                            <ext:Container runat="server" Layout="FormLayout" Height="30" ColumnWidth="0.5">
                                <Items>
                                    <ext:NumberField ID="txt_SOTHANG_KHAUHAO" runat="server" AnchorHorizontal="98%" FieldLabel="Số tháng KH" EmptyText="Số tháng khấu hao..." />
                                </Items>
                            </ext:Container>
                            <ext:NumberField ID="txt_NGUYEN_GIA" ColumnWidth="0.5" runat="server" FieldLabel="Nguyên giá" />
                        </Items>
                    </ext:Container>
                    <ext:TextArea runat="server" FieldLabel="Ghi chú" ID="txt_GHI_CHU" AnchorHorizontal="100%" />
                </Items>
                <Listeners>
                    <Hide Handler="resetForm();txt_MA_VTHH.enable();btnUpdate.hide();btnSave.show();Button2.show();" />
                </Listeners>
                <Buttons>
                    <ext:Button ID="btnUpdate" Hidden="true" runat="server" Text="Cập nhật" Icon="Disk">
                        <Listeners>
                            <Click Handler="return validateForm();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnSave_Click">
                                <ExtraParams>
                                    <ext:Parameter Name="Command" Value="Update" />
                                </ExtraParams>
                                <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button ID="btnSave" runat="server" Text="Cập nhật" Icon="Disk">
                        <Listeners>
                            <Click Handler="return validateForm();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnSave_Click">
                                <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button ID="Button2" runat="server" Text="Cập nhật & Đóng lại" Icon="Disk">
                        <Listeners>
                            <Click Handler="return validateForm();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnSave_Click">
                                <ExtraParams>
                                    <ext:Parameter Name="Close" Value="True" />
                                </ExtraParams>
                                <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button runat="server" Text="Đóng lại" Icon="Decline">
                        <Listeners>
                            <Click Handler="wdCapNhatTaiSan.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:Window>
            <ext:Viewport runat="server" ID="vp">
                <Items>
                    <ext:BorderLayout runat="server" ID="br">
                        <Center>
                            <ext:GridPanel
                                ID="GridPanel1"
                                runat="server"
                                StripeRows="true"
                                Title="Danh sách tài sản"
                                Border="false">
                                <Store>
                                    <ext:Store ID="Store1" runat="server">
                                        <Proxy>
                                            <ext:HttpProxy Method="GET" Url="HandlerDM_VTHH.ashx"></ext:HttpProxy>
                                        </Proxy>
                                        <Reader>
                                            <ext:JsonReader IDProperty="MA_VTHH" Root="Data" TotalProperty="TotalRecords">
                                                <Fields>
                                                    <ext:RecordField Name="MA_VTHH" />
                                                    <ext:RecordField Name="TEN_VTHH" />
                                                    <ext:RecordField Name="NhomVTHH" />
                                                    <ext:RecordField Name="GhiChu" />
                                                    <ext:RecordField Name="DVT" />
                                                    <ext:RecordField Name="NguyenGia" />
                                                    <ext:RecordField Name="SoThangKH" />
                                                </Fields>
                                            </ext:JsonReader>
                                        </Reader>
                                        <AutoLoadParams>
                                            <ext:Parameter Name="start" Value="={0}" />
                                            <ext:Parameter Name="limit" Value="={30}" />
                                        </AutoLoadParams>
                                        <BaseParams>
                                            <ext:Parameter Name="GroupID" Value="hdfNodeID.getValue()" Mode="Raw" />
                                            <ext:Parameter Name="SearchKey" Value="txtSearch.getValue()" Mode="Raw" />
                                        </BaseParams>
                                    </ext:Store>
                                </Store>
                                <ColumnModel ID="ColumnModel1" runat="server">
                                    <Columns>
                                        <ext:RowNumbererColumn Header="STT" Locked="true" Width="35" />
                                        <ext:Column Header="Thẻ tài sản" Locked="true" Width="75" DataIndex="MA_VTHH">
                                        </ext:Column>
                                        <ext:Column ColumnID="FortuneName" Locked="true" Header="Tên tài sản" Width="160" DataIndex="TEN_VTHH" />
                                        <ext:Column Header="Đơn vị tính" Width="75" DataIndex="DVT">
                                        </ext:Column>
                                        <ext:Column Header="Nhóm tài sản" Width="175" DataIndex="NhomVTHH">
                                        </ext:Column>
                                        <ext:Column Header="Ghi chú" Width="175" DataIndex="GhiChu">
                                        </ext:Column>
                                        <ext:Column Header="Nguyên giá" Width="100" DataIndex="NguyenGia">
                                            <Renderer Fn="RenderVND" />
                                        </ext:Column>
                                        <ext:Column Header="Số tháng khấu hao" Align="Right" Width="110" DataIndex="SoThangKH">
                                        </ext:Column>
                                        <%-- <ext:Column Header="Đơn vị sử dụng" Width="175" DataIndex="GhiChu">
                                        </ext:Column>--%>
                                    </Columns>
                                </ColumnModel>
                                <View>
                                    <ext:LockingGridView runat="server" ID="lkv" />
                                </View>
                                <DirectEvents>
                                    <RowDblClick OnEvent="GridPanel1_RowDblClick">
                                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                    </RowDblClick>
                                </DirectEvents>
                                <Listeners>
                                    <RowDblClick Handler="txt_MA_VTHH.disable();btnUpdate.show();btnSave.hide();Button2.hide();" />
                                </Listeners>
                                <SelectionModel>
                                    <ext:RowSelectionModel ID="RowSelectionModel1" runat="server">
                                        <Listeners>
                                            <RowSelect Handler="btnEditFortune.enable();btnDeleteFortune.enable();" />
                                        </Listeners>
                                    </ext:RowSelectionModel>
                                </SelectionModel>
                                <TopBar>
                                    <ext:Toolbar runat="server" ID="tb">
                                        <Items>
                                            <ext:Button runat="server" ID="btnAddFortune" Icon="Add" Text="Thêm mới">
                                                <Listeners>
                                                    <Click Handler="wdCapNhatTaiSan.show();" />
                                                </Listeners>
                                            </ext:Button>
                                            <ext:Button runat="server" ID="btnEditFortune" Disabled="true" Icon="Pencil" Text="Sửa">
                                                <Listeners>
                                                    <Click Handler="txt_MA_VTHH.disable();btnUpdate.show();btnSave.hide();Button2.hide();" />
                                                </Listeners>
                                                <DirectEvents>
                                                    <Click OnEvent="GridPanel1_RowDblClick">
                                                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:Button>
                                            <ext:Button runat="server" ID="btnDeleteFortune" Disabled="true" Icon="Delete" Text="Xóa">
                                                <DirectEvents>
                                                    <Click OnEvent="btnDeleteFortune_Click">
                                                        <EventMask ShowMask="true" Msg="Đang xóa dữ liệu" />
                                                        <Confirmation Title="Cảnh báo" Message="Bạn có chắc chắn muốn xóa không ?" ConfirmRequest="true" />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:Button>
                                            <ext:ToolbarFill runat="server" ID="tbf" />
                                            <ext:TextField runat="server" ID="txtSearch" EnableKeyEvents="true" Width="220" EmptyText="Nhập thẻ hoặc tên tài sản...">
                                                <Listeners>
                                                    <KeyPress Fn="enterKeyPressHandler" />
                                                </Listeners>
                                            </ext:TextField>
                                            <ext:Button runat="server" ID="btnSearch" Text="Tìm kiếm" Icon="Zoom">
                                                <Listeners>
                                                    <Click Handler="#{PagingToolbar1}.pageIndex=0;#{PagingToolbar1}.doLoad();" />
                                                </Listeners>
                                            </ext:Button>
                                        </Items>
                                    </ext:Toolbar>
                                </TopBar>
                                <LoadMask ShowMask="true" />
                                <BottomBar>
                                    <ext:PagingToolbar ID="PagingToolbar1" runat="server" PageSize="10">
                                        <Items>
                                            <ext:Label ID="Label1" runat="server" Text="Page size:" />
                                            <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                            <ext:ComboBox ID="ComboBox1" runat="server" Width="80">
                                                <Items>
                                                    <ext:ListItem Text="1" />
                                                    <ext:ListItem Text="2" />
                                                    <ext:ListItem Text="10" />
                                                    <ext:ListItem Text="20" />
                                                </Items>
                                                <SelectedItem Value="10" />
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
                            <ext:Panel Border="false" Header="true" Collapsed="true" CtCls="westpanel" Title="Nhóm tài sản" Layout="BorderLayout" runat="server" ID="pnl" Width="220">
                                <Items>
                                    <ext:TreePanel
                                        ID="treeFortuneGroup"
                                        runat="server"
                                        Icon="BookOpen"
                                        Header="false"
                                        Border="false"
                                        Region="Center" 
                                        RootVisible="false"
                                        AutoScroll="true">
                                        <TopBar>
                                            <ext:Toolbar ID="Toolbar1" runat="server">
                                                <Items>
                                                    <ext:Button ID="Button3" Icon="Add" runat="server" Text="Thêm nhóm">
                                                        <Listeners>
                                                            <Click Handler="wdThemNhomTaiSan.show();" />
                                                        </Listeners>
                                                    </ext:Button>
                                                    <ext:Button ID="btnEditGroup" Disabled="true" Icon="Pencil" runat="server" Text="Sửa">
                                                        <Listeners>
                                                            <Click Handler="getDataForEditGroup();" />
                                                        </Listeners>
                                                    </ext:Button>
                                                    <ext:Button ID="btnDeleteGroup" Disabled="true" Icon="Delete" runat="server" Text="Xóa">
                                                        <DirectEvents>
                                                            <Click OnEvent="btnDeleteGroup_Click">
                                                                <EventMask ShowMask="true" Msg="Đang xóa dữ liệu..." />
                                                                <Confirmation ConfirmRequest="true" Message="Bạn có chắc chắn muốn xóa không ?" Title="Cảnh báo" />
                                                            </Click>
                                                        </DirectEvents>
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
    </form>
</body>
</html>
