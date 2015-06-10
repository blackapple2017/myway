<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoaiXepHang.aspx.cs" Inherits="Modules_DanhGia_LoaiXepHang_LoaiXepHang" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        div#Panel1
        {
            border-right: 1px solid #8DB2E3 !important;
        }
        div#GridPanel1
        {
            border-left: 1px solid #8DB2E3 !important;
        }
        .x-layout-collapsed-west
        {
            background: url(../../../Resource/images/CacHinhThucXepHang.png) no-repeat center !important;
        }
    </style>
    <script type="text/javascript">
        var enterKeyPressHandler = function (f, e) {
            if (e.getKey() == e.ENTER) {
                PagingToolbar1.pageIndex = 0;
                PagingToolbar1.doLoad();
                GridPanel1.getSelectionModel().clearSelections();
            }
            if (txtSearch.getValue() != '')
                this.triggers[0].show();
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
                        Ext.net.DirectMethods.DeleteRecord(r.data.MaXepHang);
                    }
                    try {
                        btnEdit.disable();
                        btnDelete.disable();
                    }
                    catch (e) { }
                    grp_HinhThucXepLoai_Store.reload();
                    Store1.reload();
                }
            });
        }

        var CheckInput = function () {
            if (txtTuDiem.getValue() * 1 > 100 || txtDenDiem.getValue() * 1 > 100) {
                alert("Điểm bạn nhập phải không lớn hơn 100");
                return false;
            }
            if (txtTuDiem.getValue() * 1 > txtDenDiem.getValue() * 1) {
                alert('Từ điểm phải nhỏ hơn đến điểm');
                txtDenDiem.focus();
                return false;
            }
            if (txtKiHieuXapHang.getValue() == '') {
                alert("Bạn chưa nhập mã xếp hạng");
                txtKiHieuXapHang.focus();
                return false;
            }
            if (txtTenXepHang.getValue() == '') {
                alert("Bạn chưa nhập tên xếp hạng");
                txtTenXepHang.focus();
                return false;
            }
            if (cbLoaiXepHang.getValue() == '') {
                alert("Bạn chưa chọn loại xếp hạng");
                cbLoaiXepHang.focus();
                return false;
            }
            if (txtTuDiem.getValue() == '') {
                alert('Bạn chưa nhập từ điểm');
                txtTuDiem.focus();
                return false;
            }
            if (txtDenDiem.getValue() == '') {
                alert('Bạn chưa nhập đến điểm');
                txtDenDiem.focus();
                return false;
            }
            return true;
        }

        var resetWindowHide = function () {
            txtTenXepHang.reset();
            cbLoaiXepHang.reset();
            txtGhiChu.reset();
            txtTuDiem.reset();
            txtDenDiem.reset();
            txtKiHieuXapHang.reset();

            btnCapNhat.show(); btnSua.hide(); Button2.show();
        }
        var CheckSelectedRecord = function (grid, Store) {

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
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager runat="server" ID="RM" />
        <ext:Hidden runat="server" ID="hdfRecordID" />
        <ext:Hidden runat="server" ID="hdfMaDonVi" />
        <ext:Window runat="server" Resizable="false" Hidden="true" AutoHeight="true" Layout="FormLayout"
            Width="500" Modal="true" Padding="6" Constrain="true" ID="wdAddWindow" Title="Thêm mới loại xếp hạng"
            Icon="Add">
            <Items>
                <ext:Hidden runat="server" ID="hdfCommand" />
                <ext:Hidden runat="server" ID="hdfMaXepHang" />
                <ext:TextField runat="server" ID="txtKiHieuXapHang" FieldLabel="Mã xếp hạng<span style='color:red;'>*</span>"
                    CtCls="requiredData" TabIndex="1" AnchorHorizontal="99%" MaxLength="20" />
                <ext:TextField runat="server" ID="txtTenXepHang" FieldLabel="Tên xếp hạng<span style='color:red;'>*</span>"
                    CtCls="requiredData" TabIndex="1" AnchorHorizontal="99%" MaxLength="500" />
                <ext:ComboBox runat="server" ID="cbLoaiXepHang" FieldLabel="Loại xếp hạng<span style='color:red;'>*</span>"
                    CtCls="requiredData" DisplayField="TenXepHang" ValueField="MaXepHang" AnchorHorizontal="99%"
                    TabIndex="2" Editable="false">
                    <Triggers>
                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                    </Triggers>
                    <Store>
                        <ext:Store runat="server" ID="cbLoaiXepHang_Store" AutoLoad="False" OnRefreshData="cbLoaiXepHang_Store_OnRefreshData">
                            <Reader>
                                <ext:JsonReader IDProperty="MaXepHang">
                                    <Fields>
                                        <ext:RecordField Name="MaXepHang" />
                                        <ext:RecordField Name="TenXepHang" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <Listeners>
                        <Expand Handler="cbLoaiXepHang_Store.reload();" />
                        <Select Handler="this.triggers[0].show(); 
                            if(cbLoaiXepHang.getValue() == '-1') {
                                txtTuDiem.setValue('-1'); txtTuDiem.disable(); 
                                txtDenDiem.setValue('-1'); txtDenDiem.disable();
                                txtKiHieuXapHang.setValue('Node'); txtKiHieuXapHang.disable();
                            } else {
                                txtTuDiem.enable(); txtDenDiem.enable(); txtKiHieuXapHang.enable();
                            }" />
                        <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                    </Listeners>
                </ext:ComboBox>
                <ext:Container runat="server" Layout="ColumnLayout" AutoHeight="true" AnchorHorizontal="100%">
                    <Items>
                        <ext:Container runat="server" Layout="FormLayout" Height="25" ColumnWidth="0.5">
                            <Items>
                                <ext:TextField runat="server" ID="txtTuDiem" AnchorHorizontal="99%" MaskRe="/[0-9\.,]/"
                                    FieldLabel="Từ điểm<span style='color:red;'>*</span>" CtCls="requiredData" AllowBlank="false"
                                    TabIndex="3" />
                                <%--<ext:NumberField runat="server" ID="txtTuDiem" AnchorHorizontal="99%" FieldLabel="Từ điểm"
                                    AllowBlank="false" TabIndex="3" MaxValue="5" MinValue="0" />--%>
                            </Items>
                        </ext:Container>
                        <ext:Container runat="server" Layout="FormLayout" Height="25" ColumnWidth="0.5">
                            <Items>
                                <ext:TextField runat="server" ID="txtDenDiem" AnchorHorizontal="98%" MaskRe="/[0-9\.,]/"
                                    FieldLabel="Đến điểm<span style='color:red;'>*</span>" CtCls="requiredData" AllowBlank="false"
                                    TabIndex="4" />
                                <%--<ext:NumberField runat="server" ID="txtDenDiem" AnchorHorizontal="99%" FieldLabel="Đến điểm"
                                    AllowBlank="false" TabIndex="4" MaxValue="5" MinValue="0" />--%>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Container>
                <ext:TextArea runat="server" ID="txtGhiChu" FieldLabel="Ghi chú" AnchorHorizontal="99%"
                    Height="50" TabIndex="5" MaxLength="500" />
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnCapNhat" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckInput();" />
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
                <ext:Button runat="server" ID="btnSua" Hidden="true" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckInput();" />
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
                <ext:Button ID="Button2" runat="server" Text="Cập nhật & Đóng lại" Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckInput();" />
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
                <ext:Button ID="Button5" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdAddWindow}.hide();resetWindowHide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="#{btnCapNhat}.show(); #{btnSua}.hide(); #{txtKiHieuXapHang}.enable();
                               #{Button2}.show(); resetWindowHide(); Ext.net.DirectMethods.ResetWindowTitle();" />
            </Listeners>
        </ext:Window>
        <ext:Store ID="Store1" GroupField="TenLoaiXepHang" AutoLoad="true" runat="server">
            <Proxy>
                <ext:HttpProxy Method="GET" Url="HandlerDM_LOAIXEPHANG.ashx" />
            </Proxy>
            <AutoLoadParams>
                <ext:Parameter Name="start" Value="={0}" />
                <ext:Parameter Name="limit" Value="={20}" />
            </AutoLoadParams>
            <BaseParams>
                <ext:Parameter Name="SearchKey" Value="txtSearch.getValue()" Mode="Raw" />
                <ext:Parameter Name="MaDonVi" Value="hdfMaDonVi.getValue()" Mode="Raw" />
                <ext:Parameter Name="MaLoaiXepHang" Value="hdfMaHinhThucXL.getValue()" Mode="Raw" />
            </BaseParams>
            <Reader>
                <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="MaXepHang">
                    <Fields>
                        <ext:RecordField Name="MaXepHang" />
                        <ext:RecordField Name="KiHieuXepHang" />
                        <ext:RecordField Name="TenXepHang" />
                        <ext:RecordField Name="ParentID" />
                        <ext:RecordField Name="GhiChu" />
                        <ext:RecordField Name="TenLoaiXepHang" />
                        <ext:RecordField Name="TuDiem" />
                        <ext:RecordField Name="DenDiem" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        <ext:Viewport runat="server" ID="vp">
            <Items>
                <ext:BorderLayout runat="server" ID="brlayout">
                    <West Collapsible="true" Split="true">
                        <ext:Panel ID="Panel1" runat="server" Collapsed="true" Width="300" Border="false"
                            Layout="BorderLayout" Title="Các hình thức xếp hạng">
                            <Items>
                                <ext:Hidden runat="server" ID="hdfMaHinhThucXL" />
                                <ext:GridPanel ID="grp_HinhThucXepLoai" runat="server" StripeRows="true" Border="false"
                                    TrackMouseOver="true" AnchorHorizontal="100%" Region="Center" AutoExpandColumn="TenXepHang"
                                    AutoExpandMin="100">
                                    <TopBar>
                                        <ext:Toolbar ID="Toolbar1" runat="server">
                                            <Items>
                                                <ext:Button runat="server" ID="btnThemMoiXL" Icon="Add" Text="Thêm mới">
                                                    <Listeners>
                                                        <Click Handler="txtTuDiem.setValue('-1');txtTuDiem.disable();txtDenDiem.setValue('-1');
                                                            txtDenDiem.disable();cbLoaiXepHang.setValue('-1');cbLoaiXepHang.disable();wdAddWindow.show();" />
                                                    </Listeners>
                                                </ext:Button>
                                                <ext:Button runat="server" ID="btnSuaXL" Icon="Pencil" Text="Sửa" Disabled="true">
                                                    <Listeners>
                                                        <Click Handler="return CheckSelectedRecord(#{grp_HinhThucXepLoai},#{grp_HinhThucXepLoai_Store});" />
                                                    </Listeners>
                                                    <DirectEvents>
                                                        <Click OnEvent="btnEdit_Click" Before="txtTuDiem.setValue('-1');txtTuDiem.disable();txtDenDiem.setValue('-1');
                                                            txtDenDiem.disable();cbLoaiXepHang.setValue('-1');cbLoaiXepHang.disable();
                                                            #{btnCapNhat}.hide();#{btnSua}.show();#{Button2}.hide();">
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:Button>
                                                <ext:Button runat="server" ID="btnXoaXL" Icon="Delete" Text="Xóa" Disabled="true">
                                                    <Listeners>
                                                        <Click Handler="RemoveItemOnGrid(grp_HinhThucXepLoai,grp_HinhThucXepLoai_Store);" />
                                                    </Listeners>
                                                </ext:Button>
                                                <ext:Button runat="server" ID="btnRefreshData" Icon="TableRefresh" Text="Xem tất cả">
                                                    <Listeners>
                                                        <Click Handler="hdfMaHinhThucXL.setValue(''); grp_HinhThucXepLoai_Store.reload(); Store1.reload();" />
                                                    </Listeners>
                                                </ext:Button>
                                            </Items>
                                        </ext:Toolbar>
                                    </TopBar>
                                    <Store>
                                        <ext:Store ID="grp_HinhThucXepLoai_Store" ShowWarningOnFailure="false" SkipIdForNewRecords="false"
                                            RefreshAfterSaving="None" AutoLoad="true" OnRefreshData="grp_HinhThucXepLoai_Store_OnRefreshData"
                                            runat="server">
                                            <Reader>
                                                <ext:JsonReader IDProperty="MaXepHang">
                                                    <Fields>
                                                        <ext:RecordField Name="MaXepHang" />
                                                        <ext:RecordField Name="TenXepHang" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                    <ColumnModel ID="ColumnModelCanBoDuocDanhGia" runat="server">
                                        <Columns>
                                            <ext:RowNumbererColumn Width="30" Header="STT" />
                                            <ext:Column ColumnID="TenXepHang" Width="100" Header="Tên hình thức xếp hạng" DataIndex="TenXepHang" />
                                        </Columns>
                                    </ColumnModel>
                                    <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                                    <SelectionModel>
                                        <ext:RowSelectionModel ID="RowSelectionHinhThucXepHang" runat="server">
                                            <Listeners>
                                                <RowSelect Handler="hdfMaHinhThucXL.setValue(RowSelectionHinhThucXepHang.getSelected().id); 
                                                    hdfRecordID.setValue(RowSelectionHinhThucXepHang.getSelected().id);
                                                    Store1.reload(); btnSuaXL.enable(); btnXoaXL.enable();" />
                                            </Listeners>
                                        </ext:RowSelectionModel>
                                    </SelectionModel>
                                    <DirectEvents>
                                        <RowDblClick OnEvent="btnEdit_Click" Before="txtTuDiem.setValue('-1');txtTuDiem.disable();txtDenDiem.setValue('-1');
                                                            txtDenDiem.disable();cbLoaiXepHang.setValue('-1');cbLoaiXepHang.disable();
                                                            #{btnCapNhat}.hide();#{btnSua}.show();#{Button2}.hide();" />
                                    </DirectEvents>
                                </ext:GridPanel>
                            </Items>
                        </ext:Panel>
                    </West>
                    <Center>
                        <ext:GridPanel ID="GridPanel1" Border="false" runat="server" StoreID="Store1" StripeRows="true"
                            AutoExpandColumn="TenXepHang" AutoExpandMin="150" TrackMouseOver="false" AnchorHorizontal="100%"
                            Title="Thang điểm của các hình thức xếp hạng">
                            <TopBar>
                                <ext:Toolbar runat="server" ID="tb">
                                    <Items>
                                        <ext:Button ID="btnAddNew" runat="server" Text="Thêm mới" Icon="Add">
                                            <Listeners>
                                                <Click Handler="txtTuDiem.reset(); txtTuDiem.enable();txtDenDiem.reset();
                                                            txtDenDiem.enable();cbLoaiXepHang.reset();cbLoaiXepHang.enable(); #{wdAddWindow}.show();" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:Button ID="btnEdit" runat="server" Disabled="true" Text="Sửa" Icon="Pencil">
                                            <Listeners>
                                                <Click Handler="return CheckSelectedRecord(#{GridPanel1},#{Store1});txtTuDiem.reset(); txtTuDiem.enable();txtDenDiem.reset();
                                                            txtDenDiem.enable();cbLoaiXepHang.reset();cbLoaiXepHang.enable(); #{btnCapNhat}.hide();#{btnSua}.show();#{Button2}.hide();" />
                                            </Listeners>
                                            <DirectEvents>
                                                <Click OnEvent="btnEdit_Click">
                                                    <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:Button ID="btnDelete" runat="server" Text="Xóa" Disabled="true" Icon="Delete">
                                            <Listeners>
                                                <Click Handler="RemoveItemOnGrid(GridPanel1,Store1)" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:ToolbarFill runat="server" ID="tbfill" />
                                        <ext:TriggerField runat="server" Width="200" EnableKeyEvents="true" EmptyText="Nhập từ khóa tìm kiếm"
                                            ID="txtSearch">
                                            <Triggers>
                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                            </Triggers>
                                            <Listeners>
                                                <KeyPress Fn="enterKeyPressHandler" />
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
                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn Locked="true" Width="35" Header="STT" />
                                    <ext:Column ColumnID="KiHieuXepHang" Header="Mã xếp hạng" Width="90" DataIndex="KiHieuXepHang" />
                                    <ext:Column ColumnID="TenXepHang" Header="Tên xếp hạng" Width="150" DataIndex="TenXepHang" />
                                    <%--<ext:Column ColumnID="TenLoaiXepHang" Header="Loại xếp hạng" DataIndex="TenLoaiXepHang" />--%>
                                    <ext:GroupingSummaryColumn ColumnID="TenLoaiXepHang" Width="90" Header="TenLoaiXepHang"
                                        Sortable="true" DataIndex="TenLoaiXepHang" Hideable="false">
                                    </ext:GroupingSummaryColumn>
                                    <ext:Column ColumnID="TuDiem" Align="Right" Header="Từ điểm" Width="70" DataIndex="TuDiem" />
                                    <ext:Column ColumnID="DenDiem" Align="Right" Header="Đến điểm" Width="70" DataIndex="DenDiem" />
                                    <ext:Column ColumnID="GhiChu" Header="Ghi chú" Width="150" DataIndex="GhiChu" />
                                </Columns>
                            </ColumnModel>
                            <View>
                                <ext:GroupingView ID="GroupingView1" runat="server" ForceFit="true" MarkDirty="false"
                                    ShowGroupName="false" EnableNoGroups="true" HideGroupedColumn="true" />
                            </View>
                            <SelectionModel>
                                <ext:RowSelectionModel runat="server" ID="checkboxSelection">
                                    <Listeners>
                                        <RowSelect Handler="hdfRecordID.setValue(checkboxSelection.getSelected().id);btnEdit.enable();btnDelete.enable();" />
                                    </Listeners>
                                </ext:RowSelectionModel>
                            </SelectionModel>
                            <BottomBar>
                                <ext:PagingToolbar ID="PagingToolbar1" EmptyMsg="Hiện không có dữ liệu" NextText="Trang sau"
                                    PageSize="20" PrevText="Trang trước" LastText="Trang cuối cùng" FirstText="Trang đầu tiên"
                                    DisplayMsg="Dòng {0} đến dòng {1} / {2} dòng" runat="server">
                                    <Listeners>
                                        <Change Handler="checkboxSelection.clearSelections();" />
                                    </Listeners>
                                    <Items>
                                        <ext:Label ID="Label1" runat="server" Text="Số bản ghi trên 1 trang:" />
                                        <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                        <ext:ComboBox ID="ComboBoxPaging" runat="server" Width="80">
                                            <Items>
                                                <ext:ListItem Text="15" />
                                                <ext:ListItem Text="35" />
                                                <ext:ListItem Text="45" />
                                                <ext:ListItem Text="50" />
                                            </Items>
                                            <SelectedItem Value="20" />
                                            <Listeners>
                                                <Select Handler="#{PagingToolbar1}.pageSize = parseInt(this.getValue()); #{PagingToolbar1}.doLoad();" />
                                            </Listeners>
                                        </ext:ComboBox>
                                    </Items>
                                </ext:PagingToolbar>
                            </BottomBar>
                            <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                            <Listeners>
                                <RowDblClick Handler="#{btnCapNhat}.hide();#{btnSua}.show();#{Button2}.hide();" />
                                <ViewReady Handler="cbLoaiXepHang.store.reload();" />
                            </Listeners>
                            <DirectEvents>
                                <RowDblClick OnEvent="btnEdit_Click">
                                    <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                </RowDblClick>
                            </DirectEvents>
                        </ext:GridPanel>
                    </Center>
                </ext:BorderLayout>
            </Items>
        </ext:Viewport>
    </div>
    </form>
</body>
</html>
