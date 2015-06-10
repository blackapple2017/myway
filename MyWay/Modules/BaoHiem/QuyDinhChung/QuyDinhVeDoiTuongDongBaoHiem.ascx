<%@ Control Language="C#" AutoEventWireup="true" CodeFile="QuyDinhVeDoiTuongDongBaoHiem.ascx.cs"
    Inherits="Modules_BaoHiem_QuyDinhChung_QuyDinhVeDoiTuongDongBaoHiem" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<script type="text/javascript">
    var enterKeyPressHandler4 = function (f, e) {
        if (e.getKey() == e.ENTER) {
            //            QuyDinhVeDoiTuongDongBaoHiem1_Store1.reload();
            QuyDinhVeDoiTuongDongBaoHiem1_PagingToolbar1.pageIndex = 0;
            QuyDinhVeDoiTuongDongBaoHiem1_PagingToolbar1.doLoad();
        }
        if (this.getValue() != '') {
            this.triggers[0].show();
        }
    }
    var RenderThoihanhopdong = function (value, p, record) {

        return value + " tháng";
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
</script>
<ext:Hidden runat="server" ID="hdfMaDonVi">
</ext:Hidden>
<ext:Hidden runat="server" ID="hdfRecordID">
</ext:Hidden>
<ext:Window runat="server" Resizable="false" Hidden="true" AutoHeight="true" Layout="FormLayout"
    Width="390" Modal="true" Padding="6" Constrain="true" ID="wdAddWindow" Title=""
    Icon="Add">
    <Items>
        <ext:Hidden runat="server" ID="hdfCommand" />
        <ext:Container runat="server" Layout="ContainerLayout" LabelWidth="120">
            <Items>
                <ext:Container runat="server" Layout="ColumnLayout">
                    <Items>
                        <ext:Checkbox ID="chkIsBHXH" BoxLabel="Bảo hiểm xã hội" runat="server" LabelWidth="180"
                            Width="120" />
                        <ext:Checkbox ID="chkIsBHYT" BoxLabel="Bảo hiểm y tế" runat="server" LabelWidth="180"
                            Width="120" />
                        <ext:Checkbox ID="chkIsBHTN" BoxLabel="Bảo hiểm thất nghiệp" runat="server" LabelWidth="180"
                            Width="120" />
                    </Items>
                </ext:Container>
            </Items>
        </ext:Container>
    </Items>
    <Buttons>
        <ext:Button runat="server" ID="btnSua" Hidden="true" Text="Cập nhật" Icon="Disk">
            <DirectEvents>
                <Click OnEvent="btnCapNhat_Click">
                    <ExtraParams>
                        <ext:Parameter Name="Command" Value="Edit">
                        </ext:Parameter>
                    </ExtraParams>
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="Button5" runat="server" Text="Đóng lại" Icon="Decline">
            <Listeners>
                <Click Handler="#{wdAddWindow}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
    <Listeners>
    </Listeners>
</ext:Window>
<ext:Store ID="Store1" AutoLoad="true" runat="server">
    <Proxy>
        <ext:HttpProxy Method="GET" Url="HandlerDM_LOAI_HDONG.ashx" />
    </Proxy>
    <AutoLoadParams>
        <ext:Parameter Name="start" Value="={0}" />
        <ext:Parameter Name="limit" Value="={30}" />
    </AutoLoadParams>
    <BaseParams>
        <ext:Parameter Name="SearchKey" Value="#{txtSearch}.getValue()" Mode="Raw" />
        <ext:Parameter Name="MaDonVi" Value="#{hdfMaDonVi}.getValue()" Mode="Raw" />
    </BaseParams>
    <Reader>
        <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="MA_LOAI_HDONG">
            <Fields>
                <ext:RecordField Name="MA_LOAI_HDONG" />
                <ext:RecordField Name="TEN_LOAI_HDONG" />
                <ext:RecordField Name="GHI_CHU" />
                <ext:RecordField Name="DATE_CREATE" />
                <ext:RecordField Name="USERNAME" />
                <ext:RecordField Name="MA_DONVI" />
                <ext:RecordField Name="THOI_HAN_HOPDONG(MONTH)" />
                <ext:RecordField Name="BHXH" />
                <ext:RecordField Name="BHYT" />
                <ext:RecordField Name="BHTN" />
            </Fields>
        </ext:JsonReader>
    </Reader>
</ext:Store>
<ext:BorderLayout runat="server" ID="brlayout">
    <Center>
        <ext:GridPanel ID="GridPanel1" Border="false" runat="server" StoreID="Store1" StripeRows="true"
            Icon="ApplicationViewColumns" AutoExpandColumn="GHI_CHU" TrackMouseOver="false"
            AnchorHorizontal="100%">
            <TopBar>
                <ext:Toolbar runat="server" ID="tb">
                    <Items>
                        <ext:Button ID="btnEdit" runat="server" Disabled="true" Text="Thay đổi chế độ bảo hiểm"
                            Icon="Pencil">
                            <Listeners>
                                <Click Handler="return CheckSelectedRecord(#{GridPanel1},#{Store1});#{btnSua}.show();" />
                            </Listeners>
                            <DirectEvents>
                                <Click OnEvent="btnEdit_Click">
                                    <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                </Click>
                            </DirectEvents>
                        </ext:Button>
                        <ext:ToolbarFill runat="server" ID="tbfill" />
                        <ext:TriggerField runat="server" Width="200" EnableKeyEvents="true" EmptyText="Nhập từ khóa tìm kiếm"
                            EmptyTex="Nhập từ khóa tìm kiếm" ID="txtSearch">
                            <Triggers>
                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                            </Triggers>
                            <Listeners>
                                <KeyPress Fn="enterKeyPressHandler4" />
                                <TriggerClick Handler="this.clear(); this.triggers[0].hide(); #{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad();" />
                            </Listeners>
                        </ext:TriggerField>
                        <ext:Button Text="Tìm kiếm" Icon="Zoom" runat="server" ID="btnSearch">
                            <Listeners>
                                <Click Handler="#{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad();" />
                            </Listeners>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </TopBar>
            <ColumnModel ID="ColumnModel1" runat="server">
                <Columns>
                    <ext:RowNumbererColumn Locked="true" Header="STT" Width="30" />
                    <ext:Column ColumnID="MA_LOAI_HDONG" Header="Mã loại hợp đồng" DataIndex="MA_LOAI_HDONG" />
                    <ext:Column ColumnID="TEN_LOAI_HDONG" Header="Tên loại hợp đồng" DataIndex="TEN_LOAI_HDONG"
                        Width="280" />
                    <ext:DateColumn Format="dd/MM/yyyy" ColumnID="DATE_CREATE" Header="Ngày tạo" DataIndex="DATE_CREATE" />
                    <ext:Column ColumnID="THOI_HAN_HOPDONG(MONTH)" Header="Thời hạn hợp đồng" Align="Right"
                        DataIndex="THOI_HAN_HOPDONG(MONTH)" Width="150">
                        <Renderer Fn="RenderThoihanhopdong" />
                    </ext:Column>
                    <%--  <ext:BooleanColumn Header="Bảo hiểm xã hội" DataIndex="BHXH" Align="Center" Width="120"
                        TrueText="Yes" FalseText="No">
                        <Editor>
                            <ext:Checkbox ID="Checkbox1" runat="server" X="50" />
                        </Editor>
                    </ext:BooleanColumn>
                    <ext:BooleanColumn Header="Bảo hiểm y tế" DataIndex="BHYT" Align="Center" Width="120"
                        TrueText="Yes" FalseText="No">
                        <Editor>
                            <ext:Checkbox ID="chkBHYT" runat="server" />
                        </Editor>
                    </ext:BooleanColumn>
                    <ext:BooleanColumn Header="Bảo hiểm thất nghiệp" DataIndex="BHTN" Align="Center"
                        Width="120" TrueText="Yes" FalseText="No">
                        <Editor >
                            <ext:Checkbox ID="chkBHTN" runat="server"  />
                        </Editor>
                    </ext:BooleanColumn>--%>
                    <ext:CheckColumn ColumnID="BHXH" Header="Bảo hiểm xã hội" DataIndex="BHXH" Width="100"
                        Align="Center" />
                    <ext:CheckColumn ColumnID="BHYT" Header="Bảo hiểm y tế" DataIndex="BHYT" Width="100"
                        Align="Center" />
                    <ext:CheckColumn ColumnID="BHTN" Header="Bảo hiểm thất nghiệp" DataIndex="BHTN" Width="120"
                        Align="Center" />
                    <ext:Column ColumnID="GHI_CHU" Header="Ghi chú" DataIndex="GHI_CHU" />
                </Columns>
            </ColumnModel>
            <SelectionModel>
                <ext:RowSelectionModel runat="server" ID="checkboxSelection">
                    <Listeners>
                        <RowSelect Handler="#{hdfRecordID}.setValue(#{checkboxSelection}.getSelected().id);#{btnEdit}.enable();" />
                        <RowDeselect Handler="#{hdfRecordID}.reset();#{btnEdit}.disable();" />
                    </Listeners>
                </ext:RowSelectionModel>
            </SelectionModel>
            <BottomBar>
                <ext:PagingToolbar ID="PagingToolbar1" EmptyMsg="Hiện không có dữ liệu" NextText="Trang sau"
                    PageSize="30" PrevText="Trang trước" LastText="Trang cuối cùng" FirstText="Trang đầu tiên"
                    DisplayMsg="Dòng {0} đến dòng {1} / {2} dòng" runat="server">
                    <Items>
                        <ext:Label ID="Label1" runat="server" Text="Số bản ghi trên 1 trang:" />
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
                                <Select Handler="#{PagingToolbar1}.pageSize = parseInt(this.getValue());#{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad();" />
                            </Listeners>
                        </ext:ComboBox>
                    </Items>
                    <Listeners>
                        <Change Handler="#{checkboxSelection}.clearSelections();" />
                    </Listeners>
                </ext:PagingToolbar>
            </BottomBar>
            <Listeners>
                <DblClick Handler="#{btnSua}.show();" />
            </Listeners>
            <DirectEvents>
                <DblClick OnEvent="btnEdit_Click">
                    <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                </DblClick>
            </DirectEvents>
            <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
        </ext:GridPanel>
    </Center>
</ext:BorderLayout>
